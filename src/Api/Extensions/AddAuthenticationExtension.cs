using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.Extensions
{
    public static class AddAuthenticationExtension
    {
        public static void AddAuth(this IServiceCollection services,
            IConfiguration configuration)
        {
            string? signInKeyVariable =
                configuration["SIGNIN_KEY"];

            if (string.IsNullOrEmpty(signInKeyVariable))
            {
                throw new ArgumentException(
                    "Variável `SIGNIN_KEY` não configurada.");
            }

            byte[] signinKey =
                Encoding.UTF8.GetBytes(
                    signInKeyVariable);

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme =
                        JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme =
                        JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters =
                        new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ClockSkew = new TimeSpan(0),
                            IssuerSigningKey =
                                new SymmetricSecurityKey(signinKey)
                        };
                });
        }
    }
}
