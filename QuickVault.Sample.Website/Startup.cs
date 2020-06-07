using System.Web;
using Microsoft.Owin;
using Owin;
using QuickVault.Configuration;

[assembly: OwinStartup(typeof(QuickVault.Sample.Website.Startup))]

namespace QuickVault.Sample.Website
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            QuickVaultConfigurationManager.SetRootFolder(HttpRuntime.AppDomainAppPath);
        }
    }
}
