using System;
using System.Collections.Immutable;
using System.Text.Json.Nodes;

namespace Beey.DataExchangeModel.Messaging;

public record ProgressMessage(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, string Subsystem, DateTimeOffset Sent, JsonNode Data) : Message(Id, Index, ProjectId, ChainId, Subsystem, Sent)
{
    public override MessageType Type => MessageType.Progress;
}
