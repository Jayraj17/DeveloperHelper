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
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> EmployeeList(int id)
        {
            return new DHDataExtension<Employee>().ExecuteListStoredProcedure("sp_GetEmployee", new { @empId = id });
        }
        public BaseResponse SaveEmployee(Employee model)
        {
            return new DHDataExtension<BaseResponse>().ExecuteStoredProcedure("sp_SaveEmployee", new { model.id }
                                                                                               , new { model.name }
                                                                                               , new { model.gender }
                                                                                               , new { model.email }
                                                                                               , new { model.phoneNumber }
                                                                                               , new { model.contactPreference }
                                                                                               , new { model.dateofBirth }
                                                                                               , new { model.department }
                                                                                               , new { model.eduId }
                                                                                               , new { model.isActive }
                                                                                               , new { model.photoPath }
                                                                                               , new { model.password }
                                                                                               , new { model.confirmPassword }
                                                                                                );
        }
        public bool Login(string username, string password)
        {
            var list = new DHDataExtension<Employee>().ExecuteListStoredProcedure("sp_GetEmployee", new { @empId = 0 }).Where(x => x.name == username && x.password == password);
            if (list.Count() == 0)
            {
                return false;
            }
            return true;
        }

    }
}
