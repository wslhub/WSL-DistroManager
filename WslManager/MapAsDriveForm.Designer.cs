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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapAsDriveForm));
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
            resources.ApplyResources(this.DriveLetterLabel, "DriveLetterLabel");
            this.DriveLetterLabel.Name = "DriveLetterLabel";
            // 
            // DriveLetter
            // 
            resources.ApplyResources(this.DriveLetter, "DriveLetter");
            this.DriveLetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DriveLetter.FormattingEnabled = true;
            this.DriveLetter.Name = "DriveLetter";
            this.DriveLetter.SelectedIndexChanged += new System.EventHandler(this.DriveLetter_SelectedIndexChanged);
            // 
            // TargetDistroLabel
            // 
            resources.ApplyResources(this.TargetDistroLabel, "TargetDistroLabel");
            this.TargetDistroLabel.Name = "TargetDistroLabel";
            // 
            // TargetDistro
            // 
            resources.ApplyResources(this.TargetDistro, "TargetDistro");
            this.TargetDistro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TargetDistro.FormattingEnabled = true;
            this.TargetDistro.Name = "TargetDistro";
            // 
            // OptionsLabel
            // 
            resources.ApplyResources(this.OptionsLabel, "OptionsLabel");
            this.OptionsLabel.Name = "OptionsLabel";
            // 
            // PersistentConnection
            // 
            resources.ApplyResources(this.PersistentConnection, "PersistentConnection");
            this.PersistentConnection.Name = "PersistentConnection";
            this.PersistentConnection.UseVisualStyleBackColor = true;
            // 
            // MapDriveButton
            // 
            resources.ApplyResources(this.MapDriveButton, "MapDriveButton");
            this.MapDriveButton.Name = "MapDriveButton";
            this.MapDriveButton.UseVisualStyleBackColor = true;
            this.MapDriveButton.Click += new System.EventHandler(this.MapDriveButton_Click);
            // 
            // UnmapDriveButton
            // 
            resources.ApplyResources(this.UnmapDriveButton, "UnmapDriveButton");
            this.UnmapDriveButton.Name = "UnmapDriveButton";
            this.UnmapDriveButton.UseVisualStyleBackColor = true;
            this.UnmapDriveButton.Click += new System.EventHandler(this.UnmapDriveButton_Click);
            // 
            // CloseButton
            // 
            resources.ApplyResources(this.CloseButton, "CloseButton");
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // DataSourceRefresher
            // 
            this.DataSourceRefresher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DataSourceRefresher_DoWork);
            this.DataSourceRefresher.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DataSourceRefresher_RunWorkerCompleted);
            // 
            // StatusStrip
            // 
            resources.ApplyResources(this.StatusStrip, "StatusStrip");
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshStatusLabel});
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.SizingGrip = false;
            // 
            // RefreshStatusLabel
            // 
            resources.ApplyResources(this.RefreshStatusLabel, "RefreshStatusLabel");
            this.RefreshStatusLabel.Name = "RefreshStatusLabel";
            this.RefreshStatusLabel.Spring = true;
            // 
            // MapAsDriveForm
            // 
            this.AcceptButton = this.CloseButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.CloseButton;
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