using System;
using System.Windows.Forms;
using WslManager.Interop;

namespace WslManager
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            var initResult = NativeMethods.CoInitializeSecurity(IntPtr.Zero, -1, IntPtr.Zero,
                IntPtr.Zero, RpcAuthnLevel.Default, RpcImpLevel.Delegate, IntPtr.Zero,
                EoAuthnCap.StaticCloaking, IntPtr.Zero);

            if (initResult < 0)
            {
                MessageBox.Show("Failed to initialize COM security.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Application.OleRequired();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var form = new MainForm())
            {
                var appContext = new ApplicationContext(form);
                Application.Run(appContext);
            }
        }
    }
}
