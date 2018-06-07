using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DistroManager
{
    internal static class Program
    {
        internal static class NativeMethods
        {
            public static readonly uint UID_INVALID = unchecked((uint)-1);

            public static readonly uint E_INVALIDARG = 0x80070057;

            public static readonly uint S_OK = 0x00000000u;

            public static readonly uint FACILITY_WIN32 = 7u;

            public static readonly uint ERROR_ALREADY_EXISTS = 0xB7u;

            public static readonly uint ERROR_LINUX_SUBSYSTEM_NOT_PRESENT = 414;

            public static uint HRESULT_FROM_WIN32(uint x)
            {
                return (uint)(x) <= 0 ? (uint)(x) : (uint) (((x) & 0x0000FFFF) | (FACILITY_WIN32 << 16) | 0x80000000);
            }

            [DllImport("kernel32.dll", ExactSpelling = true, EntryPoint = "SetConsoleTitleW", CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetConsoleTitleW(string lpConsoleTitle);
        }

        public static readonly string ARG_CONFIG = "config";
        public static readonly string ARG_CONFIG_DEFAULT_USER = "--default-user";
        public static readonly string ARG_INSTALL = "install";
        public static readonly string ARG_INSTALL_ROOT = "--root";
        public static readonly string ARG_RUN = "run";
        public static readonly string ARG_RUN_C = "-c";

        public static readonly WslApiLoader g_wslApi = new WslApiLoader(DistributionInfo.Name);

        [STAThread]
        private static int Main(string[] args)
        {
            NativeMethods.SetConsoleTitleW(DistributionInfo.WindowTitle);
            List<string> arguments = new List<string>(args);

            uint exitCode = 1u;
            if (!g_wslApi.WslIsOptionalComponentInstalled())
            {
                Helpers.PrintMessage(Messages.MSG_MISSING_OPTIONAL_COMPONENT);
                if (arguments.Count < 1)
                    Helpers.PromptForInput();

                return (int)exitCode;
            }

            bool installOnly = (arguments.Count > 0 && arguments[0] == ARG_INSTALL);
            uint hr = NativeMethods.S_OK;
            
            if (!g_wslApi.WslIsDistributionRegistered())
            {
                bool useRoot = (installOnly && arguments.Count > 1 && arguments[1] == ARG_INSTALL_ROOT);
                hr = InstallDistribution(!useRoot);

                if (((int)hr) < 0)
                {
                    if (NativeMethods.HRESULT_FROM_WIN32(NativeMethods.ERROR_ALREADY_EXISTS) == hr)
                    {
                        Helpers.PrintMessage(Messages.MSG_INSTALL_ALREADY_EXISTS);
                    }
                }
                else
                {
                    Helpers.PrintMessage(Messages.MSG_INSTALL_SUCCESS);
                }

                exitCode = (hr >= 0) ? 0u : 1u;
            }

            if (hr >= 0u && !installOnly)
            {
                if (arguments.Count < 1)
                {
                    hr = g_wslApi.WslLaunchInteractive("", false, out exitCode);
                }
                else if (arguments[0].Equals(ARG_RUN) || arguments[0].Equals(ARG_RUN_C))
                {
                    string command = String.Join(" ", arguments);
                    hr = g_wslApi.WslLaunchInteractive(command, true, out exitCode);
                }
                else if (arguments[0].Equals(ARG_CONFIG))
                {
                    hr = NativeMethods.E_INVALIDARG;
                    if (arguments.Count == 3)
                    {
                        if (arguments[1] == ARG_CONFIG_DEFAULT_USER)
                        {
                            hr = SetDefaultUser(arguments[2]);
                        }
                    }

                    if (hr >= 0)
                        exitCode = 0;
                }
                else
                {
                    Helpers.PrintMessage(Messages.MSG_USAGE);
                    return (int)exitCode;
                }
            }

            if (((int)hr) < 0)
            {
                if (NativeMethods.HRESULT_FROM_WIN32(NativeMethods.ERROR_LINUX_SUBSYSTEM_NOT_PRESENT) == hr)
                {
                    Helpers.PrintMessage(Messages.MSG_MISSING_OPTIONAL_COMPONENT);
                }
                else
                {
                    Helpers.PrintErrorMessage(hr);
                }

                if (arguments.Count < 1)
                {
                    Helpers.PromptForInput();
                }
            }

            return hr >= 0 ? (int)exitCode : 1;
        }

        public static uint InstallDistribution(bool createUser)
        {
            Helpers.PrintMessage(Messages.MSG_STATUS_INSTALLING);
            uint hr = g_wslApi.WslRegisterDistribution();
            if (((int)hr) < 0)
            {
                return hr;
            }

            uint exitCode;
            hr = g_wslApi.WslLaunchInteractive("/bin/rm /etc/resolv.conf", true, out exitCode);
            if (((int)hr) < 0)
            {
                return hr;
            }

            if (createUser)
            {
                Helpers.PrintMessage(Messages.MSG_CREATE_USER_PROMPT);
                string userName;

                do
                {
                    userName = Helpers.GetUserInput(Messages.MSG_ENTER_USERNAME);
                }
                while (!DistributionInfo.CreateUser(userName));

                hr = SetDefaultUser(userName);
                if (((int)hr) < 0)
                    return hr;
            }

            return hr;
        }

        public static uint SetDefaultUser(string userName)
        {
            uint uid = DistributionInfo.QueryUid(userName);
            if (uid == NativeMethods.UID_INVALID)
            {
                return NativeMethods.E_INVALIDARG;
            }

            uint hr = g_wslApi.WslConfigureDistribution(uid, WslApiLoader.WSL_DISTRIBUTION_FLAGS.WSL_DISTRIBUTION_FLAGS_DEFAULT);

            if (((int)hr) < 0)
                return hr;

            return hr;
        }
    }
}
