using System.ComponentModel.DataAnnotations;

namespace MyPocketPal.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name must not exceed 100 characters.")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Description must not exceed 500 characters.")]
        public string? Description { get; set; }

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
