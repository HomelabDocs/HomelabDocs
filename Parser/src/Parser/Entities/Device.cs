namespace Parser.Entities;

public class Device
{
    public required string Name { get; set; }
    public List<Service> Services { get; set; } = new();
}