using System.Configuration;

namespace QuickVault.Configuration
{
    public class ConnectionStrings
    {
        public ConnectionStrings(string folder = null)
        {
            _reader = new VaultReader(folder);
            _manager = new VaultManager(folder);
        }

        private const string ConnectionStringsPrefix = "ConnectionStrings:";

        private readonly VaultReader _reader;
        private readonly VaultManager _manager;

        private string PrefixedKey(string key) => $"{ConnectionStringsPrefix}{key}";

        public string this[string key]
        {
            get => _reader[PrefixedKey(key)] ?? ConfigurationManager.ConnectionStrings[key].ConnectionString;
            set => _manager.SetValue(PrefixedKey(key), value);
        }
    }
}
