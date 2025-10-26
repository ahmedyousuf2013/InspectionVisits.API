using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionVisits.Application.DTo
{
    public class BaseResponse
    {

        public Exception Error { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        protected int StatusCode { get; set; }
        public int Count { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
