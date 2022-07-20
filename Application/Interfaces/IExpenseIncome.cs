using Application.Dto;
using Domain.Models;

namespace Application.Interfaces;

public interface IExpenseIncomeService
{
    Task<ExpenseIncome> AddExpenseIncome(ExpenseIncomeDto expenseIncomeDto);
    Task<ExpenseIncome> UpdateExpenseIncome(Guid id,ExpenseIncomeDto expenseIncomeDto);
    Task<List<ExpenseIncome>> GetAllExpensesIncomes();
    Task<ExpenseIncome> GetExpenseIncomeById(Guid id);
    Task<Guid> DeleteExpenseIncome(Guid id);
}