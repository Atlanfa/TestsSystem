using Microsoft.Extensions.Configuration;

namespace TestsSystem.Web.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetApiEndpoint(this IConfiguration configuration)
            => configuration.GetSection("ApiCredentials").GetSection("ApiEndpoint").Value;
    }
}
