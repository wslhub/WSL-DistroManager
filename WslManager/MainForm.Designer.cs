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
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportDistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.unregisterDistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.terminateDistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DefaultContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.installDistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ubuntu1804ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ubuntu1604ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debianGNULinuxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kaliLinuxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSUSEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sLESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.fromMicrosoftStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.importDistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportDistroFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ImportDistroFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ImportLocationFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.distroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DistroContextMenuStrip.SuspendLayout();
            this.DefaultContextMenuStrip.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DistroListView
            // 
            this.DistroListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DistroListView.HideSelection = false;
            this.DistroListView.LargeImageList = this.ImageList;
            this.DistroListView.Location = new System.Drawing.Point(0, 24);
            this.DistroListView.Name = "DistroListView";
            this.DistroListView.Size = new System.Drawing.Size(624, 417);
            this.DistroListView.SmallImageList = this.ImageList;
            this.DistroListView.TabIndex = 0;
            this.DistroListView.UseCompatibleStateImageBehavior = false;
            this.DistroListView.ItemActivate += new System.EventHandler(this.DistroListView_ItemActivate);
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
            // 
            // DistroContextMenuStrip
            // 
            this.DistroContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exportDistroToolStripMenuItem,
            this.toolStripMenuItem2,
            this.unregisterDistroToolStripMenuItem,
            this.toolStripMenuItem3,
            this.terminateDistroToolStripMenuItem});
            this.DistroContextMenuStrip.Name = "DistroContextMenuStrip";
            this.DistroContextMenuStrip.Size = new System.Drawing.Size(174, 132);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            this.exploreToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exploreToolStripMenuItem.Text = "&Explore...";
            this.exploreToolStripMenuItem.Click += new System.EventHandler(this.ExploreToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(170, 6);
            // 
            // exportDistroToolStripMenuItem
            // 
            this.exportDistroToolStripMenuItem.Name = "exportDistroToolStripMenuItem";
            this.exportDistroToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exportDistroToolStripMenuItem.Text = "E&xport Distro...";
            this.exportDistroToolStripMenuItem.Click += new System.EventHandler(this.ExportDistroToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(170, 6);
            // 
            // unregisterDistroToolStripMenuItem
            // 
            this.unregisterDistroToolStripMenuItem.Name = "unregisterDistroToolStripMenuItem";
            this.unregisterDistroToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.unregisterDistroToolStripMenuItem.Text = "&Unregister Distro...";
            this.unregisterDistroToolStripMenuItem.Click += new System.EventHandler(this.UnregisterDistroToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(170, 6);
            // 
            // terminateDistroToolStripMenuItem
            // 
            this.terminateDistroToolStripMenuItem.Name = "terminateDistroToolStripMenuItem";
            this.terminateDistroToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.terminateDistroToolStripMenuItem.Text = "&Terminate Distro...";
            this.terminateDistroToolStripMenuItem.Click += new System.EventHandler(this.TerminateDistroToolStripMenuItem_Click);
            // 
            // DefaultContextMenuStrip
            // 
            this.DefaultContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installDistroToolStripMenuItem,
            this.toolStripMenuItem5,
            this.refreshToolStripMenuItem,
            this.toolStripMenuItem4,
            this.importDistroToolStripMenuItem});
            this.DefaultContextMenuStrip.Name = "DefaultContextMenuStrip";
            this.DefaultContextMenuStrip.Size = new System.Drawing.Size(156, 82);
            // 
            // installDistroToolStripMenuItem
            // 
            this.installDistroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ubuntu1804ToolStripMenuItem,
            this.ubuntu1604ToolStripMenuItem,
            this.debianGNULinuxToolStripMenuItem,
            this.kaliLinuxToolStripMenuItem,
            this.openSUSEToolStripMenuItem,
            this.sLESToolStripMenuItem,
            this.toolStripMenuItem7,
            this.fromMicrosoftStoreToolStripMenuItem});
            this.installDistroToolStripMenuItem.Name = "installDistroToolStripMenuItem";
            this.installDistroToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.installDistroToolStripMenuItem.Text = "&Install Distro...";
            // 
            // ubuntu1804ToolStripMenuItem
            // 
            this.ubuntu1804ToolStripMenuItem.Name = "ubuntu1804ToolStripMenuItem";
            this.ubuntu1804ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.ubuntu1804ToolStripMenuItem.Text = "Ubuntu 18.04...";
            this.ubuntu1804ToolStripMenuItem.Click += new System.EventHandler(this.Ubuntu1804ToolStripMenuItem_Click);
            // 
            // ubuntu1604ToolStripMenuItem
            // 
            this.ubuntu1604ToolStripMenuItem.Name = "ubuntu1604ToolStripMenuItem";
            this.ubuntu1604ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.ubuntu1604ToolStripMenuItem.Text = "Ubuntu 16.04...";
            this.ubuntu1604ToolStripMenuItem.Click += new System.EventHandler(this.Ubuntu1604ToolStripMenuItem_Click);
            // 
            // debianGNULinuxToolStripMenuItem
            // 
            this.debianGNULinuxToolStripMenuItem.Name = "debianGNULinuxToolStripMenuItem";
            this.debianGNULinuxToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.debianGNULinuxToolStripMenuItem.Text = "Debian GNU/Linux...";
            this.debianGNULinuxToolStripMenuItem.Click += new System.EventHandler(this.DebianGNULinuxToolStripMenuItem_Click);
            // 
            // kaliLinuxToolStripMenuItem
            // 
            this.kaliLinuxToolStripMenuItem.Name = "kaliLinuxToolStripMenuItem";
            this.kaliLinuxToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.kaliLinuxToolStripMenuItem.Text = "Kali Linux...";
            this.kaliLinuxToolStripMenuItem.Click += new System.EventHandler(this.KaliLinuxToolStripMenuItem_Click);
            // 
            // openSUSEToolStripMenuItem
            // 
            this.openSUSEToolStripMenuItem.Name = "openSUSEToolStripMenuItem";
            this.openSUSEToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.openSUSEToolStripMenuItem.Text = "OpenSUSE...";
            this.openSUSEToolStripMenuItem.Click += new System.EventHandler(this.OpenSUSEToolStripMenuItem_Click);
            // 
            // sLESToolStripMenuItem
            // 
            this.sLESToolStripMenuItem.Name = "sLESToolStripMenuItem";
            this.sLESToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.sLESToolStripMenuItem.Text = "SLES...";
            this.sLESToolStripMenuItem.Click += new System.EventHandler(this.SLESToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(195, 6);
            // 
            // fromMicrosoftStoreToolStripMenuItem
            // 
            this.fromMicrosoftStoreToolStripMenuItem.Name = "fromMicrosoftStoreToolStripMenuItem";
            this.fromMicrosoftStoreToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.fromMicrosoftStoreToolStripMenuItem.Text = "From Microsoft Store...";
            this.fromMicrosoftStoreToolStripMenuItem.Click += new System.EventHandler(this.FromMicrosoftStoreToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(152, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 6);
            // 
            // importDistroToolStripMenuItem
            // 
            this.importDistroToolStripMenuItem.Name = "importDistroToolStripMenuItem";
            this.importDistroToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.importDistroToolStripMenuItem.Text = "&Import Distro...";
            this.importDistroToolStripMenuItem.Click += new System.EventHandler(this.ImportDistroToolStripMenuItem_Click);
            // 
            // ExportDistroFileDialog
            // 
            this.ExportDistroFileDialog.DefaultExt = "tar.gz";
            this.ExportDistroFileDialog.Filter = "Tarball GZIP file (*.tar.gz)|*.tar.gz";
            this.ExportDistroFileDialog.SupportMultiDottedExtensions = true;
            this.ExportDistroFileDialog.Title = "Export Distro";
            // 
            // ImportDistroFileDialog
            // 
            this.ImportDistroFileDialog.DefaultExt = "tar.gz";
            this.ImportDistroFileDialog.Filter = "Tarball GZIP file (*.tar.gz, *.tgz)|*.tar.gz;*.tgz";
            this.ImportDistroFileDialog.SupportMultiDottedExtensions = true;
            this.ImportDistroFileDialog.Title = "Import Distro";
            // 
            // ImportLocationFolderDialog
            // 
            this.ImportLocationFolderDialog.Description = "Specify the directory path to install distro.";
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.distroToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(624, 24);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "menuStrip1";
            // 
            // distroToolStripMenuItem
            // 
            this.distroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.distroToolStripMenuItem.Name = "distroToolStripMenuItem";
            this.distroToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.distroToolStripMenuItem.Text = "&Distro";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AboutToolStripMenuItem.Text = "&About...";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.DistroListView);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "WSL Manager [Beta]";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DistroContextMenuStrip.ResumeLayout(false);
            this.DefaultContextMenuStrip.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView DistroListView;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.ContextMenuStrip DistroContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportDistroToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem unregisterDistroToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem terminateDistroToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip DefaultContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem installDistroToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem importDistroToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog ExportDistroFileDialog;
        private System.Windows.Forms.OpenFileDialog ImportDistroFileDialog;
        private System.Windows.Forms.FolderBrowserDialog ImportLocationFolderDialog;
        private System.Windows.Forms.ToolStripMenuItem ubuntu1804ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ubuntu1604ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debianGNULinuxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kaliLinuxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSUSEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sLESToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem fromMicrosoftStoreToolStripMenuItem;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem distroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    }
}

