using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace PodcastLib
{
    public class Configuration
    {

        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public string ArchivePath { get; set; }
        public bool ArchiveFiles { get; set; }

        public Configuration()
        {            
        }

        public static Configuration GetConfiguration()
        {
            string json = File.ReadAllText(Path.Combine(Environment.CurrentDirectory + "podcast.json"));
            Configuration config = JsonConvert.DeserializeObject<Configuration>(json);
            return config;
        }
    }
}
