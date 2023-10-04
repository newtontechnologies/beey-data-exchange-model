using System;
using System.Collections.Immutable;

namespace Beey.DataExchangeModel.Messaging;

public record CompletedMessage(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, string Subsystem, DateTimeOffset Sent)
    : Message(Id, Index, ProjectId, ChainId, Subsystem, Sent)
{
    public override MessageType Type => MessageType.Completed;
}
