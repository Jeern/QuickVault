using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;

namespace QuickVault
{
    public class VaultReader
    {
        private readonly VaultFiles _files;
        private Vault Vault => _files.Load();
        public VaultReader(string folder = null)
        {
            _files = new VaultFiles(folder);
        }

        public string this[string key, Encoding encoding = null] 
        {
            get
            {
                encoding = encoding ?? Encoding.UTF8;
                var rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(_files.LoadPrivateKey());
                var vault = Vault;
                if (!vault.HasKey(key))
                    return null;
                return encoding.GetString(rsa.Decrypt(vault[key]));
            }
        }

        public IEnumerable<string> Keys => Vault.Keys;

        public bool PrivateKeyExists => _files.PrivateKeyExists;
        public bool PublicKeyExists => _files.PublicKeyExists;
    }
}
