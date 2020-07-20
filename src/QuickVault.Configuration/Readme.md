# QuickVault.Configuration

For configuration of a full .NET framework application (an ASP.NET, Winforms, WPF or Console App), QuickVault offers the QuickVault.Configuration package.

It can be installed with 

```
Install-Package QuickVault.Configuration
```

To (kind of) emulate the functionality of the .NET core pipeline where there is an ordered list of configuration
providers, the QuickVault.Configuration package takes the approach of offering a QuickVaultConfigurationManager 
class that reads encrypted configuration values from the QuickVault and if they do not exist in the vault
just pipes all the rest of the requests to the regular ConfigurationManager. 

Like the ConfigurationManager - QuickVaultConfigurationManager offers an AppSettings and a ConnectionStrings property.

The values are read by using QuickVaultConfigurationManager.AppSettings["KeyName"] instead of the built in ConfigurationManager.AppSettings["KeyName"]. 