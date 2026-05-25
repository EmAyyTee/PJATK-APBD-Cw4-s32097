namespace PcComponentsApi.DTOs.PCs;

public class ComponentManufacturerResponseDto
{
    public int Id { get; set; }

    public string Abbreviation { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateOnly FoundationDate { get; set; }
}