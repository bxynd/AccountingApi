using Application.Dto;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> AddUser(UserDto userDto)
    {
        var user = new User
        {
            Email = userDto.Email,
            Role = userDto.Role,
            Password = userDto.Password
        };
        await _userRepository.Create(user);
        return user;
    }
    public async Task<User> UpdateUser(Guid id,UserDto userDto)
    {
        var user = await _userRepository.ReadById(id);
        user.Email = userDto.Email;
        user.Role = userDto.Role;
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

    public async Task<User?> GetByEmail(string email)
    {
        return await _userRepository.FindByEmail(email);
    }
}