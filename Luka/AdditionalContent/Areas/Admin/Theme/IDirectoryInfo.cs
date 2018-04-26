using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Argosy.Common.Contracts.Core.Interfaces
{
    public interface IDirectoryInfo {
        List<IFileInfo> GetFiles(string searchPattern = "", SearchOption searchOption = SearchOption.TopDirectoryOnly);
        List<IDirectoryInfo> GetDirectories(string searchPattern = "", SearchOption searchOption = SearchOption.TopDirectoryOnly);
        IDirectoryInfo GetChildDirectory(string directoryName);
        IDirectoryInfo CreateSubdirectory(string directoryName);
        [JsonIgnore]
        IDirectoryInfo Parent { get; }
        string Name { get; }
        string FullName { get; }
        [JsonIgnore]
        DateTime CreationTime { get; }
        void Delete();
        bool Exists { get; }
        /// <summary>
        /// Gets the uri to reference this file from the web
        /// </summary>
        [JsonIgnore]
        Uri Uri { get; }

        /// <summary>
        /// Gets or sets the root domain to use for the uri generation
        /// </summary>
        [JsonIgnore]
        string HostName { get; set; }

        void Empty();
        void CopyTo(IDirectoryInfo target, bool overwrite = true, bool clearDestination = false);
    }
}