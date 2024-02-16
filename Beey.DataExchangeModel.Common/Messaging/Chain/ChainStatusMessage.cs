using System.Collections.Immutable;
using System.Text.Json.Serialization;
using Beey.DataExchangeModel.Messaging;

namespace Backend.Messaging.Chain;

public abstract record ChainStatusMessage(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, StatusNode? Statuses)
    : Message(Id, Index, ProjectId, ChainId, KnownSubsystemNames.ChainControl, Sent)
{
    public SubsystemStatus? this[string name] => Statuses?[name]?.Status;
    [JsonPropertyOrder(int.MinValue)]//always must be second for deserialization to work
    public override MessageType Type => MessageType.ChainStatus;
}

public class StatusNode
{
    public StatusNode? this[string name]
    {
        get
        {
            if (Subsystem == name)
                return this;

            if (Nodes == null || Nodes.Length == 0)
                return null;

            foreach (var n in Nodes)
            {
                var res = n[name];
                if (res is { })
                    return res;
            }

            return null;
        }
    }

    public IEnumerable<StatusNode> Flatten()
    {
        yield return this;
        if (Nodes is null)
            yield break;

        foreach (var n in Nodes)
        {
            foreach (var c in n.Flatten())
                yield return c;
        }
    }


    public string? Subsystem { get; set; }
    public SubsystemStatus Status { get; set; }
    public ImmutableArray<int> Index { get; set; } = ImmutableArray<int>.Empty;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public StatusNode[]? Nodes { get; set; }
}
