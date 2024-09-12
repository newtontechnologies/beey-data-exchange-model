using System.Collections.Concurrent;
using System.Globalization;

namespace Beey.DataExchangeModel.Common.Tools;

public static class LanguageHelper
{
    static readonly ConcurrentDictionary<string, CultureInfo?> s_languageCache = [];

    public static bool TryParseLanguage(string ietfTag, out CultureInfo ci)
    {
        var value = s_languageCache.GetOrAdd(ietfTag, s =>
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
}
