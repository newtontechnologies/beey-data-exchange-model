using Beey.DataExchangeModel.Messaging.Subsystems;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Immutable;
using System.Text.Json.Nodes;

namespace Beey.DataExchangeModel.Messaging;

public record StartedMessage(int Id, ImmutableArray<int> Index, int? ProjectId, string Subsystem, DateTimeOffset Sent) : Message(Id, Index, ProjectId, Subsystem, Sent)
{
    public override MessageType Type => MessageType.Started;

    [Obsolete("just for backwards compatibility with deserializers")]
    public JsonNode Config => new JsonObject();
}
