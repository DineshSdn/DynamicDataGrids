
using System;
using System.Collections.Generic;

namespace CleanArchitecture.ApplicationCore.Common.Models
{
    public class JsonResponse
    {
        public string Id { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public string ErrorDetail { get; set; }

        public bool Ishra { get; set; }
        public object Data { get; set; } // This can be of any type depending on the data you want to return

        public JsonResponse()
        {
            Ishra = true; // Set default value
        }


    }
}
