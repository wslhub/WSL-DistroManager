using System;
using System.Runtime.InteropServices;

namespace WslManager.Interop
{
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("536a6bcf-fe04-41d9-b978-dcaca9a9b5b9")]
    public interface ILxssSession
    {
        [return: MarshalAs(UnmanagedType.Interface)]
        ILxssInstance GetCurrentInstance();

        [return: MarshalAs(UnmanagedType.Interface)]
        ILxssInstance StartDefaultInstance([In] ref Guid InstanceIid);

        [PreserveSig]
        uint SetState();

        [PreserveSig]
        LxssSessionState QueryState();

        [PreserveSig]
        uint InitializeFileSystem();

        [PreserveSig]
        uint Destroy();
    }
}
