using Domain.Repositories.Expenses;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra;

public static class DependencyInjectionExtension
{
    public static void AddInfra(this IServiceCollection services)
    {
        services.AddScoped<IExpenseRepository, ExpensesRepository>();
    }
}