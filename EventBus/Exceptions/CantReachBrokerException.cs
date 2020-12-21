using System;
using System.IO;

namespace EventBus_Framework.Exceptions
{
    public class CantReachBrokerException : IOException
    {
        public CantReachBrokerException(Exception Inner) : base(Inner.Message, Inner.InnerException)
        {
        }
    }
}
