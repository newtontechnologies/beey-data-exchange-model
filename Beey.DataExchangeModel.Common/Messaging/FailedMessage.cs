using System;
using System.Collections.Immutable;

namespace Beey.DataExchangeModel.Messaging;

public record FailedMessage(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, string Subsystem, DateTimeOffset Sent, string Reason)
    : Message(Id, Index, ProjectId, ChainId, Subsystem, Sent)
{
    public override MessageType Type => MessageType.Failed;
}
