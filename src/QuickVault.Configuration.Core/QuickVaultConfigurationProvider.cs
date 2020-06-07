using Microsoft.Extensions.Configuration;

namespace QuickVault.Configuration.Core
{
    public class QuickVaultConfigurationProvider : ConfigurationProvider
    {
        private readonly VaultReader _reader = new VaultReader();
        private const string Encrypted = "<QuickVaultEncrypted>";
        public override void Load()
        {
            foreach(var key in _reader.Keys)
            {
                Data.Add(key, Encrypted);
            }
        }

        public override bool TryGet(string key, out string value)
        {
            if(!base.TryGet(key, out value))
                return false;
            if (value == Encrypted)
            {
                value = _reader[key];
                Data[key] = value;
            }
            return true;
        }

    }
}
