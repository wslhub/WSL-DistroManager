using DistroManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Security.Principal;

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
        
        public static bool IsAdministrator()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            WindowsPrincipal wp = new WindowsPrincipal(wi);
            return wp.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static IEnumerable<KeyValuePair<string, string>> ParseEnvironmentVariables(IEnumerable<string> expressions)
        {
            var defaultEnvironment = new List<KeyValuePair<string, string>>(expressions.Count());

            if (expressions == null || expressions.Count() < 1)
                return defaultEnvironment;

            foreach (var eachLine in expressions)
            {
                var separatorIndex = eachLine.IndexOf('=', 0);

                if (separatorIndex < 0)
                {
                    defaultEnvironment.Add(new KeyValuePair<string, string>(eachLine, String.Empty));
                }
                else
                {
                    defaultEnvironment.Add(new KeyValuePair<string, string>(
                        eachLine.Substring(0, separatorIndex),
                        eachLine.Substring(separatorIndex + 1)));
                }
            }

            return defaultEnvironment;
        }
    }
}
