using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TranscriptionCore;



namespace Beey.DataExchangeModel.Transcriptions;

public class NgPhraseEvent : NgEvent
{
    public TimeSpan End { get; set; }

    public string Text { get; set; }
    public double Confidence { get; set; }
    public NgPhraseEvent()
    {
        Confidence = 1.0;
    }
    public NgPhraseEvent(JObject source) : base(source)
    {
        Begin = TimeSpan.FromMilliseconds(source["b"].Value<long>());

        End = TimeSpan.FromMilliseconds(source["e"].Value<long>());

        Text = source["t"].Value<string>();

        if (source.TryGetValue("c", out var token))
            Confidence = token.Value<double>();
        else
            Confidence = 1.0;
    }

    public override JObject Serialize()
    {
        return
            new JObject(
                new JProperty("b", (long)Begin.TotalMilliseconds),
                new JProperty("e", (long)End.TotalMilliseconds),
                new JProperty("k", "p"),
                new JProperty("t", Text),
                new JProperty("c", Confidence)
                );
    }

    public TranscriptionPhrase ToPhrase()
    {
        var result = new TranscriptionPhrase() { Begin = Begin, End = End, Text = Text };
        result.Elements.Add("c", Confidence.ToString(System.Globalization.CultureInfo.InvariantCulture));
        return result;
    }
}
