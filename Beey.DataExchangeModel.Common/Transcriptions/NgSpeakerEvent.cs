using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Transcriptions;

public class NgSpeakerEvent : NgEvent
{
    public TimeSpan? End { get; set; }
    public string? SpeakerId { get; set; }
    public NgSpeakerEvent(JsonObject source) : base(source)
    {
        Begin = TimeSpan.FromMilliseconds(source["b"].Deserialize<long>());

        if (source["k"].Deserialize<string>() == "s")
            SpeakerId = source["s"].Deserialize<string>()!;
        else
        {
            End = TimeSpan.FromMilliseconds(source["e"].Deserialize<long>());
            SpeakerId = source["a"]!["ID"].Deserialize<string>()!;
        }
    }

    public NgSpeakerEvent() : base(null)
    {
    }

    public override JsonObject Serialize()
    {
        return new JsonObject()
        {
            {"b", (long)Begin.TotalMilliseconds},
            {"k", "s"},
            {"s", SpeakerId}
        };
    }
}
