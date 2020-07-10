using System;
using System.IO;
using Xunit;

namespace QuickVault.IntegrationTests
{
    public class ManagerTests
    {
        private string GetFolder(string subFolder) =>
            TestHelper.GetFolder("Manager", subFolder);

        [Fact]
        public void Can_create_keyfiles()
        {
            string folder = GetFolder("Create");
            TestHelper.DeleteFolder(folder);
            var manager = new VaultManager(folder);

            manager.CreateKeyFiles();
        }

        [Fact]
        public void Can_update_keyfiles()
        {
            var manager = new VaultManager(GetFolder("Update"));

            manager.CreateKeyFiles(true);
        }

        [Fact]
        public void Can_set_key()
        {
            var folder = GetFolder("SetKey");
            var manager = new VaultManager(folder);
            manager.CreateKeyFiles(true);
            string key = TestHelper.GenerateValue();
            string value = TestHelper.GenerateValue();

            manager.SetValue(key, value);

            var reader = new VaultReader(folder);
            Assert.Equal(value, reader[key]);
        }

        [Fact]
        public void Can_delete_key()
        {
            var folder = GetFolder("DeleteKey");
            var manager = new VaultManager(folder);
            manager.CreateKeyFiles(true);
            string key = TestHelper.GenerateValue();
            string value = TestHelper.GenerateValue();
            manager.SetValue(key, value);

            manager.Delete(key);

            var reader = new VaultReader(folder);
            Assert.True(reader[key] == null);
        }
    }
}
