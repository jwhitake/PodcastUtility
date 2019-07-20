using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using PodcastLib;

namespace PodcatAppUI
{
    class Program
    {

        static void Main(string[] args)
        {
            FileManagement fm = new FileManagement();
            Configuration config = new Configuration();
            Console.ForegroundColor = ConsoleColor.Green;
            if (fm.CheckIfThereAreDownloadedPodcasts())
            {
                while (true)
                {
                    var driveLetter = DisplayDrives();
                    Console.Clear();
                    RunApp(driveLetter);
                }
            }
            else
            {
                Console.WriteLine("There are no downloaded Podcasts");
                Thread.Sleep(1500);
                Environment.Exit(1);
            }
            Console.Clear();
        }



        private static void LoadMainMenu()
        {
            var menu = new List<string>(File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Menu1.txt")));
            foreach(string s in menu)
                Console.WriteLine(s);
        }

        private static string DisplayDrives()
        {
            string driveLetter = "";
            var drives = DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable);
            Console.WriteLine("The following are external drives attached to this system.");
            int driveNumber = 0;
            foreach (var i in drives)
            {
                driveNumber++;
                Console.WriteLine($"{driveNumber} - {i.Name}. This is a {i.DriveType}");
                
            }
            Console.WriteLine("Please select a drive use, and press enter.");
            var select = Console.ReadLine();
            if(int.TryParse(select.ToString(), out int iCheck))
            {
                int k = Convert.ToInt32(select.ToString()) - 1;
                driveLetter = drives.ToList()[k].Name;
            }
            else if(driveNumber > 0)
            {
                Console.Clear();
                Console.WriteLine("Please enter a number to select a drive");
                DisplayDrives();
            }
            else if(driveNumber == 0)
            {
                Console.Clear();
                Console.WriteLine("No suitable drive has been found");
                Thread.Sleep(2500);
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("An error has occured");
                Thread.Sleep(2500);
                Environment.Exit(1);
            }
            
            return driveLetter;
        }

        private static void RunApp(string driveLetter)
        {
            Configuration config = new Configuration();
            FileManagement fm = new FileManagement();
            Console.WriteLine("What would you like to do?");
            LoadMainMenu();
            string item = Console.ReadLine();
            switch (item)
            {
                case "1":
                    Console.WriteLine($"Removeing files from {driveLetter}");
                    fm.ClearDirectory(driveLetter);
                    Console.WriteLine("Completed....");
                    Thread.Sleep(1500);
                    break;
                case "2":
                    Console.WriteLine($"Loading {driveLetter} with podcasts");
                    fm.LoadUsbDrive(driveLetter);
                    Console.WriteLine("Completed....");
                    Thread.Sleep(1500);
                    break;
                case "3":
                    Console.WriteLine($"Archiving all podcasts to {config.SourcePath} to {config.ArchivePath}");
                    fm.ArchiveFiles();
                    Console.WriteLine("Completed....");
                    Thread.Sleep(1500);
                    break;
                case "4":
                    Console.WriteLine($"Removeing files from {driveLetter}");
                    fm.ClearDirectory(driveLetter);
                    Console.WriteLine($"Loading {driveLetter} with podcasts");
                    fm.LoadUsbDrive(driveLetter);
                    Console.WriteLine($"Archiving all podcasts to {config.SourcePath} to {config.ArchivePath}");
                    fm.ArchiveFiles();
                    Console.WriteLine("Completed....");
                    Thread.Sleep(1500);
                    Console.WriteLine("Exit application...");
                    Thread.Sleep(500);
                    Environment.Exit(1);
                    break;
                case "5":
                    Environment.Exit(1);
                    break;
                default:
                    break;
            }
        }
    }
}
