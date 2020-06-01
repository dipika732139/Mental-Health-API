using System;
using System.Collections.Generic;
using System.Net;

namespace Mental.Health
{
    public class BaseException:Exception
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public List<ErrorInfo> Infos { get; set; }
        public BaseException(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
        public BaseException(int errorCode, string errorMessage, HttpStatusCode httpStatusCode)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            HttpStatusCode = httpStatusCode;
        }
    }
}
