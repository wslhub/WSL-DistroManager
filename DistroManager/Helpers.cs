using System;
using System.ComponentModel;
using System.Globalization;

namespace DistroManager
{
    internal static class Helpers
    {
        public static string GetUserInput(int promptMsg)
        {
            string message = String.Format(
                CultureInfo.InvariantCulture,
                Messages.MessageTable_English[promptMsg]);
            Console.Out.Write(message);
            return Console.In.ReadLine();
        }

        public static void PrintErrorMessage(uint hr)
        {
            string message = String.Format(
                CultureInfo.InvariantCulture,
                Messages.MessageTable_English[Messages.MSG_ERROR_CODE],
                hr, new Win32Exception((int)hr).Message);
            Console.Out.WriteLine(message);
        }

        public static void PrintMessage(int messageId, params object[] parameters)
        {
            string message = String.Format(
                CultureInfo.InvariantCulture,
                Messages.MessageTable_English[messageId],
                parameters);
            Console.Out.WriteLine(message);
        }

        public static void PromptForInput()
        {
            PrintMessage(Messages.MSG_PRESS_A_KEY);
            Console.ReadKey();
        }
    }
}
