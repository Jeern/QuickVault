using System;
using System.Linq;
using System.Text;
using QuickVault;

namespace QuickVaultTool
{
    public class Choice
    {
        public string OutputText { get; }
        public string ErrorText { get; }
        public Action<VaultReader, VaultManager> Action { get; }

        public Choice(string outputText, string errorText, Action<VaultReader, VaultManager> action)
        {
            OutputText = outputText;
            ErrorText = errorText;
            Action = action;
        }

        public static Choice ListKeyValues = new Choice("List QuickVault keys/values",
            "Keys/values could not be listed", (r, m) =>
            {
                var keys = r.Keys.ToList();
                Output.WriteLine($"{keys.Count} keys found:", OutputType.Content);
                foreach (var key in keys)
                {
                    Output.WriteLine($"{key}: {r[key]}", OutputType.Content);
                }
            });

        public static Choice ListKeysOnly = new Choice("List QuickVault keys", "Keys could not be listed", (r, m) =>
        {
            var keys = r.Keys.ToList();
            Output.WriteLine($"{keys.Count} keys found:", OutputType.Content);
            foreach (var key in keys)
            {
                Output.WriteLine(key, OutputType.Content);
            }
        });

        public static Choice UpdateCryptographicKeys = new Choice("Update cryptographic keys",
            "Cryptographic keys could not be updated", (r, m) =>
            {
                m.CreateKeyFiles(true);
            });

        public static Choice CreateCryptographicKeys = new Choice("Create cryptographic keys",
            "Cryptographic keys could not be created", (r, m) =>
            {
                m.CreateKeyFiles(false);
            });

        public static Choice SetNewValue = new Choice("Set new value", "Value could not be set", (r, m) =>
        {
            Output.Write("Enter key:", OutputType.Question);
            string key = InputHelper.GetEnteredValue();
            Output.Write("Enter value:", OutputType.Question);
            string value = InputHelper.GetEnteredValue();
            Output.Write($"Are you sure you want to set {key} = {value} (Y/N)", OutputType.Question);
            Output.Flush();
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                m.SetValue(key, value, Encoding.UTF8);
            }
        });

        public static Choice DeleteValue = new Choice("Delete value", "Value could not be deleted", (r, m) =>
        {
            Output.Write("Enter key:", OutputType.Question);
            string key = InputHelper.GetEnteredValue();
            var value = r[key];
            if(string.IsNullOrWhiteSpace(value))
                Output.Write($"Are you sure you want to delete {key} (Y/N)", OutputType.Question);
            else
                Output.Write($"Are you sure you want to delete {key} = {value} (Y/N)", OutputType.Question);
            Output.Flush();
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                m.Delete(key);
            }
        });
    }
}
