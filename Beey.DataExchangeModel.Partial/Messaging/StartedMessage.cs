using Beey.DataExchangeModel.Messaging.Subsystems;
using Microsoft.Extensions.Configuration;
using System;

namespace Beey.DataExchangeModel.Messaging
{
    public sealed record StartedMessage(int Id, int[] Index, int? ProjectId, string Subsystem, DateTimeOffset Sent) : Message(Id, Index, ProjectId, Subsystem, Sent)
    {
        public override MessageType Type => MessageType.Started;
    }
}
