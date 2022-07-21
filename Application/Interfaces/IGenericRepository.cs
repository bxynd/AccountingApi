namespace Application.Interfaces;

public interface IGenericRepository<T> where T : class
{
    public Task<int> Create(T entity);
    public Task<List<T>> ReadAll();
    public Task<T> ReadById(Guid Id);
    public Task<int> Update(T entity);
    public Task<int> Delete(Guid Id);
}