using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


#pragma warning disable 8625
namespace Beey.DataExchangeModel.Transcriptions;

public partial class NgRecoveryEvent : NgEvent
{
    public NgRecoveryEvent() : base(null) { }
    public NgRecoveryEvent(JObject source) : base(source)
    {
        Begin = TimeSpan.FromMilliseconds(source["b"].Value<long>());
    }

    public override JObject Serialize()
    {
        return
            new JObject(
                new JProperty("b", (long)Begin.TotalMilliseconds),
                new JProperty("k", "r")
                );
    }
}
