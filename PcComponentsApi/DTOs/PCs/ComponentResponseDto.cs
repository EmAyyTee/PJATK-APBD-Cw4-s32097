namespace PcComponentsApi.DTOs.PCs;

public class ComponentResponseDto
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public ComponentManufacturerResponseDto Manufacturer { get; set; } = null!;

    public ComponentTypeResponseDto Type { get; set; } = null!;
}