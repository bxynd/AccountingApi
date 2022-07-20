using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IDataContext
{
    DbSet<ExpenseIncome> ExpensesIncomes { get; set; }
    DbSet<Record> Records { get; set; }
    DbSet<User> Users { get; set; }
    Task<int> ContextSaveChanges();
    DbSet<T> Set<T>() where T : class;
}