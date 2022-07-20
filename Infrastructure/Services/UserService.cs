using Application.Dto;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IGenericRepository<User> _userRepository;

    public UserService(IGenericRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> AddUser(UserDto userDto)
    {
        var user = new User
        {
            Email = userDto.Email,
            Password = userDto.Password
        };
        await _userRepository.Create(user);
        return user;
    }
    public async Task<User> UpdateUser(Guid id,UserDto userDto)
    {
        var user = await _userRepository.ReadById(id);
        user.Email = userDto.Email;
        user.Password = userDto.Password;
        await _userRepository.Update(user);
        return user;
    }
    public async Task<List<User>> GetAllUsers()
    {
        return await _userRepository.ReadAll();
    }

    public async Task<User> GetUserById(Guid id)
    {
        return await _userRepository.ReadById(id);
    }
    public async Task<Guid> DeleteUser(Guid id)
    {
        await _userRepository.Delete(id);
        return id;
    }
}