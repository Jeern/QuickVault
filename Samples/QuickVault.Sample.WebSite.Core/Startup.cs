using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace QuickVault.Sample.WebSite.Core
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<DemoConfig>(Configuration.GetSection("DemoConfig"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var demoConfig = app.ApplicationServices.GetService<IOptions<DemoConfig>>();

                    await context.Response.WriteAsync($"Demo Config:{Environment.NewLine}");
                    await context.Response.WriteAsync($"DemoProp1: {demoConfig?.Value.DemoProp1}{Environment.NewLine}");
                    await context.Response.WriteAsync($"DemoProp2: {demoConfig?.Value.DemoProp2}{Environment.NewLine}");
                });
            });
        }
    }
}
