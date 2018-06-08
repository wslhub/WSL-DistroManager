using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

namespace DistroManager
{
    internal static class NativeMethods
    {
        public static readonly uint UID_INVALID = unchecked((uint)-1);

        public static readonly uint E_INVALIDARG = 0x80070057u;

        public static readonly uint S_OK = 0x00000000u;

        public static readonly uint FACILITY_WIN32 = 7u;

        public static readonly uint ERROR_ALREADY_EXISTS = 0xB7u;

        public static readonly uint ERROR_LINUX_SUBSYSTEM_NOT_PRESENT = 414u;
        
        public static readonly int STD_INPUT_HANDLE = (-10);

        public static readonly int STD_ERROR_HANDLE = (-12);

        public static readonly uint INFINITE = 0xFFFFFFFFu;

        public static readonly uint LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800u;

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreatePipe(ref IntPtr hReadPipe, ref IntPtr hWritePipe, IntPtr lpPipeAttributes, int nSize);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetExitCodeProcess(IntPtr hProcess, out uint lpExitCode);

        [SuppressUnmanagedCodeSecurity] 
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] 
        [DllImport("kernel32.dll", EntryPoint = "RtlZeroMemory", SetLastError = false)]
        public static extern void ZeroMemory(IntPtr dest, int size); 

        [DllImport("kernel32.dll", SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadFile(IntPtr hFile, IntPtr pBuffer, int NumberOfBytesToRead, out int pNumberOfBytesRead, IntPtr Overlapped);

        [DllImport("kernel32.dll", ExactSpelling = true, EntryPoint = "SetConsoleTitleW", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleTitleW(string lpConsoleTitle);

        [DllImport("kernel32.dll", EntryPoint = "LoadLibraryExW", CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, uint dwFlags);

        [DllImport("kernel32.dll", EntryPoint = "GetProcAddress", CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", EntryPoint = "FreeLibrary", ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [StructLayout(LayoutKind.Sequential)]
        internal struct SECURITY_ATTRIBUTES
        {
            public uint nLength;
            public IntPtr lpSecurityDescriptor;

            [MarshalAs(UnmanagedType.Bool)]
            public bool bInheritHandle;
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

        public static uint HRESULT_FROM_WIN32(uint x)
        {
            return (uint)(x) <= 0 ? (uint)(x) : (uint) (((x) & 0x0000FFFF) | (FACILITY_WIN32 << 16) | 0x80000000);
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

    }
}
