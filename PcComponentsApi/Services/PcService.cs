using Microsoft.EntityFrameworkCore;
using PcComponentsApi.Data;
using PcComponentsApi.DTOs.PCs;
using PcComponentsApi.Models;
using PcComponentsApi.Services.Interfaces;

namespace PcComponentsApi.Services;

public class PcService : IPcService
{
    private readonly AppDbContext _context;

    public PcService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PcResponseDto>> GetAllAsync()
    {
        return await _context.Pcs
            .Select(pc => new PcResponseDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock
            })
            .ToListAsync();
    }

    public async Task<PcDetailsResponseDto?> GetByIdWithComponentsAsync(int id)
    {
        return await _context.Pcs
            .Where(pc => pc.Id == id)
            .Select(pc => new PcDetailsResponseDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock,
                Components = pc.PcComponents
                    .Select(pcComponent => new PcComponentResponseDto
                    {
                        Amount = pcComponent.Amount,
                        Component = new ComponentResponseDto
                        {
                            Code = pcComponent.Component.Code,
                            Name = pcComponent.Component.Name,
                            Description = pcComponent.Component.Description,
                            Manufacturer = new ComponentManufacturerResponseDto
                            {
                                Id = pcComponent.Component.Manufacturer.Id,
                                Abbreviation = pcComponent.Component.Manufacturer.Abbreviation,
                                FullName = pcComponent.Component.Manufacturer.FullName,
                                FoundationDate = pcComponent.Component.Manufacturer.FoundationDate
                            },
                            Type = new ComponentTypeResponseDto
                            {
                                Id = pcComponent.Component.Type.Id,
                                Abbreviation = pcComponent.Component.Type.Abbreviation,
                                Name = pcComponent.Component.Type.Name
                            }
                        }
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();
    }

    public async Task<PcResponseDto> CreateAsync(CreatePcDto dto)
    {
        var pc = new Pc
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        _context.Pcs.Add(pc);
        await _context.SaveChangesAsync();

        return MapToResponseDto(pc);
    }

    public async Task<PcResponseDto?> UpdateAsync(int id, UpdatePcDto dto)
    {
        var pc = await _context.Pcs.FindAsync(id);

        if (pc is null)
        {
            return null;
        }

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _context.SaveChangesAsync();

        return MapToResponseDto(pc);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pc = await _context.Pcs.FindAsync(id);

        if (pc is null)
        {
            return false;
        }

        _context.Pcs.Remove(pc);
        await _context.SaveChangesAsync();

        return true;
    }

    private static PcResponseDto MapToResponseDto(Pc pc)
    {
        return new PcResponseDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }
}