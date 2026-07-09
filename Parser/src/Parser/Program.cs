using Parser.Entities;
using Parser.Extensions;
using Parser.Helpers;

var servicesDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../../Services"));

var composeFiles = Directory.EnumerateFiles(servicesDirectory, "*", SearchOption.AllDirectories)
    .Where(file => RegexHelper.IsComposeFile(Path.GetFileName(file)));

var result = new List<Device>();
foreach (var filePath in composeFiles)
{
    FileInfo file = new FileInfo(filePath);
    var serviceName = file?.Directory?.Name.ValueOrUnknown();
    var deviceName = file?.Directory?.Parent?.Name.ValueOrUnknown();

    var device = 
    result.FirstOrDefault(x => x.Name == deviceName) ?? 
    result.AddNewEntity<Device>(new Device
    {
        Name = deviceName
    });
}