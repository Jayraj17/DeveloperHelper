using DH.Data.Database;
using DH.Data.DataFactory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Extensions;
using System.Linq;

namespace DH.Data.Extension
{
    public class CurrentContext : IDisposable
    {
        private static ObjectContext _context;

        public static ObjectContext GetInstance
        {
            get
            {
                return ((IObjectContextAdapter)new DeveloperHelperEntities()).ObjectContext;
            }

        }
        public static void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                _context.AcceptAllChanges();
            }
            catch (Exception)
            {
                _context = null;
                throw;
            }
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(_context);
        }
        #endregion
    }


    public class DHDataExtension : DataWorker
    {
        #region variables

        internal readonly ObjectContext _context = CurrentContext.GetInstance;

        internal DbConnection conn;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor to initialize the variables
        /// </summary>
        public DHDataExtension()
        {
            var entityConnection = (EntityConnection)_context.Connection;
            conn = entityConnection.StoreConnection;
        }
        #endregion

        #region Connection Methods

        /// <summary>
        /// Open Database connection
        /// </summary>
        public void OpenConnection()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }

        /// <summary>
        /// CLose the database connection
        /// </summary>
        public void CloseConnection()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        #endregion
    }

    public sealed class DHDataExtension<T> : DHDataExtension where T : new()
    {



        public T ExecuteScaler(string spName, params object[] parameters)
        {
            OpenConnection();

            try
            {               

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandTimeout = 1000000;
                    cmd.CommandType = CommandType.Text;

                    string query = "EXECUTE " + spName;

                    if (parameters != null)
                    {
                        foreach (var parm in parameters)
                            query += parm.GetParameterInfo() + ",";

                    }
                    query = query.TrimEnd(',');
                    cmd.CommandText = query;
                    return cmd.ExecuteScalar().TryCast<T>();

                }
            }
            finally
            {
                CloseConnection();
            }
        }





        /// <summary>
        /// Returns the single raw object from the SP
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T ExecuteStoredProcedure(string spName, params object[] parameters)
        {
            try
            {
                OpenConnection();
                DbDataReader dr = ExecuteMultipleListStoredProcedure(spName, parameters);

                List<T> _TResult = dr.Cast<IDataRecord>().CastTo<T>();
                return _TResult.FirstOrDefault();
            }
            catch (Exception exception)
            {
                throw new DataException(exception.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Returns the list of an object
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<T> ExecuteListStoredProcedure(string spName, params object[] parameters)
        {
            try
            {
                OpenConnection();
                DbDataReader dr = ExecuteMultipleListStoredProcedure(spName, parameters);

                List<T> _TResult = dr.Cast<IDataRecord>().CastTo<T>();
                return _TResult;
            }
            catch (Exception exception)
            {
                throw new DataException(exception.Message);
            }
            finally
            {
                CloseConnection();
            }
        }


        /// <summary>
        /// Returns the list of an object
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DbDataReader ExecuteMultipleListStoredProcedure(string spName, params object[] parameters)
        {

            try
            {
                OpenConnection();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        string query = "EXECUTE " + spName;

                        if (parameters != null)
                        {
                            foreach (var parm in parameters)
                                query += parm.GetParameterInfo() + ",";

                        }

                        query = query.TrimEnd(',');
                        cmd.CommandText = query;
                        DbDataReader dr = cmd.ExecuteReader();
                        return dr;
                    }
                    catch (Exception exception)
                    {
                        throw new DataException(exception.Message);
                    }
                }
            }
            finally
            {

            }
        }

        public decimal ExecuteFunction(string funName, params object[] parameters)
        {
            try
            {
                OpenConnection();

                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    string query = "SELECT dbo." + funName + "(";

                    if (parameters != null)
                    {
                        foreach (var parm in parameters)
                            query += parm.GetFunParameterInfo() + ",";

                    }

                    query = query.TrimEnd(',') + ")";
                    cmd.CommandText = query;

                    DbDataReader dr = cmd.ExecuteReader();

                    decimal returnValue = 0;
                    while (dr.Read())
                    {
                        returnValue = Convert.ToDecimal(dr.GetValue(0));
                    }

                    return returnValue;
                }
            }
            catch (Exception exception)
            {
                throw new DataException(exception.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }

    public static class StringHelper
    {
        public static string GetParameterInfo(this object obj)
        {
            List<string> strs = obj.ToString().Split('=').ToList();
            if (strs.Count > 2)
            {
                strs[1] = string.Join("=", strs.Skip(1).Select(s => s).ToArray());

            }
            if (strs.Count > 1)
            {
                if (obj.GetType().FullName.ToLower().Contains("system.datetime"))
                {
                    return " @" + strs[0].Replace("{ ", "").Trim() + " = '" + (!string.IsNullOrEmpty(strs[1].Replace(" }", "").Trim()) ? strs[1].Replace(" }", "").Trim().TryCast<DateTime>().ToString("yyyy-MM-dd HH:mm:ss") : null) + "'";
                }
                return " @" + strs[0].Replace("{ ", "").Trim() + " = '" + strs[1].Replace(" }", "").Replace("'", "''").Trim() + "'";
            }
            return null;
        }

        public static string GetFunParameterInfo(this object obj)
        {
            List<string> strs = obj.ToString().Split('=').ToList();
            if (strs.Count > 2)
            {
                strs[1] = string.Join("", strs.Skip(1).Select(s => s).ToArray());

            }
            if (strs.Count > 1)
            {
                if (obj.GetType().FullName.ToLower().Contains("system.datetime"))
                {
                    return "'" + (!string.IsNullOrEmpty(strs[1].Replace(" }", "").Trim()) ? strs[1].Replace(" }", "").Trim().TryCast<DateTime>().ToString("yyyy-MM-dd HH:mm:ss") : null) + "'";
                }
                return "'" + strs[1].Replace(" }", "").Replace("'", "''").Trim() + "'";
            }
            return null;
        }
    }

    public static class IENumerableExtensions
    {
        public static IEnumerable<T> FromDataReader<T>(this IEnumerable<T> list, IDataReader dr)
        {
            //Instance reflec object from Reflection class coded above
            Reflection reflec = new Reflection();
            //Declare one "instance" object of Object type and an object list
            Object instance;
            List<Object> lstObj = new List<Object>();

            //dataReader loop
            while (dr.Read())
            {
                //Create an instance of the object needed.
                //The instance is created by obtaining the object type T of the object
                //list, which is the object that calls the extension method
                //Type T is inferred and is instantiated
                instance = Activator.CreateInstance(list.GetType().GetGenericArguments()[0]);

                // Loop all the fields of each row of dataReader, and through the object
                // reflector (first step method) fill the object instance with the datareader values
                foreach (DataRow drow in dr.GetSchemaTable().Rows)
                {
                    try
                    {
                        reflec.FillObjectWithProperty(ref instance,
                            drow.ItemArray[0].ToString(), dr[drow.ItemArray[0].ToString()]);
                    }
                    catch
                    {
                    }
                }

                //Add object instance to list
                lstObj.Add(instance);
            }

            List<T> lstResult = new List<T>();
            foreach (Object item in lstObj)
            {
                lstResult.Add((T)Convert.ChangeType(item, typeof(T)));
            }

            return lstResult;
        }
    }

    public class Reflection
    {
        public void FillObjectWithProperty(ref object objectTo, string propertyName, object propertyValue)
        {
            Type tOb2 = objectTo.GetType();
            tOb2.GetProperty(propertyName).SetValue(objectTo, propertyValue);
        }
    }

    //public static class ExecuteStoreProcedureUsingDataTable
    //{
    //    public static DataTable ExecuteStoreProcedure(string SpName, params object[] parameters)
    //    {
    //        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DHConnection"].ConnectionString);
    //        SqlCommand com = new SqlCommand(SpName, con);
    //        string query = "EXECUTE " + SpName;
    //        if (parameters != null)
    //        {
    //            foreach (var parm in parameters)
    //            {
    //                query += parm.GetParameterInfo() + ",";
    //            }
    //        }

    //        query = query.TrimEnd(',');
    //        DataTable dt = new DataTable();
    //        SqlDataAdapter adapt = new SqlDataAdapter(query, con);
    //        con.Open();
    //        adapt.Fill(dt);
    //        con.Close();

    //        return dt;
    //    }
    //}

}
