using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FarmTwin.Application.Interfaces.Repositories;
using FarmTwin.Domain.Entities;
using FarmTwin.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmTwin.Infrastructure.Repositories;

public class FieldRepository : IFieldRepository
{
    private readonly ApplicationDbContext _context;

    public FieldRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Field?> GetByIdAsync(Guid id)
    {
        return await _context.Fields.FindAsync(id);
    }

    public async Task<IEnumerable<Field>> GetAllAsync()
    {
        return await _context.Fields.ToListAsync();
    }

    public async Task<Field> AddAsync(Field entity)
    {
        _context.Fields.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Field entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Fields.FindAsync(id);
        if (entity != null)
        {
            _context.Fields.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
