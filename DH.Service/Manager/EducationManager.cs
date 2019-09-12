using DH.Data.Contracts;
using DH.Data.Repository;
using DH.Model.DataModel;
using DH.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH.Service.Manager
{
    public class EducationManager : IEducationManager
    {

        private EducationRepository _educationRepository;

        public EducationManager(EducationRepository educationRepository)
        {
            this._educationRepository = educationRepository;
        }

        public List<Educations> EducationList(int id)
        {
            return this._educationRepository.EducationList(id);
        }

        public BaseResponse RemoveEducation(int id)
        {
            return this._educationRepository.RemoveEducation(id);
        }

        public int SaveEducation(Educations model)
        {
            return this._educationRepository.SaveEducation(model);
        }
    }
}
