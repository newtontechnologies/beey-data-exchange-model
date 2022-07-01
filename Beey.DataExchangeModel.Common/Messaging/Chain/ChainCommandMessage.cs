using System.Collections.Immutable;
using Beey.DataExchangeModel.Messaging;


namespace Backend.Messaging.Chain;
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

public abstract record ChainCommandMessage(int Id, ImmutableArray<int> Index, int? ProjectId, DateTimeOffset Sent, ChainCommand Command) : Message(Id, Index, ProjectId, KnownSubsystemNames.ChainControl, Sent)
{
    public override MessageType Type => MessageType.ChainCommand;
}
