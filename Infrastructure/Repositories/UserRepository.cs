using Application.Interfaces;
using Domain.Models;

namespace Infrastructure.Repositories;

public class UserRepository: GenericRepository<User>, IUserRepository
{
    private readonly IDataContext _dataContext;

    public UserRepository(IDataContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<User?> FindByEmail(string email)
    {
        var user = _dataContext.Users.FirstOrDefault(u => u.Email == email);
        return user;
    }
}