using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;

namespace QuickVault
{
    public class VaultReader
    {
        private readonly VaultFiles _files;
        private readonly Vault _vault;
        public VaultReader(string folder = null)
        {
            _files = new VaultFiles(folder);
            _vault = _files.Load();
        }

        public string this[string key, Encoding encoding = null] 
        {
            get
            {
                encoding = encoding ?? Encoding.UTF8;
                var rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(_files.LoadPrivateKey());
                if (!_vault.HasKey(key))
                    return null;
                return encoding.GetString(rsa.Decrypt(_vault[key]));
            }
        }

        public IEnumerable<string> Keys => _vault.Keys;

    }
}
