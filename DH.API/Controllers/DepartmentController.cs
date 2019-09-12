using DH.Model.DataModel;
using DH.Service.Contract;
using DH.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DH.API.Controllers
{
    [RoutePrefix("api/Department")]
    public class DepartmentController : ApiController
    {

        private IDepartmentManager _departmentManager;
        public DepartmentController(IDepartmentManager departmentManager)
        {
            this._departmentManager = departmentManager;
        }
        [HttpGet]
        [Route("GetAllDepartment/{id}")]
        public List<Department> Get(int id = 0)
        {
            List<Department> list = new List<Department>();
            try
            {
                return _departmentManager.DepartmentList(id);
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        [HttpPost]
        [Route("SaveDepartment")]
        public int SaveDepartment(Department model)
        {
            try
            {
                return _departmentManager.SaveDepartment(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        [HttpDelete]
        [Route("RemoveDepartment/{id}")]
        public BaseResponse RemoveDepartment(int id)
        {
            BaseResponse obj = new BaseResponse();
            try
            {
                _departmentManager.RemoveDepartment(id);
                obj.ResponseCode = 200;
                return obj;
            }
            catch (Exception ex)
            {
                obj.ResponseCode = 404;
                obj.ResponseMessage = ex.ToString();
            }
            return obj;
        }


    }
}
