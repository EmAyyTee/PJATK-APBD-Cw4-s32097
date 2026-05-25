using System.ComponentModel.DataAnnotations;

namespace PcComponentsApi.DTOs.PCs;

public class UpdatePcDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Range(0.01, double.MaxValue)]
    public double Weight { get; set; }

    [Range(1, int.MaxValue)]
    public int Warranty { get; set; }

    public DateTime CreatedAt { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}