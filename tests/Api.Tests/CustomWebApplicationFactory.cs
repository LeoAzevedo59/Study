using CommonTestUtilities.Entities;
using Domain.Entities;
using Domain.Tokens;
using Infra.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Tests
{
    public class
        CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        private string _token;
        private User _user;

        public string GetEmail()
        {
            return _user.Email;
        }

        public string GetToken()
        {
            return _token;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("IntegrationTests")
                .ConfigureServices(services =>
                {
                    ServiceProvider provider =
                        services.AddEntityFrameworkInMemoryDatabase()
                            .BuildServiceProvider();

                    services.AddDbContext<ApiDbContext>(config =>
                    {
                        config.UseInMemoryDatabase("InMemoryDbForTesting");
                        config.UseInternalServiceProvider(provider);
                    });
                    IServiceScope scope =
                        services.BuildServiceProvider().CreateScope();
                    ApiDbContext dbContext = scope.ServiceProvider
                        .GetRequiredService<ApiDbContext>();
                    IAccessTokenGenerator tokenGenerator = scope.ServiceProvider
                        .GetRequiredService<IAccessTokenGenerator>();

                    StartDatabase(dbContext);

                    _token = tokenGenerator.Generate(_user);
                });
        }

        private void StartDatabase(ApiDbContext dbContext)
        {
            _user = UserBuild.Build();
            dbContext.Add(_user);

            dbContext.SaveChanges();
        }
    }
}
