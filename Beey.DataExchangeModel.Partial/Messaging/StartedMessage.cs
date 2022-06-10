using Beey.DataExchangeModel.Messaging.Subsystems;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Immutable;

namespace Beey.DataExchangeModel.Messaging
{
    public sealed record StartedMessage(int Id, ImmutableArray<int> Index, int? ProjectId, string Subsystem, DateTimeOffset Sent) : Message(Id, Index, ProjectId, Subsystem, Sent)
    {
        public override StartedMessage WithCurrentTime()
            => (StartedMessage)base.WithCurrentTime();

        public override MessageType Type => MessageType.Started;
    }
}
