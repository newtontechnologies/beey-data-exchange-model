using System;
using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Messaging;

public record CompletedMessage(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, string Subsystem, DateTimeOffset Sent)
    : Message(Id, Index, ProjectId, ChainId, Subsystem, Sent)
{
    [JsonPropertyOrder(int.MinValue)]//always must be second for deserialization to work
    public override MessageType Type => MessageType.Completed;
}
