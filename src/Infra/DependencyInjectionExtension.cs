using Domain.Repositories;
using Domain.Repositories.Expenses;
using Domain.Repositories.User;
using Domain.Security.Cryptography;
using Domain.Tokens;
using Infra.DataAccess;
using Infra.Extensions;
using Infra.Repositories;
using Infra.Security.Cryptography;
using Infra.Security.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfra(this IServiceCollection services,
            IConfiguration configuration)
        {
            AddRepositories(services);
            AddAuthorization(services, configuration);

            if (!configuration.IsTestIntegrationEnvironment())
            {
                AddDbContext(services, configuration);
            }
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

        private static void AddDbContext(IServiceCollection services,
            IConfiguration configuration)
        {
            string? x = configuration["SIGNIN_KEY"];

            string? connectionString =
                configuration["CONNECTION_STRING"];

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException(
                    "Variável de ambiente: `CONNECTION_STRING` não configurada.");
            }

            services.AddDbContext<ApiDbContext>(config =>
                config.UseNpgsql(connectionString));
        }

        private static void AddAuthorization(IServiceCollection services,
            IConfiguration configuration)
        {
            string? signinKey = configuration["SIGNIN_KEY"];

            if (string.IsNullOrEmpty(signinKey))
            {
                throw new ArgumentException(
                    "Variável `SIGNIN_KEY` não configurada.");
            }

            uint expiresMinutes =
                Convert.ToUInt16(configuration["EXPIRES_MINUTES"]);

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
