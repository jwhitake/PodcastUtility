using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PodcastLib
{
    public class FileManagement
    {
        public bool CheckIfThereAreDownloadedPodcasts()
        {
            try
            {
                var config = new Configuration();
                DirectoryInfo di = new DirectoryInfo(config.SourcePath);
                DirectoryInfo[] dia = di.GetDirectories();
                foreach (DirectoryInfo dir in dia)
                {                    
                    FileInfo[] fia = dir.GetFiles();
                    if (fia.Length > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
            }
            return false;
        }

        public bool ArchiveFiles()
        {
            bool result = false;
            try
            {
                var config = new Configuration();
                DirectoryInfo di = new DirectoryInfo(config.SourcePath);
                DirectoryInfo[] dia = di.GetDirectories();
                foreach (DirectoryInfo dir in dia)
                {
                    FileInfo[] fia = dir.GetFiles();
                    foreach (FileInfo fi in fia)
                    {
                        string CopyPath = Path.Combine(config.ArchivePath, dir.Name);
                        if (!Directory.Exists(CopyPath))
                            Directory.CreateDirectory(CopyPath);
                        if (fi.Name.Contains(".mp3") || fi.Name.Contains(".mp4"))
                        {
                            if (File.Exists(Path.Combine(CopyPath, fi.Name)))
                            {
                                File.Delete(fi.FullName);
                                continue;
                            }
                            File.Move(fi.FullName, Path.Combine(CopyPath, fi.Name));
                        }
                    }
                }
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool LoadUsbDrive(string path)
        {
            bool result = false;
            try
            {
                var config = new Configuration();
                DirectoryInfo di = new DirectoryInfo(config.SourcePath);
                DirectoryInfo[] dia = di.GetDirectories();
                foreach (DirectoryInfo dir in dia)
                {
                    FileInfo[] fia = dir.GetFiles();
                    foreach (FileInfo fi in fia)
                    {
                        File.Copy(fi.FullName, Path.Combine(path, fi.Name));
                    }
                }
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public void ClearDirectory(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] fia = di.GetFiles();
            foreach(FileInfo fi in fia)
            {
                if (fi.Extension != ".mp3")
                    continue;
                File.Delete(fi.FullName);
            }
        }
    }


}
