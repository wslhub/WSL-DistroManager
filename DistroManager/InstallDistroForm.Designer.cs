namespace DistroManager
{
    partial class InstallDistroForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallDistroForm));
            this.distroNameLabel = new System.Windows.Forms.Label();
            this.distroName = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.distroInstallPathLabel = new System.Windows.Forms.Label();
            this.distroInstallPath = new System.Windows.Forms.TextBox();
            this.directoryBrowseButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.installSourcePathLabel = new System.Windows.Forms.Label();
            this.installSourcePath = new System.Windows.Forms.TextBox();
            this.browseInstallPathButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // distroNameLabel
            // 
            this.distroNameLabel.AutoSize = true;
            this.distroNameLabel.Location = new System.Drawing.Point(9, 9);
            this.distroNameLabel.Name = "distroNameLabel";
            this.distroNameLabel.Size = new System.Drawing.Size(92, 13);
            this.distroNameLabel.TabIndex = 0;
            this.distroNameLabel.Text = "&New distro name: ";
            // 
            // distroName
            // 
            this.distroName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.distroName.Location = new System.Drawing.Point(12, 29);
            this.distroName.Name = "distroName";
            this.distroName.Size = new System.Drawing.Size(440, 20);
            this.distroName.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(377, 206);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmButton.Location = new System.Drawing.Point(296, 206);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 8;
            this.confirmButton.Text = "C&onfirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // distroInstallPathLabel
            // 
            this.distroInstallPathLabel.AutoSize = true;
            this.distroInstallPathLabel.Location = new System.Drawing.Point(9, 61);
            this.distroInstallPathLabel.Name = "distroInstallPathLabel";
            this.distroInstallPathLabel.Size = new System.Drawing.Size(93, 13);
            this.distroInstallPathLabel.TabIndex = 2;
            this.distroInstallPathLabel.Text = "&Distro install path: ";
            // 
            // distroInstallPath
            // 
            this.distroInstallPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.distroInstallPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.distroInstallPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.distroInstallPath.Location = new System.Drawing.Point(12, 81);
            this.distroInstallPath.Name = "distroInstallPath";
            this.distroInstallPath.Size = new System.Drawing.Size(359, 20);
            this.distroInstallPath.TabIndex = 3;
            // 
            // directoryBrowseButton
            // 
            this.directoryBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryBrowseButton.Location = new System.Drawing.Point(377, 79);
            this.directoryBrowseButton.Name = "directoryBrowseButton";
            this.directoryBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.directoryBrowseButton.TabIndex = 4;
            this.directoryBrowseButton.Text = "&Browse...";
            this.directoryBrowseButton.UseVisualStyleBackColor = true;
            this.directoryBrowseButton.Click += new System.EventHandler(this.directoryBrowseButton_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select an install path";
            // 
            // installSourcePathLabel
            // 
            this.installSourcePathLabel.AutoSize = true;
            this.installSourcePathLabel.Location = new System.Drawing.Point(9, 114);
            this.installSourcePathLabel.Name = "installSourcePathLabel";
            this.installSourcePathLabel.Size = new System.Drawing.Size(99, 13);
            this.installSourcePathLabel.TabIndex = 5;
            this.installSourcePathLabel.Text = "&Install source path: ";
            // 
            // installSourcePath
            // 
            this.installSourcePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.installSourcePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.installSourcePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.installSourcePath.Location = new System.Drawing.Point(12, 134);
            this.installSourcePath.Name = "installSourcePath";
            this.installSourcePath.Size = new System.Drawing.Size(359, 20);
            this.installSourcePath.TabIndex = 6;
            // 
            // browseInstallPathButton
            // 
            this.browseInstallPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseInstallPathButton.Location = new System.Drawing.Point(377, 132);
            this.browseInstallPathButton.Name = "browseInstallPathButton";
            this.browseInstallPathButton.Size = new System.Drawing.Size(75, 23);
            this.browseInstallPathButton.TabIndex = 7;
            this.browseInstallPathButton.Text = "&Browse...";
            this.browseInstallPathButton.UseVisualStyleBackColor = true;
            this.browseInstallPathButton.Click += new System.EventHandler(this.browseInstallPathButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "tar.gz";
            this.openFileDialog.Filter = "tar.gz File|*.tar.gz;*.tgz";
            this.openFileDialog.ReadOnlyChecked = true;
            this.openFileDialog.SupportMultiDottedExtensions = true;
            this.openFileDialog.Title = "Open an installation tar.gz file";
            // 
            // InstallDistroForm
            // 
            this.AcceptButton = this.confirmButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(464, 241);
            this.Controls.Add(this.browseInstallPathButton);
            this.Controls.Add(this.directoryBrowseButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.installSourcePath);
            this.Controls.Add(this.distroInstallPath);
            this.Controls.Add(this.distroName);
            this.Controls.Add(this.installSourcePathLabel);
            this.Controls.Add(this.distroInstallPathLabel);
            this.Controls.Add(this.distroNameLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 280);
            this.Name = "InstallDistroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Install new distro";
            this.Load += new System.EventHandler(this.InstallDistroForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label distroNameLabel;
        private System.Windows.Forms.TextBox distroName;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label distroInstallPathLabel;
        private System.Windows.Forms.TextBox distroInstallPath;
        private System.Windows.Forms.Button directoryBrowseButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label installSourcePathLabel;
        private System.Windows.Forms.TextBox installSourcePath;
        private System.Windows.Forms.Button browseInstallPathButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}