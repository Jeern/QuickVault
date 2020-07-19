# QuickVault

The QuickVault.dll contains the base functionality of QuickVault.

It can be installed in your .NET Core or full framework project using

```
Install-Package QuickVault
```

## Philosophy

QuickVault consists of a reader and a manager api. The reader is all that is 
used in a live website or similar and the manager is used to create and manipulate 
the vault from a tool when builting the website. For instance the [QuickVaulTool](Tool/QuickVaultTool/Readme.md).

There a 3 files involved in a QuickVault

QuickVault.priv containing the private key used to encrypt the values of the vault. This file is never added
to source code. Its released to your website by copying it manually or in a similar way.

QuickvVault.pub containing the public key used to decrypt the values in the QuickVault.

And finally the vault itself QuickVault.bin containing the unencrypted keys, and encrypted values.

## VaultManager.cs

The VaultManager.cs is used to Create key files or update existing keyfiles and to Set values and delete values.

You create new key files by calling `CreateKeyFiles()` and you update existing key files by calling `CreateKeyFiles(true)`.

Update key files is smart if your keys are compromised. It will not only update the keyfiles but also update all the values to use the new keys.

`SetValue(string key)` sets the value of a key and `Delete(string key)` deletes the value of a key.

And that's about it

## VaultReader.cs

VaultReader.cs is used to iterate over keys using the Keys collection or return the value of specific key using the
indexer. I.e to list all values

```csharp
var reader = new VaultReader();
foreach(var key in reader.Keys)
{
	Console.Writeln($"{key}={reader[key]}");
}
```

Could not be simpler.

