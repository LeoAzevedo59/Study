using Application.AutoMapper;
using Application.UseCase.Expense.Create;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCase(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }
    
    private static void AddUseCase(IServiceCollection services)
    {
        services.AddScoped<ICreateExpenseUseCase, CreateExpenseUseCase>();
    }
}