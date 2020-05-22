using Microsoft.Extensions.Configuration;

namespace QuickVault.Configuration.Core
{
    public static class ConfigurationExtensions
    {
        public static IConfigurationBuilder AddQuickVault(this IConfigurationBuilder builder) => builder.Add(new QuickVaultConfigurationSource());
    }
}
