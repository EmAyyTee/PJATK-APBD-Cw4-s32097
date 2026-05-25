namespace PcComponentsApi.DTOs.PCs;

public class PcComponentResponseDto
{
    public int Amount { get; set; }

    public ComponentResponseDto Component { get; set; } = null!;
}