﻿using System;
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

        public Form1()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);

            projectFilePath = Properties.Settings.Default.lastProjectFile;

            if (!string.IsNullOrEmpty(projectFilePath))
            {
                LoadProjectFile(projectFilePath);
                Log("Loaded last project: " + Path.GetFileName(projectFilePath));
            }

            //textBox_originFolder.Text = Properties.Settings.Default.originPath;
            //textBox_targetFolder.Text = Properties.Settings.Default.targetPath;

            syncer = new Syncer();
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

            AssignProjectDataFromFile(file);
        }

        bool IsCorrectExtension(string filePath)
        {
            return Path.GetExtension(filePath) == ".syncer";
        }

        void AssignProjectDataFromFile(string filePath)
        {
            LoadProjectFile(filePath);

            Log("Loaded " + Path.GetFileName(filePath));
        }

        void XMLAppend(XmlDocument doc, XmlElement appendTo, string key, string value)
        {
            var e = doc.CreateElement(key);
            e.InnerText = value;
            appendTo.AppendChild(e);
        }

        void LoadProjectFile(string path)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);

            var root = xml["syncer_data"];
            textBox_originFolder.Text = root["origin_path"].InnerText;
            textBox_targetFolder.Text = root["target_path"].InnerText;
            textBox_bypassExtensions.Text = root["bypass_extensions"].InnerText;

            SetProjectFilePath(path);
        }



        void SaveProjectFile(string path)
        {
            XmlDocument xml = new XmlDocument();

            XmlElement root = xml.CreateElement("syncer_data");
            xml.AppendChild(root);

            XMLAppend(xml, root, "origin_path", textBox_originFolder.Text);
            XMLAppend(xml, root, "target_path", textBox_targetFolder.Text);
            XMLAppend(xml, root, "bypass_extensions", textBox_bypassExtensions.Text);

            xml.Save(path);

            SetProjectFilePath(path);
        }

        void SetProjectFilePath(string path)
        {
            projectFilePath = path;
            Console.WriteLine(path);
            Properties.Settings.Default.lastProjectFile = path;
            Properties.Settings.Default.Save();
        }

        private void button_browseTargetFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog_target.ShowDialog() == DialogResult.OK)
            {
                textBox_targetFolder.Text = folderBrowserDialog_target.SelectedPath;
            }
        }

        private void button_browseOriginFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog_target.ShowDialog() == DialogResult.OK)
            {
                textBox_originFolder.Text = folderBrowserDialog_target.SelectedPath;
            }
        }

        [Obsolete]
        void SavePathsToUserData()
        {
            string origin = textBox_originFolder.Text;
            string target = textBox_targetFolder.Text;

            //Properties.Settings.Default.originPath = origin;
            //Properties.Settings.Default.targetPath = target;
            //Properties.Settings.Default.Save();
        }

        void ApplyPathsFromUIToSyncer()
        {
            string origin = textBox_originFolder.Text;
            string target = textBox_targetFolder.Text;

            syncer.originPath = origin;
            syncer.targetPath = target;
        }

        void UpdateSyncer()
        {
            ApplyPathsFromUIToSyncer();

            syncer.SetExcludedExtensions(textBox_bypassExtensions.Text);
        }

        private void button_detect_Click(object sender, EventArgs e)
        {
            UpdateSyncer();

            string[] changedPaths = syncer.GetPathsThatChanged();
            syncer.TrimOriginFolderFromPaths(changedPaths);

            bool nothingToSync = syncer.originFiles == null || syncer.originFiles.Length == 0;

            listBox1.Items.Clear();

            if (!nothingToSync)
            {
                listBox1.Items.AddRange(changedPaths);

                Log("Found " + changedPaths.Length + " changed files");
            }
            else
            {
                Log("Nothing to Sync");
            }
        }
        
        private void button_sync_Click(object sender, EventArgs e)
        {
            ApplyPathsFromUIToSyncer();

            syncer.SetExcludedExtensions(textBox_bypassExtensions.Text);

            Log(syncer.Sync());

            if (syncer.originFiles != null)
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(syncer.GetShortNames());
            }
        }

        // Save project file dialogue
        private void button_saveProjectFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog.Filter = "Project Syncer file|*.syncer";
            saveFileDialog.Title = "Save a Project Syncer file";
            saveFileDialog.InitialDirectory = syncer.originPath;
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                SaveProjectFile(saveFileDialog.FileName);

                // Saves the Image via a FileStream created by the OpenFile method.  
                //System.IO.FileStream fs =
                //   (System.IO.FileStream)saveFileDialog.OpenFile();



                // Saves the Image in the appropriate ImageFormat based upon the  
                // File type selected in the dialog box.  
                // NOTE that the FilterIndex property is one-based.  
                /*
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.button2.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        this.button2.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        this.button2.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }*/
            }
        }

        void Log(string str)
        {
            //label_error.Text = str;
            toolStripStatusLabel.Text = str;
        }
    }
}