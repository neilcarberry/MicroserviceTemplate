using System;
using System.Runtime.Serialization;

namespace Application.Abstractions
{
    [Serializable]
    internal class BaseHttpException : Exception
    {
        public BaseHttpException()
        {
        }

        public BaseHttpException(string message) : base(message)
        {
        }

        public BaseHttpException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BaseHttpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}