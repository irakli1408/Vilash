using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace Vilash.Core.Localization
{
    public static class Languages
    {
        private static string[] _supported = Array.Empty<string>();
        private static string _default = "en"; 

        public static void Initialize(IConfiguration configuration)
        {
            var section = configuration.GetSection("Localization");

            _supported = section.GetSection("Supported").Get<string[]>() ?? new[] { "en" };
            _default = section.GetValue<string>("Default") ?? "en";
        }

        public static string[] Supported => _supported;

        public static string Default => _default;

        public static string Normalize(string? lang)
            => string.IsNullOrWhiteSpace(lang) ? Default : lang.Trim().ToLowerInvariant();

        public static bool IsSupported(string? lang)
            => Supported.Contains(Normalize(lang));

        public static CultureInfo[] GetCultures()
            => Supported.Select(c => new CultureInfo(c)).ToArray();
    }
}

