using Domain.Enums;

namespace Application.Dto;

public class UserDto
{
    public string Email { get; set; }
    public Role Role { get; set; }
    public string Password { get; set; }
}