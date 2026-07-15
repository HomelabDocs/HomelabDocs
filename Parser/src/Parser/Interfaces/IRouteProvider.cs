namespace Parser.Interfaces;

public interface IRouteProvider : IPlugin
{
    string? GetRoute(IReadOnlyDictionary<string, string> labels);
}
