using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

namespace DistroManager
{
    internal static class NativeMethods
    {
        public static readonly int UID_INVALID = (-1);

        public static readonly int E_INVALIDARG = unchecked((int)0x80070057u);

        public static readonly int E_ACCESSDENIED = unchecked((int)0x80070005u);

        public static readonly int S_OK = 0x00000000;

        public static readonly int FACILITY_WIN32 = 7;

        public static readonly int ERROR_ALREADY_EXISTS = 0xB7;

        public static readonly int ERROR_LINUX_SUBSYSTEM_NOT_PRESENT = 414;
        
        public static readonly int STD_INPUT_HANDLE = (-10);

        public static readonly int STD_ERROR_HANDLE = (-12);

        public static readonly int INFINITE = unchecked((int)0xFFFFFFFFu);

        public static readonly int LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800;

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreatePipe(ref IntPtr hReadPipe, ref IntPtr hWritePipe, IntPtr lpPipeAttributes, int nSize);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern int WaitForSingleObject(
            IntPtr hHandle,
            [MarshalAs(UnmanagedType.U4)] int dwMilliseconds);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetExitCodeProcess(
            IntPtr hProcess,
            [MarshalAs(UnmanagedType.U4)] out int lpExitCode);

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
        public static extern IntPtr LoadLibraryEx(
            string lpFileName,
            IntPtr hFile,
            [MarshalAs(UnmanagedType.U4)] int dwFlags);

        [DllImport("kernel32.dll", EntryPoint = "GetProcAddress", CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", EntryPoint = "FreeLibrary", ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [StructLayout(LayoutKind.Sequential)]
        internal struct SECURITY_ATTRIBUTES
        {
            [MarshalAs(UnmanagedType.U4)]
            public int nLength;

            public IntPtr lpSecurityDescriptor;

            [MarshalAs(UnmanagedType.Bool)]
            public bool bInheritHandle;
        }

        [Flags]
        internal enum WSL_DISTRIBUTION_FLAGS : int
        {
            WSL_DISTRIBUTION_FLAGS_NONE = 0,
            WSL_DISTRIBUTION_FLAGS_ENABLE_INTEROP = 1,
            WSL_DISTRIBUTION_FLAGS_APPEND_NT_PATH = 2,
            WSL_DISTRIBUTION_FLAGS_ENABLE_DRIVE_MOUNTING = 4,

            WSL_DISTRIBUTION_FLAGS_DEFAULT = (WSL_DISTRIBUTION_FLAGS_ENABLE_INTEROP | WSL_DISTRIBUTION_FLAGS_APPEND_NT_PATH | WSL_DISTRIBUTION_FLAGS_ENABLE_DRIVE_MOUNTING)
        }

        public static uint HRESULT_FROM_WIN32(int x) => (uint)(x) <= 0 ? (uint)(x) : (uint) (((x) & 0x0000FFFF) | (FACILITY_WIN32 << 16) | 0x80000000);
        public static bool FAILED(int u) => u < 0;
        public static bool SUCCEED(int u) => u >= 0;

        [UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal delegate bool WSL_IS_DISTRIBUTION_REGISTERED(string distroName);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.U4)]
        internal delegate int WSL_REGISTER_DISTRIBUTION(string distroName, string tarGzFilename);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.U4)]
        internal delegate int WSL_CONFIGURE_DISTRIBUTION(
            string distroName,
            [MarshalAs(UnmanagedType.U4)] int defaultUID,
            [MarshalAs(UnmanagedType.U4)] WSL_DISTRIBUTION_FLAGS wslFlags);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.U4)]
        internal delegate int WSL_LAUNCH_INTERACTIVE(
            string distroName,
            string command,
            [MarshalAs(UnmanagedType.Bool)] bool useCurrentWorkingDirectory,
            [MarshalAs(UnmanagedType.U4)] out int pExitCode);
        
        [UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.U4)]
        internal delegate int WSL_LAUNCH(
            string distroName,
            string command,
            [MarshalAs(UnmanagedType.Bool)] bool useCurrentWorkingDirectory,
            IntPtr hStdIn,
            IntPtr hStdOut,
            IntPtr hStdErr,
            out IntPtr phProcess);
    }
}
