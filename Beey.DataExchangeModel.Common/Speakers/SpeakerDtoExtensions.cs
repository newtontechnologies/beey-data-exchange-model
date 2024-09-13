using System.Globalization;
using System.Text.Json.Nodes;
using Beey.DataExchangeModel.Common.Speakers.v1;
using Beey.DataExchangeModel.Common.Tools;

namespace Beey.DataExchangeModel.Common.Speakers;
public static class SpeakerDtoExtensions
{
    public static string? Get(this SpeakerDto dto, SpeakerStringField field)
        => dto.Data.Neutral.TryGetPropertyValue(field.FieldName, out var propertyNode)
           && propertyNode is JsonValue propertyValue
           && propertyValue.TryGetValue<string>(out var value)
            ? value
            : null;

    public static void Set(this SpeakerDto dto, SpeakerStringField field, string? newValue)
    {
        if (newValue == null)
            dto.Data.Neutral.Remove(field.FieldName);
        else
            dto.Data.Neutral[field.FieldName] = JsonValue.Create(newValue);
    }

    public static string? Get(this SpeakerDto dto, SpeakerLocalizedStringField field, CultureInfo? ci)
    {
        return dto.TryReadNode(field, ci, TryReadString, out string result)
            ? result
            : null;

        bool TryReadString(JsonNode node, out string value)
        {
            if (node is JsonValue textNode &&
                textNode.TryGetValue<string>(out var text))
            {
                value = text;
                return true;
            }

            value = null!;
            return false;
        }
    }

    /// <summary>Return best possible value according to requirements</summary>
    /// <returns>True if found any value at all, even if it is in different language</returns>
    public static bool TryReadNode<TValue>(this SpeakerDto dto,
        SpeakerLocalizedStringField field, CultureInfo? ci, TryGetNodeValue<TValue> reader, out TValue value)
    {
        var bestMatchLevel = -1;
        value = default!;

        if (ci is null && TryReadNode(dto.Data.Neutral, field, reader, ref value))
            return true; // requested and found neutral -> we are happy

        foreach (var kv in dto.Data.Localizations)
        {
            var matchLevel = GetMatchLevel(ci, kv.Key);

            if (matchLevel <= bestMatchLevel)
                continue; // no reason to evaluate this item

            if (!TryReadNode(kv.Value, field, reader, ref value))
                continue; // cannot read from this localization

            if (matchLevel == 3)
                return true; // exact match, cannot be better

            bestMatchLevel = matchLevel;
        }

        if (ci is not null && bestMatchLevel <= 0)
        {
            // try also neutral if only different language found (or none)
            TValue neutralValue = default!;
            if (TryReadNode(dto.Data.Neutral, field, reader, ref neutralValue))
            {
                value = neutralValue;
                return true;
            }
        }

        return bestMatchLevel >= 0;
    }

    // 0 = no match
    // 1 = weak match
    // 2 = exact match
    static int GetMatchLevel(CultureInfo? requested, string itemLang)
    {
        if (requested is null)
            return 3; // we don't have specific language request -> we take literally any value

        if (!LanguageHelper.TryParseLanguage(itemLang, out var itemCi))
            return 0; // cannot parse language -> no match at all

        if (requested.IetfLanguageTag == itemCi.IetfLanguageTag)
            return 2; // exact match

        return WeakMatch(requested, itemCi) ? 1 : 0;
    }

    static bool TryReadNode<TValue>(JsonObject data, SpeakerLocalizedStringField field, TryGetNodeValue<TValue> reader, ref TValue value)
    {
        return data.TryGetPropertyValue(field.FieldName, out var fieldNode) &&
               fieldNode is not null &&
               reader(fieldNode, out value);
    }

    public delegate bool TryGetNodeValue<TValue>(JsonNode node, out TValue value);

    static bool WeakMatch(CultureInfo a, CultureInfo b) => a.TwoLetterISOLanguageName == b.TwoLetterISOLanguageName;

    static bool TryReadAsText(JsonNode? itemNode, out string result)
    {
        if (itemNode is JsonValue textNode &&
            textNode.TryGetValue<string>(out var text))
        {
            result = text;
            return true;
        }

        result = null!;
        return false;
    }

    public static void Set(this SpeakerDto dto, SpeakerLocalizedStringField field, string? newValue, CultureInfo? ci)
    {
        if (newValue is null)
        {
            // deletes the value in all languages, because language-specific null values are not allowed
            // (fallback to other language is always applied in such case)

            dto.Data.Neutral.Remove(field.FieldName);
            foreach (var localized in dto.Data.Localizations.Values)
            {
                localized.Remove(field.FieldName);
            }
            return;
        }

        var json = GetJsonToUpdate();
        json[field.FieldName] = newValue;
        return;

        JsonObject GetJsonToUpdate()
        {
            if (ci is null)
                return dto.Data.Neutral;

            var bestMatchLevel = -1;
            JsonObject? bestCandidate = null;
            foreach (var kv in dto.Data.Localizations)
            {
                var matchLevel = GetMatchLevel(ci, kv.Key);
                if (matchLevel == 3)
                    return kv.Value; // exact match, cannot be better

                if (matchLevel <= bestMatchLevel)
                    continue;

                bestMatchLevel = matchLevel;
                bestCandidate = kv.Value;
            }

            if (bestMatchLevel >= 1)
                return bestCandidate!;

            bestCandidate = new JsonObject(); // new localization
            dto.Data.Localizations[ci.IetfLanguageTag] = bestCandidate;
            return bestCandidate;
        }
    }
}
