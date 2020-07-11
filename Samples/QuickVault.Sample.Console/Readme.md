# QuickVault.Sample.ConsoleApp

Demonstrates the use of QuickVault.Configuration to get access to secrets in the appsettings and connectionstring sections of the app.config

When you run the app you will see the output

```
Reading <appSettings>
DemoProp1: Value1 From appSettings
DemoProp2: Value from QuickVault
```

I.e. one value directly from appSettings and one from QuickVault.

It is easily read by using QuickVaultConfigurationManager.AppSettings["DemoProp2"] instead of the built in ConfigurationManager.AppSettings["DemoProp2"]. QuickVaultConfigurationManager just forwards anything not in the QuickVault to get a nice
experience similar to the one in .NET core appSettings.

The project contains both QuickVault.bin, QuickVault.priv and QuickVault.pub. QuickVault.priv is just in the repo for demo purposes. It should never be in a real sites GIT repo (but should of course be copied to the webserver to be able to decrypt the values in QuickVault.bin).

Look at [QuickVault.Configuration](src/QuickVault.Configuration/Readme.md) to see more how to add encrypted configuration to a .NET full framework Console, Winforms or WPF app.

