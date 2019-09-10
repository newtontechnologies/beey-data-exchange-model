using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

#pragma warning disable nullable
#pragma warning disable 8618,8625
namespace Beey.DataExchangeModel.Transcriptions
{
    public partial class NgSpeakerEvent : NgEvent
    {
        public TimeSpan? End { get; set; }
        public string SpeakerId { get; set; }
        public NgSpeakerEvent(JObject source) : base(source)
        {
            Begin = TimeSpan.FromMilliseconds(source["b"].Value<long>());

            if (source["k"].Value<string>() == "s")
                SpeakerId = source["s"].Value<string>();
            else
            {
                End = TimeSpan.FromMilliseconds(source["e"].Value<long>());
                SpeakerId = source["a"]["ID"].Value<string>();
            }
        }

        public NgSpeakerEvent() : base(null)
        {
        }

        public override JObject Serialize()
        {
            return
                new JObject(
                    new JProperty("b", (long)Begin.TotalMilliseconds),
                    new JProperty("k", "s"),
                    new JProperty("s", SpeakerId)
                    );
        }
    }
}
