using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace QuickVault
{
    internal class VaultFiles
    {
        private const string VaultFile = "QuickVault.bin";
        private const string PrivateKeyFile = "QuickVault.priv";
        private const string PublicKeyFile = "QuickVault.pub";

        private readonly string _folder;
        internal string PrivateKeyFullPath => Path.Combine(_folder, PrivateKeyFile);
        internal string PublicKeyFullPath => Path.Combine(_folder, PublicKeyFile);
        internal string VaultFullPath => Path.Combine(_folder, VaultFile);

        internal VaultFiles(string folder)
        {
            _folder = folder ?? Directory.GetCurrentDirectory();
            if (!Directory.Exists(_folder))
                Directory.CreateDirectory(_folder);
        }

        internal void DeleteQuickVault()
        {
            DeleteFile(VaultFullPath);
        }

        internal void DeletePrivateKeyFile()
        {
            DeleteFile(PrivateKeyFullPath);
        }

        internal void DeletePublicKeyFile()
        {
            DeleteFile(PublicKeyFullPath);
        }

        private void DeleteFile(string file)
        {
            if (File.Exists(file))
                File.Delete(file);
        }

        internal bool VaultExists => File.Exists(VaultFullPath);
        internal bool PrivateKeyExists => File.Exists(PrivateKeyFullPath);
        internal bool PublicKeyExists => File.Exists(PublicKeyFullPath);

        internal bool AnyQuickVaultFileExists => VaultExists || PrivateKeyExists || PublicKeyExists;

        internal void SavePrivateKey(string privateKey)
        {
            File.WriteAllText(PrivateKeyFullPath, privateKey);
        }

        internal void SavePublicKey(string publicKey)
        {
            File.WriteAllText(PublicKeyFullPath, publicKey);
        }

        internal string LoadPrivateKey()
        {
            return File.ReadAllText(PrivateKeyFullPath);
        }

        internal string LoadPublicKey()
        {
            return File.ReadAllText(PublicKeyFullPath);
        }

        internal Vault Load()
        {
            if(!File.Exists(VaultFullPath))
                return new Vault();
            var f = new BinaryFormatter();
            using (var fs = new FileStream(VaultFullPath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                return f.Deserialize(fs) as Vault;
            }
        }

        internal void Save(Vault vault)
        {
            var f = new BinaryFormatter();
            using (var fs = new FileStream(VaultFullPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                f.Serialize(fs, vault);
            }
        }
    }
}
