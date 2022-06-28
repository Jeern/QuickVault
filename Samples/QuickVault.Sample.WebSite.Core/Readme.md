# QuickVault.Sample.Website.Core

Demonstrates the use of [QuickVault.Configuration.Core](../../src/QuickVault.Configuration.Core/Readme.md) to get access to secrets in appsettings.json

When you start the website you will see the output

```
DemoConfig:
DemoProp1: Value1 From AppSettings
DemoProp2: Value from QuickVault
```

I.e. one value directly from appsettings.json and one from QuickVault.

The setup is simple and can be seen in [Program.cs](./Program.cs)

The call to builder.AddQuickVault() is all it takes. The use of DemoConfig.cs in [Startup.cs](./Startup.cs) is just extra syntactic sugar which is not needed.

The project contains both `QuickVault.bin`, `QuickVault.priv` and `QuickVault.pub`. `QuickVault.priv` is just in the repo for demo purposes. It should never be added to source control for a real site (but should of course be 
copied to the webserver to be able to decrypt the values in QuickVault.bin).