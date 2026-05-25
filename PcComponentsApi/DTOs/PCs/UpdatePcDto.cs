using System.ComponentModel.DataAnnotations;

namespace PcComponentsApi.DTOs.PCs;

public class UpdatePcDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Range(0.1, 100.0)]
    public double Weight { get; set; }

    [Range(1, 120)]
    public int Warranty { get; set; }

    public DateTime CreatedAt { get; set; }

    [Range(0, 10000)]
    public int Stock { get; set; }
}