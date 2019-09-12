﻿using DH.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH.Service.Contract
{
    public interface IDepartmentManager
    {
        List<Department> DepartmentList(int id);
        int SaveDepartment(Department model);
        BaseResponse RemoveDepartment(int id);
    }
}
