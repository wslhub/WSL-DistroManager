using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
using WslManager.Helpers;
using WslManager.Interop;
using WslManager.Shared;
using WslManager.Structures;

namespace WslManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            wscriptShellType = Type.GetTypeFromProgID("WScript.Shell");
            shellObjectFactory = new Lazy<object>(
                () => Activator.CreateInstance(wscriptShellType),
                false);
        }

        private Label emptyLabel;
        private Type wscriptShellType;
        private Lazy<object> shellObjectFactory;
        private ManagementEventWatcher managementEventWatcher;
        private GroupTypes groupType;
        private OrderTypes orderType;
        private SortOrder sortOrder;

        private void PerformGrouppingDistroList()
        {
            DistroListView.Groups.Clear();

            switch (groupType)
            {
                case GroupTypes.WSLVersion:
                    DistroListView.ShowGroups = true;
                    var v1Group = DistroListView.Groups.Add("v1", "Windows Subsystem for Linux v1");
                    var v2Group = DistroListView.Groups.Add("v2", "Windows Subsystem for Linux v2");

                    foreach (ListViewItem eachItem in DistroListView.Items)
                    {
                        var distroProperties = eachItem.Tag as DistroProperties;
                        if (distroProperties == null)
                            continue;

                        if (string.Equals(distroProperties.Version, "1", StringComparison.OrdinalIgnoreCase))
                            eachItem.Group = v1Group;
                        else
                            eachItem.Group = v2Group;
                    }
                    break;

                case GroupTypes.DistroType:
                    DistroListView.ShowGroups = true;
                    var debianGroup = DistroListView.Groups.Add("debian", "Debian");
                    var ubuntuGroup = DistroListView.Groups.Add("ubuntu", "Ubuntu");
                    var suseGroup = DistroListView.Groups.Add("suse", "SUSE");
                    var kaliGroup = DistroListView.Groups.Add("kali", "Kali");
                    var linuxGroup = DistroListView.Groups.Add("linux", "Variant");

                    foreach (ListViewItem eachItem in DistroListView.Items)
                    {
                        var distroProperties = eachItem.Tag as DistroProperties;
                        if (distroProperties == null)
                            continue;

                        switch (SharedRoutines.GetImageKey(distroProperties.DistroName))
                        {
                            case "debian":
                                eachItem.Group = debianGroup;
                                break;
                            case "ubuntu":
                                eachItem.Group = ubuntuGroup;
                                break;
                            case "suse":
                                eachItem.Group = suseGroup;
                                break;
                            case "kali":
                                eachItem.Group = kaliGroup;
                                break;
                            default:
                                eachItem.Group = linuxGroup;
                                break;
                        }
                    }
                    break;

                case GroupTypes.DistroStatus:
                    DistroListView.ShowGroups = true;
                    var stoppedGroup = DistroListView.Groups.Add("stopped", "Stopped");
                    var runningGroup = DistroListView.Groups.Add("running", "Running");
                    var installingGroup = DistroListView.Groups.Add("installing", "Installing");
                    var uninstallingGroup = DistroListView.Groups.Add("uninstalling", "Uninstalling");
                    var convertingGroup = DistroListView.Groups.Add("converting", "Converting");
                    var unknownGroup = DistroListView.Groups.Add("unknown", "Unknown");

                    foreach (ListViewItem eachItem in DistroListView.Items)
                    {
                        var distroProperties = eachItem.Tag as DistroProperties;
                        if (distroProperties == null)
                            continue;

                        switch (distroProperties.DistroStatus?.ToUpperInvariant()?.Trim())
                        {
                            case "STOPPED":
                                eachItem.Group = stoppedGroup;
                                break;
                            case "RUNNING":
                                eachItem.Group = runningGroup;
                                break;
                            case "INSTALLING":
                                eachItem.Group = installingGroup;
                                break;
                            case "UNINSTALLING":
                                eachItem.Group = uninstallingGroup;
                                break;
                            case "CONVERTING":
                                eachItem.Group = convertingGroup;
                                break;
                            default:
                                eachItem.Group = unknownGroup;
                                break;
                        }
                    }
                    break;

                default:
                    DistroListView.ShowGroups = false;
                    break;
            }
        }

        private void PerformSortingDistroList()
        {
            DistroListView.ListViewItemSorter = null;
            DistroListView.Sorting = SortOrder.None;

            switch (orderType)
            {
                case OrderTypes.DistroName:
                    DistroListView.ListViewItemSorter = new AdaptableComparer<ListViewItem>(
                        (x, y) => string.Compare(
                            (x.Tag as DistroProperties)?.DistroName,
                            (y.Tag as DistroProperties)?.DistroName,
                            false));
                    break;

                case OrderTypes.DistroStatus:
                    DistroListView.ListViewItemSorter = new AdaptableComparer<ListViewItem>(
                        (x, y) => string.Compare(
                            (x.Tag as DistroProperties)?.DistroStatus,
                            (y.Tag as DistroProperties)?.DistroStatus,
                            false));
                    break;

                case OrderTypes.DistroType:
                    DistroListView.ListViewItemSorter = new AdaptableComparer<ListViewItem>(
                        (x, y) => string.Compare(
                            (x.Tag as DistroProperties)?.ImageKey,
                            (y.Tag as DistroProperties)?.ImageKey,
                            false));
                    break;

                default:
                    DistroListView.ListViewItemSorter = new AdaptableComparer<ListViewItem>(
                        (x, y) => ((DistroProperties)x.Tag).Order.CompareTo(((DistroProperties)y.Tag).Order));
                    break;
            }

            DistroListView.Sorting = this.sortOrder;
            DistroListView.Sort();
        }

        private void PerformRefreshDistroList(bool triggeredByUser)
        {
            DistroListView.Items.Clear();

            var items = SharedRoutines.LoadDistroList().ToArray();

            foreach (var eachItem in items)
            {
                var lvItem = new ListViewItem()
                {
                    ImageKey = eachItem.ImageKey,
                    Tag = eachItem,
                    Text = eachItem.DistroName,
                };
                foreach (ColumnHeader eachColumn in DistroListView.Columns.Cast<ColumnHeader>().Skip(1))
                {
                    var propName = eachColumn.Tag as string;
                    var subItem = new ListViewItem.ListViewSubItem(lvItem, string.Empty);

                    if (propName != null && eachItem.Properties.ContainsKey(propName))
                        subItem.Text = eachItem.Properties[propName] as string;
                    else
                        subItem.Text = string.Empty;

                    lvItem.SubItems.Add(subItem);
                }

                DistroListView.Items.Add(lvItem);
            }

            PerformGrouppingDistroList();

            PerformSortingDistroList();

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
                ShimGenerator.RunWorkerAsync(new BackgroundWorkerArgument<DistroProperties[]>(triggeredByUser, items));

            if (!ShortcutGenerator.IsBusy)
                ShortcutGenerator.RunWorkerAsync(new BackgroundWorkerArgument<DistroProperties[]>(triggeredByUser, items));
        }

        private void OpenWslFolder(DistroProperties distro)
        {
            var startInfo = new ProcessStartInfo(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "explorer.exe"),
                $@"\\wsl$\{distro.DistroName}")
            {
                UseShellExecute = false,
            };

            Process.Start(startInfo);
        }

        private void LaunchWslDistro(Action<DistroProperties> afterCallback, IEnumerable<ListViewItem> distroItems)
        {
            if (distroItems == null || distroItems.Count() < 1)
                return;

            foreach (DistroProperties eachItem in distroItems.Select(x => x.Tag as DistroProperties))
            {
                ProcessStartInfo startInfo;

                startInfo = new ProcessStartInfo(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "wsl.exe"),
                    $@"-d {eachItem.DistroName} {(afterCallback != null ? "-- exit" : "")}")
                {
                    UseShellExecute = false,
                    WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    CreateNoWindow = afterCallback != null,
                };

                var proc = Process.Start(startInfo);
                afterCallback?.Invoke(eachItem);
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

                foreach (DistroProperties eachItem in distroItems.Select(x => x.Tag as DistroProperties))
                {
                    string distroExecutable = Path.Combine(
                        SharedRoutines.GetWslShimDirectoryPath(),
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

        private void LaunchWindowsTerminal(IEnumerable<ListViewItem> distroItems)
        {
            MessageBox.Show("TODO");
        }

        private void ExportDistro(DistroProperties distroItem, string filePath, bool revealAfterComplete)
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
            };
        }

        private void TerminateDistro(DistroProperties distroItem)
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

        private void ShutdownAllDistro()
        {
            if (!SharedRoutines.IsWsl2SupportedOS())
                return;

            ProcessStartInfo startInfo;

            startInfo = new ProcessStartInfo(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "wsl.exe"),
                $@"--shutdown")
            {
                UseShellExecute = false,
            };

            var proc = Process.Start(startInfo);
            proc.WaitForExit();
        }

        private void UnregisterDistro(DistroProperties distroItem)
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

        private bool CreateDistroShortcut(DistroProperties selectedDistro, string targetFilePath)
        {
            var shortcut = (IWshShortcut)wscriptShellType.InvokeMember(
                "CreateShortcut",
                BindingFlags.InvokeMethod,
                null, shellObjectFactory.Value,
                new object[] { targetFilePath });

            shortcut.Description = selectedDistro.DistroName;
            shortcut.TargetPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.System),
                "wsl.exe");
            shortcut.WorkingDirectory = Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile);
            shortcut.Arguments = $@"-d {selectedDistro.DistroName}";
            shortcut.IconLocation = Path.Combine(
                SharedRoutines.GetIconDirectoryPath(),
                SharedRoutines.GetImageKey(selectedDistro.DistroName) + ".ico");
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

            DistroListView.Columns.Clear();
            foreach (var eachProperty in typeof(DistroProperties).GetProperties())
            {
                var browsableAttr = eachProperty.GetCustomAttribute<BrowsableAttribute>();
                if (browsableAttr != null && !browsableAttr.Browsable)
                    continue;

                var colItem = new ColumnHeader();

                var displayNameAttr = eachProperty.GetCustomAttribute<DisplayNameAttribute>();
                if (displayNameAttr != null)
                    colItem.Text = displayNameAttr.DisplayName;
                else
                    colItem.Text = eachProperty.Name;

                colItem.Tag = eachProperty.Name;
                DistroListView.Columns.Add(colItem);
            }

            if (!SharedRoutines.IsWsl2SupportedOS())
            {
                shutdownAllDistrosToolStripMenuItem.Visible = false;
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
            LaunchWslDistro(
                shiftKeyPressed ? new Action<DistroProperties>(OpenWslFolder) : null,
                DistroListView.SelectedItems.Cast<ListViewItem>());
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
            LaunchWslDistro(
                shiftKeyPressed ? new Action<DistroProperties>(OpenWslFolder) : null,
                DistroListView.SelectedItems.Cast<ListViewItem>());
        }

        private void HyperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchHyper(DistroListView.SelectedItems.Cast<ListViewItem>());
        }

        private void ExploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchWslDistro(
                new Action<DistroProperties>(OpenWslFolder),
                DistroListView.SelectedItems.Cast<ListViewItem>());
        }

        private void ExportDistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = DistroListView.SelectedItems.Cast<ListViewItem>().Select(x => x.Tag).Cast<DistroProperties>().FirstOrDefault();

            if (item == null)
                return;

            var response = MessageBox.Show(this,
                "To prevent unintentional data loss, save your all current data in its distro instance before exporting. Would you like to continue?",
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
            var item = DistroListView.SelectedItems.Cast<ListViewItem>().Select(x => x.Tag).Cast<DistroProperties>().FirstOrDefault();

            if (item == null)
                return;

            var response = MessageBox.Show(this,
                "To prevent unintentional data loss, save your all current data in its distro instance before exporting. Would you like to continue?",
                Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (response != DialogResult.Yes)
                return;

            TerminateDistro(item);
            UnregisterDistro(item);
        }

        private void TerminateDistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = DistroListView.SelectedItems.Cast<ListViewItem>().Select(x => x.Tag).Cast<DistroProperties>().FirstOrDefault();

            if (item == null)
                return;

            var response = MessageBox.Show(this,
                "To prevent unintentional data loss, save your all current data in its distro instance before exporting. Would you like to continue?",
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
            var item = DistroListView.SelectedItems.Cast<ListViewItem>().Select(x => x.Tag).Cast<DistroProperties>().FirstOrDefault();

            if (item == null)
                return;

            using (var propertiesDialog = new DistroPropertiesForm())
            {
                propertiesDialog.Model = item.WslDistroInfo;
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
                .Cast<ListViewItem>()
                .Select(x => x.Tag)
                .Cast<DistroProperties>()
                .FirstOrDefault();

            if (selectedDistro == null)
                return;

            ShortcutSaveFileDialog.FileName = $"{selectedDistro.DistroName}.lnk";
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

            var targetDir = SharedRoutines.GetIconDirectoryPath();
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
                .Cast<ListViewItem>()
                .Select(x => x.Tag)
                .Cast<DistroProperties>()
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
            var targetDir = SharedRoutines.GetWslShimDirectoryPath();
            EnsureDirectoryCreate(targetDir, false);

            var arg = e.Argument as BackgroundWorkerArgument<DistroProperties[]>;

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
            var targetDir = SharedRoutines.GetWslShortcutDirectoryPath();
            EnsureDirectoryCreate(targetDir, false);

            var filesToDrag = new List<string>();

            foreach (var eachItem in DistroListView.SelectedItems)
            {
                var eachDistro = (DistroProperties)eachItem;
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
            var targetDir = SharedRoutines.GetWslShortcutDirectoryPath();
            EnsureDirectoryCreate(targetDir, false);

            var arg = e.Argument as BackgroundWorkerArgument<DistroProperties[]>;

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

                if (!item.IsAppxDistro())
                    MessageBox.Show(this, "Custom distro installation is not supported.");

                //item.Id
                var currentAssemblyDir = Path.GetDirectoryName(this.GetType().Assembly.Location);
                var wslSetupPath = Path.Combine(currentAssemblyDir, "WslSetup.exe");
                if (!File.Exists(wslSetupPath))
                    MessageBox.Show(this, "WslSetup.exe is missing.");

                var psi = new ProcessStartInfo(wslSetupPath, item.Id)
                {
                    UseShellExecute = true,
                };

                Process.Start(psi);
            }
        }

        private void WindowsTerminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchWindowsTerminal(DistroListView.SelectedItems.Cast<ListViewItem>());
        }

        private void ShutdownAllDistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show(this,
                "To prevent unintentional data loss, save your all current data in its distro instance before exporting. Would you like to continue?",
                Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (response != DialogResult.Yes)
                return;

            ShutdownAllDistro();
        }

        private void WSLManagerOfficialWebSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.wslhub.com/") { UseShellExecute = true });
        }

        private void WSLOfficialBlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://blogs.msdn.microsoft.com/wsl/") { UseShellExecute = true });
        }

        private void WSLDocumentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://docs.microsoft.com/en-us/windows/wsl/about") { UseShellExecute = true });
        }

        private void WSLVersionGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupType = GroupTypes.WSLVersion;
            PerformRefreshDistroList(true);
        }

        private void DistroTypesGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupType = GroupTypes.DistroType;
            PerformRefreshDistroList(true);
        }

        private void DistroStatusGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupType = GroupTypes.DistroStatus;
            PerformRefreshDistroList(true);
        }

        private void NoneGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupType = GroupTypes.None;
            PerformRefreshDistroList(true);
        }

        private void GroupByToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            wSLVersionGroupToolStripMenuItem.Checked =
                distroTypesGroupToolStripMenuItem.Checked =
                noneGroupToolStripMenuItem.Checked =
                distroStatusGroupToolStripMenuItem.Checked =
                false;

            switch (groupType)
            {
                case GroupTypes.WSLVersion:
                    wSLVersionGroupToolStripMenuItem.Checked = true;
                    break;
                case GroupTypes.DistroType:
                    distroTypesGroupToolStripMenuItem.Checked = true;
                    break;
                case GroupTypes.DistroStatus:
                    distroStatusGroupToolStripMenuItem.Checked = true;
                    break;
                default:
                    noneGroupToolStripMenuItem.Checked = true;
                    break;
            }
        }

        private void OrderByRegisteredOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orderType = OrderTypes.None;
            PerformRefreshDistroList(true);
        }

        private void OrderByDistroNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orderType = OrderTypes.DistroName;
            PerformRefreshDistroList(true);
        }

        private void OrderByDistroTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orderType = OrderTypes.DistroType;
            PerformRefreshDistroList(true);
        }

        private void OrderByDistroStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orderType = OrderTypes.DistroStatus;
            PerformRefreshDistroList(true);
        }

        private void AscendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortOrder = SortOrder.Ascending;
            PerformRefreshDistroList(true);
        }

        private void DescendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortOrder = SortOrder.Descending;
            PerformRefreshDistroList(true);
        }

        private void OrderByToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            orderByRegisteredOrderToolStripMenuItem.Checked =
                orderByDistroNameToolStripMenuItem.Checked =
                orderByDistroStatusToolStripMenuItem.Checked =
                orderByDistroTypesToolStripMenuItem.Checked =
                false;

            switch (orderType)
            {
                case OrderTypes.DistroName:
                    orderByDistroNameToolStripMenuItem.Checked = true;
                    break;
                case OrderTypes.DistroStatus:
                    orderByDistroStatusToolStripMenuItem.Checked = true;
                    break;
                case OrderTypes.DistroType:
                    orderByDistroTypesToolStripMenuItem.Checked = true;
                    break;
                default:
                    orderByRegisteredOrderToolStripMenuItem.Checked = true;
                    break;
            }

            ascendingToolStripMenuItem.Checked =
                descendingToolStripMenuItem.Checked =
                false;

            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    ascendingToolStripMenuItem.Checked = true;
                    break;
                case SortOrder.Descending:
                    descendingToolStripMenuItem.Checked = true;
                    break;
            }
        }
    }
}
