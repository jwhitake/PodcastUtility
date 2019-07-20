using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;
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
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("settings.json", true)
                .AddEnvironmentVariables();

            var configuration = configurationBuilder.Build();

            SourcePath = configuration["SourcePath"];
            //DestinationPath = configuration[""];
            ArchiveFiles = Convert.ToBoolean(configuration["ArchiveFiles"]);
            ArchivePath = configuration["ArchivePath"];
        }
    }
}
