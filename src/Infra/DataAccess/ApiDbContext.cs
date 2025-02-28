using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataAccess
{
    internal class ApiDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplySnakeCaseNames();

            modelBuilder.Entity<Expense>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
