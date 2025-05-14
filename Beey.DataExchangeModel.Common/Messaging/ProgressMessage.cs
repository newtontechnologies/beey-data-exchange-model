using System.Collections.Immutable;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Beey.DataExchangeModel.Messaging.Subsystems;

namespace Beey.DataExchangeModel.Messaging;

public record ProgressMessage(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, SubsystemName Subsystem, DateTimeOffset Sent, JsonNode Data) : Message(Id, Index, ProjectId, ChainId, Subsystem, Sent)
{
    [JsonPropertyOrder(int.MinValue)]//always must be second for deserialization to work
    public override MessageType Type => MessageType.Progress;
}
