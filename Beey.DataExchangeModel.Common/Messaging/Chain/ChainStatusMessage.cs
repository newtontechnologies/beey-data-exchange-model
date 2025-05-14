using System.Collections.Immutable;
using System.Text.Json.Serialization;
using Beey.DataExchangeModel.Messaging;
using Beey.DataExchangeModel.Messaging.Subsystems;

namespace Backend.Messaging.Chain;

public abstract record ChainStatusMessage(int Id, ImmutableArray<int> Index, int? ProjectId, int? ChainId, DateTimeOffset Sent, StatusNode? Statuses)
    : Message(Id, Index, ProjectId, ChainId, KnownSubsystemNames.ChainControl, Sent)
{
    public SubsystemStatus? this[SubsystemName name] => Statuses?[name]?.Status;

    [JsonPropertyOrder(int.MinValue)]//always must be second for deserialization to work
    public override MessageType Type => MessageType.ChainStatus;
}

public class StatusNode
{
    public StatusNode? this[SubsystemName name]
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


    public SubsystemName? Subsystem { get; set; }
    public SubsystemStatus Status { get; set; }
    public ImmutableArray<int> Index { get; set; } = [];

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public StatusNode[]? Nodes { get; set; }
}
