using Parser.Interfaces;

namespace Parser.Services.Plugins;

public class HomepagePlugin : IIconProvider
{
    public int Priority => 0;

    public string? GetIcon(IReadOnlyDictionary<string, string> labels)
    {
        var reference = "homepage.icon";

        if (labels.TryGetValue(reference, out var value) == false)
            return null;

        if (Uri.TryCreate(value, UriKind.Absolute, out var uri) && 
            (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            return value;
        
        var iconType = Path.GetExtension(value).Substring(1);
        return $"https://cdn.jsdelivr.net/gh/homarr-labs/dashboard-icons/{iconType}/{value}";
    }
}
