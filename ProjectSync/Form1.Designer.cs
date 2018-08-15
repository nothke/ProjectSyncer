namespace ProjectSync
{
    partial class Form1
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
            this.label_target = new System.Windows.Forms.Label();
            this.folderBrowserDialog_target = new System.Windows.Forms.FolderBrowserDialog();
            this.button_browseTargetFolder = new System.Windows.Forms.Button();
            this.textBox_targetFolder = new System.Windows.Forms.TextBox();
            this.button_sync = new System.Windows.Forms.Button();
            this.textBox_originFolder = new System.Windows.Forms.TextBox();
            this.button_browseOriginFolder = new System.Windows.Forms.Button();
            this.label_origin = new System.Windows.Forms.Label();
            this.textBox_bypassExtensions = new System.Windows.Forms.TextBox();
            this.label_dontsync = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_saveProjectFile = new System.Windows.Forms.Button();
            this.button_detect = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_target
            // 
            this.label_target.AutoSize = true;
            this.label_target.Location = new System.Drawing.Point(12, 37);
            this.label_target.Name = "label_target";
            this.label_target.Size = new System.Drawing.Size(50, 17);
            this.label_target.TabIndex = 0;
            this.label_target.Text = "Target";
            // 
            // button_browseTargetFolder
            // 
            this.button_browseTargetFolder.Location = new System.Drawing.Point(336, 34);
            this.button_browseTargetFolder.Name = "button_browseTargetFolder";
            this.button_browseTargetFolder.Size = new System.Drawing.Size(39, 23);
            this.button_browseTargetFolder.TabIndex = 1;
            this.button_browseTargetFolder.Text = "...";
            this.button_browseTargetFolder.UseVisualStyleBackColor = true;
            this.button_browseTargetFolder.Click += new System.EventHandler(this.button_browseTargetFolder_Click);
            // 
            // textBox_targetFolder
            // 
            this.textBox_targetFolder.Location = new System.Drawing.Point(68, 34);
            this.textBox_targetFolder.Name = "textBox_targetFolder";
            this.textBox_targetFolder.Size = new System.Drawing.Size(262, 22);
            this.textBox_targetFolder.TabIndex = 3;
            // 
            // button_sync
            // 
            this.button_sync.Location = new System.Drawing.Point(68, 119);
            this.button_sync.Name = "button_sync";
            this.button_sync.Size = new System.Drawing.Size(307, 55);
            this.button_sync.TabIndex = 4;
            this.button_sync.Text = "Sync!";
            this.button_sync.UseVisualStyleBackColor = true;
            this.button_sync.Click += new System.EventHandler(this.button_sync_Click);
            // 
            // textBox_originFolder
            // 
            this.textBox_originFolder.Location = new System.Drawing.Point(68, 6);
            this.textBox_originFolder.Name = "textBox_originFolder";
            this.textBox_originFolder.Size = new System.Drawing.Size(262, 22);
            this.textBox_originFolder.TabIndex = 7;
            // 
            // button_browseOriginFolder
            // 
            this.button_browseOriginFolder.Location = new System.Drawing.Point(336, 6);
            this.button_browseOriginFolder.Name = "button_browseOriginFolder";
            this.button_browseOriginFolder.Size = new System.Drawing.Size(39, 24);
            this.button_browseOriginFolder.TabIndex = 6;
            this.button_browseOriginFolder.Text = "...";
            this.button_browseOriginFolder.UseVisualStyleBackColor = true;
            this.button_browseOriginFolder.Click += new System.EventHandler(this.button_browseOriginFolder_Click);
            // 
            // label_origin
            // 
            this.label_origin.AutoSize = true;
            this.label_origin.Location = new System.Drawing.Point(12, 9);
            this.label_origin.Name = "label_origin";
            this.label_origin.Size = new System.Drawing.Size(46, 17);
            this.label_origin.TabIndex = 5;
            this.label_origin.Text = "Origin";
            // 
            // textBox_bypassExtensions
            // 
            this.textBox_bypassExtensions.Location = new System.Drawing.Point(92, 63);
            this.textBox_bypassExtensions.Name = "textBox_bypassExtensions";
            this.textBox_bypassExtensions.Size = new System.Drawing.Size(262, 22);
            this.textBox_bypassExtensions.TabIndex = 8;
            this.textBox_bypassExtensions.Text = "psd, tiff, raw";
            // 
            // label_dontsync
            // 
            this.label_dontsync.AutoSize = true;
            this.label_dontsync.Location = new System.Drawing.Point(12, 65);
            this.label_dontsync.Name = "label_dontsync";
            this.label_dontsync.Size = new System.Drawing.Size(74, 17);
            this.label_dontsync.TabIndex = 9;
            this.label_dontsync.Text = "Don\'t sync";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 261);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(357, 164);
            this.listBox1.TabIndex = 12;
            // 
            // button_saveProjectFile
            // 
            this.button_saveProjectFile.Image = global::ProjectSync.Properties.Resources._1f914;
            this.button_saveProjectFile.Location = new System.Drawing.Point(336, 206);
            this.button_saveProjectFile.Name = "button_saveProjectFile";
            this.button_saveProjectFile.Size = new System.Drawing.Size(36, 32);
            this.button_saveProjectFile.TabIndex = 13;
            this.button_saveProjectFile.UseVisualStyleBackColor = true;
            this.button_saveProjectFile.Click += new System.EventHandler(this.button_saveProjectFile_Click);
            // 
            // button_detect
            // 
            this.button_detect.Location = new System.Drawing.Point(11, 119);
            this.button_detect.Name = "button_detect";
            this.button_detect.Size = new System.Drawing.Size(60, 55);
            this.button_detect.TabIndex = 14;
            this.button_detect.Text = "Detect";
            this.button_detect.UseVisualStyleBackColor = true;
            this.button_detect.Click += new System.EventHandler(this.button_detect_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 426);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(384, 24);
            this.statusStrip.TabIndex = 15;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.AutoSize = false;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(260, 19);
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 18);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 450);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.button_detect);
            this.Controls.Add(this.button_saveProjectFile);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label_dontsync);
            this.Controls.Add(this.textBox_bypassExtensions);
            this.Controls.Add(this.label_origin);
            this.Controls.Add(this.textBox_originFolder);
            this.Controls.Add(this.button_browseOriginFolder);
            this.Controls.Add(this.button_sync);
            this.Controls.Add(this.textBox_targetFolder);
            this.Controls.Add(this.button_browseTargetFolder);
            this.Controls.Add(this.label_target);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ProjectSyncer";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_target;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_target;
        private System.Windows.Forms.Button button_browseTargetFolder;
        private System.Windows.Forms.TextBox textBox_targetFolder;
        private System.Windows.Forms.Button button_sync;
        private System.Windows.Forms.TextBox textBox_originFolder;
        private System.Windows.Forms.Button button_browseOriginFolder;
        private System.Windows.Forms.Label label_origin;
        private System.Windows.Forms.TextBox textBox_bypassExtensions;
        private System.Windows.Forms.Label label_dontsync;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button_saveProjectFile;
        private System.Windows.Forms.Button button_detect;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
    }
}

