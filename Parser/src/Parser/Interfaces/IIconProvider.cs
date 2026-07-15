namespace Parser.Interfaces;

public interface IIconProvider : IPlugin
{
    string? GetIcon(IReadOnlyDictionary<string, string> labels);
}
