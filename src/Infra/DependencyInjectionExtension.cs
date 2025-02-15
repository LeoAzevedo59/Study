using Domain.Repositories;
using Domain.Repositories.Expenses;
using Domain.Repositories.User;
using Domain.Security.Cryptography;
using Infra.DataAccess;
using Infra.Repositories;
using Infra.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfra(this IServiceCollection services)
        {
            AddDbContext(services);
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            #region ExpensesRepository

            services
                .AddScoped<IExpenseReadOnlyRepository, ExpensesRepository>();
            services
                .AddScoped<IExpenseWriteOnlyRepository, ExpensesRepository>();
            services
                .AddScoped<IExpenseUpdateOnlyRepository, ExpensesRepository>();

            #endregion

            #region UnityOfWork

            services.AddScoped<IUnityOfWork, UnityOfWork>();

            #endregion

            #region UserRepository

            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();

            #endregion

            #region UserRepository

            services.AddScoped<IPasswordEncrypt, Cryptography>();

            #endregion
        }

        private static void AddDbContext(IServiceCollection services)
        {
            string? connectionString =
                Environment.GetEnvironmentVariable("CONNECTION_STRING");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException(
                    "Variável de ambiente: `CONNECTION_STRING` não configurada.");
            }

            services.AddDbContext<ApiDbContext>(config =>
                config.UseNpgsql(connectionString));
        }
    }
}
