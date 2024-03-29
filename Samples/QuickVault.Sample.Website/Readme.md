﻿# QuickVault.Sample.Website

Demonstrates the use of [QuickVault.Configuration](../../src/QuickVault.Configuration/Readme.md) to get access to secrets in the appsettings and connectionstring sections of the web.config

When you start the website you will see the output

```
DemoProp1: Value1 From appSettings
DemoProp2: Value from QuickVault
```

I.e. one value directly from appSettings and one from QuickVault.

The values are read by using QuickVaultConfigurationManager.AppSettings["KeyName"] instead of the built in ConfigurationManager.AppSettings["KeyName"]. QuickVaultConfigurationManager just forwards anything not in the QuickVault to ConfigurationManager to get a nice experience similar to the one for .NET core appsettings.json files.

The project contains both `QuickVault.bin`, `QuickVault.priv` and `QuickVault.pub`. `QuickVault.priv` is just in the repo for demo purposes. It should never be added to source control for a real site (but should of course be 
copied to the webserver to be able to decrypt the values in QuickVault.bin).