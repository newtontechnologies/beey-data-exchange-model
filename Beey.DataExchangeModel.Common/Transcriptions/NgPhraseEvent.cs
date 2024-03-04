using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using TranscriptionCore;



namespace Beey.DataExchangeModel.Transcriptions;

public class NgPhraseEvent : NgEvent
{
    public TimeSpan End { get; set; }

    public string? Text { get; set; }
    public double Confidence { get; set; }
    public string? Phonetics { get; set; }
    public NgPhraseEvent()
    {
        Confidence = 1.0;
        Phonetics = null;
    }
    public NgPhraseEvent(JsonObject source) : base(source)
    {
        Begin = TimeSpan.FromMilliseconds(source["b"].Deserialize<long>());
        End = TimeSpan.FromMilliseconds(source["e"].Deserialize<long>());
        Text = source["t"]?.Deserialize<string>();
        if (source.TryGetPropertyValue("c", out var token))
            Confidence = token.Deserialize<double>();
        else
            Confidence = 1.0;
    }

    public override JsonObject Serialize()
    {
        return
            new JsonObject()
            {
                { "b", (long)Begin.TotalMilliseconds },
                { "e", (long)End.TotalMilliseconds },
                { "k", "p" },
                { "t", Text },
                { "c", Confidence },
            };
    }

    public TranscriptionPhrase ToPhrase()
    {
        var result = new TranscriptionPhrase() { Begin = Begin, End = End, Text = Text };
        result.Elements.Add("c", Confidence.ToString(System.Globalization.CultureInfo.InvariantCulture));
        return result;
    }
}
