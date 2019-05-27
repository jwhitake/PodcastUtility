using System;
using System.Collections.Generic;
using System.IO;

namespace PodcatAppUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("What would you like to do?");
            LoadMianMenu();
            string item = Console.ReadLine();
            //Console.WriteLine(item);
            switch (item)
            {
                case "1":

                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                default:
                    break;
            }
            Console.Clear();

        }

        private static void LoadMianMenu()
        {
            var menu = new List<string>(File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Menu1.txt")));
            foreach(string s in menu)
                Console.WriteLine(s);
        }
    }
}
