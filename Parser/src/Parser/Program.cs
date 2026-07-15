using Microsoft.Extensions.DependencyInjection;
using Parser.Extensions;
using Parser.Services;

var services = new ServiceCollection()
    .AddPlugins();

services.AddSingleton<Mapper>();
var serviceProvider = services.BuildServiceProvider();

serviceProvider.GetRequiredService<Mapper>().Run();
