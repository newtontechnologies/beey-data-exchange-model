﻿using System.Globalization;
using System.Text.Json.Nodes;
using Beey.DataExchangeModel.Common.Speakers.v1;
using Beey.DataExchangeModel.Common.Tools;

namespace Beey.DataExchangeModel.Common.Speakers;
public static class SpeakerDtoExtensions
{
    public static string? Get(this SpeakerDto dto, SpeakerStringField field)
        => dto.Data.Neutral.TryGetPropertyValue(field.FieldName, out var propertyNode) && propertyNode is not null
            ? SpeakerJsonReader.GetString(propertyNode, field.StringReadOptions)
            : null;

    public static SpeakerDto Set(this SpeakerDto dto, SpeakerStringField field, string? newValue)
    {
        if (newValue == null)
            dto.Data.Neutral.Remove(field.FieldName);
        else
            dto.Data.Neutral[field.FieldName] = JsonValue.Create(newValue);

        return dto;
    }

    public static IReadOnlyList<string>? GetArray(this SpeakerDto dto, SpeakerStringField field)
        => dto.Data.Neutral.TryGetPropertyValue(field.FieldName, out var propertyNode) && propertyNode is not null
            ? SpeakerJsonReader.GetStringArray(propertyNode, field.StringReadOptions)
            : null;

    public static SpeakerDto SetArray(this SpeakerDto dto, SpeakerStringField field, IReadOnlyList<string>? newValue)
    {
        if (newValue == null)
            dto.Data.Neutral.Remove(field.FieldName);
        else
        {
            var array = new JsonArray();
            foreach (var v in newValue)
                array.Add(v);
            dto.Data.Neutral[field.FieldName] = array;
        }

        return dto;
    }
    public static string? Get(this SpeakerDto dto, SpeakerLocalizedStringField field, CultureInfo? ci)
    {
        return dto.TryReadNode(field, ci, TryReadString, out string result)
            ? result
            : null;

        bool TryReadString(JsonNode node, out string value)
        {
            var v = SpeakerJsonReader.GetString(node, field.StringReadOptions);
            value = v!;
            return v is not null;
        }
    }

    public static IReadOnlyList<string>? GetArray(this SpeakerDto dto, SpeakerLocalizedStringField field, CultureInfo? ci)
    {
        return dto.TryReadNode<IReadOnlyList<string>>(field, ci, TryReadStringArray, out var result)
            ? result
            : null;

        bool TryReadStringArray(JsonNode node, out IReadOnlyList<string> value)
        {
            var arrayData = SpeakerJsonReader.GetStringArray(node, field.StringReadOptions);
            value = arrayData!;
            return arrayData is not null;
        }
    }

    /// <summary>Return best possible value according to requirements</summary>
    /// <returns>True if found any value at all, even if it is in different language</returns>
    public static bool TryReadNode<TValue>(this SpeakerDto dto,
        SpeakerLocalizedStringField field, CultureInfo? ci, TryGetNodeValue<TValue> reader, out TValue value)
    {
        var isNeutralRequest = ci.IsInvariant();

        var bestMatchLevel = -1;
        value = default!;

        if (isNeutralRequest && TryReadNode(dto.Data.Neutral, field.FieldName, reader, ref value))
            return true; // requested and found neutral -> we are happy

        foreach (var kv in dto.Data.Localizations)
        {
            var matchLevel = GetMatchLevel(ci, kv.Key);

            if (matchLevel <= bestMatchLevel)
                continue; // no reason to evaluate this item

            if (!TryReadNode(kv.Value, field.FieldName, reader, ref value))
                continue; // cannot read from this localization

            if (matchLevel == 3)
                return true; // exact match, cannot be better

            bestMatchLevel = matchLevel;
        }

        if (!isNeutralRequest && bestMatchLevel <= 0)
        {
            // try also neutral if only different language found (or none)
            TValue neutralValue = default!;
            if (TryReadNode(dto.Data.Neutral, field.FieldName, reader, ref neutralValue))
            {
                value = neutralValue;
                return true;
            }
        }

        return bestMatchLevel >= 0;
    }

    public static void RemoveLocalization(this SpeakerDto dto, CultureInfo ci)
    {
        var matchingKeys = dto.Data.Localizations.Keys.Where(k => GetMatchLevel(ci, k) > 0).ToList();

        foreach (var key in matchingKeys)
            dto.Data.Localizations.Remove(key);
    }

    // 0 = no match
    // 1 = weak match
    // 2 = exact match
    static int GetMatchLevel(CultureInfo? requested, string itemLang)
    {
        if (requested is null || requested.IsInvariant())
            return 3; // we don't have specific language request -> we take literally any value

        if (!LanguageHelper.TryParseLanguage(itemLang, out var itemCi))
            return 0; // cannot parse language -> no match at all

        if (requested.IetfLanguageTag == itemCi.IetfLanguageTag)
            return 2; // exact match

        return WeakMatch(requested, itemCi) ? 1 : 0;
    }

    static bool TryReadNode<TValue>(JsonObject data, string fieldName, TryGetNodeValue<TValue> reader, ref TValue value)
    {
        return data.TryGetPropertyValue(fieldName, out var fieldNode) &&
               fieldNode is not null &&
               reader(fieldNode, out value);
    }

    public delegate bool TryGetNodeValue<TValue>(JsonNode node, out TValue value);

    static bool WeakMatch(CultureInfo a, CultureInfo b) => a.TwoLetterISOLanguageName == b.TwoLetterISOLanguageName;

    public static SpeakerDto Set(this SpeakerDto dto, SpeakerLocalizedStringField field, string? newValue, CultureInfo? ci)
        => Set(dto, field.FieldName, newValue, CreateJsonNode, ci);

    public static SpeakerDto SetArray(this SpeakerDto dto, SpeakerLocalizedStringField field, IReadOnlyList<string>? newValue, CultureInfo? ci)
        => Set(dto, field.FieldName, newValue, CreateJsonNode, ci);

    static JsonNode CreateJsonNode(string value)
        => JsonValue.Create(value);

    static JsonNode CreateJsonNode(IReadOnlyList<string> value)
    {
        if (value.Count == 1)
            return CreateJsonNode(value[0]);

        var arrayNode = new JsonArray();
        foreach (var item in value)
            arrayNode.Add(CreateJsonNode(item));

        return arrayNode;
    }

    static SpeakerDto Set<TValue>(this SpeakerDto dto, string fieldName, TValue? newValue,
        Func<TValue, JsonNode> createNode, CultureInfo? ci)
    {
        if (newValue is null)
        {
            // deletes the value in all languages, because language-specific null values are not allowed
            // (fallback to other language is always applied in such case)

            dto.Data.Neutral.Remove(fieldName);
            List<string>? languagesToRemove = null;
            foreach (var kv in dto.Data.Localizations)
            {
                kv.Value.Remove(fieldName);
                if (kv.Value.Count > 0)
                    continue;

                // localization is empty -> clean up
                languagesToRemove ??= [];
                languagesToRemove.Add(kv.Key);
            }

            if (languagesToRemove is not null)
                foreach (var lang in languagesToRemove)
                    dto.Data.Localizations.Remove(lang);

            return dto;
        }

        var json = GetJsonToUpdate();
        json[fieldName] = createNode(newValue);
        return dto;

        JsonObject GetJsonToUpdate()
        {
            if (ci.IsInvariant())
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
