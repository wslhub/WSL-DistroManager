using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
                Properties.Resources.MSG_ERROR_CODE,
                hr, new Win32Exception(hr).Message);
            Console.Error.WriteLine(message);
        }

        public static void PromptForInput()
        {
            Console.Out.WriteLine(Properties.Resources.MSG_PRESS_A_KEY);
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

        public static bool IsWslInstalledProperly()
        {
            IntPtr wslApiDll;
            NativeMethods.WSL_IS_DISTRIBUTION_REGISTERED isDistributionRegistered;
            NativeMethods.WSL_REGISTER_DISTRIBUTION registerDistribution;
            NativeMethods.WSL_UNREGISTER_DISTRIBUTION unregisterDistribution;
            NativeMethods.WSL_CONFIGURE_DISTRIBUTION configureDistribution;
            NativeMethods.WSL_LAUNCH_INTERACTIVE launchInteractive;
            NativeMethods.WSL_LAUNCH launch;

            wslApiDll = NativeMethods.LoadLibraryEx("wslapi.dll", IntPtr.Zero, NativeMethods.LOAD_LIBRARY_SEARCH_SYSTEM32);
            isDistributionRegistered = null;
            registerDistribution = null;
            unregisterDistribution = null;
            configureDistribution = null;
            launchInteractive = null;
            launch = null;

            if (wslApiDll != IntPtr.Zero)
            {
                isDistributionRegistered = (NativeMethods.WSL_IS_DISTRIBUTION_REGISTERED)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(wslApiDll, "WslIsDistributionRegistered"), typeof(NativeMethods.WSL_IS_DISTRIBUTION_REGISTERED));
                registerDistribution = (NativeMethods.WSL_REGISTER_DISTRIBUTION)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(wslApiDll, "WslRegisterDistribution"), typeof(NativeMethods.WSL_REGISTER_DISTRIBUTION));
                unregisterDistribution = (NativeMethods.WSL_UNREGISTER_DISTRIBUTION)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(wslApiDll, "WslUnregisterDistribution"), typeof(NativeMethods.WSL_UNREGISTER_DISTRIBUTION));
                configureDistribution = (NativeMethods.WSL_CONFIGURE_DISTRIBUTION)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(wslApiDll, "WslConfigureDistribution"), typeof(NativeMethods.WSL_CONFIGURE_DISTRIBUTION));
                launchInteractive = (NativeMethods.WSL_LAUNCH_INTERACTIVE)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(wslApiDll, "WslLaunchInteractive"), typeof(NativeMethods.WSL_LAUNCH_INTERACTIVE));
                launch = (NativeMethods.WSL_LAUNCH)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(wslApiDll, "WslLaunch"), typeof(NativeMethods.WSL_LAUNCH));

                bool testResult = isDistributionRegistered != null &&
                    registerDistribution != null &&
                    unregisterDistribution != null &&
                    configureDistribution != null &&
                    launchInteractive != null &&
                    launch != null;

                NativeMethods.FreeLibrary(wslApiDll);
                wslApiDll = IntPtr.Zero;
                return testResult;
            }

            return false;
        }
    }
}
