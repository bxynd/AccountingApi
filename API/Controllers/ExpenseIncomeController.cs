using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountingApp.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ExpenseIncomeController : ControllerBase
{
    private readonly IExpenseIncomeService _expenseIncomeService;

    public ExpenseIncomeController(IExpenseIncomeService expenseIncomeService)
    {
        _expenseIncomeService = expenseIncomeService;
    }
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _expenseIncomeService.GetAllExpensesIncomes());
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin,Regular")]
    public async Task<IActionResult> CreateExpenseIncome([FromBody]ExpenseIncomeDto expenseIncome)
    {
        return Ok(await _expenseIncomeService.AddExpenseIncome(expenseIncome));
    }
    
    [HttpGet("ByExpenseIncomeId/{id:Guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        return Ok(await _expenseIncomeService.GetExpenseIncomeById(id));
    }
    
    [HttpPut("{id:Guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] ExpenseIncomeDto expenseIncome)
    {
        return Ok(await _expenseIncomeService.UpdateExpenseIncome(id,expenseIncome));
    }

    [HttpDelete("{id:Guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        return Ok(await _expenseIncomeService.DeleteExpenseIncome(id));
    }
}