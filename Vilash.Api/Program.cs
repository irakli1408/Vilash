using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Vilash.Api.OpenApi;
using Vilash.Core.Localization;

var builder = WebApplication.CreateBuilder(args);

// 1. Инициализация языков из конфигурации
Languages.Initialize(builder.Configuration);

Console.WriteLine("Supported: " + string.Join(", ", Languages.Supported));
Console.WriteLine("Default: " + Languages.Default);


// 2. Версионирование API
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// 3. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<SwaggerConfiguration>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestLanguageMiddleware>();

// Swagger UI с версиями
if (app.Environment.IsDevelopment())
{
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                $"Vilash API {description.GroupName}");
        }

        // Открывать Swagger на корневом URL
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.Run();
