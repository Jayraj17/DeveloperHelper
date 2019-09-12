using DH.Data.Contracts;
using DH.Model.DataModel;
using DH.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH.Service.Manager
{
    public class EmployeeManager : IEmployeeManager
    {

        private IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        public List<Employee> EmployeeList(int id)
        {
            return _employeeRepository.EmployeeList(id);
        }
        public bool Login(string userName, string password)
        {
            return _employeeRepository.Login(userName, password);
        }
        public BaseResponse SaveEmployee(Employee model)
        {
            return _employeeRepository.SaveEmployee(model);
        }
    }
}
