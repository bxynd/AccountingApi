using Application.Dto;
using FluentValidation;

namespace Infrastructure.Validation;

public class UserValidator:AbstractValidator<UserDto>
{
    public UserValidator()
    {
        RuleFor(u => u.Email).EmailAddress().NotEmpty();
        RuleFor(u => u.Password)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .MinimumLength(8);
    }
}