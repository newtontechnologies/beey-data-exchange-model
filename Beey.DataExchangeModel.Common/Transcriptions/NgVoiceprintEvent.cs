using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Beey.DataExchangeModel.Transcriptions;

public class NgVoiceprintEvent : NgEvent
{
    public TimeSpan End { get; set; }
    public string Voiceprint { get; set; }
    public string SpeakerId { get; set; }
    public NgVoiceprintEvent(JsonObject source) : base(source)
    {
        Begin = TimeSpan.FromMilliseconds(source["b"].Deserialize<long>());
        End = TimeSpan.FromMilliseconds(source["e"].Deserialize<long>());
        Voiceprint = source["v"]?.Deserialize<string>() ?? throw new ArgumentException("Voiceprint is null.");
        SpeakerId = source["s"]?.Deserialize<string>() ?? throw new ArgumentException("SpeakerId is null.");
    }

    public NgVoiceprintEvent() : base(null)
    {
    }

    public override JsonObject Serialize()
    {
        return new JsonObject()
        {
            {"b", (long)Begin.TotalMilliseconds},
            {"e", (long)End.TotalMilliseconds},
            {"k", "v"},
            {"v", Voiceprint},
            {"s", SpeakerId},
        };
    }
}

