using System;

namespace Beey.DataExchangeModel.Messaging
{
    public sealed record ProgressMessage(int Id, int[] Index, int? ProjectId, string Subsystem, DateTimeOffset Sent, JsonData Data) : Message(Id, Index, ProjectId, Subsystem, Sent)
    {
        public override MessageType Type => MessageType.Progress;
    }
}
