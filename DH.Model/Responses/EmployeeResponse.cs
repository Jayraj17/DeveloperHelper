using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH.Model.Responses
{
    public class EmployeeResponse
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string contactPreference { get; set; }
        public DateTime dateofBirth { get; set; }
        public string department { get; set; }
        public bool isActive { get; set; }
        public string photoPath { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }
}
