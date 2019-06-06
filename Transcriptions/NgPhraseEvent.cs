using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TranscriptionCore;

#pragma warning disable nullable
namespace BeeyApi.POCO.Transcriptions
{
    public partial class NgPhraseEvent : NgEvent
    {
        public TimeSpan End { get; set; }

        public string Text { get; set; }
        public NgPhraseEvent()
        { }
        public NgPhraseEvent(JObject source) : base(source)
        {
            Begin = TimeSpan.FromMilliseconds(source["b"].Value<long>());

            End = TimeSpan.FromMilliseconds(source["e"].Value<long>());

            Text = source["t"].Value<string>();
        }

        public override JObject Serialize()
        {
            return
                new JObject(
                    new JProperty("b", (long)Begin.TotalMilliseconds),
                    new JProperty("e", (long)End.TotalMilliseconds),
                    new JProperty("k", "p"),
                    new JProperty("t", Text)
                    );
        }

        public TranscriptionPhrase ToPhrase()
        {
            return new TranscriptionPhrase() { Begin = Begin, End = End, Text = Text };
        }
    }
}
