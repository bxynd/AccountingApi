using Application.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<T>: IGenericRepository<T> where T : class
{ 
    private readonly IDataContext _dataContext;
    private readonly DbSet<T> dbSet;

    public GenericRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
        dbSet = _dataContext.Set<T>();
    }
    public async Task<int> Create(T entity)
    {
        await dbSet.AddAsync(entity);
        return await _dataContext.ContextSaveChanges();
    }

    public async Task<List<T>> ReadAll()
    {
        return await dbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task<T> ReadById(Guid Id)
    {
        return await dbSet.FindAsync(Id);
    }

    public async Task<int> Update(T entity)
    {
        dbSet.Update(entity);
        return await _dataContext.ContextSaveChanges();
    }

    public async Task<int> Delete(Guid Id)
    {
        var foundEntity = await dbSet.FindAsync(Id); 
        dbSet.Remove(foundEntity);
        return await _dataContext.ContextSaveChanges();
    }
}