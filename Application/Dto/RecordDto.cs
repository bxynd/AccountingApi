namespace Application.Dto;

public class RecordDto
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }
    public Guid ExpenseIncomeId { get; set; }
    public string Comment { get; set; }

}