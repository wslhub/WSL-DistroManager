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

        public int WslRegisterDistribution()
        {
            int hr = _registerDistribution(_distributionName, "install.tar.gz");

            if (NativeMethods.FAILED(hr))
                Helpers.PrintMessage(Messages.MSG_WSL_REGISTER_DISTRIBUTION_FAILED, hr);

            return hr;
        }

        public int WslConfigureDistribution(int defaultUID, NativeMethods.WSL_DISTRIBUTION_FLAGS wslDistributionFlags)
        {
            int hr = _configureDistribution(_distributionName, defaultUID, wslDistributionFlags);

            if (NativeMethods.FAILED(hr))
                Helpers.PrintMessage(Messages.MSG_WSL_CONFIGURE_DISTRIBUTION_FAILED, hr);

            return hr;
        }

        public int WslLaunchInteractive(string command, bool useCurrentWorkingDirectory, out int exitCode)
        {
            int hr = _launchInteractive(_distributionName, command, useCurrentWorkingDirectory, out exitCode);

            if (NativeMethods.FAILED(hr))
                Helpers.PrintMessage(Messages.MSG_WSL_LAUNCH_INTERACTIVE_FAILED, command, hr);

            return hr;
        }

        public int WslLaunch(string command, bool useCurrentWorkingDirectory, IntPtr stdIn, IntPtr stdOut, IntPtr stdErr, out IntPtr process)
        {
            int hr = _launch(_distributionName, command, useCurrentWorkingDirectory, stdIn, stdOut, stdErr, out process);

            if (NativeMethods.FAILED(hr))
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
