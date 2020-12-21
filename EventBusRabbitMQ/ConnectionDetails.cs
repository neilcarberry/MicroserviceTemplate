using System;
using System.Threading.Tasks;

namespace EventBus
{
    public class ConnectionDetails
    {
        public string EventBusConnection { get; set; }
        public int EventBusRetryCount { get; set; }
        public string EventBusUserName { get; set; }
        public string EventBusPassword { get; set; }
        public int EventBusPort { get; set; }
    }
}