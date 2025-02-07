using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataAccess;

public class ApiDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        
        var connectionString = "Host=ep-round-unit-a8jb25zs-pooler.eastus2.azure.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_yamN7UBSc9CE";
        
        
        optionsBuilder.UseNpgsql(connectionString);
    }
}