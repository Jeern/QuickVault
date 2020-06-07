using Microsoft.Extensions.Configuration;

namespace QuickVault.Configuration.Core
{
    public class QuickVaultConfigurationSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new QuickVaultConfigurationProvider();
        }
    }
}
