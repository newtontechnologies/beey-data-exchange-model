using System.Collections.Immutable;
using System.Text.Json.Serialization;
using Beey.DataExchangeModel.Messaging;

namespace Backend.Messaging.Chain;

[JsonConverter(typeof(JsonStringEnumConverter<ChainCommand>))]
public enum ChainCommand
{
    /// <summary>
    /// Update of chain configurations
    /// </summary>
    Configuration,

    /// <summary>
    /// Start transcribtion
    /// </summary>
    Transcribe,

    /// <summary>
    /// Invoke external cancellation
    /// </summary>
    Cancel,

    /// <summary>
    /// something is terribly wrong and chain needs to be broken immediately..
    /// </summary>
    Kill,
}

public abstract record ChainCommandMessage(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, ChainCommand Command)
    : Message(Id, Index, ProjectId, ChainId, KnownSubsystemNames.ChainControl, Sent)
{
    [JsonPropertyOrder(int.MinValue)]//always must be second for deserialization to work
    public override MessageType Type => MessageType.ChainCommand;
}
