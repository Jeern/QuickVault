# QuickVaultTool

Although a QuickVault can be managed by using the VaultManager and VaultReader class of the QuickVault.dll 
it is nice to have some tooling.

Currently the only tool available is the ConsoleApp QuickVaultTool.

When you start it the available options will be dependent on the existence of priv/public key.

If none exists the only option is to create them, while if both exists you can manipulate them in all ways possible.

The available optiones are:

1. Create cryptographic keys - available if there is no public key.  
1. Update cryptographic keys - avaliable if there is a public key. If there is also a Private key the vault is 
reencrypted. *Be aware If there is only a public key the old vault is deleted (i.e. all settings lost - always have a backup or have the vault in source control).*
1. Set new value - Can be done if there is a public key
1. Delete value - Possible if any key is available
1. List QuickVault keys/values - Only possible if there is a private key. The values are read using the VaultReader.cs
1. List QuickVault keys - If there is a public key but no public key only the QuickVault keys can be read.




