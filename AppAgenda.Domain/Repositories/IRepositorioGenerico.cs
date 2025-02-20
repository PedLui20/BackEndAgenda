﻿namespace AppAgenda.Domain.Repositories;

public interface IRepositorioGenerico<TEntity> where TEntity: class
{
    public Task<TEntity> CreateAsync(TEntity entity);
    public Task<TEntity?> GetByIdAsync(int id); 
    public Task<bool>DeleteHardAsync(int id); 
    // public Task<bool>ExistsByIdAsync(int id); 
}