using System;
using System.Windows.Forms;

namespace WslManager
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
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
