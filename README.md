# QuickVault

A simple key/value store with encrypted values. Supports .NET Configuration (both Core and Full Framework)

## What does it solve

You know the problem. You use a cheap web hosting company where you only have limited access to the server, 
and you do not want your precious secrets, password, api keys etc. to be openly accesible in the web.config 
or appsettings. You could use something like Azure Key vault but if you had access to that you would probably 
use Azure for the website as well.

QuickVault solves the problem by giving you Key/Value store in a file QuickVault.bin. All keys are readable, 
all values are encrypted with the RSACryptoServiceProvider.

The values are encrypted with the public key (stored in QuickVault.pub) and decrypted with the private key 
(stored in QuickVault.priv)

This means you need to protect your private key, for example by not pushing it to git. Make sure to add 
`QuickVault.priv` to your .gitignore file. 

Microsoft recommends you never store your private key in a file, which makes sense but the purpose of QuickVault 
is not to provide military grade security but rather to make cheap good enough security for most cases. So its 
definitely not meant for your big enterprise systems.

If you ever suspect your private key file has been lost, its easy to generate new keys and reencrypt your secrets 
(of course you should also change all the secrets in that case) !

The code contains 8 projects 

1. [QuickVault](src/QuickVault/Readme.md) - the basic functionality in a .NET Standard dll and also 
published as a nuget package (soon)
1. [QuickVault.Configuration](src/QuickVault.Configuration/Readme.md) - functionality for having secrets in appSettings and ConnectionStrings in an oldschool
app.config or web.config - this is also published as a nuget package (soon)
1. [QuickVault.Configuration.Core](src/QuickVault.Configuration.Core/Readme.md) - functionality for having secrets in an appsettings.json file - this is also 
published as a nuget package (soon)
1. [QuickVaulTool](Tool/QuickVaultTool/Readme.md) - A ConsoleApp for generating and regenerating keys, the QuickVault.bin file etc.
1. QuickVault.IntegrationsTests - The test suite that runs when pushing to master
1. [QuickVault.Sample.Console](Samples/QuickVault.Sample.Console/Readme.md) - A ConsoleApp that demos use of secrets in an app.config
1. [QuickVault.Sample.Website](Samples/QuickVault.Sample.Website/Readme.md) - A Website that demos use of secrets in a web.config
1. [QuickVault.Sample.Website.Core](Samples/QuickVault.Sample.WebSite.Core/Readme.md) - A Website that demos use of secrets in appsettings.json

The three samples all contains the QuickVault.priv file - this is just for demo'ing and as explained above 
QuickVault.priv file for real secrets should never be committed to GIT.

