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
            this.IsDefaultDistroLabel = new System.Windows.Forms.Label();
            this.DistroPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.IsDefaultDistro = new System.Windows.Forms.Label();
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
            this.DistroIcon.Location = new System.Drawing.Point(12, 12);
            this.DistroIcon.Name = "DistroIcon";
            this.DistroIcon.Size = new System.Drawing.Size(48, 48);
            this.DistroIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DistroIcon.TabIndex = 0;
            this.DistroIcon.TabStop = false;
            // 
            // DistroNameText
            // 
            this.DistroNameText.Location = new System.Drawing.Point(100, 39);
            this.DistroNameText.Name = "DistroNameText";
            this.DistroNameText.ReadOnly = true;
            this.DistroNameText.Size = new System.Drawing.Size(232, 21);
            this.DistroNameText.TabIndex = 0;
            // 
            // DistroLocationLabel
            // 
            this.DistroLocationLabel.AutoSize = true;
            this.DistroLocationLabel.Location = new System.Drawing.Point(12, 85);
            this.DistroLocationLabel.Name = "DistroLocationLabel";
            this.DistroLocationLabel.Size = new System.Drawing.Size(61, 12);
            this.DistroLocationLabel.TabIndex = 1;
            this.DistroLocationLabel.Text = "Location: ";
            // 
            // DistroSizeLabel
            // 
            this.DistroSizeLabel.AutoSize = true;
            this.DistroSizeLabel.Location = new System.Drawing.Point(12, 117);
            this.DistroSizeLabel.Name = "DistroSizeLabel";
            this.DistroSizeLabel.Size = new System.Drawing.Size(38, 12);
            this.DistroSizeLabel.TabIndex = 3;
            this.DistroSizeLabel.Text = "Size: ";
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Location = new System.Drawing.Point(12, 149);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(41, 12);
            this.StateLabel.TabIndex = 5;
            this.StateLabel.Text = "State: ";
            // 
            // IsDefaultDistroLabel
            // 
            this.IsDefaultDistroLabel.AutoSize = true;
            this.IsDefaultDistroLabel.Location = new System.Drawing.Point(12, 180);
            this.IsDefaultDistroLabel.Name = "IsDefaultDistroLabel";
            this.IsDefaultDistroLabel.Size = new System.Drawing.Size(51, 12);
            this.IsDefaultDistroLabel.TabIndex = 7;
            this.IsDefaultDistroLabel.Text = "Default: ";
            // 
            // DistroPropertyGrid
            // 
            this.DistroPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DistroPropertyGrid.HelpVisible = false;
            this.DistroPropertyGrid.Location = new System.Drawing.Point(12, 241);
            this.DistroPropertyGrid.Name = "DistroPropertyGrid";
            this.DistroPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.DistroPropertyGrid.Size = new System.Drawing.Size(320, 99);
            this.DistroPropertyGrid.TabIndex = 9;
            this.DistroPropertyGrid.ToolbarVisible = false;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ConfirmButton.Location = new System.Drawing.Point(257, 346);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 10;
            this.ConfirmButton.Text = "&Close";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            // 
            // IsDefaultDistro
            // 
            this.IsDefaultDistro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IsDefaultDistro.AutoEllipsis = true;
            this.IsDefaultDistro.Location = new System.Drawing.Point(98, 180);
            this.IsDefaultDistro.Name = "IsDefaultDistro";
            this.IsDefaultDistro.Size = new System.Drawing.Size(234, 12);
            this.IsDefaultDistro.TabIndex = 8;
            this.IsDefaultDistro.Text = "...";
            // 
            // State
            // 
            this.State.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.State.AutoEllipsis = true;
            this.State.Location = new System.Drawing.Point(98, 149);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(234, 12);
            this.State.TabIndex = 6;
            this.State.Text = "0x00000000";
            // 
            // DistroSize
            // 
            this.DistroSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DistroSize.AutoEllipsis = true;
            this.DistroSize.Location = new System.Drawing.Point(98, 117);
            this.DistroSize.Name = "DistroSize";
            this.DistroSize.Size = new System.Drawing.Size(234, 12);
            this.DistroSize.TabIndex = 4;
            this.DistroSize.Text = "0 byte";
            // 
            // DistroLocation
            // 
            this.DistroLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DistroLocation.AutoEllipsis = true;
            this.DistroLocation.Location = new System.Drawing.Point(98, 85);
            this.DistroLocation.Name = "DistroLocation";
            this.DistroLocation.Size = new System.Drawing.Size(234, 12);
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
            this.WSLVersionLabel.Location = new System.Drawing.Point(12, 211);
            this.WSLVersionLabel.Name = "WSLVersionLabel";
            this.WSLVersionLabel.Size = new System.Drawing.Size(85, 12);
            this.WSLVersionLabel.TabIndex = 7;
            this.WSLVersionLabel.Text = "WSL Version: ";
            // 
            // WSLVersion
            // 
            this.WSLVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WSLVersion.AutoEllipsis = true;
            this.WSLVersion.Location = new System.Drawing.Point(98, 211);
            this.WSLVersion.Name = "WSLVersion";
            this.WSLVersion.Size = new System.Drawing.Size(234, 12);
            this.WSLVersion.TabIndex = 8;
            this.WSLVersion.Text = "...";
            // 
            // DistroPropertiesForm
            // 
            this.AcceptButton = this.ConfirmButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.ConfirmButton;
            this.ClientSize = new System.Drawing.Size(344, 381);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.DistroPropertyGrid);
            this.Controls.Add(this.DistroLocation);
            this.Controls.Add(this.DistroSize);
            this.Controls.Add(this.State);
            this.Controls.Add(this.WSLVersion);
            this.Controls.Add(this.IsDefaultDistro);
            this.Controls.Add(this.WSLVersionLabel);
            this.Controls.Add(this.IsDefaultDistroLabel);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.DistroSizeLabel);
            this.Controls.Add(this.DistroLocationLabel);
            this.Controls.Add(this.DistroNameText);
            this.Controls.Add(this.DistroIcon);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
        private System.Windows.Forms.Label IsDefaultDistroLabel;
        private System.Windows.Forms.PropertyGrid DistroPropertyGrid;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label IsDefaultDistro;
        private System.Windows.Forms.Label State;
        private System.Windows.Forms.Label DistroSize;
        private System.Windows.Forms.Label DistroLocation;
        private System.ComponentModel.BackgroundWorker DistroSizeCalculator;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.Label WSLVersionLabel;
        private System.Windows.Forms.Label WSLVersion;
    }
}