using Application.Dto;
using Domain.Models;

namespace Application.Interfaces;

public interface IUserService
{
    Task<User> AddUser(UserDto userDto);
    Task<User> UpdateUser(Guid id,UserDto userDto);
    Task<List<User>> GetAllUsers();
    Task<User> GetUserById(Guid id);
    Task<Guid> DeleteUser(Guid id);
}