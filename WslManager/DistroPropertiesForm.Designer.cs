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
            resources.ApplyResources(this.DistroIcon, "DistroIcon");
            this.DistroIcon.Name = "DistroIcon";
            this.DistroIcon.TabStop = false;
            // 
            // DistroNameText
            // 
            resources.ApplyResources(this.DistroNameText, "DistroNameText");
            this.DistroNameText.Name = "DistroNameText";
            this.DistroNameText.ReadOnly = true;
            // 
            // DistroLocationLabel
            // 
            resources.ApplyResources(this.DistroLocationLabel, "DistroLocationLabel");
            this.DistroLocationLabel.Name = "DistroLocationLabel";
            // 
            // DistroSizeLabel
            // 
            resources.ApplyResources(this.DistroSizeLabel, "DistroSizeLabel");
            this.DistroSizeLabel.Name = "DistroSizeLabel";
            // 
            // StateLabel
            // 
            resources.ApplyResources(this.StateLabel, "StateLabel");
            this.StateLabel.Name = "StateLabel";
            // 
            // IsDefaultDistroLabel
            // 
            resources.ApplyResources(this.IsDefaultDistroLabel, "IsDefaultDistroLabel");
            this.IsDefaultDistroLabel.Name = "IsDefaultDistroLabel";
            // 
            // DistroPropertyGrid
            // 
            resources.ApplyResources(this.DistroPropertyGrid, "DistroPropertyGrid");
            this.DistroPropertyGrid.Name = "DistroPropertyGrid";
            this.DistroPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.DistroPropertyGrid.ToolbarVisible = false;
            // 
            // ConfirmButton
            // 
            resources.ApplyResources(this.ConfirmButton, "ConfirmButton");
            this.ConfirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            // 
            // IsDefaultDistro
            // 
            resources.ApplyResources(this.IsDefaultDistro, "IsDefaultDistro");
            this.IsDefaultDistro.AutoEllipsis = true;
            this.IsDefaultDistro.Name = "IsDefaultDistro";
            // 
            // State
            // 
            resources.ApplyResources(this.State, "State");
            this.State.AutoEllipsis = true;
            this.State.Name = "State";
            // 
            // DistroSize
            // 
            resources.ApplyResources(this.DistroSize, "DistroSize");
            this.DistroSize.AutoEllipsis = true;
            this.DistroSize.Name = "DistroSize";
            // 
            // DistroLocation
            // 
            resources.ApplyResources(this.DistroLocation, "DistroLocation");
            this.DistroLocation.AutoEllipsis = true;
            this.DistroLocation.Name = "DistroLocation";
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
            resources.ApplyResources(this.WSLVersionLabel, "WSLVersionLabel");
            this.WSLVersionLabel.Name = "WSLVersionLabel";
            // 
            // WSLVersion
            // 
            resources.ApplyResources(this.WSLVersion, "WSLVersion");
            this.WSLVersion.AutoEllipsis = true;
            this.WSLVersion.Name = "WSLVersion";
            // 
            // DistroPropertiesForm
            // 
            this.AcceptButton = this.ConfirmButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.ConfirmButton;
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