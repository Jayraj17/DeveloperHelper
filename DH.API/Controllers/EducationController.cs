using DH.Model.DataModel;
using DH.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DH.API.Controllers
{
    [RoutePrefix("api/Education")]
    public class EducationController : ApiController
    {
        private IEducationManager _educationManager;
        public EducationController(IEducationManager educationManager)
        {
            this._educationManager = educationManager;
        }


        [HttpGet]
        [Route("GetAllEducation/{id}")]
        public List<Educations> Get(int id = 0)
        {
            List<Educations> list = new List<Educations>();
            try
            {
                return _educationManager.EducationList(id);
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        [HttpPost]
        [Route("SaveEducation")]
        public int SaveEducation(Educations model)
        {
            try
            {
                return _educationManager.SaveEducation(model);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        [HttpDelete]
        [Route("RemoveEducation/{id}")]
        public BaseResponse RemoveEducation(int id)
        {
            BaseResponse obj = new BaseResponse();
            try
            {
                _educationManager.RemoveEducation(id);
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
