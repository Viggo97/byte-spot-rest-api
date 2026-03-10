using ByteSpot.Domain.Enums;

namespace ByteSpot.Api.Utils;

public static class LanguageCodeConverter
{
    public static LanguageCode Get(HttpContext httpContext)
    {
        var acceptLanguageHeader = httpContext.Request.Headers.AcceptLanguage;
        var languageParsed = Enum.TryParse(acceptLanguageHeader, ignoreCase: true, out LanguageCode languageCode);

        return languageParsed ? languageCode : LanguageCode.En;
    }
}