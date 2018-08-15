using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace ProjectSync
{
    public partial class Form1 : Form
    {
        public Syncer syncer;
        string projectFilePath;

        public Form1(string path)
        {
            InitializeComponent();

            AllowDrop = true;
            DragEnter += new DragEventHandler(Form1_DragEnter);
            DragDrop += new DragEventHandler(Form1_DragDrop);

            if (!string.IsNullOrEmpty(path))
                LoadProjectFile(path);
            else
                LoadLastProjectFile();

            syncer = new Syncer();
        }

        #region Project file handling

        void LoadLastProjectFile()
        {
            projectFilePath = Properties.Settings.Default.lastProjectFile;

            if (string.IsNullOrEmpty(projectFilePath)) return;

            if (File.Exists(projectFilePath))
            {
                LoadProjectFile(projectFilePath);
                Log("Loaded last project: " + Path.GetFileName(projectFilePath));
            }
            else
            {
                Log("Last project not found");
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (IsCorrectExtension(files[0]))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            string file = files[0];

            if (!IsCorrectExtension(file))
            {
                Log("Incorrect file extension");
                return;
            }

            LoadProjectFile(file);
        }

        bool IsCorrectExtension(string filePath)
        {
            return Path.GetExtension(filePath) == ".syncer";
        }

        void SetProjectFilePath(string path)
        {
            projectFilePath = path;
            Console.WriteLine(path);
            Properties.Settings.Default.lastProjectFile = path;
            Properties.Settings.Default.Save();
        }

        #endregion

        #region XML Serialization

        void LoadProjectFile(string path)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(path);

                var root = xml["syncer_data"];
                textBox_originFolder.Text = root["origin_path"].InnerText;
                textBox_targetFolder.Text = root["target_path"].InnerText;
                textBox_bypassExtensions.Text = root["bypass_extensions"].InnerText;
                textBox_bypassPrefixes.Text = root["bypass_prefixes"].InnerText;

                SetProjectFilePath(path);

                Log("Loaded " + Path.GetFileName(path));
            }
            catch (Exception e)
            {
                Log(e.ToString());
            }
        }

        void SaveProjectFile(string path)
        {
            XmlDocument xml = new XmlDocument();

            XmlElement root = xml.CreateElement("syncer_data");
            xml.AppendChild(root);

            XMLAppend(xml, root, "origin_path", textBox_originFolder.Text);
            XMLAppend(xml, root, "target_path", textBox_targetFolder.Text);
            XMLAppend(xml, root, "bypass_extensions", textBox_bypassExtensions.Text);
            XMLAppend(xml, root, "bypass_prefixes", textBox_bypassPrefixes.Text);

            xml.Save(path);

            SetProjectFilePath(path);
        }

        static void XMLAppend(XmlDocument doc, XmlElement appendTo, string key, string value)
        {
            var e = doc.CreateElement(key);
            e.InnerText = value;
            appendTo.AppendChild(e);
        }

        #endregion
        
        private void button_browseTargetFolder_Click(object sender, EventArgs e)
        {
            //folderBrowserDialog_target.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            folderBrowserDialog_target.SelectedPath = textBox_targetFolder.Text;
            if (folderBrowserDialog_target.ShowDialog() == DialogResult.OK)
                textBox_targetFolder.Text = folderBrowserDialog_target.SelectedPath;
        }

        private void button_browseOriginFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog_target.SelectedPath = textBox_originFolder.Text;
            if (folderBrowserDialog_target.ShowDialog() == DialogResult.OK)
                textBox_originFolder.Text = folderBrowserDialog_target.SelectedPath;
        }

        void UpdateSyncerParameters()
        {
            string origin = textBox_originFolder.Text;
            string target = textBox_targetFolder.Text;

            syncer.originPath = origin;
            syncer.targetPath = target;

            syncer.SetExcludedExtensions(textBox_bypassExtensions.Text);
            syncer.SetExcudedPrefixes(textBox_bypassPrefixes.Text);
        }

        // Detect
        private void button_detect_Click(object sender, EventArgs e)
        {
            UpdateSyncerParameters();

            int fileCount = syncer.CacheAllPaths();

            string[] changedPaths = syncer.GetPathsThatChanged(toolStripProgressBar);
            syncer.TrimOriginFolderFromPaths(changedPaths);

            bool nothingToSync = syncer.originFiles == null || syncer.originFiles.Length == 0;

            //listBox1.Items.Clear();

            if (!nothingToSync)
            {
                outputBox.Items.Add("..");
                outputBox.Items.AddRange(changedPaths);

                Log("Found " + changedPaths.Length + " changed files");
            }
            else
            {
                Log("Nothing to Sync");
            }
        }

        // SYNC!
        private void button_sync_Click(object sender, EventArgs e)
        {
            UpdateSyncerParameters();

            int fileCount = syncer.CacheAllPaths();

            toolStripProgressBar.Maximum = fileCount;
            toolStripProgressBar.Step = 1;

            syncer.Sync(toolStripProgressBar);

            if (syncer.originFiles != null)
            {
                //listBox1.Items.Clear();
                outputBox.Items.Add("..");
                outputBox.Items.AddRange(syncer.log.ToArray());
                OutputBoxSelectLast();
            }
        }

        // Save project file dialogue
        private void button_saveProjectFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Project Syncer file|*.syncer";
            saveFileDialog.Title = "Save a Project Syncer file";
            saveFileDialog.InitialDirectory = syncer.originPath;
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                SaveProjectFile(saveFileDialog.FileName);
            }
        }

        #region Log

        void Log(string str)
        {
            toolStripStatusLabel.Text = str;
            outputBox.Items.Add(str);
            OutputBoxSelectLast();
        }

        void OutputBoxSelectLast()
        {
            outputBox.SelectedIndex = outputBox.Items.Count - 1;
        }

        private void button_clearLog_Click(object sender, EventArgs e)
        {
            outputBox.Items.Clear();
        }

        #endregion
    }
}
