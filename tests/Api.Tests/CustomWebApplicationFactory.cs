using CommonTestUtilities.Entities;
using Domain.Entities;
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
        private User _user;

        public string GetEmail()
        {
            return _user.Email;
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

                    StartDatabase(dbContext);
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
