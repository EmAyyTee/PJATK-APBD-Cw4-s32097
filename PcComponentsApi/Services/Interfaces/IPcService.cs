using PcComponentsApi.DTOs.PCs;

namespace PcComponentsApi.Services.Interfaces;

public interface IPcService
{
    Task<List<PcResponseDto>> GetAllAsync();

    Task<PcDetailsResponseDto?> GetByIdWithComponentsAsync(int id);

    Task<PcResponseDto> CreateAsync(CreatePcDto dto);

    Task<PcResponseDto?> UpdateAsync(int id, UpdatePcDto dto);

    Task<bool> DeleteAsync(int id);
}