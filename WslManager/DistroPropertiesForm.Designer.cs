namespace WslManager
{
    partial class DistroPropertiesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistroPropertiesForm));
            this.DistroIcon = new System.Windows.Forms.PictureBox();
            this.DistroNameText = new System.Windows.Forms.TextBox();
            this.DistroLocationLabel = new System.Windows.Forms.Label();
            this.DistroSizeLabel = new System.Windows.Forms.Label();
            this.StateLabel = new System.Windows.Forms.Label();
            this.AppxNameLabel = new System.Windows.Forms.Label();
            this.DistroPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.AppxName = new System.Windows.Forms.Label();
            this.State = new System.Windows.Forms.Label();
            this.DistroSize = new System.Windows.Forms.Label();
            this.DistroLocation = new System.Windows.Forms.Label();
            this.DistroSizeCalculator = new System.ComponentModel.BackgroundWorker();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.WSLVersionLabel = new System.Windows.Forms.Label();
            this.WSLVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DistroIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // DistroIcon
            // 
            this.DistroIcon.Image = ((System.Drawing.Image)(resources.GetObject("DistroIcon.Image")));
            this.DistroIcon.Location = new System.Drawing.Point(21, 21);
            this.DistroIcon.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.DistroIcon.Name = "DistroIcon";
            this.DistroIcon.Size = new System.Drawing.Size(84, 84);
            this.DistroIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DistroIcon.TabIndex = 0;
            this.DistroIcon.TabStop = false;
            // 
            // DistroNameText
            // 
            this.DistroNameText.Location = new System.Drawing.Point(175, 68);
            this.DistroNameText.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.DistroNameText.Name = "DistroNameText";
            this.DistroNameText.ReadOnly = true;
            this.DistroNameText.Size = new System.Drawing.Size(403, 32);
            this.DistroNameText.TabIndex = 0;
            // 
            // DistroLocationLabel
            // 
            this.DistroLocationLabel.AutoSize = true;
            this.DistroLocationLabel.Location = new System.Drawing.Point(21, 149);
            this.DistroLocationLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.DistroLocationLabel.Name = "DistroLocationLabel";
            this.DistroLocationLabel.Size = new System.Drawing.Size(97, 21);
            this.DistroLocationLabel.TabIndex = 1;
            this.DistroLocationLabel.Text = "Location: ";
            // 
            // DistroSizeLabel
            // 
            this.DistroSizeLabel.AutoSize = true;
            this.DistroSizeLabel.Location = new System.Drawing.Point(21, 205);
            this.DistroSizeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.DistroSizeLabel.Name = "DistroSizeLabel";
            this.DistroSizeLabel.Size = new System.Drawing.Size(61, 21);
            this.DistroSizeLabel.TabIndex = 3;
            this.DistroSizeLabel.Text = "Size: ";
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Location = new System.Drawing.Point(21, 261);
            this.StateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(70, 21);
            this.StateLabel.TabIndex = 5;
            this.StateLabel.Text = "State: ";
            // 
            // AppxNameLabel
            // 
            this.AppxNameLabel.AutoSize = true;
            this.AppxNameLabel.Location = new System.Drawing.Point(21, 315);
            this.AppxNameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.AppxNameLabel.Name = "AppxNameLabel";
            this.AppxNameLabel.Size = new System.Drawing.Size(124, 21);
            this.AppxNameLabel.TabIndex = 7;
            this.AppxNameLabel.Text = "Appx Name: ";
            // 
            // DistroPropertyGrid
            // 
            this.DistroPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DistroPropertyGrid.HelpVisible = false;
            this.DistroPropertyGrid.Location = new System.Drawing.Point(21, 421);
            this.DistroPropertyGrid.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.DistroPropertyGrid.Name = "DistroPropertyGrid";
            this.DistroPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.DistroPropertyGrid.Size = new System.Drawing.Size(560, 173);
            this.DistroPropertyGrid.TabIndex = 9;
            this.DistroPropertyGrid.ToolbarVisible = false;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ConfirmButton.Location = new System.Drawing.Point(450, 606);
            this.ConfirmButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(131, 40);
            this.ConfirmButton.TabIndex = 10;
            this.ConfirmButton.Text = "&Close";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            // 
            // AppxName
            // 
            this.AppxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppxName.AutoEllipsis = true;
            this.AppxName.Location = new System.Drawing.Point(172, 315);
            this.AppxName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.AppxName.Name = "AppxName";
            this.AppxName.Size = new System.Drawing.Size(410, 21);
            this.AppxName.TabIndex = 8;
            this.AppxName.Text = "...";
            // 
            // State
            // 
            this.State.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.State.AutoEllipsis = true;
            this.State.Location = new System.Drawing.Point(172, 261);
            this.State.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(410, 21);
            this.State.TabIndex = 6;
            this.State.Text = "0x00000000";
            // 
            // DistroSize
            // 
            this.DistroSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DistroSize.AutoEllipsis = true;
            this.DistroSize.Location = new System.Drawing.Point(172, 205);
            this.DistroSize.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.DistroSize.Name = "DistroSize";
            this.DistroSize.Size = new System.Drawing.Size(410, 21);
            this.DistroSize.TabIndex = 4;
            this.DistroSize.Text = "0 byte";
            // 
            // DistroLocation
            // 
            this.DistroLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DistroLocation.AutoEllipsis = true;
            this.DistroLocation.Location = new System.Drawing.Point(172, 149);
            this.DistroLocation.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.DistroLocation.Name = "DistroLocation";
            this.DistroLocation.Size = new System.Drawing.Size(410, 21);
            this.DistroLocation.TabIndex = 2;
            this.DistroLocation.Text = "...";
            // 
            // DistroSizeCalculator
            // 
            this.DistroSizeCalculator.WorkerReportsProgress = true;
            this.DistroSizeCalculator.WorkerSupportsCancellation = true;
            this.DistroSizeCalculator.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DistroSizeCalculator_DoWork);
            this.DistroSizeCalculator.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DistroSizeCalculator_ProgressChanged);
            this.DistroSizeCalculator.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DistroSizeCalculator_RunWorkerCompleted);
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
            // WSLVersionLabel
            // 
            this.WSLVersionLabel.AutoSize = true;
            this.WSLVersionLabel.Location = new System.Drawing.Point(21, 369);
            this.WSLVersionLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.WSLVersionLabel.Name = "WSLVersionLabel";
            this.WSLVersionLabel.Size = new System.Drawing.Size(135, 21);
            this.WSLVersionLabel.TabIndex = 7;
            this.WSLVersionLabel.Text = "WSL Version: ";
            // 
            // WSLVersion
            // 
            this.WSLVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WSLVersion.AutoEllipsis = true;
            this.WSLVersion.Location = new System.Drawing.Point(172, 369);
            this.WSLVersion.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.WSLVersion.Name = "WSLVersion";
            this.WSLVersion.Size = new System.Drawing.Size(410, 21);
            this.WSLVersion.TabIndex = 8;
            this.WSLVersion.Text = "...";
            // 
            // DistroPropertiesForm
            // 
            this.AcceptButton = this.ConfirmButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.ConfirmButton;
            this.ClientSize = new System.Drawing.Size(602, 667);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.DistroPropertyGrid);
            this.Controls.Add(this.DistroLocation);
            this.Controls.Add(this.DistroSize);
            this.Controls.Add(this.State);
            this.Controls.Add(this.WSLVersion);
            this.Controls.Add(this.AppxName);
            this.Controls.Add(this.WSLVersionLabel);
            this.Controls.Add(this.AppxNameLabel);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.DistroSizeLabel);
            this.Controls.Add(this.DistroLocationLabel);
            this.Controls.Add(this.DistroNameText);
            this.Controls.Add(this.DistroIcon);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DistroPropertiesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Distro Properties";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DistroPropertiesForm_FormClosed);
            this.Load += new System.EventHandler(this.DistroPropertiesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DistroIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DistroIcon;
        private System.Windows.Forms.TextBox DistroNameText;
        private System.Windows.Forms.Label DistroLocationLabel;
        private System.Windows.Forms.Label DistroSizeLabel;
        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.Label AppxNameLabel;
        private System.Windows.Forms.PropertyGrid DistroPropertyGrid;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label AppxName;
        private System.Windows.Forms.Label State;
        private System.Windows.Forms.Label DistroSize;
        private System.Windows.Forms.Label DistroLocation;
        private System.ComponentModel.BackgroundWorker DistroSizeCalculator;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.Label WSLVersionLabel;
        private System.Windows.Forms.Label WSLVersion;
    }
}