using AppAgenda.Domain.Repositories;
using AppAgenda.Infraestructure.Context;
using AppAgenda.Infraestructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppAgenda.Infraestructure.Database.Repositories;

public class RepositorioGenerico<TEntity>: IRepositorioGenerico<TEntity> where TEntity: class
{
    private readonly AgendaDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    protected RepositorioGenerico( AgendaDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }
    public async Task<TEntity> CreateAsync(TEntity entity) 
    {
        var entityEntry = await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entityEntry = _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    
    public async Task<bool> DeleteHardAsync(int id) 
    {
        var del = await _dbSet.FindAsync(id);
        if (del is null) return false; 
        _dbSet.Remove(del);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    // public async Task<bool> ExistsByIdAsync(int id)
    // {
    //     return await _dbSet.AnyAsync(e => e.Id == id);
    // }
}