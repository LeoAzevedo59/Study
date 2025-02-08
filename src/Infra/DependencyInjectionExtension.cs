using Domain.Repositories.Expenses;
using Exception.Exceptions;
using Infra.DataAccess;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra;

public static class DependencyInjectionExtension
{
    public static void AddInfra(this IServiceCollection services)
    {
        AddDbContext(services);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IExpenseRepository, ExpensesRepository>();
    } 
    
    private static void AddDbContext(IServiceCollection services)
    {
        string? connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        if (string.IsNullOrEmpty(connectionString))
            throw new EnvironmentVariablesEmpty("Variável de ambiente: `CONNECTION_STRING` não configurada.");
        
        services.AddDbContext<ApiDbContext>(config => config.UseNpgsql(connectionString));
    }
}