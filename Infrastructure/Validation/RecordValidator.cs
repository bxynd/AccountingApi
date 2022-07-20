using Application.Dto;
using FluentValidation;

namespace Infrastructure.Validation;

public class RecordValidator:AbstractValidator<RecordDto>
{
    public RecordValidator()
    {
        RuleFor(r => r.Amount).GreaterThan(0);
        RuleFor(r => r.Date).LessThan(DateTime.UtcNow.ToUniversalTime().AddDays(1));
    }
}