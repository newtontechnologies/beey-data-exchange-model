using System;

namespace Beey.DataExchangeModel.Messaging
{
    public sealed record CompletedMessage(int Id, int[] Index, int? ProjectId, string Subsystem, DateTimeOffset Sent) : Message(Id, Index, ProjectId, Subsystem, Sent)
    {
        public override MessageType Type => MessageType.Completed;
    }
}
