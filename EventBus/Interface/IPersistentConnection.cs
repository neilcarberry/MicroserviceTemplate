using System;
using System.Threading.Tasks;

namespace EventBus.Interfaces
{
    public interface IPersistentConnection : IDisposable
    {
        bool IsConnected { get; }
        bool TryConnect();
        void CreateChannel();
        void RemoveRoutingKey(string eventName);
        void AddRoutingKey(string eventName);
        void Publish(string eventName, byte[] body);
        void CreateConsumerChannel(Func<string, string, Task<bool>> callback);
    }
}