using System;
using System.Collections.Immutable;
using System.Text.Json.Nodes;

namespace Beey.DataExchangeModel.Messaging
{
    public abstract record ProgressMessage(int Id, ImmutableArray<int> Index, int? ProjectId, string Subsystem, DateTimeOffset Sent, JsonNode Data) : Message(Id, Index, ProjectId, Subsystem, Sent)
    {
        public override MessageType Type => MessageType.Progress;
    }
}
