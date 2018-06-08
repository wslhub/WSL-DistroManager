using System;
using System.Collections.Generic;

namespace DistroManager
{
    internal static class Program
    {
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
                if (NativeMethods.IS_EMPTY(arguments))
                    Helpers.PromptForInput();

                return (int)exitCode;
            }

            bool installOnly = (arguments.Count > 0 && arguments[0] == ARG_INSTALL);
            uint hr = NativeMethods.S_OK;
            
            if (!g_wslApi.WslIsDistributionRegistered())
            {
                bool useRoot = (installOnly && arguments.Count > 1 && arguments[1] == ARG_INSTALL_ROOT);
                hr = InstallDistribution(!useRoot);

                if (NativeMethods.FAILED(hr))
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

                exitCode = (NativeMethods.SUCCEED(hr)) ? 0u : 1u;
            }

            if (NativeMethods.SUCCEED(hr) && !installOnly)
            {
                if (NativeMethods.IS_EMPTY(arguments))
                {
                    hr = g_wslApi.WslLaunchInteractive(String.Empty, false, out exitCode);
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

                    if (NativeMethods.SUCCEED(hr))
                        exitCode = 0;
                }
                else
                {
                    Helpers.PrintMessage(Messages.MSG_USAGE);
                    return (int)exitCode;
                }
            }

            if (NativeMethods.FAILED(hr))
            {
                if (NativeMethods.HRESULT_FROM_WIN32(NativeMethods.ERROR_LINUX_SUBSYSTEM_NOT_PRESENT) == hr)
                {
                    Helpers.PrintMessage(Messages.MSG_MISSING_OPTIONAL_COMPONENT);
                }
                else
                {
                    Helpers.PrintErrorMessage(hr);
                }

                if (NativeMethods.IS_EMPTY(arguments))
                {
                    Helpers.PromptForInput();
                }
            }

            return NativeMethods.SUCCEED(hr) ? (int)exitCode : 1;
        }

        public static uint InstallDistribution(bool createUser)
        {
            Helpers.PrintMessage(Messages.MSG_STATUS_INSTALLING);
            uint hr = g_wslApi.WslRegisterDistribution();
            if (NativeMethods.FAILED(hr))
            {
                return hr;
            }

            uint exitCode;
            hr = g_wslApi.WslLaunchInteractive("/bin/rm /etc/resolv.conf", true, out exitCode);
            if (NativeMethods.FAILED(hr))
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
                if (NativeMethods.FAILED(hr))
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

            uint hr = g_wslApi.WslConfigureDistribution(uid, NativeMethods.WSL_DISTRIBUTION_FLAGS.WSL_DISTRIBUTION_FLAGS_DEFAULT);

            if (NativeMethods.FAILED(hr))
                return hr;

            return hr;
        }
    }
}
