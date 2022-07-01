using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Beey.DataExchangeModel.Transcriptions;

public class DiarEventList
{
    public DiarEventType Type { get; set; }
    public TimeSpan? Begin { get; set; }
    public TimeSpan? End { get; set; }

    public NgEvent[] Events { get; set; }

    public string Content { get; set; }

    public DiarEventList() { }
    public DiarEventList(JObject source)
    {
        Type = source["type"].ToObject<DiarEventType>();

        if (source["begin"] != null)
            Begin = TimeSpan.FromMilliseconds(source["begin"].Value<long>());

        if (source["end"] != null)
            End = TimeSpan.FromMilliseconds(source["end"].Value<long>());

        if (source["events"] != null && source["events"].HasValues)
        {
            Events = ((JArray)source["events"])
                .Select(e => NgEvent.Deserialize((JObject)e, this))
                .ToArray();
        }

        switch (Type)
        {
            case DiarEventType.info:
                Content = source["content"].Value<string>();
                break;
            case DiarEventType.demand:
                Content = source["task"].Value<string>();
                break;
            case DiarEventType.F:
                Events = source.Property("events").Value
                    .Cast<JObject>()
                    .Select(jo => NgEvent.Deserialize(jo, this))
                    .ToArray();
                break;
        }
    }

    public JObject Serialize()
    {
        var o =
            new JObject(
                new JProperty("type", Type.ToString())
            );

        if (Events != null)
            o.Add("events", JArray.FromObject(Events.Select(e => e.Serialize()).ToArray()));

        if (Begin != null)
            o.Add("begin", (long)Begin.Value.TotalMilliseconds);

        if (End != null)
            o.Add("end", (long)End.Value.TotalMilliseconds);

        switch (Type)
        {
            case DiarEventType.info:
                o.Add("content", Content);
                break;
            case DiarEventType.demand:
                o.Add("task", Content);
                break;
        }

        return o;
    }
}
