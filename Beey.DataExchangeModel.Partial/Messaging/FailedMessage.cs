using System;

namespace Beey.DataExchangeModel.Messaging
{
    public sealed record FailedMessage(int Id, int[] Index, int? ProjectId, string Subsystem, DateTimeOffset Sent, string Reason) : Message(Id, Index, ProjectId, Subsystem, Sent)
    {
        public override MessageType Type => MessageType.Failed;
    }
}
