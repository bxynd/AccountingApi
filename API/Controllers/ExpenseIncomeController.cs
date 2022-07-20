using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountingApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExpenseIncomeController : ControllerBase
{
    private readonly IExpenseIncomeService _expenseIncomeService;

    public ExpenseIncomeController(IExpenseIncomeService expenseIncomeService)
    {
        _expenseIncomeService = expenseIncomeService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _expenseIncomeService.GetAllExpensesIncomes());
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody]ExpenseIncomeDto expenseIncome)
    {
        return Ok(await _expenseIncomeService.AddExpenseIncome(expenseIncome));
    }
    
    [HttpGet("ByExpenseIncomeId/{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        return Ok(await _expenseIncomeService.GetExpenseIncomeById(id));
    }
    
    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] ExpenseIncomeDto expenseIncome)
    {
        return Ok(await _expenseIncomeService.UpdateExpenseIncome(id,expenseIncome));
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        return Ok(await _expenseIncomeService.DeleteExpenseIncome(id));
    }
}