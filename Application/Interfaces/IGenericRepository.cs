namespace Application.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<int> Create(T entity);
    Task<List<T>> ReadAll();
    Task<T> ReadById(Guid Id);
    Task<int> Update(T entity);
    Task<int> Delete(Guid Id);
}