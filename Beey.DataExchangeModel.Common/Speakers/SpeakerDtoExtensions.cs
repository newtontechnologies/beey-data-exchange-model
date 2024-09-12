using System.Globalization;
using System.Text.Json.Nodes;
using Beey.DataExchangeModel.Common.Speakers.v1;
using Beey.DataExchangeModel.Common.Tools;

namespace Beey.DataExchangeModel.Common.Speakers;
public static class SpeakerDtoExtensions
{
    public static string? Get(this SpeakerDto dto, SpeakerStringField field)
        => dto.Data.Json.TryGetPropertyValue(field.FieldName, out var propertyNode)
           && propertyNode is JsonValue propertyValue
           && propertyValue.TryGetValue<string>(out var value)
            ? value
            : null;

    public static void Set(this SpeakerDto dto, SpeakerStringField field, string? newValue)
    {
        if (newValue == null)
            dto.Data.Json.Remove(field.FieldName);
        else
            dto.Data.Json[field.FieldName] = JsonValue.Create(newValue);
    }

    public static string? Get(this SpeakerDto dto, SpeakerLocalizedStringField field, CultureInfo? ci)
    {
        if (!dto.Data.Json.TryGetPropertyValue(field.FieldName, out var propertyNode))
            return null; // not found at all

        if (TryReadAsText(propertyNode, out var result))
            return result;

        if (propertyNode is not JsonObject localizations)
            return null; // unexpected type

        string? candidate = null;

        // 1 = at least something
        // 2 = neutral match
        // 3 = weak match (only by language, not by country/culture)
        var candidateQuality = 0;

        foreach (var kv in localizations)
        {
            if (kv.Key == "*")
            {
                if (ci is null && TryReadAsText(kv.Value, out result))
                {
                    // this is an exact match if we look for neutral version
                    return result;
                }

                if (candidateQuality < 2 && TryReadAsText(kv.Value, out result))
                {
                    // neutral version is the best candidate so far
                    candidate = result;
                    candidateQuality = 2;
                    continue;
                }
            }

            if (ci is not null && LanguageHelper.TryParseLanguage(kv.Key, out var locLang))
            {
                if (locLang.LCID == ci.LCID && TryReadAsText(kv.Value, out result))
                {
                    // exact match
                    return result;
                }

                if (candidateQuality < 3 && ci.TwoLetterISOLanguageName == locLang.TwoLetterISOLanguageName &&
                    TryReadAsText(kv.Value, out result))
                {
                    // weak match
                    candidateQuality = 3;
                    candidate = result;
                    continue;
                }
            }

            if (candidateQuality < 1 && TryReadAsText(kv.Value, out result))
            {
                candidate = result;
                candidateQuality = 1;
            }
        }

        // this is the best we have
        return candidate;
    }

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
        // TODO: Update only the specific language version

        if (newValue == null)
            dto.Data.Json.Remove(field.FieldName);
        else
            dto.Data.Json[field.FieldName] = JsonValue.Create(newValue);
    }
}
