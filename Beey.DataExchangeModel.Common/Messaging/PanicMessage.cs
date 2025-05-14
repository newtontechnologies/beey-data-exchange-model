using System.Collections.Immutable;
using System.Text.Json.Serialization;
using Beey.DataExchangeModel.Messaging.Subsystems;

namespace Beey.DataExchangeModel.Messaging;

/// <summary>
/// Unfixable problem in chain, everything should terminate and chain will be broken..
/// </summary>
/// <param name="Id"></param>
/// <param name="Index"></param>
/// <param name="ProjectId"></param>
/// <param name="Subsystem"></param>
/// <param name="Sent"></param>
/// <param name="Reason"></param>
public sealed record PanicMessage(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, SubsystemName Subsystem, DateTimeOffset Sent, string Reason)
    : Message(Id, Index, ProjectId, ChainId, Subsystem, Sent)
{
    [JsonPropertyOrder(int.MinValue)]//always must be second for deserialization to work
    public override MessageType Type => MessageType.Panic;
}
