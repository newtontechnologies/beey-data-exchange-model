using System.Collections.Concurrent;
using System.Globalization;

namespace Beey.DataExchangeModel.Common.Tools;

public static class LanguageHelper
{
    // see https://stackoverflow.com/a/17863380
    public const int IetfTagMaxLength = 35;

    static readonly ConcurrentDictionary<string, CultureInfo?> s_languageCache = [];

    public static CultureInfo? TryParseLanguage(string? ietfTag, bool emptyIsInvariant)
        => TryParseLanguage(ietfTag, emptyIsInvariant, out var ci) ? ci : null;

    public static bool TryParseLanguage(string? ietfTag, out CultureInfo ci)
        => TryParseLanguage(ietfTag, false, out ci);

    public static bool TryParseLanguage(string? ietfTag, bool emptyIsInvariant, out CultureInfo ci)
    {
        var value = string.IsNullOrEmpty(ietfTag)
            ? (emptyIsInvariant ? CultureInfo.InvariantCulture : null)
            : s_languageCache.GetOrAdd(ietfTag, s =>
            {
                try
                {
                    return CultureInfo.GetCultureInfoByIetfLanguageTag(ietfTag);
                }
                catch
                {
                    // If parsing fails, we still want to cache the value, because exceptions are slow,
                    // and we don't want to throw the exception again next time with the same input
                    return null;
                }
            });

        ci = value!;
        return value is not null;
    }

    public static string? IetfTagOrNull(this CultureInfo? ci)
        => ci.IsInvariant() ? null : ci?.IetfLanguageTag;

    public static bool IsInvariant(this CultureInfo? ci)
        => ci is null || ci.TwoLetterISOLanguageName == "iv"; // TODO: or is there any better solution?
}
