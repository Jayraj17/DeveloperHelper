using DH.Model.DataModel;
using DH.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DH.API.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {

        private IEmployeeManager _employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }


        [HttpGet]
        [Route("GetAllEmployee/{id}")]
        public List<Employee> Get(int id = 0)
        {
            List<Employee> list = new List<Employee>();
            try
            {
                return _employeeManager.EmployeeList(id);
            }
            catch (Exception ex)
            {
                return list;
            }
        }


        [HttpPost]
        [Route("SaveEmployee")]
        public BaseResponse SaveEmployee(Employee model)
        {
            BaseResponse obj = new BaseResponse();
            try
            {
                obj.ResponseCode = 200;
                // obj.ResponseStatus = EnumHelpers.ReturnCode.Success.ToString();
                return _employeeManager.SaveEmployee(model);
            }
            catch (Exception ex)
            {
                return obj;
            }
        }

        [HttpGet]
        [Route("GetLogin")]
        public bool Login(string username, string password)
        {          
           
            try
            {
                return _employeeManager.Login(username, password);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
