using Domain.Enums;

namespace Application.Dto;

public class ExpenseIncomeDto
{
    public TurnoverType TurnoverType { get; set; }
    public string Name { get; set; }
}