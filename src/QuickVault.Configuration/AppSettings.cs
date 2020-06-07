using System.Configuration;

namespace QuickVault.Configuration
{
    public class AppSettings
    {
        public AppSettings(string folder = null)
        {
            _reader = new VaultReader(folder);
            _manager = new VaultManager(folder);
        }

        private const string AppSettingsPrefix = "AppSettings:";

        private readonly VaultReader _reader;
        private readonly VaultManager _manager;

        private string PrefixedKey(string key) => $"{AppSettingsPrefix}{key}";
        public string this[string key] 
        {
            get => _reader[PrefixedKey(key)] ?? ConfigurationManager.AppSettings[key];
            set => _manager.SetValue(PrefixedKey(key), value);
        }
    }
}
