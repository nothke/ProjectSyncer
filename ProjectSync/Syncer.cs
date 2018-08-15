using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Windows.Forms;

using System.Security.Cryptography;

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

        public string[] lastChangedFiles;

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
            return IsExcludedByExtension(path) || IsExcludedByPrefix(path);
        }

        bool IsExcludedByExtension(string path)
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

        bool IsExcludedByPrefix(string path)
        {
            if (excludedPrefixes == null)
                return false;

            string fileName = Path.GetFileName(path);

            for (int p = 0; p < excludedPrefixes.Length; p++)
            {
                if (fileName.StartsWith(excludedPrefixes[p]))
                    return true;
            }

            return false;
        }

        [Obsolete]
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

        public void SetExcudedPrefixes(string rawPrefixes)
        {
            string[] prefixes = rawPrefixes.Split(',');

            for (int i = 0; i < prefixes.Length; i++)
            {
                prefixes[i] = prefixes[i].Trim();
            }

            excludedPrefixes = prefixes;
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

        public int CacheAllPaths()
        {
            originFiles = Directory.GetFiles(originPath, "*", SearchOption.AllDirectories);

            List<string> files = new List<string>();

            for (int i = 0; i < originFiles.Length; i++)
            {
                string filePath = originFiles[i];

                if (IsExcluded(filePath))
                    continue;

                files.Add(filePath);
            }

            originFiles = files.ToArray();

            return originFiles.Length;
        }

        int asyncstep;
        List<string> changedPathsAsync = new List<string>();

        public void ResetAsync()
        {
            asyncstep = 0;
            progress = 0;
            changedPathsAsync.Clear();
        }

        public void StepPathsThatChanged()
        {
            if (asyncstep >= originFiles.Length)
                return;

            if (asyncstep == 0)
                changedPathsAsync.Clear();

            string source = originFiles[asyncstep];
            string trimmed = TrimOrigin(source);
            string destination = Path.Combine(targetPath, trimmed);

            bool exists = File.Exists(destination);

            if (!exists) // if it doesn't exist just overwrite it
            {
                changedPathsAsync.Add(source);
            }
            else // instead compare hashes
            {
                byte[] sourceHash = GetFileSHA1(source);
                byte[] destinationHash = GetFileSHA1(destination);

                if (!sourceHash.SequenceEqual(destinationHash))
                    changedPathsAsync.Add(source);

                //Console.WriteLine(System.Text.Encoding.Default.GetString(hash));
            }

            asyncstep++;
            Console.WriteLine(trimmed);
        }

        public void QueryChanges()
        {
            GetPathsThatChanged();
        }

        public IEnumerable<string> FindChangeAndSync()
        {
            //List<string> changedPaths = new List<string>();

            yield return "Detecting changes..";
            foreach (var str in GetPathsThatChange())
            {
                yield return "Change: " + TrimOrigin(str);
            }

            if (changedPathsAsync.Count == 0)
            {
                yield return "No changes found";
                yield break;
            }

            yield return "Copying files..";
            string[] changedPathsArray = changedPathsAsync.ToArray();

            foreach (var str in SyncCo(changedPathsArray))
            {
                yield return "Copied: " + str;
            }
        }

        public IEnumerable<string> GetPathsThatChange()
        {
            changedPathsAsync.Clear();

            for (int i = 0; i < originFiles.Length; i++)
            {
                string source = originFiles[i];
                string trimmed = TrimOrigin(originFiles[i]);
                string destination = Path.Combine(targetPath, trimmed);

                bool exists = File.Exists(destination);

                if (!exists) // if it doesn't exist just overwrite it
                {
                    changedPathsAsync.Add(source);
                    yield return source;
                }
                else // instead compare hashes
                {
                    byte[] sourceHash = GetFileSHA1(source);
                    byte[] destinationHash = GetFileSHA1(destination);

                    if (!sourceHash.SequenceEqual(destinationHash))
                    {
                        changedPathsAsync.Add(source);
                        yield return source;
                    }
                    else
                    {
                    }

                    yield return source;
                    Console.WriteLine(source);

                    //if (!change)
                      //  Form1.progressMax = 0;
                }




                Console.WriteLine("Do we see this? " + progress);
                progress++;
            }
        }

        public IEnumerable<string> SyncCo(string[] changedPaths)
        {
            if (!Directory.Exists(originPath)) { log.Add("Origin folder does not exist"); yield break; }
            if (!Directory.Exists(targetPath)) { log.Add("Target folder does not exist"); yield break; }
            if (!hasWriteAccessToFolder(targetPath)) { log.Add("You do not have write permission"); yield break; }

            if (changedPaths.Length == 0)
            {
                yield break;
            }

            for (int i = 0; i < changedPaths.Length; i++)
            {
                string source = changedPaths[i];
                string trimmed = TrimOrigin(source);
                string destination = Path.Combine(targetPath, trimmed);

                string dir = Path.GetDirectoryName(destination);

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                Console.WriteLine("Attempting to copy " + source + " to " + destination);
                File.Copy(source, destination, true);
                progress++;
                yield return source;
            }

            lastChangedFiles = changedPaths;
        }

        public string[] GetPathsThatChanged()
        {
            //CacheChanges();

            List<string> changedPaths = new List<string>();

            for (int i = 0; i < originFiles.Length; i++)
            {
                string source = originFiles[i];
                string trimmed = TrimOrigin(originFiles[i]);
                string destination = Path.Combine(targetPath, trimmed);

                bool exists = File.Exists(destination);

                if (!exists) // if it doesn't exist just overwrite it
                {
                    changedPaths.Add(source);
                }
                else // instead compare hashes
                {
                    byte[] sourceHash = GetFileSHA1(source);
                    byte[] destinationHash = GetFileSHA1(destination);

                    if (!sourceHash.SequenceEqual(destinationHash))
                        changedPaths.Add(source);

                    //Console.WriteLine(System.Text.Encoding.Default.GetString(hash));
                }

                Console.WriteLine(progress);
                progress++;
            }

            return changedPaths.ToArray();
        }

        byte[] GetFileSHA1(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);

            var sha = SHA1.Create();
            var hash = sha.ComputeHash(stream);

            stream.Close();

            return hash;
        }

        public List<string> log = new List<string>();

        public int progress = 0;

        public void Sync()
        {
            log.Clear();

            if (!Directory.Exists(originPath)) { log.Add("Origin folder does not exist"); return; }
            if (!Directory.Exists(targetPath)) { log.Add("Target folder does not exist"); return; }
            if (!hasWriteAccessToFolder(targetPath)) { log.Add("You do not have write permission"); return; }

            string[] changedPaths = GetPathsThatChanged();

            if (changedPaths.Length == 0)
            {
                log.Add("Nothing to sync");
                return;
            }

            for (int i = 0; i < changedPaths.Length; i++)
            {
                string source = changedPaths[i];
                string trimmed = TrimOrigin(source);
                string destination = Path.Combine(targetPath, trimmed);

                string dir = Path.GetDirectoryName(destination);

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                Console.WriteLine("Attempting to copy " + source + " to " + destination);
                File.Copy(source, destination, true);
                log.Add(trimmed);

                progress++;
            }

            lastChangedFiles = changedPaths;

            log.Add("Successfully synced " + changedPaths.Length + " files");
            return;
        }
    }
}
