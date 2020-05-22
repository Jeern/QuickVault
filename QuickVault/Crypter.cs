using System.Security.Cryptography;

namespace QuickVault
{
    internal static class Crypter
    {
        internal static Vault ReencryptVault(Vault vault, RSACryptoServiceProvider oldRsa, RSACryptoServiceProvider newRsa)
        {
            var newVault = new Vault();
            foreach(var key in vault.Keys)
            {
                newVault.SetValue(key, newRsa.Encrypt(oldRsa.Decrypt(vault[key])));
            }
            return newVault;
        }
    }
}
