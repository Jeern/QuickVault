using System;

namespace QuickVaultTool
{
    public static class InputHelper
    {
        public static string GetEnteredValue()
        {
            Output.Flush();
            string value = null;
            do
            {
                value = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(value));
            return value.Trim();
        }
    }
}
