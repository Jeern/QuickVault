# QuickVault.Configuration.Core

The simple yet powerful configuration pipeline of ASP.NET Core is easy to extend. QuickVault.Configuration.Core.dll contains such an extension.

It can be installed with:

```
Install-Package QuickVault.Configuration.Core
```

After that you can use QuickVault configuration on top of the rest of your configuration. The (ease of) use is demonstrated in the sample project [QuickVault.Sample.WebSite.Core](../../Samples/QuickVault.Sample.WebSite.Core/Readme.md) in the [Program.cs](../../Samples/QuickVault.Sample.WebSite.Core/Program.cs) file.

```csharp
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((context, builder) => builder.AddQuickVault());
                    webBuilder.UseStartup<Startup>();
                });
```


You use the same naming standard as for environment variables to overwrite appsettings.

I.e this appsetting

```json
{
	"Bad": {
		"Boy": true
	}
}
```

You have to store as:

```
Bad__Boy = true
```

I.e this appsetting

```json
{
	"Bad": {
		"Boys": [
			{
				"Boy": true

			}
		]
	}
}
```

Will be stored as: 

```
Bad__Boys__0__Boy = true; 
````

```
Bad__Boy = true
```