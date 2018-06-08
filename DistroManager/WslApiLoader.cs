using System;
using System.Runtime.InteropServices;

namespace DistroManager
{
    internal sealed class WslApiLoader : IDisposable
    {
        private bool _disposed;
        private string _distributionName;
        private IntPtr _wslApiDll;
        private NativeMethods.WSL_IS_DISTRIBUTION_REGISTERED _isDistributionRegistered;
        private NativeMethods.WSL_REGISTER_DISTRIBUTION _registerDistribution;
        private NativeMethods.WSL_CONFIGURE_DISTRIBUTION _configureDistribution;
        private NativeMethods.WSL_LAUNCH_INTERACTIVE _launchInteractive;
        private NativeMethods.WSL_LAUNCH _launch;

        public WslApiLoader(string distributionName)
        {
            _distributionName = distributionName;
            _wslApiDll = NativeMethods.LoadLibraryEx("wslapi.dll", IntPtr.Zero, NativeMethods.LOAD_LIBRARY_SEARCH_SYSTEM32);

            if (_wslApiDll != IntPtr.Zero)
            {
                _isDistributionRegistered = (NativeMethods.WSL_IS_DISTRIBUTION_REGISTERED)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(_wslApiDll, "WslIsDistributionRegistered"), typeof(NativeMethods.WSL_IS_DISTRIBUTION_REGISTERED));
                _registerDistribution = (NativeMethods.WSL_REGISTER_DISTRIBUTION)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(_wslApiDll, "WslRegisterDistribution"), typeof(NativeMethods.WSL_REGISTER_DISTRIBUTION));
                _configureDistribution = (NativeMethods.WSL_CONFIGURE_DISTRIBUTION)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(_wslApiDll, "WslConfigureDistribution"), typeof(NativeMethods.WSL_CONFIGURE_DISTRIBUTION));
                _launchInteractive = (NativeMethods.WSL_LAUNCH_INTERACTIVE)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(_wslApiDll, "WslLaunchInteractive"), typeof(NativeMethods.WSL_LAUNCH_INTERACTIVE));
                _launch = (NativeMethods.WSL_LAUNCH)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(_wslApiDll, "WslLaunch"), typeof(NativeMethods.WSL_LAUNCH));
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

        public uint WslConfigureDistribution(uint defaultUID, NativeMethods.WSL_DISTRIBUTION_FLAGS wslDistributionFlags)
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
