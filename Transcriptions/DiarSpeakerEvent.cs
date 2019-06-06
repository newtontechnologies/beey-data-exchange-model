using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

#pragma warning disable nullable
namespace BeeyApi.POCO.Transcriptions
{
    public partial class DiarSpeakerEvent : NgEvent
    {
        public TimeSpan End { get; set; }

        public string SpeakerId { get; set; }
        public (string Key, string Value) SpeakerAttr { get; set; }

        public string Text { get; set; }
        public DiarSpeakerEvent(JObject source) : base(source)
        {
            Begin = TimeSpan.FromMilliseconds(source["b"].Value<long>());

            End = TimeSpan.FromMilliseconds(source["e"].Value<long>());

            Text = source["text"].Value<string>();
        }

        public override JObject Serialize()
        {
            return
                new JObject(
                    new JProperty("b", (long)Begin.TotalMilliseconds),
                    new JProperty("e", (long)End.TotalMilliseconds),
                    new JProperty("k", "e"),
                    new JProperty("t", Text),
                    new JProperty("a", new JObject(
                        new JProperty("ID", SpeakerId),
                        new JProperty("attr", new JObject(
                            new JProperty(SpeakerAttr.Key, SpeakerAttr.Value)
                            ))
                        ))
                    );
        }
    }
}
