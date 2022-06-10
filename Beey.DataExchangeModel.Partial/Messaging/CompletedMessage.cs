﻿using System;
using System.Collections.Immutable;

namespace Beey.DataExchangeModel.Messaging
{
    public sealed record CompletedMessage(int Id, ImmutableArray<int> Index, int? ProjectId, string Subsystem, DateTimeOffset Sent) : Message(Id, Index, ProjectId, Subsystem, Sent)
    {
        public override CompletedMessage WithCurrentTime()
            => (CompletedMessage)base.WithCurrentTime();
        public override MessageType Type => MessageType.Completed;
    }
}
