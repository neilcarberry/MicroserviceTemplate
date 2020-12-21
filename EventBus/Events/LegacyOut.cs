using EventBus.Events;
using Newtonsoft.Json;

public class LegacyOut : IntegrationEvent
{
    public string QueueName { get; set; }
    public string PayloadIn { get; set; }
    public LegacyOut(IntegrationEvent _legacyEvent, string queueName)
    {
        QueueName = queueName.Substring(0, queueName.IndexOf("Integration"));
        PayloadIn = JsonConvert.SerializeObject(_legacyEvent);
    }
}
