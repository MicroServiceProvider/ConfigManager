﻿namespace ConfigManager.ConfigClasses
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The strongly typed class to deserialize the
    /// global configuration file ConfigPaths.conf
    /// </summary>
    public class ConfigPathsConfig
    {
        /// <summary>
        /// An ordered list of search paths to search
        /// in for configuration files.
        /// </summary>
        public DirectoryInfo[] Paths { get; set; }

        /// <summary>
        /// Contructs the configuration with the default
        /// values for search paths, which are: the local
        /// application root directory, C:/Configs, and
        /// D:/Configs
        /// </summary>
        public ConfigPathsConfig()
        {
            DirectoryInfo baseDirectory = new DirectoryInfo(
                AppDomain.CurrentDomain.BaseDirectory);
            while (baseDirectory.Name.ToLower().EndsWith("bin")
                || baseDirectory.Name.ToLower().EndsWith("debug")
                || baseDirectory.Name.ToLower().EndsWith("release"))
            {
                baseDirectory = baseDirectory.Parent;
            }
            DirectoryInfo cdir = new DirectoryInfo("C:/Configs");
            DirectoryInfo ddir = new DirectoryInfo("D:/Configs");
            Paths = new DirectoryInfo[] { baseDirectory, cdir, ddir };
        }
    }
}
