using Domain.Repositories.Expenses;
using Infra.DataAccess;
using Infra.Repositories;
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
        services.AddDbContext<ApiDbContext>();
    }
}