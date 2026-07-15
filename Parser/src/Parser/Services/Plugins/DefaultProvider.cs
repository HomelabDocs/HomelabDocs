using Parser.Interfaces;

namespace Parser.Services.Plugins;

public class DefaultProvider : IIconProvider, IRouteProvider
{
    public int Priority => 999;

    public string? GetIcon(IReadOnlyDictionary<string, string> labels) => null;

    public string? GetRoute(IReadOnlyDictionary<string, string> labels) => null;
}
