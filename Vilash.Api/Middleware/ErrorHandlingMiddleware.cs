using System.Net;
using System.Text.Json;
using Vilash.Core.Localization;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");

            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var lang = context.Items["Language"]?.ToString() ?? Languages.Default;

        var response = new
        {
            Success = false,
            Error = new
            {
                Message = GetLocalizedMessage(lang, ex),
                Code = "INTERNAL_ERROR"
            }
        };

        var payload = JsonSerializer.Serialize(response);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        return context.Response.WriteAsync(payload);
    }

    // Здесь можно подключить ресурсные файлы или базу для переводов
    private static string GetLocalizedMessage(string lang, Exception ex)
    {
        return lang switch
        {
            "ka" => "შიდა სერვერის შეცდომა",
            "uk" => "Внутрішня помилка сервера",
            "ru" => "Внутренняя ошибка сервера",
            _ => "Internal server error"
        };
    }
}
