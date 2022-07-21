using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    
    //Relation
    public IEnumerable<Record> Records { get; set; }
}