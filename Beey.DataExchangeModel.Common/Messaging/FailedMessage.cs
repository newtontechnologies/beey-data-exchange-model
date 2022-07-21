using System;
using System.Collections.Immutable;

namespace Beey.DataExchangeModel.Messaging;

public record FailedMessage(int Id, ImmutableArray<int> Index, int? ProjectId, string Subsystem, DateTimeOffset Sent, string Reason) : Message(Id, Index, ProjectId, Subsystem, Sent)
{
    public override MessageType Type => MessageType.Failed;
}
