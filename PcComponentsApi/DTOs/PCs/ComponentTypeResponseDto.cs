namespace PcComponentsApi.DTOs.PCs;

public class ComponentTypeResponseDto
{
    public int Id { get; set; }

    public string Abbreviation { get; set; } = null!;

    public string Name { get; set; } = null!;
}