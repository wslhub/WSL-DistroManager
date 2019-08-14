namespace WslManager
{
    partial class DistroGalleryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistroGalleryForm));
            this.ItemListView = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DefaultImageList = new System.Windows.Forms.ImageList(this.components);
            this.FeedLoadWorker = new System.ComponentModel.BackgroundWorker();
            this.IconLoader = new System.ComponentModel.BackgroundWorker();
            this.DetailView = new System.Windows.Forms.WebBrowser();
            this.DeclineButton = new System.Windows.Forms.Button();
            this.InstallButton = new System.Windows.Forms.Button();
            this.ContributeButton = new System.Windows.Forms.Button();
            this.BrowseMSStoreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ItemListView
            // 
            resources.ApplyResources(this.ItemListView, "ItemListView");
            this.ItemListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.AuthorColumn});
            this.ItemListView.FullRowSelect = true;
            this.ItemListView.HideSelection = false;
            this.ItemListView.LargeImageList = this.DefaultImageList;
            this.ItemListView.MultiSelect = false;
            this.ItemListView.Name = "ItemListView";
            this.ItemListView.ShowItemToolTips = true;
            this.ItemListView.SmallImageList = this.DefaultImageList;
            this.ItemListView.UseCompatibleStateImageBehavior = false;
            this.ItemListView.View = System.Windows.Forms.View.Tile;
            this.ItemListView.ItemActivate += new System.EventHandler(this.ItemListView_ItemActivate);
            this.ItemListView.SelectedIndexChanged += new System.EventHandler(this.ItemListView_SelectedIndexChanged);
            // 
            // NameColumn
            // 
            resources.ApplyResources(this.NameColumn, "NameColumn");
            // 
            // AuthorColumn
            // 
            resources.ApplyResources(this.AuthorColumn, "AuthorColumn");
            // 
            // DefaultImageList
            // 
            this.DefaultImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DefaultImageList.ImageStream")));
            this.DefaultImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.DefaultImageList.Images.SetKeyName(0, "linux");
            this.DefaultImageList.Images.SetKeyName(1, "debian");
            this.DefaultImageList.Images.SetKeyName(2, "kali");
            this.DefaultImageList.Images.SetKeyName(3, "suse");
            this.DefaultImageList.Images.SetKeyName(4, "ubuntu");
            // 
            // FeedLoadWorker
            // 
            this.FeedLoadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FeedLoadWorker_DoWork);
            this.FeedLoadWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FeedLoadWorker_RunWorkerCompleted);
            // 
            // IconLoader
            // 
            this.IconLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.IconLoader_DoWork);
            this.IconLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.IconLoader_RunWorkerCompleted);
            // 
            // DetailView
            // 
            resources.ApplyResources(this.DetailView, "DetailView");
            this.DetailView.IsWebBrowserContextMenuEnabled = false;
            this.DetailView.Name = "DetailView";
            this.DetailView.ScriptErrorsSuppressed = true;
            this.DetailView.TabStop = false;
            this.DetailView.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.DetailView.WebBrowserShortcutsEnabled = false;
            // 
            // DeclineButton
            // 
            resources.ApplyResources(this.DeclineButton, "DeclineButton");
            this.DeclineButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DeclineButton.Name = "DeclineButton";
            this.DeclineButton.UseVisualStyleBackColor = true;
            // 
            // InstallButton
            // 
            resources.ApplyResources(this.InstallButton, "InstallButton");
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.UseVisualStyleBackColor = true;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // ContributeButton
            // 
            resources.ApplyResources(this.ContributeButton, "ContributeButton");
            this.ContributeButton.Name = "ContributeButton";
            this.ContributeButton.UseVisualStyleBackColor = true;
            this.ContributeButton.Click += new System.EventHandler(this.ContributeButton_Click);
            // 
            // BrowseMSStoreButton
            // 
            resources.ApplyResources(this.BrowseMSStoreButton, "BrowseMSStoreButton");
            this.BrowseMSStoreButton.Name = "BrowseMSStoreButton";
            this.BrowseMSStoreButton.UseVisualStyleBackColor = true;
            this.BrowseMSStoreButton.Click += new System.EventHandler(this.BrowseMSStoreButton_Click);
            // 
            // DistroGalleryForm
            // 
            this.AcceptButton = this.InstallButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.DeclineButton;
            this.Controls.Add(this.BrowseMSStoreButton);
            this.Controls.Add(this.ContributeButton);
            this.Controls.Add(this.InstallButton);
            this.Controls.Add(this.DeclineButton);
            this.Controls.Add(this.DetailView);
            this.Controls.Add(this.ItemListView);
            this.DoubleBuffered = true;
            this.Name = "DistroGalleryForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.DistroGalleryForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ItemListView;
        private System.Windows.Forms.ImageList DefaultImageList;
        private System.ComponentModel.BackgroundWorker FeedLoadWorker;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader AuthorColumn;
        private System.ComponentModel.BackgroundWorker IconLoader;
        private System.Windows.Forms.WebBrowser DetailView;
        private System.Windows.Forms.Button DeclineButton;
        private System.Windows.Forms.Button InstallButton;
        private System.Windows.Forms.Button ContributeButton;
        private System.Windows.Forms.Button BrowseMSStoreButton;
    }
}