using DistroManager.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DistroManager
{
    internal static class Program
    {
        [STAThread]
        private static int Main(string[] arguments)
        {
            Application.OleRequired();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var mainForm = new MainForm())
            {
                var appContext = new ApplicationContext(mainForm);
                Application.Run(appContext);
                return Environment.ExitCode;
            }
        }
    }
}
