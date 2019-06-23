using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WslManager.Interop
{
    // https://stackoverflow.com/questions/12925748/iapplicationactivationmanageractivateapplication-in-c
    [ComImport, Guid("45BA127D-10A8-46EA-8AB7-56EA9078943C")]//Application Activation Manager
    public class ApplicationActivationManager : IApplicationActivationManager
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)/*, PreserveSig*/]
        public extern IntPtr ActivateApplication([In] string appUserModelId, [In] string arguments, [In] ActivateOptions options, [Out] out uint processId);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern IntPtr ActivateForFile([In] string appUserModelId, [In] IntPtr /*IShellItemArray* */ itemArray, [In] string verb, [Out] out uint processId);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern IntPtr ActivateForProtocol([In] string appUserModelId, [In] IntPtr /* IShellItemArray* */itemArray, [Out] out uint processId);
    }
}
