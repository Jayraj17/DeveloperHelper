using DH.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH.Service.Contract
{
    public interface IEducationManager
    {
        List<Educations> EducationList(int id);
        int SaveEducation(Educations model);
        BaseResponse RemoveEducation(int id);
    }
}
