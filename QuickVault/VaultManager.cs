using System;
using System.Security.Cryptography;
using System.Text;

namespace QuickVault
{
    public class VaultManager
    {
        private readonly VaultFiles _files;
        public VaultManager(string folder = null)
        {
            _files = new VaultFiles(folder);
        }

        public void CreateKeyFiles(bool updateExisting = false)
        {
            var rsa = new RSACryptoServiceProvider(4096);
            string publicKey = rsa.ToXmlString(false);
            string privateKey = rsa.ToXmlString(true);

            if (!updateExisting && _files.AlreadyExists)
                throw new InvalidOperationException("There is already QuickVault files here");
            else if (updateExisting && _files.AlreadyExists)
                UpdateVault(publicKey, privateKey, rsa);
            else
                CreateVault(publicKey, privateKey);

        }

        public void SetValue(string key, string value, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(_files.LoadPublicKey());
            var vault = _files.Load();
            vault.SetValue(key, rsa.Encrypt(encoding.GetBytes(value)));
            _files.Save(vault);
        }

        private void CreateVault(string publicKey, string privateKey, Vault vault = null)
        {
            _files.SavePrivateKey(privateKey);
            _files.SavePublicKey(publicKey);
            _files.Save(vault ?? new Vault());
        }

        private void UpdateVault(string publicKey, string privateKey, RSACryptoServiceProvider rsa)
        {
            if(!_files.AllFilesExist)
            {
                _files.DeletePublicKeyFile();
                _files.DeletePrivateKeyFile();
                _files.DeleteQuickVault();
                CreateVault(publicKey, privateKey);
            }
            else
            {
                var vault = _files.Load();
                string oldPrivateKey = _files.LoadPrivateKey();
                var oldRsa = new RSACryptoServiceProvider();
                oldRsa.FromXmlString(oldPrivateKey);
                CreateVault(publicKey, privateKey, Crypter.ReencryptVault(vault, oldRsa, rsa));
            }
        }
    }
}
