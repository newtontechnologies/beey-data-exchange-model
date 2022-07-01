using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Beey.DataExchangeModel.Transcriptions;

public class NgRecoveryEvent : NgEvent
{
    public NgRecoveryEvent() : base(null) { }
    public NgRecoveryEvent(JsonObject source) : base(source)
    {
        Begin = TimeSpan.FromMilliseconds(source["b"].Deserialize<long>());
    }

    public override JsonObject Serialize()
    {
        return new JsonObject()
        {
            {"b", (long)Begin.TotalMilliseconds},
            {"k", "r" }
        };
    }
}
