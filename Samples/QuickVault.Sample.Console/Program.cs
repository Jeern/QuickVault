using System;
using System.Diagnostics;
using QuickVault.Configuration;

namespace QuickVault.Sample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Reading AppSettings");
                Console.WriteLine("DemoProp1: {0}", QuickVaultConfigurationManager.AppSettings["DemoProp1"]);
                Console.WriteLine("DemoProp2: {0}", QuickVaultConfigurationManager.AppSettings["DemoProp2"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (Debugger.IsAttached)
            {
                Console.ReadLine();
            }
        }
    }
}
