using System;

namespace CleanArchitecture.ApplicationCore.Common.Models
{
    public class ErrorDetail
    {
        public int ErrorId { get; set; }
        public int StatusCode { get; set; }
        public string ErrorDescription { get; set; }
        public string InnerException { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public DateTime ErrorTime { get; set; }
    }
}
