using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
using WslManager.Models;

namespace WslManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private static Type wscriptShellType = Type.GetTypeFromProgID("WScript.Shell");
        private static object shellObject = Activator.CreateInstance(wscriptShellType);

        private Label emptyLabel;
        private ManagementEventWatcher managementEventWatcher;

        private void PerformRefreshDistroList(bool triggeredByUser)
        {
            var items = Helpers.LoadDistroList().ToArray();
            DistroListView.Items.Clear();
            DistroListView.Items.AddRange(items);
            TotalCountLabel.Text = $"{items.Length} item{(items.Length > 1 ? "s" : "")}";

            if (DistroListView.Items.Count < 1)
            {
                DistroListView.Visible = false;
                emptyLabel.Visible = true;
            }
            else
            {
                DistroListView.Visible = true;
                emptyLabel.Visible = false;
            }

            if (!ShimGenerator.IsBusy)
                ShimGenerator.RunWorkerAsync(new BackgroundWorkerArgument<DistroListViewItem[]>(triggeredByUser, items));

            if (!ShortcutGenerator.IsBusy)
                ShortcutGenerator.RunWorkerAsync(new BackgroundWorkerArgument<DistroListViewItem[]>(triggeredByUser, items));
        }

        private RegistryKey GetDistroRegistryKeyByDistroName(string distroName)
        {
            if (string.IsNullOrWhiteSpace(distroName))
                return null;

            var lxssKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Lxss");

            if (lxssKey == null)
                return null;

            using (lxssKey)
            {
                foreach (var eachName in lxssKey.GetSubKeyNames())
                {
                    var subKey = lxssKey.OpenSubKey(eachName, true);

                    if (subKey == null)
                        continue;

                    var foundName = subKey.GetValue("DistributionName", string.Empty, RegistryValueOptions.DoNotExpandEnvironmentNames) as string;

                    if (string.Equals(distroName, foundName, StringComparison.Ordinal))
                        return subKey;

                    subKey.Dispose();
                }
            }

            return null;
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

        private void LaunchHyper(IEnumerable<ListViewItem> distroItems)
        {
            string hyperConfigFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Hyper", ".hyper.js");
            string tempHyperConfigFile = hyperConfigFile + ".tmp";

            if (File.Exists(hyperConfigFile))
            {
                if (distroItems == null || distroItems.Count() < 1)
                    return;

                foreach (DistroListViewItem eachItem in distroItems)
                {
                    string distroExecutable = Path.Combine(
                        Helpers.GetWslShimDirectoryPath(),
                        eachItem.DistroName + "_simple.exe")
                        .Replace("\\", "\\\\");

                    StreamReader input = new StreamReader(hyperConfigFile);
                    StreamWriter output = new StreamWriter(tempHyperConfigFile);
                    string line;
                    while (null != (line = input.ReadLine()))
                    {
                        if (line.StartsWith("    shell: "))
                            output.WriteLine("    shell: '" + distroExecutable + "',");
                        else
                            output.WriteLine(line);
                    }
                    input.Close();
                    output.Close();
                    File.Delete(hyperConfigFile);
                    File.Move(tempHyperConfigFile, hyperConfigFile);

                    ProcessStartInfo startInfo;

                    startInfo = new ProcessStartInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "hyper", "Hyper.exe"));

                    var proc = Process.Start(startInfo);
                }
            }

            if (!File.Exists(hyperConfigFile))
            {
                MessageBox.Show(this, "Hyper installation not found!\n" +
                    "Hyper can be installed from: https://hyper.is", 
                    "Error: Hyper not Installed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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

        private void InstallDistro(string tarGzFilePath, string distroName, string installLocation, string userId, string password)
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

                var distroKey = GetDistroRegistryKeyByDistroName(distroName);
                if (distroKey == null)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(this, "Distro installation seems failed.",
                            Text, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    }), null);

                    return;
                }

                // Add user account and fetch UID
                startInfo = new ProcessStartInfo(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "wsl.exe"),
                    $@"-d {distroName} -- useradd {userId} -m -p {password} && id -u {userId}")
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                };

                proc = Process.Start(startInfo);
                proc.EnableRaisingEvents = true;

                var rawUid = proc.StandardOutput.ReadToEnd();
                var uidFound = Int32.TryParse(rawUid, out int uid);
                proc.WaitForExit();

                if (uidFound)
                    distroKey.SetValue("DefaultUid", uid, RegistryValueKind.DWord);

                distroKey.Dispose();
            };
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
            string userId, password;

            using (var accountForm = new AccountCreateForm()
            {
                UsedAccountIdList = new string[] { "root", },
                ExpectedPasswordScore = PasswordScore.Weak,
            })
            {
                if (accountForm.ShowDialog(this) != DialogResult.OK)
                    return;

                userId = accountForm.AccountId;
                password = accountForm.AccountPassword;
            }

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

                    InstallDistro(downloadForm.LocalFilePath, dlg.SelectedDistroName, ImportLocationFolderDialog.SelectedPath, userId, password);
                }
            }
        }

        private bool CreateDistroShortcut(DistroListViewItem selectedDistro, string targetFilePath)
        {
            var shortcut = (IWshShortcut)wscriptShellType.InvokeMember(
                "CreateShortcut",
                BindingFlags.InvokeMethod,
                null, shellObject,
                new object[] { targetFilePath });

            shortcut.Description = selectedDistro.Name;
            shortcut.TargetPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.System),
                "wsl.exe");
            shortcut.WorkingDirectory = Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile);
            shortcut.Arguments = $@"-d {selectedDistro.DistroName}";
            shortcut.IconLocation = Path.Combine(
                Helpers.GetIconDirectoryPath(),
                Helpers.GetImageKey(selectedDistro.DistroName) + ".ico");
            shortcut.Save();

            return File.Exists(targetFilePath);
        }

        private string EnsureDirectoryCreate(string targetDirectoryPath, bool shouldEmptyDirectory)
        {
            if (File.Exists(targetDirectoryPath))
                File.Delete(targetDirectoryPath);

            if (shouldEmptyDirectory && Directory.Exists(targetDirectoryPath))
                Directory.Delete(targetDirectoryPath, true);

            if (!Directory.Exists(targetDirectoryPath))
                Directory.CreateDirectory(targetDirectoryPath);

            return targetDirectoryPath;
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

            if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "wsl.exe")))
            {
                MessageBox.Show(this, "This program is only available when Windows Subsystem for Linux is enabled. Check the system settings.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                Close();
                return;
            }

            this.emptyLabel = new Label()
            {
                Parent = this,
                Text = "No WSL distro installed.",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(this.Font.FontFamily, 18f, FontStyle.Bold),
                Dock = DockStyle.Fill,
                UseMnemonic = false,
                Visible = false,
            };

            refreshToolStripMenuItem.PerformClick();

            if (!IconGenerator.IsBusy)
                IconGenerator.RunWorkerAsync();
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
            PerformRefreshDistroList(true);
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

        private void HyperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchHyper(DistroListView.SelectedItems.Cast<ListViewItem>());
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
            openWithToolStripMenuItem1.Enabled = DistroListView.SelectedItems.Count == 1;
        }

        private void DistroContextMenuStrip_Opening(object sender, EventArgs e)
        {
            openToolStripMenuItem.Enabled =
                exploreToolStripMenuItem.Enabled =
                toolStripMenuItem1.Enabled =
                exportDistroToolStripMenuItem.Enabled =
                toolStripMenuItem2.Enabled =
                unregisterDistroToolStripMenuItem.Enabled =
                terminateDistroToolStripMenuItem.Enabled =
                toolStripMenuItem12.Enabled =
                propertiesToolStripMenuItem.Enabled =
                DistroListView.SelectedItems.Count > 0;
            openWithToolStripMenuItem.Enabled = DistroListView.SelectedItems.Count == 1;
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

        private void DistroListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var count = DistroListView.SelectedItems.Count;
            SelectedCountLabel.Text = count != 0 ?
                $"{count} item{(count > 1 ? "s" : "")} selected." :
                string.Empty;
        }

        private void CreateShortcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedDistro = DistroListView.SelectedItems
                .Cast<DistroListViewItem>()
                .FirstOrDefault();

            if (selectedDistro == null)
                return;

            ShortcutSaveFileDialog.FileName = $"{selectedDistro.Name}.lnk";
            if (ShortcutSaveFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            if (!CreateDistroShortcut(selectedDistro, ShortcutSaveFileDialog.FileName))
            {
                MessageBox.Show(this, "Shortcut was not created due to error.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void IconGenerator_DoWork(object sender, DoWorkEventArgs e)
        {
            var results = new Dictionary<string, string>();
            e.Result = results;

            var targetDir = Helpers.GetIconDirectoryPath();
            EnsureDirectoryCreate(targetDir, false);

            foreach (var eachKey in ImageList.Images.Keys)
            {
                var targetPath = Path.Combine(targetDir, eachKey + ".ico");
                var fileInfo = new FileInfo(targetPath);

                if (fileInfo.Exists && fileInfo.Length > 0L)
                    continue;

                var creationResult = ImagingHelper.ConvertToIcon(ImageList.Images[eachKey], fileInfo.FullName);

                if (!creationResult)
                    results.Add(eachKey, targetPath);
            }
        }

        private void MapAsADriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedDistro = DistroListView.SelectedItems
                .Cast<DistroListViewItem>()
                .FirstOrDefault();

            using (var dialog = new MapAsDriveForm())
            {
                if (selectedDistro != null)
                    dialog.SelectedDistro = selectedDistro.DistroName;

                dialog.ShowDialog(this);
            }
        }

        private void ShimGenerator_DoWork(object sender, DoWorkEventArgs e)
        {
            var targetDir = Helpers.GetWslShimDirectoryPath();
            EnsureDirectoryCreate(targetDir, false);

            var arg = e.Argument as BackgroundWorkerArgument<DistroListViewItem[]>;

            if (arg?.Argument == null)
                return;

            // Shim exe file may not have icon due to missing icon cache
            var result = new Dictionary<string, CompilerResults>();
            e.Result = new BackgroundWorkerResult<Dictionary<string, CompilerResults>>(arg.HasTriggeredByUser, result);

            foreach (var eachItem in arg.Argument)
            {
                var fileName = eachItem.DistroName;
                var eachResult = WslShimGenerator.CreateWslShim(
                    eachItem.DistroName, false, targetDir, fileName);

                if (eachResult.Errors.HasErrors)
                    result.Add(fileName, eachResult);

                fileName = eachItem.DistroName + "_simple";
                eachResult = WslShimGenerator.CreateWslShim(
                    eachItem.DistroName, true, targetDir, fileName);

                if (eachResult.Errors.HasErrors)
                    result.Add(fileName, eachResult);
            }
        }

        private void ShimGenerator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(this, $"Cannot create WSL shim files due to error - {e.Error.Message}", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (e.Cancelled)
            {
                MessageBox.Show(this, $"Cannot create WSL shim files due to cancellation.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            var result = e.Result as BackgroundWorkerResult<Dictionary<string, CompilerResults>>;

            if (result == null)
                return;

            if (result.Result == null)
            {
                if (result.HasTriggeredByUser)
                {
                    MessageBox.Show(this, $"Cannot create WSL shim files due to unexpected error.", Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                return;
            }

            if (result.Result.Count > 0)
            {
                if (result.HasTriggeredByUser)
                {
                    MessageBox.Show(this, $"Some WSL shim files not created due to unexpected error.", Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                return;
            }
        }

        private void DistroListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var targetDir = Helpers.GetWslShortcutDirectoryPath();
            EnsureDirectoryCreate(targetDir, false);

            var filesToDrag = new List<string>();

            foreach (var eachItem in DistroListView.SelectedItems)
            {
                var eachDistro = (DistroListViewItem)eachItem;
                var targetPath = Path.Combine(targetDir, eachDistro.DistroName + ".lnk");

                if (!File.Exists(targetDir))
                    CreateDistroShortcut(eachDistro, targetPath);

                if (File.Exists(targetPath))
                    filesToDrag.Add(targetPath);
            }

            if (filesToDrag.Count > 0)
            {
                this.DistroListView.DoDragDrop(
                    new DataObject(DataFormats.FileDrop, filesToDrag.ToArray()),
                    DragDropEffects.Copy);
            }
        }

        private void ShortcutGenerator_DoWork(object sender, DoWorkEventArgs e)
        {
            var targetDir = Helpers.GetWslShortcutDirectoryPath();
            EnsureDirectoryCreate(targetDir, false);

            var arg = e.Argument as BackgroundWorkerArgument<DistroListViewItem[]>;

            if (arg?.Argument == null)
                return;

            // Shorcut file may not have icon due to missing icon cache
            var result = new Dictionary<string, string>();
            e.Result = new BackgroundWorkerResult<Dictionary<string, string>>(arg.HasTriggeredByUser, result);

            foreach (var eachItem in arg.Argument)
            {
                var targetFilePath = Path.Combine(targetDir, eachItem.DistroName + ".lnk");
                var creationResult = CreateDistroShortcut(eachItem, targetFilePath);
                
                if (!creationResult)
                    result.Add(eachItem.DistroName, targetFilePath);
            }
        }

        private void ShortcutGenerator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(this, $"Cannot create WSL shortcut files due to error - {e.Error.Message}", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (e.Cancelled)
            {
                MessageBox.Show(this, $"Cannot create WSL shortcut files due to cancellation.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            var result = e.Result as BackgroundWorkerResult<Dictionary<string, string>>;

            if (result == null)
                return;

            if (result.Result == null)
            {
                if (result.HasTriggeredByUser)
                {
                    MessageBox.Show(this, $"Cannot create WSL shortcut files due to unexpected error.", Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                return;
            }

            if (result.Result.Count > 0)
            {
                if (result.HasTriggeredByUser)
                {
                    MessageBox.Show(this, $"Some WSL shortcut files not created due to unexpected error.", Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                return;
            }
        }

        private void IconGenerator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(this, $"Cannot create distro icon image files due to error - {e.Error.Message}", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (e.Cancelled)
            {
                MessageBox.Show(this, $"Cannot create distro icon image files due to cancellation.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            var result = e.Result as Dictionary<string, string>;

            if (result == null)
            {
                MessageBox.Show(this, $"Cannot create distro icon image files due to unexpected error.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            if (result.Count > 0)
            {
                MessageBox.Show(this, $"Some distro icon image files not created due to unexpected error.", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            var query = new WqlEventQuery("SELECT * FROM RegistryTreeChangeEvent " +
                "WHERE Hive = 'HKEY_USERS' AND " +
                $@"RootPath = '{WindowsIdentity.GetCurrent().User.Value}\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Lxss'");
            managementEventWatcher = new ManagementEventWatcher(query);
            managementEventWatcher.EventArrived += ManagementEventWatcher_EventArrived;
            managementEventWatcher.Start();
        }

        private void ManagementEventWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            if (InvokeRequired)
                Invoke(new Action<bool>(PerformRefreshDistroList), new object[] { false });
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (managementEventWatcher != null)
            {
                managementEventWatcher.EventArrived -= ManagementEventWatcher_EventArrived;

                try { managementEventWatcher.Stop(); }
                catch { }

                try { managementEventWatcher.Dispose(); }
                catch { }

                managementEventWatcher = null;
            }
        }

        private void NewDistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var gallery = new DistroGalleryForm())
            {
                if (gallery.ShowDialog(this) != DialogResult.OK)
                    return;

                var item = gallery.SelectedItem;

                if (item == null)
                    return;

                if (item.IsAppxDistro())
                    InstallDistroFromUrl(item.Url.AbsoluteUri);
                else
                    MessageBox.Show(this, "Custom distro installation is not supported.");
            }
        }
    }
}
