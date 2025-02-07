using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.Common.Models
{
    public class ApiResponse
    {
        public bool Status { get; set; }
        public object Data { get; set; }
        public object Message { get; set; }
    }
}
