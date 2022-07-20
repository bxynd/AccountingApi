using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Models;

public class ExpenseIncome
{
    [Key]
    public Guid Id { get; set; }
    public TurnoverType TurnoverType { get; set; }
    public string Name { get; set; }
    
    //Relation
    public IQueryable<Record> Records { get; set; }
}