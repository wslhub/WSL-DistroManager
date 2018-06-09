using DistroManager.Properties;
using System;

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

        [STAThread]
        private static int Main(string[] arguments)
        {
            using (Distro wslApi = new Distro(DistributionInfo.Name))
            {
                NativeMethods.SetConsoleTitleW(DistributionInfo.WindowTitle);

                int exitCode = 1;
                if (!wslApi.IsOptionalComponentInstalled)
                {
                    Console.Out.WriteLine(Resources.MSG_MISSING_OPTIONAL_COMPONENT);
                    if (arguments.Length < 1)
                        Helpers.PromptForInput();

                    return (int)exitCode;
                }

                bool installOnly = (arguments.Length > 0 && arguments[0] == ARG_INSTALL);
                int hr = NativeMethods.S_OK;
            
                if (!wslApi.IsDistributionRegistered)
                {
                    bool useRoot = (installOnly && arguments.Length > 1 && arguments[1] == ARG_INSTALL_ROOT);
                    hr = InstallDistribution(wslApi, !useRoot);

                    if (NativeMethods.FAILED(hr))
                    {
                        if (NativeMethods.HRESULT_FROM_WIN32(NativeMethods.ERROR_ALREADY_EXISTS) == hr)
                        {
                            Console.Out.WriteLine(Resources.MSG_INSTALL_ALREADY_EXISTS);
                        }
                    }
                    else
                    {
                        Console.Out.WriteLine(Resources.MSG_INSTALL_SUCCESS);
                    }

                    exitCode = (NativeMethods.SUCCEED(hr)) ? 0 : 1;
                }

                if (NativeMethods.SUCCEED(hr) && !installOnly)
                {
                    if (arguments.Length < 1)
                    {
                        hr = wslApi.LaunchInteractive(String.Empty, false, out exitCode);
                    }
                    else if (arguments[0].Equals(ARG_RUN) || arguments[0].Equals(ARG_RUN_C))
                    {
                        string command = String.Join(" ", arguments);
                        hr = wslApi.LaunchInteractive(command, true, out exitCode);
                    }
                    else if (arguments[0].Equals(ARG_CONFIG))
                    {
                        hr = NativeMethods.E_INVALIDARG;
                        if (arguments.Length == 3)
                        {
                            if (arguments[1] == ARG_CONFIG_DEFAULT_USER)
                            {
                                hr = SetDefaultUser(wslApi, arguments[2]);
                            }
                        }

                        if (NativeMethods.SUCCEED(hr))
                            exitCode = 0;
                    }
                    else
                    {
                        Console.Out.WriteLine(Resources.MSG_USAGE);
                        return (int)exitCode;
                    }
                }

                if (NativeMethods.FAILED(hr))
                {
                    if (NativeMethods.HRESULT_FROM_WIN32(NativeMethods.ERROR_LINUX_SUBSYSTEM_NOT_PRESENT) == hr)
                    {
                        Console.Out.WriteLine(Resources.MSG_MISSING_OPTIONAL_COMPONENT);
                    }
                    else
                    {
                        Helpers.PrintErrorMessage(hr);
                    }

                    if (arguments.Length < 1)
                    {
                        Helpers.PromptForInput();
                    }
                }

                return NativeMethods.SUCCEED(hr) ? (int)exitCode : 1;
            }
        }

        public static int InstallDistribution(Distro wslApi, bool createUser)
        {
            if (!Helpers.IsAdministrator())
            {
                Console.Error.WriteLine(Resources.MSG_INSUFFICIENT_RIGHTS);
                return NativeMethods.E_ACCESSDENIED;
            }

            Console.Out.WriteLine(Resources.MSG_STATUS_INSTALLING);
            int hr = wslApi.RegisterDistro();
            if (NativeMethods.FAILED(hr))
            {
                return hr;
            }

            int exitCode;
            hr = wslApi.LaunchInteractive("/bin/rm /etc/resolv.conf", true, out exitCode);
            if (NativeMethods.FAILED(hr))
            {
                return hr;
            }

            if (createUser)
            {
                Console.Out.WriteLine(Resources.MSG_CREATE_USER_PROMPT);
                string userName;

                do
                {
                    userName = Helpers.GetUserInput(Resources.MSG_ENTER_USERNAME);
                }
                while (!DistributionInfo.CreateUser(wslApi, userName));

                hr = SetDefaultUser(wslApi, userName);
                if (NativeMethods.FAILED(hr))
                    return hr;
            }

            return hr;
        }

        public static int SetDefaultUser(Distro wslApi, string userName)
        {
            int uid = DistributionInfo.QueryUid(wslApi, userName);
            if (uid == NativeMethods.UID_INVALID)
            {
                return NativeMethods.E_INVALIDARG;
            }
            
            int hr = wslApi.ConfigDistro(uid, NativeMethods.WSL_DISTRIBUTION_FLAGS.WSL_DISTRIBUTION_FLAGS_DEFAULT);

            if (NativeMethods.FAILED(hr))
                return hr;

            return hr;
        }
    }
}
