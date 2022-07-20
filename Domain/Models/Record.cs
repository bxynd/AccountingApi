using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models;

public class Record
{
    
    [Key]
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }
    public string Comment { get; set; }
    
    //Relation
    [ForeignKey("User")]
    public Guid UserId { get; set; }
    
    [InverseProperty("Records")]
    [JsonIgnore]
    public User User { get; set; }
    
    
    [ForeignKey("ExpenseIncome")]
    public Guid ExpenseIncomeId { get; set; }
    
    [InverseProperty("Records")]
    [JsonIgnore]
    public ExpenseIncome ExpenseIncome { get; set; }
}