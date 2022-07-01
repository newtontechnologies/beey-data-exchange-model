using System.Text.Json.Serialization;

namespace Backend.Messaging.Chain;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubsystemStatus
{
    NotRunning = 0,
    Running = 1,
    Completed = 2,
    Failed = 3,
}
