# QuickVault.Configuration.Core

The simple yet powerful configuration pipeline of ASP.NET Core is easy to extend. QuickVault.Configuration.Core.dll contains such an extension.

It can be installed with 

```
Install-Package QuickVault.Configuration.Core
```

After that you can use QuickVault configuration on top of the rest of your configuration. The (easy of) use is demonstrated in the sample project (QuickVault.Sample.Website.Core)[../../Sample/QuickVault.Sample.Website.Core/Readme.md] in the (Program.cs)[../../Sample/QuickVault.Sample.Website.Core/Program.cs] file.

```csharp
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((context, builder) => builder.AddQuickVault());
                    webBuilder.UseStartup<Startup>();
                });
```





