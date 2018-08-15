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
            this.outputBox = new System.Windows.Forms.ListBox();
            this.button_saveProjectFile = new System.Windows.Forms.Button();
            this.button_detect = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_bypassPrefixes = new System.Windows.Forms.TextBox();
            this.button_clearLog = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.testbackgroundWorker = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_target
            // 
            this.label_target.AutoSize = true;
            this.label_target.Location = new System.Drawing.Point(8, 40);
            this.label_target.Name = "label_target";
            this.label_target.Size = new System.Drawing.Size(50, 17);
            this.label_target.TabIndex = 0;
            this.label_target.Text = "Target";
            // 
            // button_browseTargetFolder
            // 
            this.button_browseTargetFolder.Location = new System.Drawing.Point(344, 40);
            this.button_browseTargetFolder.Name = "button_browseTargetFolder";
            this.button_browseTargetFolder.Size = new System.Drawing.Size(32, 24);
            this.button_browseTargetFolder.TabIndex = 1;
            this.button_browseTargetFolder.Text = "...";
            this.button_browseTargetFolder.UseVisualStyleBackColor = true;
            this.button_browseTargetFolder.Click += new System.EventHandler(this.button_browseTargetFolder_Click);
            // 
            // textBox_targetFolder
            // 
            this.textBox_targetFolder.Location = new System.Drawing.Point(64, 40);
            this.textBox_targetFolder.Name = "textBox_targetFolder";
            this.textBox_targetFolder.Size = new System.Drawing.Size(272, 22);
            this.textBox_targetFolder.TabIndex = 3;
            // 
            // button_sync
            // 
            this.button_sync.Location = new System.Drawing.Point(80, 128);
            this.button_sync.Name = "button_sync";
            this.button_sync.Size = new System.Drawing.Size(296, 55);
            this.button_sync.TabIndex = 4;
            this.button_sync.Text = "Sync!";
            this.button_sync.UseVisualStyleBackColor = true;
            this.button_sync.Click += new System.EventHandler(this.button_sync_Click);
            // 
            // textBox_originFolder
            // 
            this.textBox_originFolder.Location = new System.Drawing.Point(64, 8);
            this.textBox_originFolder.Name = "textBox_originFolder";
            this.textBox_originFolder.Size = new System.Drawing.Size(272, 22);
            this.textBox_originFolder.TabIndex = 7;
            // 
            // button_browseOriginFolder
            // 
            this.button_browseOriginFolder.Location = new System.Drawing.Point(344, 8);
            this.button_browseOriginFolder.Name = "button_browseOriginFolder";
            this.button_browseOriginFolder.Size = new System.Drawing.Size(32, 24);
            this.button_browseOriginFolder.TabIndex = 6;
            this.button_browseOriginFolder.Text = "...";
            this.button_browseOriginFolder.UseVisualStyleBackColor = true;
            this.button_browseOriginFolder.Click += new System.EventHandler(this.button_browseOriginFolder_Click);
            // 
            // label_origin
            // 
            this.label_origin.AutoSize = true;
            this.label_origin.Location = new System.Drawing.Point(8, 8);
            this.label_origin.Name = "label_origin";
            this.label_origin.Size = new System.Drawing.Size(46, 17);
            this.label_origin.TabIndex = 5;
            this.label_origin.Text = "Origin";
            // 
            // textBox_bypassExtensions
            // 
            this.textBox_bypassExtensions.Location = new System.Drawing.Point(104, 72);
            this.textBox_bypassExtensions.Name = "textBox_bypassExtensions";
            this.textBox_bypassExtensions.Size = new System.Drawing.Size(272, 22);
            this.textBox_bypassExtensions.TabIndex = 8;
            this.textBox_bypassExtensions.Text = "psd, tiff, raw";
            // 
            // label_dontsync
            // 
            this.label_dontsync.AutoSize = true;
            this.label_dontsync.Location = new System.Drawing.Point(8, 72);
            this.label_dontsync.Name = "label_dontsync";
            this.label_dontsync.Size = new System.Drawing.Size(76, 17);
            this.label_dontsync.TabIndex = 9;
            this.label_dontsync.Text = "Bypass ext";
            // 
            // outputBox
            // 
            this.outputBox.FormattingEnabled = true;
            this.outputBox.ItemHeight = 16;
            this.outputBox.Location = new System.Drawing.Point(8, 232);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(368, 180);
            this.outputBox.TabIndex = 12;
            // 
            // button_saveProjectFile
            // 
            this.button_saveProjectFile.Image = global::ProjectSync.Properties.Resources._1f914;
            this.button_saveProjectFile.Location = new System.Drawing.Point(344, 192);
            this.button_saveProjectFile.Name = "button_saveProjectFile";
            this.button_saveProjectFile.Size = new System.Drawing.Size(32, 32);
            this.button_saveProjectFile.TabIndex = 13;
            this.button_saveProjectFile.UseVisualStyleBackColor = true;
            this.button_saveProjectFile.Click += new System.EventHandler(this.button_saveProjectFile_Click);
            // 
            // button_detect
            // 
            this.button_detect.Location = new System.Drawing.Point(8, 128);
            this.button_detect.Name = "button_detect";
            this.button_detect.Size = new System.Drawing.Size(72, 55);
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
            this.progressBar});
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
            // progressBar
            // 
            this.progressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 18);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Bypass prefix";
            // 
            // textBox_bypassPrefixes
            // 
            this.textBox_bypassPrefixes.Location = new System.Drawing.Point(104, 104);
            this.textBox_bypassPrefixes.Name = "textBox_bypassPrefixes";
            this.textBox_bypassPrefixes.Size = new System.Drawing.Size(272, 22);
            this.textBox_bypassPrefixes.TabIndex = 17;
            this.textBox_bypassPrefixes.Text = "_";
            // 
            // button_clearLog
            // 
            this.button_clearLog.Location = new System.Drawing.Point(8, 200);
            this.button_clearLog.Name = "button_clearLog";
            this.button_clearLog.Size = new System.Drawing.Size(104, 31);
            this.button_clearLog.TabIndex = 18;
            this.button_clearLog.Text = "Clear Log";
            this.button_clearLog.UseVisualStyleBackColor = true;
            this.button_clearLog.Click += new System.EventHandler(this.button_clearLog_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // testbackgroundWorker
            // 
            this.testbackgroundWorker.Location = new System.Drawing.Point(152, 192);
            this.testbackgroundWorker.Name = "testbackgroundWorker";
            this.testbackgroundWorker.Size = new System.Drawing.Size(75, 23);
            this.testbackgroundWorker.TabIndex = 19;
            this.testbackgroundWorker.Text = "button1";
            this.testbackgroundWorker.UseVisualStyleBackColor = true;
            this.testbackgroundWorker.Click += new System.EventHandler(this.testbackgroundWorker_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 450);
            this.Controls.Add(this.testbackgroundWorker);
            this.Controls.Add(this.button_clearLog);
            this.Controls.Add(this.textBox_bypassPrefixes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.button_detect);
            this.Controls.Add(this.button_saveProjectFile);
            this.Controls.Add(this.outputBox);
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
        private System.Windows.Forms.ListBox outputBox;
        private System.Windows.Forms.Button button_saveProjectFile;
        private System.Windows.Forms.Button button_detect;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_bypassPrefixes;
        private System.Windows.Forms.Button button_clearLog;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button testbackgroundWorker;
    }
}

