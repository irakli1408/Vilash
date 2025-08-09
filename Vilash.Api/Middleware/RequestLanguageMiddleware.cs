using System.Globalization;
using Vilash.Core.Localization;

public class RequestLanguageMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLanguageMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string? lang = context.Request.Query["lang"].FirstOrDefault();

        if (string.IsNullOrWhiteSpace(lang))
        {
            var acceptLang = context.Request.Headers["Accept-Language"].FirstOrDefault();
            lang = acceptLang?.Split(',').FirstOrDefault();
        }

        lang = Languages.Normalize(lang);
        if (!Languages.IsSupported(lang))
        {
            lang = Languages.Default;
        }

        // Сохраняем в HttpContext
        context.Items["Language"] = lang;

        // Меняем культуру для текущего запроса
        var culture = new CultureInfo(lang);
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;

        await _next(context);
    }
}
