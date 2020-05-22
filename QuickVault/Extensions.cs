using System.Security.Cryptography;

namespace QuickVault
{
    internal static class Extensions
    {
        internal static byte[] Encrypt(this RSACryptoServiceProvider rsa, byte[] data)
        {
            return rsa.Encrypt(data, true);
        }
        internal static byte[] Decrypt(this RSACryptoServiceProvider rsa, byte[] data)
        {
            return rsa.Decrypt(data, true);
        }

    }
}
