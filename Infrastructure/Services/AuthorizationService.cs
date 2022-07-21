using Application.Interfaces;
using Domain.Models;

namespace Infrastructure.Services;

public class AuthorizationService
{
    public AuthorizationService(IGenericRepository<User> userRepository)
    {
        
    }
}