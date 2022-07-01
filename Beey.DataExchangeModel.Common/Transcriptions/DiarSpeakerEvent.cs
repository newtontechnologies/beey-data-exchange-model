using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;



namespace Beey.DataExchangeModel.Transcriptions;

public class DiarSpeakerEvent : NgEvent
{
    public TimeSpan End { get; set; }

    public string? SpeakerId { get; set; }
    public (string Key, string Value) SpeakerAttr { get; set; }

    public string Text { get; set; }
    public DiarSpeakerEvent(JsonObject source) : base(source)
    {
        Begin = TimeSpan.FromMilliseconds(source["b"].Deserialize<long>());

        End = TimeSpan.FromMilliseconds(source["e"].Deserialize<long>());

        Text = source["text"].Deserialize<string>()!;
    }

    public override JsonObject Serialize()
    {
        return new JsonObject()
        {
            { "b", (long)Begin.TotalMilliseconds},
            { "e", (long)End.TotalMilliseconds},
            { "k", "e"},
            { "t", Text},
            { "a", new JsonObject()
                {
                    {"ID",SpeakerId },
                    {"attr",new JsonObject()
                            {{SpeakerAttr.Key,SpeakerAttr.Value}}
                    }
                }
            }
        };
    }
}
