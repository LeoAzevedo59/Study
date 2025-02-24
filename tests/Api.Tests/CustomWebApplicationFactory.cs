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
                });
        }
    }
}
