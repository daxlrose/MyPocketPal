namespace MyPocketPal.Core.Dtos.Expenses
{
    public class ExpenseWithCategoryNameDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? CategoryName { get; set; }

    }
}
