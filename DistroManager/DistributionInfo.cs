using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Text;

namespace DistroManager
{
    internal class DistributionInfo
    {
        public static readonly string Name = ConfigurationManager.AppSettings["DistroName"];

        public static readonly string WindowTitle = ConfigurationManager.AppSettings["DistroDisplayName"];

        public static bool CreateUser(WslApiLoader wslApi, string userName)
        {
            uint exitCode;
            string commandLine = "/usr/sbin/adduser --quiet --gecos '' ";
            commandLine += userName;
            uint hr = wslApi.WslLaunchInteractive(commandLine, true, out exitCode);

            if (NativeMethods.FAILED(hr) || exitCode != 0u)
                return false;

            commandLine = "/usr/sbin/usermod -aG adm,cdrom,sudo,dip,plugdev ";
            commandLine += userName;
            hr = wslApi.WslLaunchInteractive(commandLine, true, out exitCode);

            if (NativeMethods.FAILED(hr) || exitCode != 0u)
            {
                commandLine = "/usr/sbin/deluser ";
                commandLine += userName;
                wslApi.WslLaunchInteractive(commandLine, true, out exitCode);
                return false;
            }

            return true;
        }

        public static uint QueryUid(WslApiLoader wslApi, string userName)
        {
            IntPtr readPipe = new IntPtr();
            IntPtr writePipe = new IntPtr();
            
            NativeMethods.SECURITY_ATTRIBUTES sa = new NativeMethods.SECURITY_ATTRIBUTES();
            sa.nLength = (uint)Marshal.SizeOf(sa);
            sa.lpSecurityDescriptor = IntPtr.Zero;
            sa.bInheritHandle = true;
            uint uid = NativeMethods.UID_INVALID;

            IntPtr attr = Marshal.AllocHGlobal(Marshal.SizeOf(sa));
            try
            {
                Marshal.StructureToPtr(sa, attr, true);

                if (NativeMethods.CreatePipe(ref readPipe, ref writePipe, attr, 0))
                {
                    string command = "/usr/bin/id -u ";
                    command += userName;
                    IntPtr child;
                    uint hr = wslApi.WslLaunch(command, true, NativeMethods.GetStdHandle(NativeMethods.STD_INPUT_HANDLE), writePipe, NativeMethods.GetStdHandle(NativeMethods.STD_ERROR_HANDLE), out child);

                    if (NativeMethods.SUCCEED(hr))
                    {
                        NativeMethods.WaitForSingleObject(child, NativeMethods.INFINITE);
                        uint exitCode;

                        if (NativeMethods.GetExitCodeProcess(child, out exitCode) == false)
                        {
                            hr = NativeMethods.E_INVALIDARG;
                        }

                        NativeMethods.CloseHandle(child);

                        if (NativeMethods.SUCCEED(hr))
                        {
                            int bufferLength = 64;
                            IntPtr buffer = Marshal.AllocHGlobal(bufferLength);
                            NativeMethods.ZeroMemory(buffer, bufferLength);
                            int bytesRead;

                            if (NativeMethods.ReadFile(readPipe, buffer, bufferLength - 1, out bytesRead, IntPtr.Zero))
                            {
                                byte[] content = new byte[bytesRead];
                                Marshal.Copy(buffer, content, 0, bytesRead);
                                UInt32.TryParse(
                                    Encoding.ASCII.GetString(content, 0, bytesRead),
                                    out uid);
                            }

                            Marshal.FreeHGlobal(buffer);
                            buffer = IntPtr.Zero;
                        }
                    }

                    NativeMethods.CloseHandle(readPipe);
                    NativeMethods.CloseHandle(writePipe);
                }
            }
            finally
            {
                if (attr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(attr);
                    attr = IntPtr.Zero;
                }
            }

            return 0u;
        }
    }
}
