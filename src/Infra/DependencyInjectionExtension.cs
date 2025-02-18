using Domain.Repositories;
using Domain.Repositories.Expenses;
using Domain.Repositories.User;
using Domain.Security.Cryptography;
using Domain.Tokens;
using Infra.DataAccess;
using Infra.Repositories;
using Infra.Security.Cryptography;
using Infra.Security.Tokens;
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
            AddAuthorization(services);
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

            #region Cryptography

            services.AddScoped<IPasswordEncrypt, PasswordEncryptBuilder>();

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

        private static void AddAuthorization(IServiceCollection services)
        {
            string? signinKey =
                Environment.GetEnvironmentVariable("SIGNIN_KEY");

            if (string.IsNullOrEmpty(signinKey))
            {
                throw new ArgumentException(
                    "Variável `SIGNIN_KEY` não configurada.");
            }

            uint expiresMinutes =
                Convert.ToUInt16(
                    Environment.GetEnvironmentVariable("EXPIRES_MINUTES"));

            if (expiresMinutes <= 0)
            {
                throw new ArgumentException(
                    "Variável `EXPIRES_MINUTES` não configurada.");
            }

            services.AddScoped<IAccessTokenGenerator>(config =>
                new JwtTokenGeneratorBuilder(expiresMinutes, signinKey));
        }
    }
}
