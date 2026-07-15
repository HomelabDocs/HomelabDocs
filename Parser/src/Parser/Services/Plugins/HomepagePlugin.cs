using Parser.Interfaces;

namespace Parser.Services.Plugins;

public class HomepagePlugin : IIconProvider
{
    public int Priority => 0;

    public string? GetIcon(IReadOnlyDictionary<string, string> labels)
    {
        var reference = "homepage.icon";

        if (labels.TryGetValue(reference, out var iconName) == false)
            return null;

        var iconType = Path.GetExtension(iconName).Substring(1);
        return $"https://cdn.jsdelivr.net/gh/homarr-labs/dashboard-icons/{iconType}/{iconName}";
    }
}
