using System;
using System.Collections.Generic;

namespace QuickVault
{
    [Serializable]
    internal class Vault
    {
        private Dictionary<string, byte[]> _content = new Dictionary<string, byte[]>();

        internal void SetValue(string key, byte[] value)
        {
            if(_content.ContainsKey(key))
            {
                _content[key] = value;
            }
            else
            {
                _content.Add(key, value);
            }
        }

        internal void Delete(string key)
        {
            if (_content.ContainsKey(key))
            {
                _content.Remove(key);
            }
        }

        internal IEnumerable<string> Keys => _content.Keys;

        internal bool HasKey(string key) => _content.ContainsKey(key);
        internal byte[] this[string key] => _content[key];
    }
}
