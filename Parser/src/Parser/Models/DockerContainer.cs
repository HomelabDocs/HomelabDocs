using YamlDotNet.Serialization;

namespace Parser.Models;

public class DockerContainer
{
    [YamlMember(Alias = "ports")]
    public List<string>? Ports { get; set; }
    
    [YamlMember(Alias = "labels")]
    public Dictionary<string, string>? Labels { get; set; }
}