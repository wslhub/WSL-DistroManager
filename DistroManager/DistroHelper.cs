using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Text;

namespace DistroManager
{
    internal static class DistroHelper
    {
        public static bool CreateUser(Distro wslApi, string userName)
        {
            string commandLine = $"/usr/sbin/adduser --quiet --gecos '' {userName}";
            int hr = wslApi.LaunchInteractive(commandLine, true, out int exitCode);

            if (NativeMethods.FAILED(hr) || exitCode != 0u)
                return false;

            commandLine = $"/usr/sbin/usermod -aG adm,cdrom,sudo,dip,plugdev {userName}";
            hr = wslApi.LaunchInteractive(commandLine, true, out exitCode);

            if (NativeMethods.FAILED(hr) || exitCode != 0u)
            {
                commandLine = $"/usr/sbin/deluser {userName}";
                wslApi.LaunchInteractive(commandLine, true, out exitCode);
                return false;
            }

            return true;
        }

        public static int QueryUid(Distro wslApi, string userName)
        {
            IntPtr readPipe = new IntPtr();
            IntPtr writePipe = new IntPtr();
            
            var sa = new NativeMethods.SECURITY_ATTRIBUTES();
            sa.nLength = Marshal.SizeOf(sa);
            sa.lpSecurityDescriptor = IntPtr.Zero;
            sa.bInheritHandle = true;

            int uid = NativeMethods.UID_INVALID;

            IntPtr attr = Marshal.AllocHGlobal(Marshal.SizeOf(sa));
            try
            {
                Marshal.StructureToPtr(sa, attr, true);

                if (NativeMethods.CreatePipe(ref readPipe, ref writePipe, attr, 0))
                {
                    string command = $"/usr/bin/id -u {userName}";
                    int hr = wslApi.Launch(command, true, NativeMethods.GetStdHandle(NativeMethods.STD_INPUT_HANDLE), writePipe, NativeMethods.GetStdHandle(NativeMethods.STD_ERROR_HANDLE), out IntPtr child);

                    if (NativeMethods.SUCCEED(hr))
                    {
                        NativeMethods.WaitForSingleObject(child, NativeMethods.INFINITE);

                        if (NativeMethods.GetExitCodeProcess(child, out int exitCode) == false)
                            hr = NativeMethods.E_INVALIDARG;

                        NativeMethods.CloseHandle(child);

                        if (NativeMethods.SUCCEED(hr))
                        {
                            int bufferLength = 64;
                            IntPtr buffer = Marshal.AllocHGlobal(bufferLength);
                            NativeMethods.ZeroMemory(buffer, bufferLength);

                            if (NativeMethods.ReadFile(readPipe, buffer, bufferLength - 1, out int bytesRead, IntPtr.Zero))
                            {
                                byte[] content = new byte[bytesRead];
                                Marshal.Copy(buffer, content, 0, bytesRead);

                                if (!Int32.TryParse(
                                    Encoding.ASCII.GetString(content, 0, bytesRead),
                                    out uid))
                                {
                                    uid = NativeMethods.UID_INVALID;
                                }
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

            return uid;
        }
    }
}
