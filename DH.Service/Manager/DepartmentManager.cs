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
    public class DepartmentManager : IDepartmentManager
    {

        private IDepartmentRepository _departmentRepository;


        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        public List<Department> DepartmentList(int id)
        {
            return _departmentRepository.DepartmentList(id);
        }

        public BaseResponse RemoveDepartment(int id)
        {
            return _departmentRepository.RemoveDepartment(id);
        }

        public int SaveDepartment(Department model)
        {
            return _departmentRepository.SaveDepartment(model);
        }
    }
}
