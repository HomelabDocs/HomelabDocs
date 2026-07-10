using YamlDotNet.Serialization;

namespace Parser.Models;

public class DockerCompose
{
    [YamlMember(Alias = "services")]
    public Dictionary<string, DockerContainer> Containers { get; set; } = [];
}