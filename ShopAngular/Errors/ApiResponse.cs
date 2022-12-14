using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAngular.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Lỗi",
                401 => "Chưa đăng nhập",
                404 => "Không tìm thấy",
                500 => "Errors are the path to the dark side.Errors lead to anger.Anger leads to hate.Hate leads to career change.",
                _ => null
            };
        }

       
    }
}
