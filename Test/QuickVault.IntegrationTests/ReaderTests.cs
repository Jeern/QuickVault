using System.Linq;
using Xunit;

namespace QuickVault.IntegrationTests
{
    public class ReaderTests
    {
        private string GetFolder(string subFolder) =>
            TestHelper.GetFolder("Reader", subFolder);

        [Fact]
        public void Can_tell_if_privatekey_does_not_exist()
        {
            var reader = new VaultReader(GetFolder("NoPrivate"));

            var publicKeyExists = reader.PublicKeyExists;

            Assert.False(publicKeyExists);
        }

        [Fact]
        public void Can_tell_if_publickey_does_not_exist()
        {
            var reader = new VaultReader(GetFolder("NoPublic"));

            var privateKeyExists = reader.PrivateKeyExists;

            Assert.False(privateKeyExists);
        }

        [Fact]
        public void Can_tell_if_privatekey_does_exist()
        {
            string folder = GetFolder("Private");
            var manager = new VaultManager(folder);
            manager.CreateKeyFiles(true);
            var reader = new VaultReader(folder);

            var privateKeyExists = reader.PrivateKeyExists;

            Assert.True(privateKeyExists);
        }

        [Fact]
        public void Can_tell_if_publickey_does_exist()
        {
            string folder = GetFolder("Public");
            var manager = new VaultManager(folder);
            manager.CreateKeyFiles(true);
            var reader = new VaultReader(folder);

            var publicKeyExists = reader.PublicKeyExists;

            Assert.True(publicKeyExists);
        }

        [Fact]
        public void Can_access_all_keys()
        {
            string folder = GetFolder("Keys");
            var manager = new VaultManager(folder);
            manager.CreateKeyFiles(true);
            var key1 = TestHelper.GenerateValue();
            var key2 = TestHelper.GenerateValue();
            var value = TestHelper.GenerateValue();
            manager.SetValue(key1, value);
            manager.SetValue(key2, value);
            var reader = new VaultReader(folder);

            var keys = reader.Keys.ToHashSet();

            Assert.Contains(key1, keys);
            Assert.Contains(key2, keys);
        }

        [Fact]
        public void Can_read_value()
        {
            string folder = GetFolder("Keys");
            var manager = new VaultManager(folder);
            manager.CreateKeyFiles(true);
            var key = TestHelper.GenerateValue();
            var value = TestHelper.GenerateValue();
            manager.SetValue(key, value);
            var reader = new VaultReader(folder);

            var content = reader[key];

            Assert.Equal(value, content);
        }
    }
}
