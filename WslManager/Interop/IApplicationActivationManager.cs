using System;
using System.Runtime.InteropServices;

namespace WslManager.Interop
{
    // https://stackoverflow.com/questions/12925748/iapplicationactivationmanageractivateapplication-in-c
    [ComImport, Guid("2e941141-7f97-4756-ba1d-9decde894a3d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IApplicationActivationManager
    {
        // Activates the specified immersive application for the "Launch" contract, passing the provided arguments
        // string into the application.  Callers can obtain the process Id of the application instance fulfilling this contract.
        IntPtr ActivateApplication([In] string appUserModelId, [In] string arguments, [In] ActivateOptions options, [Out] out uint processId);
        IntPtr ActivateForFile([In] string appUserModelId, [In] IntPtr /*IShellItemArray* */ itemArray, [In] string verb, [Out] out uint processId);
        IntPtr ActivateForProtocol([In] string appUserModelId, [In] IntPtr /* IShellItemArray* */itemArray, [Out] out uint processId);
    }
}
