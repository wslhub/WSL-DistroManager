namespace DistroManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.distroManagementTab = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.cloneButton = new System.Windows.Forms.Button();
            this.backupButton = new System.Windows.Forms.Button();
            this.setDefaultButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.installButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.installDistroListLabel = new System.Windows.Forms.Label();
            this.aboutTab = new System.Windows.Forms.TabPage();
            this.createBackupDialog = new System.Windows.Forms.SaveFileDialog();
            this.distributionNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defaultUidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defaultEnvironmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flagsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kernelCommandLineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distroInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl.SuspendLayout();
            this.distroManagementTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distroInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.distroManagementTab);
            this.tabControl.Controls.Add(this.aboutTab);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(600, 417);
            this.tabControl.TabIndex = 0;
            // 
            // distroManagementTab
            // 
            this.distroManagementTab.Controls.Add(this.dataGridView);
            this.distroManagementTab.Controls.Add(this.cloneButton);
            this.distroManagementTab.Controls.Add(this.backupButton);
            this.distroManagementTab.Controls.Add(this.setDefaultButton);
            this.distroManagementTab.Controls.Add(this.removeButton);
            this.distroManagementTab.Controls.Add(this.installButton);
            this.distroManagementTab.Controls.Add(this.refreshButton);
            this.distroManagementTab.Controls.Add(this.installDistroListLabel);
            this.distroManagementTab.Location = new System.Drawing.Point(4, 22);
            this.distroManagementTab.Name = "distroManagementTab";
            this.distroManagementTab.Padding = new System.Windows.Forms.Padding(3);
            this.distroManagementTab.Size = new System.Drawing.Size(592, 391);
            this.distroManagementTab.TabIndex = 0;
            this.distroManagementTab.Text = "Distro Management";
            this.distroManagementTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.distributionNameDataGridViewTextBoxColumn,
            this.defaultUidDataGridViewTextBoxColumn,
            this.basePathDataGridViewTextBoxColumn,
            this.defaultEnvironmentDataGridViewTextBoxColumn,
            this.flagsDataGridViewTextBoxColumn,
            this.kernelCommandLineDataGridViewTextBoxColumn,
            this.stateDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.distroInfoBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(20, 38);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(557, 300);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // cloneButton
            // 
            this.cloneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cloneButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cloneButton.Location = new System.Drawing.Point(257, 352);
            this.cloneButton.Name = "cloneButton";
            this.cloneButton.Size = new System.Drawing.Size(75, 23);
            this.cloneButton.TabIndex = 3;
            this.cloneButton.Text = "&Clone";
            this.cloneButton.UseVisualStyleBackColor = true;
            this.cloneButton.Click += new System.EventHandler(this.cloneButton_Click);
            // 
            // backupButton
            // 
            this.backupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backupButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backupButton.Location = new System.Drawing.Point(338, 352);
            this.backupButton.Name = "backupButton";
            this.backupButton.Size = new System.Drawing.Size(75, 23);
            this.backupButton.TabIndex = 4;
            this.backupButton.Text = "&Backup";
            this.backupButton.UseVisualStyleBackColor = true;
            this.backupButton.Click += new System.EventHandler(this.backupButton_Click);
            // 
            // setDefaultButton
            // 
            this.setDefaultButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.setDefaultButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.setDefaultButton.Location = new System.Drawing.Point(419, 352);
            this.setDefaultButton.Name = "setDefaultButton";
            this.setDefaultButton.Size = new System.Drawing.Size(75, 23);
            this.setDefaultButton.TabIndex = 5;
            this.setDefaultButton.Text = "&Set Default";
            this.setDefaultButton.UseVisualStyleBackColor = true;
            this.setDefaultButton.Click += new System.EventHandler(this.setDefaultButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.removeButton.Location = new System.Drawing.Point(500, 352);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 6;
            this.removeButton.Text = "&Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // installButton
            // 
            this.installButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.installButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.installButton.Location = new System.Drawing.Point(101, 352);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(75, 23);
            this.installButton.TabIndex = 2;
            this.installButton.Text = "&Install...";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.refreshButton.Location = new System.Drawing.Point(20, 352);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "&Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // installDistroListLabel
            // 
            this.installDistroListLabel.AutoSize = true;
            this.installDistroListLabel.Location = new System.Drawing.Point(17, 13);
            this.installDistroListLabel.Name = "installDistroListLabel";
            this.installDistroListLabel.Size = new System.Drawing.Size(193, 13);
            this.installDistroListLabel.TabIndex = 0;
            this.installDistroListLabel.Text = "Installed distro list (Double click to run): ";
            // 
            // aboutTab
            // 
            this.aboutTab.Location = new System.Drawing.Point(4, 22);
            this.aboutTab.Name = "aboutTab";
            this.aboutTab.Padding = new System.Windows.Forms.Padding(3);
            this.aboutTab.Size = new System.Drawing.Size(592, 391);
            this.aboutTab.TabIndex = 2;
            this.aboutTab.Text = "About";
            this.aboutTab.UseVisualStyleBackColor = true;
            // 
            // createBackupDialog
            // 
            this.createBackupDialog.DefaultExt = "tgz";
            this.createBackupDialog.Filter = "Tarball Archive with GZIP|*.tgz;*.tar.gz";
            this.createBackupDialog.SupportMultiDottedExtensions = true;
            this.createBackupDialog.Title = "Save Distro Backup File As";
            // 
            // distributionNameDataGridViewTextBoxColumn
            // 
            this.distributionNameDataGridViewTextBoxColumn.DataPropertyName = "DistributionName";
            this.distributionNameDataGridViewTextBoxColumn.HeaderText = "Distro Name";
            this.distributionNameDataGridViewTextBoxColumn.Name = "distributionNameDataGridViewTextBoxColumn";
            this.distributionNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.distributionNameDataGridViewTextBoxColumn.Width = 83;
            // 
            // defaultUidDataGridViewTextBoxColumn
            // 
            this.defaultUidDataGridViewTextBoxColumn.DataPropertyName = "DefaultUid";
            this.defaultUidDataGridViewTextBoxColumn.HeaderText = "Default UID";
            this.defaultUidDataGridViewTextBoxColumn.Name = "defaultUidDataGridViewTextBoxColumn";
            this.defaultUidDataGridViewTextBoxColumn.ReadOnly = true;
            this.defaultUidDataGridViewTextBoxColumn.Width = 81;
            // 
            // basePathDataGridViewTextBoxColumn
            // 
            this.basePathDataGridViewTextBoxColumn.DataPropertyName = "BasePath";
            this.basePathDataGridViewTextBoxColumn.HeaderText = "Base Path";
            this.basePathDataGridViewTextBoxColumn.Name = "basePathDataGridViewTextBoxColumn";
            this.basePathDataGridViewTextBoxColumn.ReadOnly = true;
            this.basePathDataGridViewTextBoxColumn.Width = 75;
            // 
            // defaultEnvironmentDataGridViewTextBoxColumn
            // 
            this.defaultEnvironmentDataGridViewTextBoxColumn.DataPropertyName = "DefaultEnvironment";
            this.defaultEnvironmentDataGridViewTextBoxColumn.HeaderText = "Environment Variables";
            this.defaultEnvironmentDataGridViewTextBoxColumn.Name = "defaultEnvironmentDataGridViewTextBoxColumn";
            this.defaultEnvironmentDataGridViewTextBoxColumn.ReadOnly = true;
            this.defaultEnvironmentDataGridViewTextBoxColumn.Width = 125;
            // 
            // flagsDataGridViewTextBoxColumn
            // 
            this.flagsDataGridViewTextBoxColumn.DataPropertyName = "Flags";
            this.flagsDataGridViewTextBoxColumn.HeaderText = "Flags";
            this.flagsDataGridViewTextBoxColumn.Name = "flagsDataGridViewTextBoxColumn";
            this.flagsDataGridViewTextBoxColumn.ReadOnly = true;
            this.flagsDataGridViewTextBoxColumn.Width = 57;
            // 
            // kernelCommandLineDataGridViewTextBoxColumn
            // 
            this.kernelCommandLineDataGridViewTextBoxColumn.DataPropertyName = "KernelCommandLine";
            this.kernelCommandLineDataGridViewTextBoxColumn.HeaderText = "Kernel Command Line";
            this.kernelCommandLineDataGridViewTextBoxColumn.Name = "kernelCommandLineDataGridViewTextBoxColumn";
            this.kernelCommandLineDataGridViewTextBoxColumn.ReadOnly = true;
            this.kernelCommandLineDataGridViewTextBoxColumn.Width = 105;
            // 
            // stateDataGridViewTextBoxColumn
            // 
            this.stateDataGridViewTextBoxColumn.DataPropertyName = "State";
            this.stateDataGridViewTextBoxColumn.HeaderText = "State";
            this.stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            this.stateDataGridViewTextBoxColumn.ReadOnly = true;
            this.stateDataGridViewTextBoxColumn.Width = 57;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.ReadOnly = true;
            this.versionDataGridViewTextBoxColumn.Width = 67;
            // 
            // distroInfoBindingSource
            // 
            this.distroInfoBindingSource.DataSource = typeof(DistroManager.DistroInfo);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.tabControl);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Text = "Windows Subsystem for Linux Distro Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.distroManagementTab.ResumeLayout(false);
            this.distroManagementTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distroInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage distroManagementTab;
        private System.Windows.Forms.TabPage aboutTab;
        private System.Windows.Forms.Button setDefaultButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label installDistroListLabel;
        private System.Windows.Forms.Button backupButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button cloneButton;
        private System.Windows.Forms.SaveFileDialog createBackupDialog;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn distributionNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn defaultUidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn basePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn defaultEnvironmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn flagsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kernelCommandLineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource distroInfoBindingSource;
    }
}