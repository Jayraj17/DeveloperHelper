using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH.Model.DataModel
{
    public class BaseResponse
    {
        public short ResponseCode { get; set; }
        public long ResponseID { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseStatus { get; set; }
    }
}
