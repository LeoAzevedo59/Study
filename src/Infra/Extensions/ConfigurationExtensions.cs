using Microsoft.Extensions.Configuration;

namespace Infra.Extensions
{
    public static class ConfigurationExtensions
    {
        public static bool IsTestIntegrationEnvironment(
            this IConfiguration configuration)
        {
            string integrationTest =
                configuration["INTEGRATION_TEST"] ?? "false";

            return integrationTest.ToLower().Equals("true");
        }
    }
}
