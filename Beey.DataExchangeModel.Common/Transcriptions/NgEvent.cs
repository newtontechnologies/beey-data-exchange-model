using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Beey.DataExchangeModel.Transcriptions;

public abstract class NgEvent
{
    public TimeSpan Begin { get; set; }
    public NgEvent() { }
#pragma warning disable IDE0060 // Remove unused parameter
    public NgEvent(JObject source) { }
#pragma warning restore IDE0060 // Remove unused parameter
    public abstract JObject Serialize();

    internal static NgEvent Deserialize(JObject e, DiarEventList? parent)
    {
        switch (e["k"].Value<string>())
        {
            case "s":
            case "e":
                return new NgSpeakerEvent(e);
            case "p":
                return new NgPhraseEvent(e);
            case "r":
                return new NgRecoveryEvent(e);

            default: throw new NotImplementedException();
        }
    }
}
