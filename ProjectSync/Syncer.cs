﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectSync
{
    public class Syncer
    {
        public string originPath;
        public string targetPath;

        public string[] originFiles;
        //string[] targetFiles;

        public string[] excludedExtensions;
        public string[] excludedPrefixes;

        public string[] TrimOriginFolderFromPaths(string[] paths)
        {
            int pathStartIndex = originPath.Length + 1;

            for (int i = 0; i < paths.Length; i++)
                paths[i] = paths[i].Substring(pathStartIndex);

            return paths;
        }

        string TrimOrigin(string str)
        {
            int pathStartIndex = originPath.Length + 1;
            return str.Substring(pathStartIndex);
        }

        public string[] GetShortNames()
        {
            int pathStartIndex = originPath.Length + 1;
            string[] output = new string[originFiles.Length];

            for (int i = 0; i < originFiles.Length; i++)
            {
                output[i] = originFiles[i].Substring(pathStartIndex);
            }

            return output;
        }

        bool IsExcluded(string path)
        {
            if (excludedExtensions == null)
                return false;

            string extension = Path.GetExtension(path);
            extension = extension.Trim('.');

            for (int e = 0; e < excludedExtensions.Length; e++)
            {
                if (extension == excludedExtensions[e])
                {
                    return true;
                }
            }

            return false;
        }

        void CacheChanges()
        {
            int pathStartIndex = originPath.Length + 1;

            originFiles = Directory.GetFiles(originPath, "*", SearchOption.AllDirectories);
            //originFiles = Directory.GetFileSystemEntries(originPath, "*", SearchOption.AllDirectories);

            List<string> files = new List<string>();

            for (int i = 0; i < originFiles.Length; i++)
            {
                string filePath = originFiles[i];

                if (IsExcluded(filePath))
                    continue;

                files.Add(filePath);
            }

            originFiles = files.ToArray();
        }

        public void SetExcludedExtensions(string rawext)
        {
            string[] exts = rawext.Split(',');

            for (int i = 0; i < exts.Length; i++)
            {
                exts[i] = exts[i].Trim();
            }

            excludedExtensions = exts;
        }

        private bool hasWriteAccessToFolder(string folderPath)
        {
            try
            {
                // Attempt to get a list of security permissions from the folder. 
                // This will raise an exception if the path is read only or do not have access to view the permissions. 
                System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }

        public string[] GetPathsThatChanged()
        {
            CacheChanges();

            List<string> changedPaths = new List<string>();

            for (int i = 0; i < originFiles.Length; i++)
            {
                string source = originFiles[i];
                string trimmed = TrimOrigin(originFiles[i]);
                string destination = Path.Combine(targetPath, trimmed);

                bool exists = File.Exists(destination);

                if (!exists)
                {
                    changedPaths.Add(destination);
                }
            }

            return changedPaths.ToArray();
        }

        public string Sync()
        {
            if (!Directory.Exists(originPath))
                return "Origin folder does not exist";

            if (!Directory.Exists(targetPath))
                return "Target folder does not exist";

            CacheChanges();

            if (!hasWriteAccessToFolder(targetPath))
                return "You do not have write permission";

            for (int i = 0; i < originFiles.Length; i++)
            {
                string source = originFiles[i];
                string trimmed = TrimOrigin(originFiles[i]);
                string destination = Path.Combine(targetPath, trimmed);

                bool exists = File.Exists(destination);

                if (!exists)
                {
                    string dir = Path.GetDirectoryName(destination);
                    Console.WriteLine(dir);

                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    File.Copy(source, destination);
                }

                Console.WriteLine(destination + ", " + exists);
            }

            return "Success";
        }
    }
}