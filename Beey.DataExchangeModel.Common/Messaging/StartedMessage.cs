using System.Collections.Immutable;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Beey.DataExchangeModel.Messaging.Subsystems;

namespace Beey.DataExchangeModel.Messaging;

public record StartedMessage(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, SubsystemName Subsystem, DateTimeOffset Sent)
    : Message(Id, Index, ProjectId, ChainId, Subsystem, Sent)
{
    [JsonPropertyOrder(int.MinValue)]//always must be second for deserialization to work
    public override MessageType Type => MessageType.Started;

    [Obsolete("just for backwards compatibility with deserializers")]
    public JsonNode Config => new JsonObject();
}
