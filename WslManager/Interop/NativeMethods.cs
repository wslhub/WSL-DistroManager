using System.Runtime.InteropServices;

namespace WslManager.Interop
{
    internal static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct NetworkResource
        {
            public int iScope;
            public int iType;
            public int iDisplayType;
            public int iUsage;
            public string sLocalName;
            public string sRemoteName;
            public string sComment;
            public string sProvider;
        }

        [DllImport("mpr.dll")]
        public static extern int WNetAddConnection2A(
            ref NetworkResource pstNetRes,
            string psPassword,
            string psUsername,
            int piFlags);

        [DllImport("mpr.dll")]
        public static extern int WNetCancelConnection2A(
            string psName,
            int piFlags,
            int pfForce);

        [DllImport("mpr.dll")]
        public static extern int WNetConnectionDialog(
            int phWnd,
            int piType);

        [DllImport("mpr.dll")]
        public static extern int WNetDisconnectDialog(
            int phWnd,
            int piType);

        [DllImport("mpr.dll")]
        public static extern int WNetRestoreConnectionW(
            int phWnd,
            string psLocalDrive);

        public const int RESOURCETYPE_DISK = 0x1;
        public const int CONNECT_INTERACTIVE = 0x00000008;
        public const int CONNECT_PROMPT = 0x00000010;
        public const int CONNECT_UPDATE_PROFILE = 0x00000001;
        public const int CONNECT_REDIRECT = 0x00000080;
        public const int CONNECT_COMMANDLINE = 0x00000800;
        public const int CONNECT_CMD_SAVECRED = 0x00001000;
    }
}
