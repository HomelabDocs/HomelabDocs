using System.Text.RegularExpressions;
using Parser.Interfaces;

namespace Parser.Services.Plugins;

public class TraefikPlugin : IRouteProvider
{
    public int Priority => 0;

    public string? GetRoute(IReadOnlyDictionary<string, string> labels)
    {
        var regex = new Regex(@"^traefik\.http\.routers\.[^.]+\.rule$");

        var route = labels
            .Where(label => regex.IsMatch(label.Key))
            .Select(label => label.Value)
            .FirstOrDefault();
        
        if (string.IsNullOrWhiteSpace(route))
            return null;
        
        var domainMatch = Regex.Match(route, @"`([^`]+)`");
        
        if (!domainMatch.Success)
            return null;
        
        return domainMatch.Groups[1].Value;
    }
}
