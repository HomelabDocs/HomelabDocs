using System.Text.Json;
using Parser.Entities;
using Parser.Extensions;
using Parser.Helpers;
using Parser.Models;

namespace Parser.Services;

public class Mapper(DataRepository dataRepository)
{
    public void Run()
    {
        var baseDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../../"));
        var servicesDirectory = Path.Combine(baseDirectory, "Services");

        var composeFiles = Directory.EnumerateFiles(servicesDirectory, "*", SearchOption.AllDirectories)
            .Where(file => RegexHelper.IsComposeFile(Path.GetFileName(file)));

        var result = new List<Device>();
        foreach (var filePath in composeFiles)
        {
            FileInfo file = new FileInfo(filePath);

            // Discover Device
            var deviceName = StringHelper.ValueOrUnknown(file.Directory?.Parent?.Name);
            var device =
                result.FirstOrDefault(x => x.Name == deviceName)
                ?? result.AddNewEntity(new Device { Name = deviceName });

            // Discover Service
            var serviceName = StringHelper.ValueOrUnknown(file.Directory?.Name);
            var service =
                device.Services.FirstOrDefault(x => x.Name == deviceName)
                ?? device.Services.AddNewEntity(new Service { Name = serviceName });

            // Read Compose
            var composeFile = YamlHelper.Read<DockerCompose>(file);
            foreach (var container in composeFile.Containers)
            {
                var containerViewModel = service.Containers.AddNewEntity(new Container { Name = container.Key });

                // Search service icon
                service.IconUrl = dataRepository.GetIcon(container.Value.Labels);

                // Read Ports
                foreach (var port in container.Value.Ports)
                    containerViewModel.Ports.Add(port);

                // Read routes
                containerViewModel.Route = dataRepository.GetRoute(container.Value.Labels);
            }
        }

        var json = JsonSerializer.Serialize(result, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(Path.Combine(baseDirectory, "mapping.json"), json);
    }
}
