using System;
using System.Collections.Immutable;

namespace Beey.DataExchangeModel.Messaging
{
    public abstract record ProgressMessage(int Id, ImmutableArray<int> Index, int? ProjectId, string Subsystem, DateTimeOffset Sent, JsonData Data) : Message(Id, Index, ProjectId, Subsystem, Sent)
    {
        public override MessageType Type => MessageType.Progress;
    }
}
