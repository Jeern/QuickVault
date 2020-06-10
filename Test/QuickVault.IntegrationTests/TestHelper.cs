using System;
using System.IO;

namespace QuickVault.IntegrationTests
{
    public static class TestHelper
    {
        public static string GetFolder(string rootFolder, string subFolder) =>
            Path.Combine(Directory.GetCurrentDirectory(), rootFolder, subFolder);

        public static string GenerateValue() =>
            Guid.NewGuid().ToString("N").Substring(0, 5);
    }
}
