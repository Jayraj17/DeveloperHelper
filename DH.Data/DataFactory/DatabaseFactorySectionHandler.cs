

namespace DH.Data.DataFactory
{
    using DH.Data.Contracts;
    using DH.Data.Database;
    using DH.Data.Repository;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class DatabaseFactorySectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("Name")]
        public string Name
        {
            get { return (string)base["Name"]; }
        }

        [ConfigurationProperty("ConnectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["ConnectionStringName"]; }
        }

        public string ConnectionString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
                }
                catch (Exception excep)
                {
                    throw new Exception("Connection string " + ConnectionStringName + " was not found in web.config. " + excep.Message);
                }
            }
        }
    }
    public sealed class DatabaseFactory : Disposable, IDatabaseFactory
    {
        public static DatabaseFactorySectionHandler sectionHandler = (DatabaseFactorySectionHandler)ConfigurationManager.GetSection("DatabaseFactoryConfiguration");

        private DatabaseFactory() { }

        public static Database CreateDatabase()
        {
            // Verify a DatabaseFactoryConfiguration line exists in the web.config.
            if (sectionHandler.Name.Length == 0)
            {
                throw new Exception("Database name not defined in DatabaseFactoryConfiguration section of web.config.");
            }

            try
            {
                // Find the class
                Type database = Type.GetType(sectionHandler.Name);

                // Get it's constructor
                ConstructorInfo constructor = database.GetConstructor(new Type[] { });

                // Invoke it's constructor, which returns an instance.
                Database createdObject = (Database)constructor.Invoke(null);

                // Initialize the connection string property for the database.
                createdObject.connectionString = sectionHandler.ConnectionString;

                // Pass back the instance as a Database
                return createdObject;
            }
            catch (Exception excep)
            {
                throw new Exception("Error instantiating database " + sectionHandler.Name + ". " + excep.Message);
            }
        }


        #region using EDMX

        /// <summary>

        ///     The datacontext

        /// </summary>

        private DeveloperHelperEntities _dataContext;



        /// <summary>

        ///     To get the context of learnwise

        /// </summary>

        /// <returns> returns LearnWiseEntities context </returns>

        public DeveloperHelperEntities Get()
        {

            return _dataContext ?? (_dataContext = new DeveloperHelperEntities());

        }



        /// <summary>

        ///     To dispose datacontext

        /// </summary>

        protected override void DisposeCore()
        {

            if (_dataContext != null)

                _dataContext.Dispose();

        }

        #endregion

    }




    public class DataWorker
    {
        private static Database _database = null;

        static DataWorker()
        {
            try
            {
                _database = DatabaseFactory.CreateDatabase();
            }
            catch (Exception excep)
            {
                throw excep;
            }
        }

        public static Database database
        {
            get { return _database; }
        }
    }


}
