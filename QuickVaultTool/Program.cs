using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using QuickVault;

namespace QuickVaultTool
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to the QuickVault tool.");
                Console.WriteLine("");
                string folder = GetQuickVaultFolder(Directory.GetCurrentDirectory());

                var manager = new VaultManager(folder);
                var reader = new VaultReader(folder);

                MakeChoices(reader, manager);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
#if DEBUG
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
#endif

        }

        private static void MakeChoices(VaultReader reader, VaultManager manager)
        {
            var choices = new Dictionary<int, Choice>();
            do
            {
                SetupChoices(choices, reader, manager);
                PrintChoices(choices, reader, manager);
            } while (Choose(choices, reader, manager));
        }

        private static void SetupChoices(Dictionary<int, Choice> choices, VaultReader reader, VaultManager manager)
        {
            choices.Clear();
            if (reader.PublicKeyExists && reader.PrivateKeyExists)
            {
                choices.Add(1, Choice.UpdateCryptographicKeys);
                choices.Add(2, Choice.ListKeyValues);
                choices.Add(3, Choice.DeleteValue);
                choices.Add(4, Choice.SetNewValue);
            }
            else if (reader.PublicKeyExists)
            {
                choices.Add(1, Choice.UpdateCryptographicKeys);
                choices.Add(2, Choice.ListKeysOnly);
                choices.Add(3, Choice.DeleteValue);
                choices.Add(4, Choice.SetNewValue);
            }
            else if (reader.PrivateKeyExists)
            {
                choices.Add(1, Choice.CreateCryptographicKeys);
                choices.Add(2, Choice.ListKeyValues);
                choices.Add(3, Choice.DeleteValue);
            }
            else
            {
                choices.Add(1, Choice.CreateCryptographicKeys);
            }
        }

        private static void PrintChoices(Dictionary<int, Choice>  choices, VaultReader reader, VaultManager manager)
        {
            Console.WriteLine();
            Console.WriteLine("Please choose a numbered option (i.e press the number or 'q' to quit):");
            foreach (var choicesKey in choices.Keys)
            {
                Console.WriteLine($"{choicesKey}. {choices[choicesKey].OutputText}");
            }
        }

        private static bool Choose(Dictionary<int, Choice> choices, VaultReader reader, VaultManager manager)
        {
            var key= Console.ReadKey(true).KeyChar;
            if (key == 'q')
                return false;

            if (!int.TryParse(key.ToString(), out int intkey))
                return Choose(choices, reader, manager);

            if(!choices.ContainsKey(intkey))
                return Choose(choices, reader, manager);

            try
            {
                choices[intkey].Action(reader, manager);
                Console.WriteLine($"{choices[intkey].OutputText}: Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{choices[intkey].ErrorText}: {e.Message}");
            }
            return true;
        }

        private static string GetQuickVaultFolder(string defaultFolder)
        {
            Console.WriteLine("Enter the folder containing an existing QuickVault or where you want a new one");
            Console.Write($"Press enter to use '{defaultFolder}': ");
            string folder = Console.ReadLine().Trim('\'', '\"');
            folder = string.IsNullOrWhiteSpace(folder) ? defaultFolder : folder;
            if (!Directory.Exists(folder))
            {
                Console.WriteLine($"Folder: {folder} does not exist. Please try again.");
                return GetQuickVaultFolder(folder);
            }
            return folder;
        }
    }
}
