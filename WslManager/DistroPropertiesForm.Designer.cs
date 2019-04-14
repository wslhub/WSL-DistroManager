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
            this.LocationLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.StateLabel = new System.Windows.Forms.Label();
            this.AppxNameLabel = new System.Windows.Forms.Label();
            this.DistroPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.AppxName = new System.Windows.Forms.Label();
            this.State = new System.Windows.Forms.Label();
            this.Size = new System.Windows.Forms.Label();
            this.Location = new System.Windows.Forms.Label();
            this.DistroSizeCalculator = new System.ComponentModel.BackgroundWorker();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
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
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(12, 85);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(61, 12);
            this.LocationLabel.TabIndex = 1;
            this.LocationLabel.Text = "Location: ";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(12, 117);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(38, 12);
            this.SizeLabel.TabIndex = 3;
            this.SizeLabel.Text = "Size: ";
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
            // AppxNameLabel
            // 
            this.AppxNameLabel.AutoSize = true;
            this.AppxNameLabel.Location = new System.Drawing.Point(12, 180);
            this.AppxNameLabel.Name = "AppxNameLabel";
            this.AppxNameLabel.Size = new System.Drawing.Size(80, 12);
            this.AppxNameLabel.TabIndex = 7;
            this.AppxNameLabel.Text = "Appx Name: ";
            // 
            // DistroPropertyGrid
            // 
            this.DistroPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DistroPropertyGrid.HelpVisible = false;
            this.DistroPropertyGrid.Location = new System.Drawing.Point(12, 206);
            this.DistroPropertyGrid.Name = "DistroPropertyGrid";
            this.DistroPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.DistroPropertyGrid.Size = new System.Drawing.Size(320, 134);
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
            // AppxName
            // 
            this.AppxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppxName.AutoEllipsis = true;
            this.AppxName.Location = new System.Drawing.Point(98, 180);
            this.AppxName.Name = "AppxName";
            this.AppxName.Size = new System.Drawing.Size(234, 12);
            this.AppxName.TabIndex = 8;
            this.AppxName.Text = "...";
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
            // Size
            // 
            this.Size.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Size.AutoEllipsis = true;
            this.Size.Location = new System.Drawing.Point(98, 117);
            this.Size.Name = "Size";
            this.Size.Size = new System.Drawing.Size(234, 12);
            this.Size.TabIndex = 4;
            this.Size.Text = "0 byte";
            // 
            // Location
            // 
            this.Location.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Location.AutoEllipsis = true;
            this.Location.Location = new System.Drawing.Point(98, 85);
            this.Location.Name = "Location";
            this.Location.Size = new System.Drawing.Size(234, 12);
            this.Location.TabIndex = 2;
            this.Location.Text = "...";
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
            // DistroPropertiesForm
            // 
            this.AcceptButton = this.ConfirmButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.ConfirmButton;
            this.ClientSize = new System.Drawing.Size(344, 381);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.DistroPropertyGrid);
            this.Controls.Add(this.Location);
            this.Controls.Add(this.Size);
            this.Controls.Add(this.State);
            this.Controls.Add(this.AppxName);
            this.Controls.Add(this.AppxNameLabel);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.LocationLabel);
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
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.Label AppxNameLabel;
        private System.Windows.Forms.PropertyGrid DistroPropertyGrid;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label AppxName;
        private System.Windows.Forms.Label State;
        private System.Windows.Forms.Label Size;
        private System.Windows.Forms.Label Location;
        private System.ComponentModel.BackgroundWorker DistroSizeCalculator;
        private System.Windows.Forms.ImageList ImageList;
    }
}