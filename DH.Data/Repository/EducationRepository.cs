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
    public class EducationRepository : IEducationRepository
    {
        public List<Educations> EducationList(int id)
        {
            return new DHDataExtension<Educations>().ExecuteListStoredProcedure("sp_GetEducation", new { @EduId = id });
        }

        public BaseResponse RemoveEducation(int id)
        {
            return new DHDataExtension<BaseResponse>().ExecuteStoredProcedure("sp_RemoveEducation", new { @EduId = id });
        }

        public int SaveEducation(Educations model)
        {
            return new DHDataExtension<int>().ExecuteScaler("sp_SaveEducation", new { model.EduId }
                                                                                              , new { model.Education }
                                                                                              , new { model.Description }
                                                                                              , new { model.UserId }
                                                                                               );
        }
    }
}
