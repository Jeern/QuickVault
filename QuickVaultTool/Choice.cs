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
                Console.WriteLine($"{keys.Count} keys found:");
                foreach (var key in keys)
                {
                    Console.WriteLine($"{key}: {r[key]}");
                }
            });

        public static Choice ListKeysOnly = new Choice("List QuickVault keys", "Keys could not be listed", (r, m) =>
        {
            var keys = r.Keys.ToList();
            Console.WriteLine($"{keys.Count} keys found:");
            foreach (var key in keys)
            {
                Console.WriteLine($"{key}: {r[key]}");
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
            Console.WriteLine("Enter key");
            string key = InputHelper.GetEnteredValue();
            Console.WriteLine("Enter value");
            string value = InputHelper.GetEnteredValue();
            Console.WriteLine($"Are you sure you want to set {key} = {value}");
            Console.WriteLine("(Y/N)");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                m.SetValue(key, value, Encoding.UTF8);
            }
        });

        public static Choice DeleteValue = new Choice("Delete value", "Value could not be deleted", (r, m) =>
        {
            Console.WriteLine("Enter key");
            string key = InputHelper.GetEnteredValue();
            var value = r[key];
            Console.WriteLine($"Are you sure you want to delete {key} = {value}");
            Console.WriteLine("(Y/N)");
            if (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                m.Delete(key);
            }
        });



    }
}
