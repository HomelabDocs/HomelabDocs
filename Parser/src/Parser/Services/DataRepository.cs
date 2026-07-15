using Parser.Interfaces;

namespace Parser.Services;

public class DataRepository(IEnumerable<IPlugin> plugins)
{
    public string? GetIcon(IReadOnlyDictionary<string, string> labels)
    {
        foreach (var provider in plugins.OfType<IIconProvider>().OrderBy(plugin => plugin.Priority))
        {
            var iconUrl = provider.GetIcon(labels);
            if (string.IsNullOrWhiteSpace(iconUrl) == false)
                return iconUrl;
        }

        return null;
    }

    public string? GetRoute(IReadOnlyDictionary<string, string> labels)
    {
        foreach (var provider in plugins.OfType<IRouteProvider>().OrderBy(plugin => plugin.Priority))
        {
            var route = provider.GetRoute(labels);
            if (string.IsNullOrWhiteSpace(route) == false)
                return route;
        }

        return null;
    }
}
