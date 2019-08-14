namespace WslManager
{
    partial class DistroNameRequestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistroNameRequestForm));
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.DistroName = new System.Windows.Forms.TextBox();
            this.DeclineButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InstructionLabel
            // 
            resources.ApplyResources(this.InstructionLabel, "InstructionLabel");
            this.InstructionLabel.Name = "InstructionLabel";
            // 
            // DistroName
            // 
            resources.ApplyResources(this.DistroName, "DistroName");
            this.DistroName.Name = "DistroName";
            // 
            // DeclineButton
            // 
            resources.ApplyResources(this.DeclineButton, "DeclineButton");
            this.DeclineButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DeclineButton.Name = "DeclineButton";
            this.DeclineButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmButton
            // 
            resources.ApplyResources(this.ConfirmButton, "ConfirmButton");
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // DistroNameRequestForm
            // 
            this.AcceptButton = this.ConfirmButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.DeclineButton;
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.DeclineButton);
            this.Controls.Add(this.DistroName);
            this.Controls.Add(this.InstructionLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DistroNameRequestForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InstructionLabel;
        private System.Windows.Forms.TextBox DistroName;
        private System.Windows.Forms.Button DeclineButton;
        private System.Windows.Forms.Button ConfirmButton;
    }
}