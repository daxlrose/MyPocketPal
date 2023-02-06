namespace MyPocketPal.Core.Dtos.Expenses
{
    public class CreateExpenseDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
    }
}
