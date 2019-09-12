using DH.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH.Data.Contracts
{
    public interface IEmployeeRepository
    {
        List<Employee> EmployeeList(int id);
        BaseResponse SaveEmployee(Employee model);
        bool Login(string userName, string password);
    }
}
