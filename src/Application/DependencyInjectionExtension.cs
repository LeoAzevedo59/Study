using Application.AutoMapper;
using Application.UseCase.Expense.Create;
using Application.UseCase.Expense.Delete;
using Application.useCase.Expense.Read;
using Application.useCase.Expense.ReadById;
using Application.UseCase.Expense.Update;
using Application.UseCase.User.Create;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
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
            services.AddScoped<IReadExpenseUseCase, ReadExpenseUseCase>();
            services
                .AddScoped<IReadExpenseByIdUseCase, ReadExpenseByIdUseCase>();
            services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
            services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();

            services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        }
    }
}
