using System;
using System.IO;
using TagLib;
using PodcastLib;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filePath = @"E:\";
            //DirectoryInfo di = new DirectoryInfo(filePath);
            //FileInfo[] fia = di.GetFiles();

            //foreach (FileInfo fi in fia)
            //{
            //    if (fi.Extension != ".mp3")
            //        continue;
            //    var tfile = TagLib.File.Create(fi.FullName);
            //    string title = tfile.Tag.Title;
            //    var performers = tfile.Tag.Performers;
            //    //Console.WriteLine(performers[0]);
            //    string strDirName = performers[0];
            //    strDirName = strDirName
            //        .Replace("?", "_")
            //        .Replace(":", "_");
            //    if (!Directory.Exists(Path.Combine(@"D:\Podcast Storage", strDirName)))
            //    {
            //        Directory.CreateDirectory(Path.Combine(@"D:\Podcast Storage", strDirName));
            //    }
            //    Console.WriteLine($"Moving {fi.Name}");
            //    if (System.IO.File.Exists(Path.Combine(@"D:\Podcast Storage", strDirName, fi.Name)))
            //        continue;
            //    System.IO.File.Move(fi.FullName, Path.Combine(@"D:\Podcast Storage", strDirName, fi.Name));
            //}
        }
    }
}
