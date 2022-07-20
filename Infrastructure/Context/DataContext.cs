using Application.Interfaces;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext:DbContext, IDataContext
{
    public DbSet<ExpenseIncome> ExpensesIncomes { get; set; }
    public DbSet<Record> Records { get; set; }
    public DbSet<User> Users { get; set; }
    public DataContext()
    {
    }
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpenseIncome>().HasData(
            new List<ExpenseIncome>
            {
                new ExpenseIncome
                {   
                    Id = Guid.NewGuid(),
                    Name = "Salary",
                    TurnoverType = TurnoverType.Income
                },
                new ExpenseIncome
                {
                    Id = Guid.NewGuid(),
                    Name = "Real estate rent",
                    TurnoverType = TurnoverType.Income
                },
                new ExpenseIncome
                {
                    Id = Guid.NewGuid(),
                    Name = "Other",
                    TurnoverType = TurnoverType.Income
                },
                new ExpenseIncome
                {
                    Id = Guid.NewGuid(),
                    Name = "Food",
                    TurnoverType = TurnoverType.Expense
                },
                new ExpenseIncome
                {
                    Id = Guid.NewGuid(),
                    Name = "Transportation",
                    TurnoverType = TurnoverType.Expense
                },
                new ExpenseIncome
                {
                    Id = Guid.NewGuid(),
                    Name = "Mobile connection",
                    TurnoverType = TurnoverType.Expense
                },
                new ExpenseIncome
                {
                    Id = Guid.NewGuid(),
                    Name = "Internet",
                    TurnoverType = TurnoverType.Expense
                },
                new ExpenseIncome
                {
                    Id = Guid.NewGuid(),
                    Name = "Entertainment",
                    TurnoverType = TurnoverType.Expense
                },
                new ExpenseIncome
                {
                    Id = Guid.NewGuid(),
                    Name = "Other",
                    TurnoverType = TurnoverType.Expense
                }
            });
    }

    public Task<int> ContextSaveChanges()
    {
        return base.SaveChangesAsync();
    }
}