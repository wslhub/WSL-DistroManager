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
            this.ItemListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.AuthorColumn});
            this.ItemListView.FullRowSelect = true;
            this.ItemListView.HideSelection = false;
            this.ItemListView.LargeImageList = this.DefaultImageList;
            this.ItemListView.Location = new System.Drawing.Point(12, 12);
            this.ItemListView.MultiSelect = false;
            this.ItemListView.Name = "ItemListView";
            this.ItemListView.ShowItemToolTips = true;
            this.ItemListView.Size = new System.Drawing.Size(352, 388);
            this.ItemListView.SmallImageList = this.DefaultImageList;
            this.ItemListView.TabIndex = 0;
            this.ItemListView.UseCompatibleStateImageBehavior = false;
            this.ItemListView.View = System.Windows.Forms.View.Tile;
            this.ItemListView.ItemActivate += new System.EventHandler(this.ItemListView_ItemActivate);
            this.ItemListView.SelectedIndexChanged += new System.EventHandler(this.ItemListView_SelectedIndexChanged);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Distro Name";
            // 
            // AuthorColumn
            // 
            this.AuthorColumn.Text = "Author";
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
            this.DetailView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailView.IsWebBrowserContextMenuEnabled = false;
            this.DetailView.Location = new System.Drawing.Point(370, 12);
            this.DetailView.MinimumSize = new System.Drawing.Size(20, 20);
            this.DetailView.Name = "DetailView";
            this.DetailView.ScriptErrorsSuppressed = true;
            this.DetailView.Size = new System.Drawing.Size(242, 388);
            this.DetailView.TabIndex = 1;
            this.DetailView.TabStop = false;
            this.DetailView.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.DetailView.WebBrowserShortcutsEnabled = false;
            // 
            // DeclineButton
            // 
            this.DeclineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeclineButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DeclineButton.Location = new System.Drawing.Point(537, 406);
            this.DeclineButton.Name = "DeclineButton";
            this.DeclineButton.Size = new System.Drawing.Size(75, 23);
            this.DeclineButton.TabIndex = 5;
            this.DeclineButton.Text = "&Cancel";
            this.DeclineButton.UseVisualStyleBackColor = true;
            // 
            // InstallButton
            // 
            this.InstallButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallButton.Location = new System.Drawing.Point(456, 406);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(75, 23);
            this.InstallButton.TabIndex = 4;
            this.InstallButton.Text = "&Install";
            this.InstallButton.UseVisualStyleBackColor = true;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // ContributeButton
            // 
            this.ContributeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ContributeButton.Location = new System.Drawing.Point(12, 406);
            this.ContributeButton.Name = "ContributeButton";
            this.ContributeButton.Size = new System.Drawing.Size(75, 23);
            this.ContributeButton.TabIndex = 2;
            this.ContributeButton.Text = "Contribute";
            this.ContributeButton.UseVisualStyleBackColor = true;
            this.ContributeButton.Click += new System.EventHandler(this.ContributeButton_Click);
            // 
            // BrowseMSStoreButton
            // 
            this.BrowseMSStoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BrowseMSStoreButton.Location = new System.Drawing.Point(93, 406);
            this.BrowseMSStoreButton.Name = "BrowseMSStoreButton";
            this.BrowseMSStoreButton.Size = new System.Drawing.Size(163, 23);
            this.BrowseMSStoreButton.TabIndex = 3;
            this.BrowseMSStoreButton.Text = "Open Microsoft Store";
            this.BrowseMSStoreButton.UseVisualStyleBackColor = true;
            this.BrowseMSStoreButton.Click += new System.EventHandler(this.BrowseMSStoreButton_Click);
            // 
            // DistroGalleryForm
            // 
            this.AcceptButton = this.InstallButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.DeclineButton;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.BrowseMSStoreButton);
            this.Controls.Add(this.ContributeButton);
            this.Controls.Add(this.InstallButton);
            this.Controls.Add(this.DeclineButton);
            this.Controls.Add(this.DetailView);
            this.Controls.Add(this.ItemListView);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DistroGalleryForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Distro Gallery";
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