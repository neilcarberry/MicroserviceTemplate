using System;
using System.Net;
using System.Runtime.Serialization;

namespace Application.Abstractions
{
    [Serializable]
    public class BaseHttpException : BaseException
    {
        public HttpStatusCode Code = HttpStatusCode.InternalServerError;
        public BaseHttpException(string message) : base("Http", message)
        {
        }

        public BaseHttpException(string message, Exception innerException) : base("Http", message, innerException)
        {
        }
    }
}