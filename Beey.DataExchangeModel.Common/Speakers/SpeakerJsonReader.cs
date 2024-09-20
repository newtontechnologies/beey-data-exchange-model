using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Beey.DataExchangeModel.Common.Speakers;

/// <summary>Reads various data-type values from speaker JSON nodes</summary>
public static class SpeakerJsonReader
{
    public static string? GetString(JsonNode node, SpeakerDataStringReadOptions? options)
    {
        StringCollector collector = new(options);
        CollectValues(node, ref collector, options, StringCollector.TryCollectString);
        return collector.Result;
    }

    public static IReadOnlyList<string>? GetStringArray(JsonNode node, SpeakerDataStringReadOptions? options)
    {
        StringArrayCollector collector = new(options);
        CollectValues(node, ref collector, options, StringArrayCollector.TryCollectString);
        return collector.Result;
    }

    static bool TryReadSingleString(JsonNode? node, SpeakerDataStringReadOptions? options, out string value)
    {
        switch (node?.GetValueKind())
        {
            case JsonValueKind.String:
                value = node.ToString();
                return true;

            case JsonValueKind.Number when options?.ReadNumberAsString ?? SpeakerDataStringReadOptions.DefaultReadNumberAsString:
                value = node.ToString();
                return true;
        }
        value = default!;
        return false;
    }

    struct StringCollector(SpeakerDataStringReadOptions? options)
    {
        // This is a highly optimized collector for single string value,
        // focused to do minimum memory allocations

        readonly SpeakerDataStringReadOptions? _options = options;

        public string? Result => _collected switch
        {
            string singleValue => singleValue,
            StringBuilder buff => buff.ToString(),
            _ => null
        };

        // one of (null || string || StringBuilder)
        object? _collected;

        public static bool TryCollectString(JsonNode? node, ref StringCollector collector)
        {
            if (!TryReadSingleString(node, collector._options, out var newString))
                return false;

            if (collector._collected is null)
            {
                // most usual case
                collector._collected = newString;
                return true;
            }

            var joinCharacter = collector._options is null
                ? SpeakerDataStringReadOptions.DefaultStringJoinCharacter
                : collector._options.StringJoinCharacter;

            if (joinCharacter is null)
                return true; // only previous value is used, skip this one

            StringBuilder buff;
            if (collector._collected is string prevValue)
            {
                buff = new StringBuilder(prevValue);
                collector._collected = buff;
            }
            else
            {
                buff = (StringBuilder)collector._collected;
            }
            buff.Append(joinCharacter);
            buff.Append(newString);
            return true;
        }
    }

    struct StringArrayCollector(SpeakerDataStringReadOptions? options)
    {
        readonly SpeakerDataStringReadOptions? _options = options;

        // one of (null || string || string[] || List<string>)
        object? _collected;

        public IReadOnlyList<string>? Result => _collected switch
        {
            string singleValue => [singleValue],
            string[] array => array,
            List<string> list => list,
            _ => null
        };

        public static bool TryCollectString(JsonNode? node, ref StringArrayCollector collector)
        {
            if (TryReadSingleString(node, collector._options, out var newString))
            {
                collector.AddSingleValue(newString);
                return true;
            }

            if (node is JsonArray array && collector._collected is null)
                return collector.TryLoadStringArray(array);

            return false;
        }

        void AddSingleValue(string value)
        {
            switch (_collected)
            {
                case null:
                    _collected = value;
                    return;

                case string prevValue:
                    // we are optimistic that there won't be more items
                    _collected = new[] { prevValue, value };
                    return;

                case string[] prevArray:
                    // presumably there are 2 items in the array
                    // make some more space (8 items) to avoid soon re-allocations
                    var newList = new List<string>(prevArray.Length + 6);
                    newList.AddRange(prevArray);
                    newList.Add(value);
                    _collected = newList;
                    return;

                case List<string> prevList:
                    prevList.Add(value);
                    return;
            }
        }

        bool TryLoadStringArray(JsonArray jsonArray)
        {
            // this is optimisation for case that json array is all strings
            // we postpone allocation after we check out the first item
            string[]? items = null;
            for (var i = 0; i < jsonArray.Count; i++)
            {
                if (!TryReadSingleString(jsonArray[i], _options, out var nextString))
                    return false; // fallback to non-optimized processing instead

                items ??= new string[jsonArray.Count];
                items[i] = nextString;
            }

            // we are happy now
            _collected = items ?? []; // make sure we have at least empty array to clarify that property was found
            return true;
        }
    }

    static void CollectValues<TCollector>(JsonNode? node, ref TCollector collector, SpeakerDataStringReadOptions? options, TryCollectValue<TCollector> tryCollectValue)
    {
        if (tryCollectValue(node, ref collector))
            return;

        switch (node?.GetValueKind())
        {
            case JsonValueKind.Array:
                foreach (var jsonItem in node.AsArray())
                {
                    CollectValues(jsonItem, ref collector, options, tryCollectValue);
                }
                return;

            case JsonValueKind.Object when options?.ReadValuesFromObjects ?? SpeakerDataStringReadOptions.DefaultReadValuesFromObjects:
                foreach (var kv in node.AsObject())
                {
                    CollectValues(kv.Value, ref collector, options, tryCollectValue);
                }
                return;
        }
    }

    delegate bool TryCollectValue<TCollector>(JsonNode? node, ref TCollector collector);
}

public class SpeakerDataStringReadOptions
{
    public const bool DefaultReadNumberAsString = false;
    public const bool DefaultReadValuesFromObjects = false;
    public const string DefaultStringJoinCharacter = " ";

    /// <summary>If true, JSON numbers are read as strings as well, otherwise they are ignored</summary>
    public bool ReadNumberAsString { get; set; } = DefaultReadNumberAsString;

    /// <summary>If true, JSON objects are enumerated while reading and values are processed recursively; otherwise JSON objects are ignored</summary>
    public bool ReadValuesFromObjects { get; set; } = DefaultReadValuesFromObjects;

    /// <summary>Character used when multiple strings are joined into one; if null then only first value is used</summary>
    public string? StringJoinCharacter { get; set; } = DefaultStringJoinCharacter;
}
