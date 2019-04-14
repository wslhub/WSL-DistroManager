using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WslManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        internal static IEnumerable<ListViewItem> LoadDistroList()
        {
            var list = new List<ListViewItem>();

            using (var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Lxss"))
            {
                foreach (var eachSubKeyname in reg.GetSubKeyNames())
                {
                    using (var subReg = reg.OpenSubKey(eachSubKeyname))
                    {
                        list.Add(new DistroListViewItem(subReg));
                    }
                }
            }

            return list;
        }

        private void LaunchWslDistro(bool openFolder, IEnumerable<ListViewItem> distroItems)
        {
            if (distroItems == null || distroItems.Count() < 1)
                return;

            foreach (DistroListViewItem eachItem in distroItems)
            {
                ProcessStartInfo startInfo;

                startInfo = new ProcessStartInfo(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "wsl.exe"),
                    $@"-d {eachItem.DistroName} {(openFolder ? "-- exit" : "")}")
                {
                    UseShellExecute = false,
                    WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    CreateNoWindow = openFolder,
                };

                var proc = Process.Start(startInfo);

                if (openFolder)
                {
                    startInfo = new ProcessStartInfo(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "explorer.exe"),
                        $@"\\wsl$\{eachItem.DistroName}")
                    {
                        UseShellExecute = false,
                    };

                    Process.Start(startInfo).WaitForExit();
                }
            }
        }

        private void ExportDistro(DistroListViewItem distroItem, string filePath, bool revealAfterComplete)
        {
            if (distroItem == null)
                return;

            ProcessStartInfo startInfo;

            startInfo = new ProcessStartInfo(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "wsl.exe"),
                $@"--export {distroItem.DistroName} {filePath}")
            {
                UseShellExecute = false,
                WorkingDirectory = Path.GetDirectoryName(filePath),
            };

            var proc = Process.Start(startInfo);
            proc.WaitForExit();

            if (revealAfterComplete)
            {
                var revealStartInfo = new ProcessStartInfo(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "explorer.exe"),
                    $@"/select,{filePath}")
                {
                    UseShellExecute = false,
                    WorkingDirectory = Path.GetDirectoryName(filePath),
                };

                Process.Start(revealStartInfo);
            }
        }

        private void ImportDistro(string tarGzFilePath, string distroName, string installLocation)
        {
            ProcessStartInfo startInfo;

            startInfo = new ProcessStartInfo(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "wsl.exe"),
                $@"--import {distroName} {installLocation} {tarGzFilePath}")
            {
                UseShellExecute = false,
            };

            var proc = Process.Start(startInfo);

            proc.EnableRaisingEvents = true;
            proc.Exited += (_sender, _e) =>
            {
                if (IsDisposed)
                    return;

                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        refreshToolStripMenuItem.PerformClick();
                    }));
                }
            };
        }

        private void TerminateDistro(DistroListViewItem distroItem)
        {
            if (distroItem == null)
                return;

            ProcessStartInfo startInfo;

            startInfo = new ProcessStartInfo(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "wsl.exe"),
                $@"-t {distroItem.DistroName}")
            {
                UseShellExecute = false,
            };

            var proc = Process.Start(startInfo);
            proc.WaitForExit();
        }

        private void UnregisterDistro(DistroListViewItem distroItem)
        {
            if (distroItem == null)
                return;

            ProcessStartInfo startInfo;

            startInfo = new ProcessStartInfo(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "wsl.exe"),
                $@"--unregister {distroItem.DistroName}")
            {
                UseShellExecute = false,
            };

            var proc = Process.Start(startInfo);
            proc.WaitForExit();
        }

        private void InstallDistroFromUrl(string url)
        {
            using (var downloadForm = new DownloadDistroForm()
            {
                DownloadUrl = url,
            })
            {
                var response = downloadForm.ShowDialog(this);

                if (response != DialogResult.OK)
                    return;

                if (!File.Exists(downloadForm.LocalFilePath))
                    return;

                var filePath = downloadForm.LocalFilePath;

                if (!File.Exists(filePath))
                    return;

                response = ImportLocationFolderDialog.ShowDialog(this);

                if (response != DialogResult.OK)
                    return;

                using (var dlg = new DistroNameRequestForm())
                {
                    var inferredDistroName = Path.GetFileNameWithoutExtension(ImportLocationFolderDialog.SelectedPath);
                    dlg.SelectedDistroName = inferredDistroName;
                    response = dlg.ShowDialog(this);

                    if (response != DialogResult.OK)
                        return;

                    ImportDistro(downloadForm.LocalFilePath, dlg.SelectedDistroName, ImportLocationFolderDialog.SelectedPath);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Environment.OSVersion.Version < new Version(10, 0, 18362))
            {
                MessageBox.Show(this, "This program only works on Windows 10 19H1 or later. Please upgrade to the latest OS version.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                Close();
                return;
            }

            var items = LoadDistroList().ToArray();
            DistroListView.Items.Clear();
            DistroListView.Items.AddRange(items);
        }

        private void DistroListView_ItemActivate(object sender, EventArgs e)
        {
            var altKeyPressed = ModifierKeys.HasFlag(Keys.Alt);
            if (altKeyPressed)
            {
                propertiesToolStripMenuItem.PerformClick();
                return;
            }

            var shiftKeyPressed = ModifierKeys.HasFlag(Keys.Shift);
            LaunchWslDistro(shiftKeyPressed, DistroListView.SelectedItems.Cast<ListViewItem>());
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = LoadDistroList().ToArray();
            DistroListView.Items.Clear();
            DistroListView.Items.AddRange(items);
        }

        private void DistroListView_MouseUp(object sender, MouseEventArgs e)
        {
            var realSender = sender as ListView;

            if (!object.ReferenceEquals(realSender, DistroListView))
                return;

            if (e.Button != MouseButtons.Right)
                return;

            var focusedItem = realSender.FocusedItem;
            if (focusedItem == null)
            {
                DefaultContextMenuStrip.Show(Cursor.Position);
                return;
            }

            if (!focusedItem.Bounds.Contains(e.Location))
            {
                DefaultContextMenuStrip.Show(Cursor.Position);
                return;
            }

            DistroContextMenuStrip.Show(Cursor.Position);
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var shiftKeyPressed = ModifierKeys.HasFlag(Keys.Shift);
            LaunchWslDistro(shiftKeyPressed, DistroListView.SelectedItems.Cast<ListViewItem>());
        }

        private void ExploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchWslDistro(true, DistroListView.SelectedItems.Cast<ListViewItem>());
        }

        private void ExportDistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = DistroListView.SelectedItems.Cast<DistroListViewItem>().FirstOrDefault();

            if (item == null)
                return;

            var response = MessageBox.Show(this,
                "To prevent unintentional data loss, the program must shut down its distro instance before exporting. Would you like to continue?",
                Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (response != DialogResult.Yes)
                return;

            TerminateDistro(item);

            ExportDistroFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            ExportDistroFileDialog.FileName = $"{item.DistroName}-export-{DateTime.Now:yyyy-MM-dd}.tar.gz";

            if (ExportDistroFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            ExportDistro(item, ExportDistroFileDialog.FileName, true);
        }

        private void UnregisterDistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = DistroListView.SelectedItems.Cast<DistroListViewItem>().FirstOrDefault();

            if (item == null)
                return;

            var response = MessageBox.Show(this,
                "To prevent unintentional data loss, the program must shut down its distro instance before exporting. Would you like to continue?",
                Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (response != DialogResult.Yes)
                return;

            TerminateDistro(item);
            UnregisterDistro(item);
            refreshToolStripMenuItem.PerformClick();
        }

        private void TerminateDistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = DistroListView.SelectedItems.Cast<DistroListViewItem>().FirstOrDefault();

            if (item == null)
                return;

            var response = MessageBox.Show(this,
                "To prevent unintentional data loss, the program must shut down its distro instance before exporting. Would you like to continue?",
                Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (response != DialogResult.Yes)
                return;

            TerminateDistro(item);
        }

        private void ImportDistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var response = ImportDistroFileDialog.ShowDialog(this);

            if (response != DialogResult.OK)
                return;

            response = ImportLocationFolderDialog.ShowDialog(this);

            if (response != DialogResult.OK)
                return;

            using (var dlg = new DistroNameRequestForm())
            {
                var inferredDistroName = Path.GetFileNameWithoutExtension(ImportLocationFolderDialog.SelectedPath);
                dlg.SelectedDistroName = inferredDistroName;
                response = dlg.ShowDialog(this);

                if (response != DialogResult.OK)
                    return;

                ImportDistro(ImportDistroFileDialog.FileName, dlg.SelectedDistroName, ImportLocationFolderDialog.SelectedPath);
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,
                $@"{ProductName} {ProductVersion}
(c) 2019 rkttu.com, All rights reserved.

Web Site: https://www.github.com/rkttu/WSL-DistroManager
Icons: https://www.icons8.com",
                $"About {Text}",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void Ubuntu1804ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstallDistroFromUrl("https://aka.ms/wsl-ubuntu-1804");
        }

        private void Ubuntu1604ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstallDistroFromUrl("https://aka.ms/wsl-ubuntu-1604");
        }

        private void DebianGNULinuxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstallDistroFromUrl("https://aka.ms/wsl-debian-gnulinux");
        }

        private void KaliLinuxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstallDistroFromUrl("https://aka.ms/wsl-kali-linux");
        }

        private void OpenSUSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstallDistroFromUrl("https://aka.ms/wsl-opensuse-42");
        }

        private void SLESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstallDistroFromUrl("https://aka.ms/wsl-sles-12");
        }

        private void FromMicrosoftStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("ms-windows-store://search/?query=Linux");
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ViewModeToolStripMenuItem1_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem eachItem in viewModeToolStripMenuItem1.DropDownItems)
                eachItem.Checked = false;

            switch (DistroListView.View)
            {
                case View.LargeIcon:
                    largeIconToolStripMenuItem1.Checked = true;
                    break;
                case View.Details:
                    detailsToolStripMenuItem1.Checked = true;
                    break;
                case View.List:
                    listToolStripMenuItem1.Checked = true;
                    break;
                case View.Tile:
                    tileToolStripMenuItem1.Checked = true;
                    break;
                case View.SmallIcon:
                    smallIconsToolStripMenuItem1.Checked = true;
                    break;
            }
        }

        private void LargeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DistroListView.View = View.LargeIcon;
        }

        private void TileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DistroListView.View = View.Tile;
        }

        private void SmallIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DistroListView.View = View.SmallIcon;
        }

        private void ListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DistroListView.View = View.List;
        }

        private void DetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DistroListView.View = View.Details;
            DistroListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            DistroListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ViewModeToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem eachItem in viewModeToolStripMenuItem.DropDownItems)
                eachItem.Checked = false;

            switch (DistroListView.View)
            {
                case View.LargeIcon:
                    largeIconsToolStripMenuItem.Checked = true;
                    break;
                case View.Details:
                    detailsToolStripMenuItem.Checked = true;
                    break;
                case View.List:
                    listToolStripMenuItem.Checked = true;
                    break;
                case View.Tile:
                    tileToolStripMenuItem.Checked = true;
                    break;
                case View.SmallIcon:
                    smallIconsToolStripMenuItem.Checked = true;
                    break;
            }
        }

        private void DistroToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            openToolStripMenuItem1.Enabled =
                exploreToolStripMenuItem1.Enabled =
                exportDistroToolStripMenuItem1.Enabled =
                unregisterDistroToolStripMenuItem1.Enabled =
                terminateDistroToolStripMenuItem1.Enabled =
                propertiesToolStripMenuItem1.Enabled =
                DistroListView.SelectedItems.Count > 0;
        }

        private void PropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = DistroListView.SelectedItems.Cast<DistroListViewItem>().FirstOrDefault();

            if (item == null)
                return;

            using (var propertiesDialog = new DistroPropertiesForm())
            {
                propertiesDialog.DistroName = item.DistroName;
                propertiesDialog.ShowDialog(this);
            }
        }
    }
}
