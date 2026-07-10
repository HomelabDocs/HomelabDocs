using Parser.Models;
using YamlDotNet.Serialization;

namespace Parser.Helpers;

public static class YamlHelper
{
    private static readonly IDeserializer Deserializer =
        new DeserializerBuilder()
            .IgnoreUnmatchedProperties()
            .Build();

    public static T Read<T>(FileInfo file)
    {
        using var reader = file.OpenText();

        return Deserializer.Deserialize<T>(reader);
    }
}