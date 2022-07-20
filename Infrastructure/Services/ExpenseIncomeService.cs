using Application.Dto;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ExpenseIncomeService : IExpenseIncomeService
{
    private readonly IGenericRepository<ExpenseIncome> _expensesIncomesRepository;

    public ExpenseIncomeService(IGenericRepository<ExpenseIncome> expensesIncomesRepository)
    {
        _expensesIncomesRepository = expensesIncomesRepository;
    }
    public async Task<ExpenseIncome> AddExpenseIncome(ExpenseIncomeDto expenseIncomeDto)
    {
        var expenseIncome = new ExpenseIncome
        {
            Name = expenseIncomeDto.Name,
            TurnoverType = expenseIncomeDto.TurnoverType 
            
        };
        await _expensesIncomesRepository.Create(expenseIncome);
        return expenseIncome;
    }

    public async Task<ExpenseIncome> UpdateExpenseIncome(Guid id,ExpenseIncomeDto expenseIncomeDto)
    {
        var expenseIncome = await _expensesIncomesRepository.ReadById(id);
        expenseIncome.Name = expenseIncomeDto.Name;
        expenseIncome.TurnoverType = expenseIncomeDto.TurnoverType;
        
        await _expensesIncomesRepository.Update(expenseIncome);
        return expenseIncome;
    }
    public async Task<List<ExpenseIncome>> GetAllExpensesIncomes()
    {
        return await _expensesIncomesRepository.ReadAll();
    }

    public async Task<ExpenseIncome> GetExpenseIncomeById(Guid id)
    {
        return await _expensesIncomesRepository.ReadById(id);
    }
    public async Task<Guid> DeleteExpenseIncome(Guid id)
    {
        await _expensesIncomesRepository.Delete(id);
        return id;
    }
}