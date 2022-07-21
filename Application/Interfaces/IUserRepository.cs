using Domain.Models;

namespace Application.Interfaces;

public interface IUserRepository
{
    Task<User?> FindByEmail(string email);
    Task<int> Create(User entity);
    Task<List<User>> ReadAll();
    Task<User> ReadById(Guid Id);
    Task<int> Update(User entity);
    Task<int> Delete(Guid Id);
}