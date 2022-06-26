using System;
using System.Collections.Immutable;

namespace Beey.DataExchangeModel.Messaging
{
    /// <summary>
    /// Unfixable problem in chain, everything should terminate and chain will be broken..
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Index"></param>
    /// <param name="ProjectId"></param>
    /// <param name="Subsystem"></param>
    /// <param name="Sent"></param>
    /// <param name="Reason"></param>
    public sealed record PanicMessage(int Id, ImmutableArray<int> Index, int? ProjectId, string Subsystem, DateTimeOffset Sent, string Reason) : Message(Id, Index, ProjectId, Subsystem, Sent)
    {
        public override MessageType Type => MessageType.Panic;
    }
}
