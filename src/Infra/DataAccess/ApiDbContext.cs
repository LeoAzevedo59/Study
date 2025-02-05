using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataAccess;

public class ApiDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        
        var connectionString = "Host=localhost;Database=SeuBancoDeDados;Username=SeuUsuario;Password=SuaSenha";
        
        optionsBuilder.UseNpgsql(connectionString);
    }
}