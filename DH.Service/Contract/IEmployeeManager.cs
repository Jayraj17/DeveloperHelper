using DH.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH.Service.Contract
{
    public interface IEmployeeManager
    {
        List<Employee> EmployeeList(int id);
        BaseResponse SaveEmployee(Employee model);
        bool Login(string userName, string password);
    }
}
