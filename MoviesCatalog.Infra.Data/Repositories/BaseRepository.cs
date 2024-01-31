using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Domain.Entities;
using MoviesCatalog.Domain.Interfaces;
using MoviesCatalog.Infra.Data.Context;

namespace MoviesCatalog.Infra.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAsync()
    {
        return await _context
            .Set<T>()
            .ToArrayAsync();
    }

    public virtual async Task<T> GetAsync(int? id)
    {
        return await _context
            .Set<T>()
            .FindAsync(id);
    }

    public async Task<T> CreateAsync(T entity)
    {
        _context
            .Set<T>()
            .Add(entity);

        await _context
            .SaveChangesAsync();

        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context
            .Set<T>()
            .Update(entity);
        
        await _context
            .SaveChangesAsync();

        return entity;
    }

    public async Task<T> RemoveAsync(T entity)
    {
        _context
            .Set<T>()
            .Remove(entity);
        
        await _context
            .SaveChangesAsync();

        return entity;
    }
}