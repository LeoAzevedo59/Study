using Application.UseCase.Expense.Create;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateExpenseUseCase, CreateExpenseUseCase>();
    }
}