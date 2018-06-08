using DistroManager.Properties;
using System;
using System.ComponentModel;
using System.Globalization;

namespace DistroManager
{
    internal static class Helpers
    {
        public static string GetUserInput(string template)
        {
            string message = String.Format(
                CultureInfo.InvariantCulture,
                template);
            Console.Out.Write(message);
            return Console.In.ReadLine();
        }

        public static void PrintErrorMessage(int hr)
        {
            string message = String.Format(
                CultureInfo.InvariantCulture,
                Resources.MSG_ERROR_CODE,
                hr, new Win32Exception(hr).Message);
            Console.Error.WriteLine(message);
        }

        public static void PromptForInput()
        {
            Console.Out.WriteLine(Resources.MSG_PRESS_A_KEY);
            Console.ReadKey();
        }
    }
}
