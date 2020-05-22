using System;
using QuickVault;

namespace QuickVaultTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new VaultReader();
            foreach (var key in reader.Keys)
            {
                Console.WriteLine($"{key} = {reader[key]}");
            }
            Console.ReadLine();
        }
    }
}
