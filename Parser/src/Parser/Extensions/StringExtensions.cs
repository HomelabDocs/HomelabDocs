namespace Parser.Extensions;

public static class StringExtensions
{
    public static string ValueOrUnknown(this string input) => 
        string.IsNullOrWhiteSpace(input)
        ? "Unknown"
        : input;
}