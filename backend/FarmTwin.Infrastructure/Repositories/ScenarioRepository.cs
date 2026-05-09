using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FarmTwin.Application.Interfaces.Repositories;
using FarmTwin.Domain.Entities;
using FarmTwin.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmTwin.Infrastructure.Repositories;

public class ScenarioRepository : IScenarioRepository
{
    private readonly ApplicationDbContext _context;

    public ScenarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Scenario?> GetByIdAsync(Guid id)
    {
        return await _context.Scenarios.FindAsync(id);
    }

    public async Task<IEnumerable<Scenario>> GetAllAsync()
    {
        return await _context.Scenarios.ToListAsync();
    }

    public async Task<Scenario> AddAsync(Scenario entity)
    {
        _context.Scenarios.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Scenario entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Scenarios.FindAsync(id);
        if (entity != null)
        {
            _context.Scenarios.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
