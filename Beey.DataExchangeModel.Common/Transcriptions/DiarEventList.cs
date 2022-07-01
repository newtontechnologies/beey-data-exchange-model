using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;



namespace Beey.DataExchangeModel.Transcriptions;

public class DiarEventList
{
    public DiarEventType Type { get; set; }
    public TimeSpan? Begin { get; set; }
    public TimeSpan? End { get; set; }

    public NgEvent[]? Events { get; set; }

    public string? Content { get; set; }

    public DiarEventList() { }
    public DiarEventList(JsonObject source)
    {
        Type = source["type"].Deserialize<DiarEventType>();

        if (source["begin"] != null)
            Begin = TimeSpan.FromMilliseconds(source["begin"].Deserialize<long>());

        if (source["end"] != null)
            End = TimeSpan.FromMilliseconds(source["end"].Deserialize<long>());

        if (source["events"] is JsonArray arr)
        {
            Events = arr
                .Select(e => NgEvent.Deserialize((JsonObject)e!, this))
                .ToArray();
        }

        switch (Type)
        {
            case DiarEventType.info:
                Content = source["content"].Deserialize<string>()!;
                break;
            case DiarEventType.demand:
                Content = source["task"].Deserialize<string>()!;
                break;
            case DiarEventType.F:
                //deserialized above
                break;
        }
    }

    public JsonObject Serialize()
    {
        var o = new JsonObject()
        { {"type", Type.ToString()} };

        if (Events != null)
            o.Add("events", JsonSerializer.SerializeToNode(Events));

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
