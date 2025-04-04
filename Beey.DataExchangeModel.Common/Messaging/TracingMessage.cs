﻿using System.Collections.Immutable;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Beey.DataExchangeModel.Messaging;

public record TracingMessage(
    int Id,
    ImmutableArray<int> Index,
    int? ProjectId,
    int? ChainId,
    string Subsystem,
    DateTimeOffset Sent,
    TracingMessage.Events Event,
    long? ByteCount = null)
    : Message(Id, Index, ProjectId, ChainId, Subsystem, Sent)
{
    [JsonPropertyOrder(int.MinValue)] //always must be second for deserialization to work
    public override MessageType Type => MessageType.Tracing;

    public enum Events
    {
        BytesProcessed,
        BytesUploaded
    }

    [Obsolete("just for backwards compatibility with deserializers")]
    public JsonNode Config => new JsonObject();
}
