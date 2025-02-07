using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.Common.Models
{
    public class ApiResponseAction
    {
        public static ApiResponse GetSuccessReponse()
        {
            ApiResponse apiResponse = new ApiResponse()
            {
                Status = true,
                Data = null,
                Message = "Success"
            };
            return apiResponse;
        }
        public static ApiResponse GetSuccessReponse(object payload)
        {
            ApiResponse apiResponse = new ApiResponse()
            {
                Status = true,
                Data = payload,
                Message = "Success"
            };
            return apiResponse;
        }

        public static ApiResponse GetSuccessReponse(bool payload)
        {
            ApiResponse apiResponse = new ApiResponse()
            {
                Status = true,
                Data = null,
                Message = "Success"
            };
            return apiResponse;
        }

        public static ApiResponse GetSuccessReponse(object payload, object message)
        {
            ApiResponse apiResponse = new ApiResponse()
            {
                Status = true,
                Data = payload,
                Message = message
            };
            return apiResponse;
        }

        public static ApiResponse GetSuccessFailReponse(object message)
        {
            ApiResponse apiResponse = new ApiResponse()
            {
                Status = true,
                Data = null,
                Message = message
            };
            return apiResponse;
        }

        public static ApiResponse GetFailReponse()
        {
            ApiResponse apiResponse = new ApiResponse()
            {
                Status = false,
                Data = null,
                Message = "Fail"
            };
            return apiResponse;
        }

        public static ApiResponse GetFailReponse(object message)
        {
            ApiResponse apiResponse = new ApiResponse()
            {
                Status = false,
                Data = null,
                Message = message
            };
            return apiResponse;
        }
    }
}
