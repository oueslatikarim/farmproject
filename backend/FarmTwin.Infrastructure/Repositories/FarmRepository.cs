using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FarmTwin.Application.Interfaces.Repositories;
using FarmTwin.Domain.Entities;
using FarmTwin.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmTwin.Infrastructure.Repositories;

public class FarmRepository : IFarmRepository
{
    private readonly ApplicationDbContext _context;

    public FarmRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Farm?> GetByIdAsync(Guid id)
    {
        return await _context.Farms
            .Include(f => f.Fields)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<Farm>> GetAllAsync()
    {
        return await _context.Farms.ToListAsync();
    }

    public async Task<Farm> AddAsync(Farm entity)
    {
        _context.Farms.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Farm entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Farms.FindAsync(id);
        if (entity != null)
        {
            _context.Farms.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Farm>> GetFarmsByOwnerIdAsync(string ownerId)
    {
        return await _context.Farms
            .Where(f => f.OwnerId == ownerId)
            .ToListAsync();
    }
}
