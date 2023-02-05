using Microsoft.EntityFrameworkCore;
using MyPocketPal.Data.Models;

namespace MyPocketPal.Data.Data
{
    public class MyPocketPalDbContext : DbContext
    {
        public MyPocketPalDbContext(DbContextOptions<MyPocketPalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Expenses)
                .HasForeignKey(e => e.CategoryId);
        }
    }
}
