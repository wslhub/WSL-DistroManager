namespace WslManager
{
    partial class DownloadDistroForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadDistroForm));
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.DeclineButton = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.RetryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BackgroundWorker
            // 
            this.BackgroundWorker.WorkerReportsProgress = true;
            this.BackgroundWorker.WorkerSupportsCancellation = true;
            this.BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.BackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_ProgressChanged);
            this.BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // DeclineButton
            // 
            resources.ApplyResources(this.DeclineButton, "DeclineButton");
            this.DeclineButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DeclineButton.Name = "DeclineButton";
            this.DeclineButton.UseVisualStyleBackColor = true;
            // 
            // ProgressBar
            // 
            resources.ApplyResources(this.ProgressBar, "ProgressBar");
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // RetryButton
            // 
            resources.ApplyResources(this.RetryButton, "RetryButton");
            this.RetryButton.Name = "RetryButton";
            this.RetryButton.UseVisualStyleBackColor = true;
            this.RetryButton.Click += new System.EventHandler(this.RetryButton_Click);
            // 
            // DownloadDistroForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.DeclineButton;
            this.Controls.Add(this.RetryButton);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.DeclineButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadDistroForm";
            this.ShowInTaskbar = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DownloadDistroForm_FormClosed);
            this.Load += new System.EventHandler(this.DownloadDistroForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BackgroundWorker;
        private System.Windows.Forms.Button DeclineButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button RetryButton;
    }
}