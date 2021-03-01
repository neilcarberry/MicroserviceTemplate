using System;

namespace Application.Abstractions
{
    public class BaseException :Exception
    {
        public string Type { get; }
        protected BaseException(string type, string message, Exception innerException) : base(message, innerException)
        {
            Type = type;
        }
        protected BaseException(string type, string message) : base(message)
        { 
            Type = type;
        }
        public BaseException()
        {

        }
    }
}