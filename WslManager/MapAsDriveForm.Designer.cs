namespace WslManager
{
    partial class MapAsDriveForm
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
            this.DriveLetterLabel = new System.Windows.Forms.Label();
            this.DriveLetter = new System.Windows.Forms.ComboBox();
            this.TargetDistroLabel = new System.Windows.Forms.Label();
            this.TargetDistro = new System.Windows.Forms.ComboBox();
            this.OptionsLabel = new System.Windows.Forms.Label();
            this.PersistentConnection = new System.Windows.Forms.CheckBox();
            this.MapDriveButton = new System.Windows.Forms.Button();
            this.UnmapDriveButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.DataSourceRefresher = new System.ComponentModel.BackgroundWorker();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.RefreshStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // DriveLetterLabel
            // 
            this.DriveLetterLabel.AutoSize = true;
            this.DriveLetterLabel.Location = new System.Drawing.Point(21, 18);
            this.DriveLetterLabel.Name = "DriveLetterLabel";
            this.DriveLetterLabel.Size = new System.Drawing.Size(76, 12);
            this.DriveLetterLabel.TabIndex = 0;
            this.DriveLetterLabel.Text = "Drive Letter: ";
            // 
            // DriveLetter
            // 
            this.DriveLetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DriveLetter.FormattingEnabled = true;
            this.DriveLetter.Location = new System.Drawing.Point(111, 15);
            this.DriveLetter.Name = "DriveLetter";
            this.DriveLetter.Size = new System.Drawing.Size(148, 20);
            this.DriveLetter.TabIndex = 1;
            this.DriveLetter.SelectedIndexChanged += new System.EventHandler(this.DriveLetter_SelectedIndexChanged);
            // 
            // TargetDistroLabel
            // 
            this.TargetDistroLabel.AutoSize = true;
            this.TargetDistroLabel.Location = new System.Drawing.Point(12, 48);
            this.TargetDistroLabel.Name = "TargetDistroLabel";
            this.TargetDistroLabel.Size = new System.Drawing.Size(85, 12);
            this.TargetDistroLabel.TabIndex = 2;
            this.TargetDistroLabel.Text = "Target Distro: ";
            // 
            // TargetDistro
            // 
            this.TargetDistro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetDistro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TargetDistro.FormattingEnabled = true;
            this.TargetDistro.Location = new System.Drawing.Point(111, 45);
            this.TargetDistro.Name = "TargetDistro";
            this.TargetDistro.Size = new System.Drawing.Size(221, 20);
            this.TargetDistro.TabIndex = 3;
            // 
            // OptionsLabel
            // 
            this.OptionsLabel.AutoSize = true;
            this.OptionsLabel.Location = new System.Drawing.Point(41, 81);
            this.OptionsLabel.Name = "OptionsLabel";
            this.OptionsLabel.Size = new System.Drawing.Size(56, 12);
            this.OptionsLabel.TabIndex = 4;
            this.OptionsLabel.Text = "Options: ";
            // 
            // PersistentConnection
            // 
            this.PersistentConnection.AutoSize = true;
            this.PersistentConnection.Location = new System.Drawing.Point(111, 80);
            this.PersistentConnection.Name = "PersistentConnection";
            this.PersistentConnection.Size = new System.Drawing.Size(148, 16);
            this.PersistentConnection.TabIndex = 5;
            this.PersistentConnection.Text = "Persistent Connection";
            this.PersistentConnection.UseVisualStyleBackColor = true;
            // 
            // MapDriveButton
            // 
            this.MapDriveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MapDriveButton.Enabled = false;
            this.MapDriveButton.Location = new System.Drawing.Point(12, 124);
            this.MapDriveButton.Name = "MapDriveButton";
            this.MapDriveButton.Size = new System.Drawing.Size(84, 23);
            this.MapDriveButton.TabIndex = 6;
            this.MapDriveButton.Text = "&Map Drive";
            this.MapDriveButton.UseVisualStyleBackColor = true;
            this.MapDriveButton.Click += new System.EventHandler(this.MapDriveButton_Click);
            // 
            // UnmapDriveButton
            // 
            this.UnmapDriveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UnmapDriveButton.Enabled = false;
            this.UnmapDriveButton.Location = new System.Drawing.Point(102, 124);
            this.UnmapDriveButton.Name = "UnmapDriveButton";
            this.UnmapDriveButton.Size = new System.Drawing.Size(110, 23);
            this.UnmapDriveButton.TabIndex = 7;
            this.UnmapDriveButton.Text = "&Unmap Drive";
            this.UnmapDriveButton.UseVisualStyleBackColor = true;
            this.UnmapDriveButton.Click += new System.EventHandler(this.UnmapDriveButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CloseButton.Location = new System.Drawing.Point(257, 124);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.Text = "&Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // DataSourceRefresher
            // 
            this.DataSourceRefresher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DataSourceRefresher_DoWork);
            this.DataSourceRefresher.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DataSourceRefresher_RunWorkerCompleted);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 159);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(344, 22);
            this.StatusStrip.SizingGrip = false;
            this.StatusStrip.TabIndex = 9;
            // 
            // RefreshStatusLabel
            // 
            this.RefreshStatusLabel.Name = "RefreshStatusLabel";
            this.RefreshStatusLabel.Size = new System.Drawing.Size(329, 17);
            this.RefreshStatusLabel.Spring = true;
            this.RefreshStatusLabel.Text = "Status";
            this.RefreshStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MapAsDriveForm
            // 
            this.AcceptButton = this.CloseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(344, 181);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.UnmapDriveButton);
            this.Controls.Add(this.MapDriveButton);
            this.Controls.Add(this.PersistentConnection);
            this.Controls.Add(this.TargetDistro);
            this.Controls.Add(this.DriveLetter);
            this.Controls.Add(this.OptionsLabel);
            this.Controls.Add(this.TargetDistroLabel);
            this.Controls.Add(this.DriveLetterLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapAsDriveForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Map as a drive";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapAsDriveForm_FormClosed);
            this.Load += new System.EventHandler(this.MapAsDriveForm_Load);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DriveLetterLabel;
        private System.Windows.Forms.ComboBox DriveLetter;
        private System.Windows.Forms.Label TargetDistroLabel;
        private System.Windows.Forms.ComboBox TargetDistro;
        private System.Windows.Forms.Label OptionsLabel;
        private System.Windows.Forms.CheckBox PersistentConnection;
        private System.Windows.Forms.Button MapDriveButton;
        private System.Windows.Forms.Button UnmapDriveButton;
        private System.Windows.Forms.Button CloseButton;
        private System.ComponentModel.BackgroundWorker DataSourceRefresher;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel RefreshStatusLabel;
    }
}