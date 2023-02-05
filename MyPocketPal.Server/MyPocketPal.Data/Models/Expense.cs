using System.ComponentModel.DataAnnotations;

namespace MyPocketPal.Data.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name must not exceed 100 characters.")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Description must not exceed 500 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Amount must be greater than or equal to 0.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
