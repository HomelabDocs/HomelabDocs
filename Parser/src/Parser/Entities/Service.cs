using Parser.Models;

namespace Parser.Entities;

public class Service
{
    public required string Name { get; set; }
    public List<Container> Containers { get; set; } = new();
}