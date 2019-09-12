using DH.Data.Contracts;
using DH.Data.Extension;
using DH.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH.Data.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public List<Department> DepartmentList(int id)
        {
            return new DHDataExtension<Department>().ExecuteListStoredProcedure("sp_GetDepartment", new { @deptId = id });
        }

        public int SaveDepartment(Department model)
        {
            return new DHDataExtension<int>().ExecuteScaler("sp_SaveDepartment", new { model.deptId }
                                                                                              , new { model.DepartmentName }
                                                                                              , new { model.Description }
                                                                                              , new { model.UserId }
                                                                                               );

        }
        public BaseResponse RemoveDepartment(int id)
        {
            return new DHDataExtension<BaseResponse>().ExecuteStoredProcedure("sp_RemoveDepartment", new { @deptId = id });
        }




    }
}
