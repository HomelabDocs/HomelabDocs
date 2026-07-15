using Microsoft.Extensions.DependencyInjection;
using Parser.Interfaces;
using Parser.Services;
using Parser.Services.Plugins;

namespace Parser.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPlugins(this IServiceCollection services)
    {
        services.AddSingleton<IPlugin, DefaultProvider>();
        services.AddSingleton<IPlugin, HomepagePlugin>();
        services.AddSingleton<IPlugin, TraefikPlugin>();
        services.AddSingleton<DataRepository>();

        return services;
    }
}
