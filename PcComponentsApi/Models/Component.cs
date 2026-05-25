namespace PcComponentsApi.Models;

public class Component
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int ManufacturerId { get; set; }

    public int TypeId { get; set; }

    public ComponentManufacturer Manufacturer { get; set; } = null!;

    public ComponentType Type { get; set; } = null!;

    public ICollection<PcComponent> PcComponents { get; set; } = new List<PcComponent>();
}