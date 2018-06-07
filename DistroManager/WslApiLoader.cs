using System;
using System.Runtime.InteropServices;

namespace DistroManager
{
    internal sealed class WslApiLoader : IDisposable
    {
        internal static class NativeMethods
        {
            public static readonly uint LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800u;

            [DllImport("kernel32.dll", EntryPoint = "LoadLibraryExW", CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, uint dwFlags);

            [DllImport("kernel32.dll", EntryPoint = "GetProcAddress", CharSet = CharSet.Ansi, ExactSpelling = true)]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

            [DllImport("kernel32.dll", EntryPoint = "FreeLibrary", ExactSpelling = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool FreeLibrary(IntPtr hModule);
        }

        [Flags]
        internal enum WSL_DISTRIBUTION_FLAGS : uint
        {
            WSL_DISTRIBUTION_FLAGS_NONE = 0,
            WSL_DISTRIBUTION_FLAGS_ENABLE_INTEROP = 1,
            WSL_DISTRIBUTION_FLAGS_APPEND_NT_PATH = 2,
            WSL_DISTRIBUTION_FLAGS_ENABLE_DRIVE_MOUNTING = 4,

            WSL_DISTRIBUTION_FLAGS_DEFAULT = (WSL_DISTRIBUTION_FLAGS_ENABLE_INTEROP | WSL_DISTRIBUTION_FLAGS_APPEND_NT_PATH | WSL_DISTRIBUTION_FLAGS_ENABLE_DRIVE_MOUNTING)
        }

        [UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal delegate bool WSL_IS_DISTRIBUTION_REGISTERED(string distroName);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
        internal delegate uint WSL_REGISTER_DISTRIBUTION(string distroName, string tarGzFilename);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
        internal delegate uint WSL_CONFIGURE_DISTRIBUTION(string distroName, uint defaultUID, WSL_DISTRIBUTION_FLAGS wslFlags);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
        internal delegate uint WSL_LAUNCH_INTERACTIVE(string distroName, string command, [MarshalAs(UnmanagedType.Bool)] bool useCurrentWorkingDirectory, out uint pExitCode);
        
        [UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
        internal delegate uint WSL_LAUNCH(string distroName, string command, [MarshalAs(UnmanagedType.Bool)] bool useCurrentWorkingDirectory, IntPtr hStdIn, IntPtr hStdOut, IntPtr hStdErr, out IntPtr phProcess);

        private bool _disposed;
        private string _distributionName;
        private IntPtr _wslApiDll;
        private WSL_IS_DISTRIBUTION_REGISTERED _isDistributionRegistered;
        private WSL_REGISTER_DISTRIBUTION _registerDistribution;
        private WSL_CONFIGURE_DISTRIBUTION _configureDistribution;
        private WSL_LAUNCH_INTERACTIVE _launchInteractive;
        private WSL_LAUNCH _launch;

        public WslApiLoader(string distributionName = "")
        {
            _distributionName = distributionName;
            _wslApiDll = NativeMethods.LoadLibraryEx("wslapi.dll", IntPtr.Zero, NativeMethods.LOAD_LIBRARY_SEARCH_SYSTEM32);

            if (_wslApiDll != IntPtr.Zero)
            {
                _isDistributionRegistered = (WSL_IS_DISTRIBUTION_REGISTERED)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(_wslApiDll, "WslIsDistributionRegistered"), typeof(WSL_IS_DISTRIBUTION_REGISTERED));
                _registerDistribution = (WSL_REGISTER_DISTRIBUTION)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(_wslApiDll, "WslRegisterDistribution"), typeof(WSL_REGISTER_DISTRIBUTION));
                _configureDistribution = (WSL_CONFIGURE_DISTRIBUTION)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(_wslApiDll, "WslConfigureDistribution"), typeof(WSL_CONFIGURE_DISTRIBUTION));
                _launchInteractive = (WSL_LAUNCH_INTERACTIVE)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(_wslApiDll, "WslLaunchInteractive"), typeof(WSL_LAUNCH_INTERACTIVE));
                _launch = (WSL_LAUNCH)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(_wslApiDll, "WslLaunch"), typeof(WSL_LAUNCH));
            }
        }

        ~WslApiLoader()
        {
            Dispose(false);
        }

        public bool WslIsOptionalComponentInstalled()
        {
            return (_wslApiDll != IntPtr.Zero &&
                _isDistributionRegistered != null &&
                _registerDistribution != null &&
                _configureDistribution != null &&
                _launchInteractive != null &&
                _launch != null);
        }

        public bool WslIsDistributionRegistered()
        {
            return _isDistributionRegistered(_distributionName);
        }

        public uint WslRegisterDistribution()
        {
            uint hr = _registerDistribution(_distributionName, "install.tar.gz");

            if (((int)hr) < 0)
                Helpers.PrintMessage(Messages.MSG_WSL_REGISTER_DISTRIBUTION_FAILED, hr);

            return hr;
        }

        public uint WslConfigureDistribution(uint defaultUID, WSL_DISTRIBUTION_FLAGS wslDistributionFlags)
        {
            uint hr = _configureDistribution(_distributionName, defaultUID, wslDistributionFlags);

            if (((int)hr) < 0)
                Helpers.PrintMessage(Messages.MSG_WSL_CONFIGURE_DISTRIBUTION_FAILED, hr);

            return hr;
        }

        public uint WslLaunchInteractive(string command, bool useCurrentWorkingDirectory, out uint exitCode)
        {
            uint hr = _launchInteractive(_distributionName, command, useCurrentWorkingDirectory, out exitCode);

            if (((int)hr) < 0)
                Helpers.PrintMessage(Messages.MSG_WSL_LAUNCH_INTERACTIVE_FAILED, command, hr);

            return hr;
        }

        public uint WslLaunch(string command, bool useCurrentWorkingDirectory, IntPtr stdIn, IntPtr stdOut, IntPtr stdErr, out IntPtr process)
        {
            uint hr = _launch(_distributionName, command, useCurrentWorkingDirectory, stdIn, stdOut, stdErr, out process);

            if (((int)hr) < 0)
                Helpers.PrintMessage(Messages.MSG_WSL_LAUNCH_FAILED, hr);

            return hr;
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects).
                }

                // Free unmanaged resources (unmanaged objects) and override a finalizer below.
                if (_wslApiDll != IntPtr.Zero)
                {
                    NativeMethods.FreeLibrary(_wslApiDll);
                    _wslApiDll = IntPtr.Zero;
                }

                // Set large fields to null.
                _isDistributionRegistered = null;
                _registerDistribution = null;
                _configureDistribution = null;
                _launchInteractive = null;
                _launch = null;

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
