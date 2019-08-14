namespace WslManager
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.DistroListView = new System.Windows.Forms.ListView();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.DistroContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hyperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsTerminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.createShortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapAsADriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportDistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.unregisterDistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminateDistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DefaultContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.newDistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportDistroFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ImportDistroFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ImportLocationFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.distroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDistroToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openWithToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hyperToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsTerminalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.exploreToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createShortcutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.exportDistroToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.unregisterDistroToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.terminateDistroToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewModeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripSeparator();
            this.orderByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderByRegisteredOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderByDistroNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderByDistroTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderByDistroStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripSeparator();
            this.ascendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wSLVersionGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distroTypesGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distroStatusGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripSeparator();
            this.noneGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDistroToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mapAsADriveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripSeparator();
            this.shutdownAllDistrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wSLDocumentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripSeparator();
            this.wSLOfficialBlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wSLManagerOfficialWebSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.TotalCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SelectedCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ShortcutSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.IconGenerator = new System.ComponentModel.BackgroundWorker();
            this.ShimGenerator = new System.ComponentModel.BackgroundWorker();
            this.ShortcutGenerator = new System.ComponentModel.BackgroundWorker();
            this.DistroContextMenuStrip.SuspendLayout();
            this.DefaultContextMenuStrip.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // DistroListView
            // 
            resources.ApplyResources(this.DistroListView, "DistroListView");
            this.DistroListView.FullRowSelect = true;
            this.DistroListView.HideSelection = false;
            this.DistroListView.LargeImageList = this.ImageList;
            this.DistroListView.Name = "DistroListView";
            this.DistroListView.ShowGroups = false;
            this.DistroListView.SmallImageList = this.ImageList;
            this.DistroListView.UseCompatibleStateImageBehavior = false;
            this.DistroListView.ItemActivate += new System.EventHandler(this.DistroListView_ItemActivate);
            this.DistroListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.DistroListView_ItemDrag);
            this.DistroListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.DistroListView_ItemSelectionChanged);
            this.DistroListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DistroListView_MouseUp);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "linux");
            this.ImageList.Images.SetKeyName(1, "debian");
            this.ImageList.Images.SetKeyName(2, "suse");
            this.ImageList.Images.SetKeyName(3, "ubuntu");
            this.ImageList.Images.SetKeyName(4, "kali");
            // 
            // DistroContextMenuStrip
            // 
            resources.ApplyResources(this.DistroContextMenuStrip, "DistroContextMenuStrip");
            this.DistroContextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.DistroContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openWithToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.toolStripMenuItem3,
            this.createShortcutToolStripMenuItem,
            this.mapAsADriveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exportDistroToolStripMenuItem,
            this.toolStripMenuItem2,
            this.unregisterDistroToolStripMenuItem,
            this.terminateDistroToolStripMenuItem,
            this.toolStripMenuItem12,
            this.propertiesToolStripMenuItem});
            this.DistroContextMenuStrip.Name = "DistroContextMenuStrip";
            this.DistroContextMenuStrip.Opened += new System.EventHandler(this.DistroContextMenuStrip_Opening);
            // 
            // openToolStripMenuItem
            // 
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // openWithToolStripMenuItem
            // 
            resources.ApplyResources(this.openWithToolStripMenuItem, "openWithToolStripMenuItem");
            this.openWithToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hyperToolStripMenuItem,
            this.windowsTerminalToolStripMenuItem});
            this.openWithToolStripMenuItem.Name = "openWithToolStripMenuItem";
            // 
            // hyperToolStripMenuItem
            // 
            resources.ApplyResources(this.hyperToolStripMenuItem, "hyperToolStripMenuItem");
            this.hyperToolStripMenuItem.Name = "hyperToolStripMenuItem";
            this.hyperToolStripMenuItem.Click += new System.EventHandler(this.HyperToolStripMenuItem_Click);
            // 
            // windowsTerminalToolStripMenuItem
            // 
            resources.ApplyResources(this.windowsTerminalToolStripMenuItem, "windowsTerminalToolStripMenuItem");
            this.windowsTerminalToolStripMenuItem.Name = "windowsTerminalToolStripMenuItem";
            this.windowsTerminalToolStripMenuItem.Click += new System.EventHandler(this.WindowsTerminalToolStripMenuItem_Click);
            // 
            // exploreToolStripMenuItem
            // 
            resources.ApplyResources(this.exploreToolStripMenuItem, "exploreToolStripMenuItem");
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            this.exploreToolStripMenuItem.Click += new System.EventHandler(this.ExploreToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            // 
            // createShortcutToolStripMenuItem
            // 
            resources.ApplyResources(this.createShortcutToolStripMenuItem, "createShortcutToolStripMenuItem");
            this.createShortcutToolStripMenuItem.Name = "createShortcutToolStripMenuItem";
            this.createShortcutToolStripMenuItem.Click += new System.EventHandler(this.CreateShortcutToolStripMenuItem_Click);
            // 
            // mapAsADriveToolStripMenuItem
            // 
            resources.ApplyResources(this.mapAsADriveToolStripMenuItem, "mapAsADriveToolStripMenuItem");
            this.mapAsADriveToolStripMenuItem.Name = "mapAsADriveToolStripMenuItem";
            this.mapAsADriveToolStripMenuItem.Click += new System.EventHandler(this.MapAsADriveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // exportDistroToolStripMenuItem
            // 
            resources.ApplyResources(this.exportDistroToolStripMenuItem, "exportDistroToolStripMenuItem");
            this.exportDistroToolStripMenuItem.Name = "exportDistroToolStripMenuItem";
            this.exportDistroToolStripMenuItem.Click += new System.EventHandler(this.ExportDistroToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // unregisterDistroToolStripMenuItem
            // 
            resources.ApplyResources(this.unregisterDistroToolStripMenuItem, "unregisterDistroToolStripMenuItem");
            this.unregisterDistroToolStripMenuItem.Name = "unregisterDistroToolStripMenuItem";
            this.unregisterDistroToolStripMenuItem.Click += new System.EventHandler(this.UnregisterDistroToolStripMenuItem_Click);
            // 
            // terminateDistroToolStripMenuItem
            // 
            resources.ApplyResources(this.terminateDistroToolStripMenuItem, "terminateDistroToolStripMenuItem");
            this.terminateDistroToolStripMenuItem.Name = "terminateDistroToolStripMenuItem";
            this.terminateDistroToolStripMenuItem.Click += new System.EventHandler(this.TerminateDistroToolStripMenuItem_Click);
            // 
            // toolStripMenuItem12
            // 
            resources.ApplyResources(this.toolStripMenuItem12, "toolStripMenuItem12");
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            // 
            // propertiesToolStripMenuItem
            // 
            resources.ApplyResources(this.propertiesToolStripMenuItem, "propertiesToolStripMenuItem");
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItem_Click);
            // 
            // DefaultContextMenuStrip
            // 
            resources.ApplyResources(this.DefaultContextMenuStrip, "DefaultContextMenuStrip");
            this.DefaultContextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.DefaultContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewModeToolStripMenuItem,
            this.toolStripMenuItem5,
            this.newDistroToolStripMenuItem,
            this.importDistroToolStripMenuItem,
            this.toolStripMenuItem4,
            this.refreshToolStripMenuItem});
            this.DefaultContextMenuStrip.Name = "DefaultContextMenuStrip";
            // 
            // viewModeToolStripMenuItem
            // 
            resources.ApplyResources(this.viewModeToolStripMenuItem, "viewModeToolStripMenuItem");
            this.viewModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconsToolStripMenuItem,
            this.tileToolStripMenuItem,
            this.smallIconsToolStripMenuItem,
            this.listToolStripMenuItem,
            this.detailsToolStripMenuItem});
            this.viewModeToolStripMenuItem.Name = "viewModeToolStripMenuItem";
            this.viewModeToolStripMenuItem.DropDownOpening += new System.EventHandler(this.ViewModeToolStripMenuItem_DropDownOpening);
            // 
            // largeIconsToolStripMenuItem
            // 
            resources.ApplyResources(this.largeIconsToolStripMenuItem, "largeIconsToolStripMenuItem");
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            this.largeIconsToolStripMenuItem.Click += new System.EventHandler(this.LargeIconToolStripMenuItem_Click);
            // 
            // tileToolStripMenuItem
            // 
            resources.ApplyResources(this.tileToolStripMenuItem, "tileToolStripMenuItem");
            this.tileToolStripMenuItem.Name = "tileToolStripMenuItem";
            this.tileToolStripMenuItem.Click += new System.EventHandler(this.TileToolStripMenuItem_Click);
            // 
            // smallIconsToolStripMenuItem
            // 
            resources.ApplyResources(this.smallIconsToolStripMenuItem, "smallIconsToolStripMenuItem");
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Click += new System.EventHandler(this.SmallIconsToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem
            // 
            resources.ApplyResources(this.listToolStripMenuItem, "listToolStripMenuItem");
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.ListToolStripMenuItem_Click);
            // 
            // detailsToolStripMenuItem
            // 
            resources.ApplyResources(this.detailsToolStripMenuItem, "detailsToolStripMenuItem");
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.DetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            // 
            // newDistroToolStripMenuItem
            // 
            resources.ApplyResources(this.newDistroToolStripMenuItem, "newDistroToolStripMenuItem");
            this.newDistroToolStripMenuItem.Name = "newDistroToolStripMenuItem";
            this.newDistroToolStripMenuItem.Click += new System.EventHandler(this.NewDistroToolStripMenuItem_Click);
            // 
            // importDistroToolStripMenuItem
            // 
            resources.ApplyResources(this.importDistroToolStripMenuItem, "importDistroToolStripMenuItem");
            this.importDistroToolStripMenuItem.Name = "importDistroToolStripMenuItem";
            this.importDistroToolStripMenuItem.Click += new System.EventHandler(this.ImportDistroToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            // 
            // refreshToolStripMenuItem
            // 
            resources.ApplyResources(this.refreshToolStripMenuItem, "refreshToolStripMenuItem");
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // ExportDistroFileDialog
            // 
            this.ExportDistroFileDialog.DefaultExt = "tar.gz";
            resources.ApplyResources(this.ExportDistroFileDialog, "ExportDistroFileDialog");
            this.ExportDistroFileDialog.SupportMultiDottedExtensions = true;
            // 
            // ImportDistroFileDialog
            // 
            this.ImportDistroFileDialog.DefaultExt = "tar.gz";
            resources.ApplyResources(this.ImportDistroFileDialog, "ImportDistroFileDialog");
            this.ImportDistroFileDialog.SupportMultiDottedExtensions = true;
            // 
            // ImportLocationFolderDialog
            // 
            resources.ApplyResources(this.ImportLocationFolderDialog, "ImportLocationFolderDialog");
            // 
            // MainMenu
            // 
            resources.ApplyResources(this.MainMenu, "MainMenu");
            this.MainMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.distroToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Name = "MainMenu";
            // 
            // distroToolStripMenuItem
            // 
            resources.ApplyResources(this.distroToolStripMenuItem, "distroToolStripMenuItem");
            this.distroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDistroToolStripMenuItem1,
            this.openToolStripMenuItem1,
            this.openWithToolStripMenuItem1,
            this.toolStripMenuItem9,
            this.exploreToolStripMenuItem1,
            this.createShortcutToolStripMenuItem1,
            this.toolStripMenuItem6,
            this.exportDistroToolStripMenuItem1,
            this.toolStripMenuItem8,
            this.unregisterDistroToolStripMenuItem1,
            this.terminateDistroToolStripMenuItem1,
            this.toolStripMenuItem10,
            this.propertiesToolStripMenuItem1,
            this.toolStripMenuItem13,
            this.closeToolStripMenuItem});
            this.distroToolStripMenuItem.Name = "distroToolStripMenuItem";
            this.distroToolStripMenuItem.DropDownOpening += new System.EventHandler(this.DistroToolStripMenuItem_DropDownOpening);
            // 
            // newDistroToolStripMenuItem1
            // 
            resources.ApplyResources(this.newDistroToolStripMenuItem1, "newDistroToolStripMenuItem1");
            this.newDistroToolStripMenuItem1.Name = "newDistroToolStripMenuItem1";
            this.newDistroToolStripMenuItem1.Click += new System.EventHandler(this.NewDistroToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem1
            // 
            resources.ApplyResources(this.openToolStripMenuItem1, "openToolStripMenuItem1");
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // openWithToolStripMenuItem1
            // 
            resources.ApplyResources(this.openWithToolStripMenuItem1, "openWithToolStripMenuItem1");
            this.openWithToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hyperToolStripMenuItem1,
            this.windowsTerminalToolStripMenuItem1});
            this.openWithToolStripMenuItem1.Name = "openWithToolStripMenuItem1";
            // 
            // hyperToolStripMenuItem1
            // 
            resources.ApplyResources(this.hyperToolStripMenuItem1, "hyperToolStripMenuItem1");
            this.hyperToolStripMenuItem1.Name = "hyperToolStripMenuItem1";
            this.hyperToolStripMenuItem1.Click += new System.EventHandler(this.HyperToolStripMenuItem_Click);
            // 
            // windowsTerminalToolStripMenuItem1
            // 
            resources.ApplyResources(this.windowsTerminalToolStripMenuItem1, "windowsTerminalToolStripMenuItem1");
            this.windowsTerminalToolStripMenuItem1.Name = "windowsTerminalToolStripMenuItem1";
            this.windowsTerminalToolStripMenuItem1.Click += new System.EventHandler(this.WindowsTerminalToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            // 
            // exploreToolStripMenuItem1
            // 
            resources.ApplyResources(this.exploreToolStripMenuItem1, "exploreToolStripMenuItem1");
            this.exploreToolStripMenuItem1.Name = "exploreToolStripMenuItem1";
            this.exploreToolStripMenuItem1.DisplayStyleChanged += new System.EventHandler(this.ExploreToolStripMenuItem_Click);
            // 
            // createShortcutToolStripMenuItem1
            // 
            resources.ApplyResources(this.createShortcutToolStripMenuItem1, "createShortcutToolStripMenuItem1");
            this.createShortcutToolStripMenuItem1.Name = "createShortcutToolStripMenuItem1";
            this.createShortcutToolStripMenuItem1.Click += new System.EventHandler(this.CreateShortcutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            // 
            // exportDistroToolStripMenuItem1
            // 
            resources.ApplyResources(this.exportDistroToolStripMenuItem1, "exportDistroToolStripMenuItem1");
            this.exportDistroToolStripMenuItem1.Name = "exportDistroToolStripMenuItem1";
            this.exportDistroToolStripMenuItem1.Click += new System.EventHandler(this.ExportDistroToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            resources.ApplyResources(this.toolStripMenuItem8, "toolStripMenuItem8");
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            // 
            // unregisterDistroToolStripMenuItem1
            // 
            resources.ApplyResources(this.unregisterDistroToolStripMenuItem1, "unregisterDistroToolStripMenuItem1");
            this.unregisterDistroToolStripMenuItem1.Name = "unregisterDistroToolStripMenuItem1";
            this.unregisterDistroToolStripMenuItem1.Click += new System.EventHandler(this.UnregisterDistroToolStripMenuItem_Click);
            // 
            // terminateDistroToolStripMenuItem1
            // 
            resources.ApplyResources(this.terminateDistroToolStripMenuItem1, "terminateDistroToolStripMenuItem1");
            this.terminateDistroToolStripMenuItem1.Name = "terminateDistroToolStripMenuItem1";
            this.terminateDistroToolStripMenuItem1.Click += new System.EventHandler(this.TerminateDistroToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            resources.ApplyResources(this.toolStripMenuItem10, "toolStripMenuItem10");
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            // 
            // propertiesToolStripMenuItem1
            // 
            resources.ApplyResources(this.propertiesToolStripMenuItem1, "propertiesToolStripMenuItem1");
            this.propertiesToolStripMenuItem1.Name = "propertiesToolStripMenuItem1";
            this.propertiesToolStripMenuItem1.Click += new System.EventHandler(this.PropertiesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem13
            // 
            resources.ApplyResources(this.toolStripMenuItem13, "toolStripMenuItem13");
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            // 
            // closeToolStripMenuItem
            // 
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewModeToolStripMenuItem1,
            this.toolStripMenuItem18,
            this.orderByToolStripMenuItem,
            this.groupByToolStripMenuItem,
            this.toolStripMenuItem11,
            this.refreshToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            // 
            // viewModeToolStripMenuItem1
            // 
            resources.ApplyResources(this.viewModeToolStripMenuItem1, "viewModeToolStripMenuItem1");
            this.viewModeToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconToolStripMenuItem1,
            this.tileToolStripMenuItem1,
            this.smallIconsToolStripMenuItem1,
            this.listToolStripMenuItem1,
            this.detailsToolStripMenuItem1});
            this.viewModeToolStripMenuItem1.Name = "viewModeToolStripMenuItem1";
            this.viewModeToolStripMenuItem1.DropDownOpening += new System.EventHandler(this.ViewModeToolStripMenuItem1_DropDownOpening);
            // 
            // largeIconToolStripMenuItem1
            // 
            resources.ApplyResources(this.largeIconToolStripMenuItem1, "largeIconToolStripMenuItem1");
            this.largeIconToolStripMenuItem1.Name = "largeIconToolStripMenuItem1";
            this.largeIconToolStripMenuItem1.Click += new System.EventHandler(this.LargeIconToolStripMenuItem_Click);
            // 
            // tileToolStripMenuItem1
            // 
            resources.ApplyResources(this.tileToolStripMenuItem1, "tileToolStripMenuItem1");
            this.tileToolStripMenuItem1.Name = "tileToolStripMenuItem1";
            this.tileToolStripMenuItem1.Click += new System.EventHandler(this.TileToolStripMenuItem_Click);
            // 
            // smallIconsToolStripMenuItem1
            // 
            resources.ApplyResources(this.smallIconsToolStripMenuItem1, "smallIconsToolStripMenuItem1");
            this.smallIconsToolStripMenuItem1.Name = "smallIconsToolStripMenuItem1";
            this.smallIconsToolStripMenuItem1.Click += new System.EventHandler(this.SmallIconsToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem1
            // 
            resources.ApplyResources(this.listToolStripMenuItem1, "listToolStripMenuItem1");
            this.listToolStripMenuItem1.Name = "listToolStripMenuItem1";
            this.listToolStripMenuItem1.Click += new System.EventHandler(this.ListToolStripMenuItem_Click);
            // 
            // detailsToolStripMenuItem1
            // 
            resources.ApplyResources(this.detailsToolStripMenuItem1, "detailsToolStripMenuItem1");
            this.detailsToolStripMenuItem1.Name = "detailsToolStripMenuItem1";
            this.detailsToolStripMenuItem1.Click += new System.EventHandler(this.DetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem18
            // 
            resources.ApplyResources(this.toolStripMenuItem18, "toolStripMenuItem18");
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            // 
            // orderByToolStripMenuItem
            // 
            resources.ApplyResources(this.orderByToolStripMenuItem, "orderByToolStripMenuItem");
            this.orderByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderByRegisteredOrderToolStripMenuItem,
            this.orderByDistroNameToolStripMenuItem,
            this.orderByDistroTypesToolStripMenuItem,
            this.orderByDistroStatusToolStripMenuItem,
            this.toolStripMenuItem17,
            this.ascendingToolStripMenuItem,
            this.descendingToolStripMenuItem});
            this.orderByToolStripMenuItem.Name = "orderByToolStripMenuItem";
            this.orderByToolStripMenuItem.DropDownOpening += new System.EventHandler(this.OrderByToolStripMenuItem_DropDownOpening);
            // 
            // orderByRegisteredOrderToolStripMenuItem
            // 
            resources.ApplyResources(this.orderByRegisteredOrderToolStripMenuItem, "orderByRegisteredOrderToolStripMenuItem");
            this.orderByRegisteredOrderToolStripMenuItem.Name = "orderByRegisteredOrderToolStripMenuItem";
            this.orderByRegisteredOrderToolStripMenuItem.Click += new System.EventHandler(this.OrderByRegisteredOrderToolStripMenuItem_Click);
            // 
            // orderByDistroNameToolStripMenuItem
            // 
            resources.ApplyResources(this.orderByDistroNameToolStripMenuItem, "orderByDistroNameToolStripMenuItem");
            this.orderByDistroNameToolStripMenuItem.Name = "orderByDistroNameToolStripMenuItem";
            this.orderByDistroNameToolStripMenuItem.Click += new System.EventHandler(this.OrderByDistroNameToolStripMenuItem_Click);
            // 
            // orderByDistroTypesToolStripMenuItem
            // 
            resources.ApplyResources(this.orderByDistroTypesToolStripMenuItem, "orderByDistroTypesToolStripMenuItem");
            this.orderByDistroTypesToolStripMenuItem.Name = "orderByDistroTypesToolStripMenuItem";
            this.orderByDistroTypesToolStripMenuItem.Click += new System.EventHandler(this.OrderByDistroTypesToolStripMenuItem_Click);
            // 
            // orderByDistroStatusToolStripMenuItem
            // 
            resources.ApplyResources(this.orderByDistroStatusToolStripMenuItem, "orderByDistroStatusToolStripMenuItem");
            this.orderByDistroStatusToolStripMenuItem.Name = "orderByDistroStatusToolStripMenuItem";
            this.orderByDistroStatusToolStripMenuItem.Click += new System.EventHandler(this.OrderByDistroStatusToolStripMenuItem_Click);
            // 
            // toolStripMenuItem17
            // 
            resources.ApplyResources(this.toolStripMenuItem17, "toolStripMenuItem17");
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            // 
            // ascendingToolStripMenuItem
            // 
            resources.ApplyResources(this.ascendingToolStripMenuItem, "ascendingToolStripMenuItem");
            this.ascendingToolStripMenuItem.Name = "ascendingToolStripMenuItem";
            this.ascendingToolStripMenuItem.Click += new System.EventHandler(this.AscendingToolStripMenuItem_Click);
            // 
            // descendingToolStripMenuItem
            // 
            resources.ApplyResources(this.descendingToolStripMenuItem, "descendingToolStripMenuItem");
            this.descendingToolStripMenuItem.Name = "descendingToolStripMenuItem";
            this.descendingToolStripMenuItem.Click += new System.EventHandler(this.DescendingToolStripMenuItem_Click);
            // 
            // groupByToolStripMenuItem
            // 
            resources.ApplyResources(this.groupByToolStripMenuItem, "groupByToolStripMenuItem");
            this.groupByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wSLVersionGroupToolStripMenuItem,
            this.distroTypesGroupToolStripMenuItem,
            this.distroStatusGroupToolStripMenuItem,
            this.toolStripMenuItem16,
            this.noneGroupToolStripMenuItem});
            this.groupByToolStripMenuItem.Name = "groupByToolStripMenuItem";
            this.groupByToolStripMenuItem.DropDownOpening += new System.EventHandler(this.GroupByToolStripMenuItem_DropDownOpening);
            // 
            // wSLVersionGroupToolStripMenuItem
            // 
            resources.ApplyResources(this.wSLVersionGroupToolStripMenuItem, "wSLVersionGroupToolStripMenuItem");
            this.wSLVersionGroupToolStripMenuItem.Name = "wSLVersionGroupToolStripMenuItem";
            this.wSLVersionGroupToolStripMenuItem.Click += new System.EventHandler(this.WSLVersionGroupToolStripMenuItem_Click);
            // 
            // distroTypesGroupToolStripMenuItem
            // 
            resources.ApplyResources(this.distroTypesGroupToolStripMenuItem, "distroTypesGroupToolStripMenuItem");
            this.distroTypesGroupToolStripMenuItem.Name = "distroTypesGroupToolStripMenuItem";
            this.distroTypesGroupToolStripMenuItem.Click += new System.EventHandler(this.DistroTypesGroupToolStripMenuItem_Click);
            // 
            // distroStatusGroupToolStripMenuItem
            // 
            resources.ApplyResources(this.distroStatusGroupToolStripMenuItem, "distroStatusGroupToolStripMenuItem");
            this.distroStatusGroupToolStripMenuItem.Name = "distroStatusGroupToolStripMenuItem";
            this.distroStatusGroupToolStripMenuItem.Click += new System.EventHandler(this.DistroStatusGroupToolStripMenuItem_Click);
            // 
            // toolStripMenuItem16
            // 
            resources.ApplyResources(this.toolStripMenuItem16, "toolStripMenuItem16");
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            // 
            // noneGroupToolStripMenuItem
            // 
            resources.ApplyResources(this.noneGroupToolStripMenuItem, "noneGroupToolStripMenuItem");
            this.noneGroupToolStripMenuItem.Name = "noneGroupToolStripMenuItem";
            this.noneGroupToolStripMenuItem.Click += new System.EventHandler(this.NoneGroupToolStripMenuItem_Click);
            // 
            // toolStripMenuItem11
            // 
            resources.ApplyResources(this.toolStripMenuItem11, "toolStripMenuItem11");
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            // 
            // refreshToolStripMenuItem1
            // 
            resources.ApplyResources(this.refreshToolStripMenuItem1, "refreshToolStripMenuItem1");
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importDistroToolStripMenuItem1,
            this.mapAsADriveToolStripMenuItem1,
            this.toolStripMenuItem15,
            this.shutdownAllDistrosToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            // 
            // importDistroToolStripMenuItem1
            // 
            resources.ApplyResources(this.importDistroToolStripMenuItem1, "importDistroToolStripMenuItem1");
            this.importDistroToolStripMenuItem1.Name = "importDistroToolStripMenuItem1";
            this.importDistroToolStripMenuItem1.Click += new System.EventHandler(this.ImportDistroToolStripMenuItem_Click);
            // 
            // mapAsADriveToolStripMenuItem1
            // 
            resources.ApplyResources(this.mapAsADriveToolStripMenuItem1, "mapAsADriveToolStripMenuItem1");
            this.mapAsADriveToolStripMenuItem1.Name = "mapAsADriveToolStripMenuItem1";
            this.mapAsADriveToolStripMenuItem1.Click += new System.EventHandler(this.MapAsADriveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem15
            // 
            resources.ApplyResources(this.toolStripMenuItem15, "toolStripMenuItem15");
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            // 
            // shutdownAllDistrosToolStripMenuItem
            // 
            resources.ApplyResources(this.shutdownAllDistrosToolStripMenuItem, "shutdownAllDistrosToolStripMenuItem");
            this.shutdownAllDistrosToolStripMenuItem.Name = "shutdownAllDistrosToolStripMenuItem";
            this.shutdownAllDistrosToolStripMenuItem.Click += new System.EventHandler(this.ShutdownAllDistrosToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wSLDocumentationToolStripMenuItem,
            this.toolStripMenuItem14,
            this.wSLOfficialBlogToolStripMenuItem,
            this.wSLManagerOfficialWebSiteToolStripMenuItem,
            this.toolStripMenuItem7,
            this.AboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // wSLDocumentationToolStripMenuItem
            // 
            resources.ApplyResources(this.wSLDocumentationToolStripMenuItem, "wSLDocumentationToolStripMenuItem");
            this.wSLDocumentationToolStripMenuItem.Name = "wSLDocumentationToolStripMenuItem";
            this.wSLDocumentationToolStripMenuItem.Click += new System.EventHandler(this.WSLDocumentationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem14
            // 
            resources.ApplyResources(this.toolStripMenuItem14, "toolStripMenuItem14");
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            // 
            // wSLOfficialBlogToolStripMenuItem
            // 
            resources.ApplyResources(this.wSLOfficialBlogToolStripMenuItem, "wSLOfficialBlogToolStripMenuItem");
            this.wSLOfficialBlogToolStripMenuItem.Name = "wSLOfficialBlogToolStripMenuItem";
            this.wSLOfficialBlogToolStripMenuItem.Click += new System.EventHandler(this.WSLOfficialBlogToolStripMenuItem_Click);
            // 
            // wSLManagerOfficialWebSiteToolStripMenuItem
            // 
            resources.ApplyResources(this.wSLManagerOfficialWebSiteToolStripMenuItem, "wSLManagerOfficialWebSiteToolStripMenuItem");
            this.wSLManagerOfficialWebSiteToolStripMenuItem.Name = "wSLManagerOfficialWebSiteToolStripMenuItem";
            this.wSLManagerOfficialWebSiteToolStripMenuItem.Click += new System.EventHandler(this.WSLManagerOfficialWebSiteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            // 
            // AboutToolStripMenuItem
            // 
            resources.ApplyResources(this.AboutToolStripMenuItem, "AboutToolStripMenuItem");
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // StatusStrip
            // 
            resources.ApplyResources(this.StatusStrip, "StatusStrip");
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TotalCountLabel,
            this.SelectedCountLabel});
            this.StatusStrip.Name = "StatusStrip";
            // 
            // TotalCountLabel
            // 
            resources.ApplyResources(this.TotalCountLabel, "TotalCountLabel");
            this.TotalCountLabel.Name = "TotalCountLabel";
            // 
            // SelectedCountLabel
            // 
            resources.ApplyResources(this.SelectedCountLabel, "SelectedCountLabel");
            this.SelectedCountLabel.Name = "SelectedCountLabel";
            this.SelectedCountLabel.Spring = true;
            // 
            // ShortcutSaveFileDialog
            // 
            this.ShortcutSaveFileDialog.DefaultExt = "lnk";
            resources.ApplyResources(this.ShortcutSaveFileDialog, "ShortcutSaveFileDialog");
            this.ShortcutSaveFileDialog.SupportMultiDottedExtensions = true;
            // 
            // IconGenerator
            // 
            this.IconGenerator.DoWork += new System.ComponentModel.DoWorkEventHandler(this.IconGenerator_DoWork);
            this.IconGenerator.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.IconGenerator_RunWorkerCompleted);
            // 
            // ShimGenerator
            // 
            this.ShimGenerator.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ShimGenerator_DoWork);
            this.ShimGenerator.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ShimGenerator_RunWorkerCompleted);
            // 
            // ShortcutGenerator
            // 
            this.ShortcutGenerator.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ShortcutGenerator_DoWork);
            this.ShortcutGenerator.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ShortcutGenerator_RunWorkerCompleted);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.DistroListView);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DistroContextMenuStrip.ResumeLayout(false);
            this.DefaultContextMenuStrip.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView DistroListView;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.ContextMenuStrip DistroContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openWithToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hyperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportDistroToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem unregisterDistroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminateDistroToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip DefaultContextMenuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem importDistroToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog ExportDistroFileDialog;
        private System.Windows.Forms.OpenFileDialog ImportDistroFileDialog;
        private System.Windows.Forms.FolderBrowserDialog ImportLocationFolderDialog;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem distroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openWithToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hyperToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem exportDistroToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem unregisterDistroToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem terminateDistroToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem viewModeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem largeIconToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem smallIconsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem13;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel TotalCountLabel;
        private System.Windows.Forms.ToolStripStatusLabel SelectedCountLabel;
        private System.Windows.Forms.ToolStripMenuItem createShortcutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createShortcutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mapAsADriveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.SaveFileDialog ShortcutSaveFileDialog;
        private System.ComponentModel.BackgroundWorker IconGenerator;
        private System.ComponentModel.BackgroundWorker ShimGenerator;
        private System.ComponentModel.BackgroundWorker ShortcutGenerator;
        private System.Windows.Forms.ToolStripMenuItem newDistroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDistroToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem windowsTerminalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsTerminalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem wSLManagerOfficialWebSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wSLOfficialBlogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem wSLDocumentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDistroToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mapAsADriveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem shutdownAllDistrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem15;
        private System.Windows.Forms.ToolStripMenuItem groupByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wSLVersionGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distroTypesGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem16;
        private System.Windows.Forms.ToolStripMenuItem noneGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderByDistroNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderByDistroStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem ascendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem18;
        private System.Windows.Forms.ToolStripMenuItem distroStatusGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderByDistroTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderByRegisteredOrderToolStripMenuItem;
    }
}

