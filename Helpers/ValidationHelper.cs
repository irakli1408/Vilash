namespace Vilash.Core.Helpers;
public static class ValidationHelper
{
    public static bool NotEmpty(string? value) => !string.IsNullOrWhiteSpace(value);
}
