using System;
using System.Collections.Generic;
using System.IO;
using Argosy.Common.Contracts.Contract;
using Argosy.Common.Contracts.Core.Enum;
//using Argosy.Common.Contracts.Core.Enum;

namespace Argosy.Common.Contracts.Core.Interfaces
{
    public interface IFileInfo {
        /// <summary>
        /// 
        /// </summary>
        Dictionary<string,string> UriQuerystring { get; set; }
        /// <summary>
        /// Saves the current IFileInfo object to the underlying storage device
        /// </summary>
        /// <param name="bytes">bytes to write to storage</param>
        /// <param name="overwrite">overwrite the file if it exists</param>
        void Save(byte[] bytes, bool overwrite = true);
        /// <summary>
        /// Saves the current IFileInfo object to the underlying storage device
        /// </summary>
        /// <param name="stream">stream containing the data to write</param>
        /// <param name="overwrite">overwrite the file if it exists</param>
        void Save(Stream stream, bool overwrite = true);

        /// <summary>
        /// Gets the current IFileInfo data
        /// </summary>
        byte[] Get();

        /// <summary>
        /// Gets a piece of a file
        /// </summary>
        int Get(byte[] buffer, int index, int length);

        /// <summary>
        /// The file locations this file is stored under.
        /// </summary>
        FileLocations GetFileLocation();

        /// <summary>
        /// Gets the current IFileInfo data
        /// </summary>
        Stream GetStream();

        /// <summary>
        /// Maintains the current directory structure and changes the file name referece.
        /// </summary>
        IFileInfo ChangeFileName(string newFileName);

        /// <summary>
        /// Maintains the current directory structure and filename but switches the extension.
        /// </summary>
        IFileInfo ChangeExtension(string extension);

        /// <summary>
        /// Copies an existing file to a new file, disallowing the overwriting of an existing file.
        /// </summary>
        /// <param name="destFileName">The name of the new file to copy to.</param>
        /// <returns>
        /// A new file with a fully qualified path.
        /// </returns>
        IFileInfo CopyTo(IFileInfo destFileName);

        /// <summary>
        /// Copies an existing file to a new file, allowing the overwriting of an existing file. 
        /// </summary>
        /// <param name="destFileName">The name of the new file to copy to.</param><param name="overwrite">true to allow an existing file to be overwritten; otherwise, false. </param>
        /// <returns>
        /// A new file, or an overwrite of an existing file if overwrite is true. If the file exists and overwrite is false, an IOException is thrown.
        /// </returns>
        IFileInfo CopyTo(IFileInfo destFileName, bool overwrite);

        /// <summary>
        /// Permanently deletes a file.
        /// </summary>
        void Delete();

        /// <summary>
        /// Moves a specified file to a new location, providing the option to specify a new file name. 
        /// </summary>
        /// <param name="destFileName">The path to move the file to, which can specify a different file name.</param>
        IFileInfo MoveTo(IFileInfo destFileName);

        /// <summary>
        /// Moves a specified file to a new location, providing the option to specify a new file name. 
        /// </summary>
        /// <param name="destFileName">The path to move the file to, which can specify a different file name.</param>
        /// <param name="overwrite">overwrite the file if it exists</param>
        IFileInfo MoveTo(IFileInfo destFileName, bool overwrite);

        /// <summary>
        /// Gets an instance of the parent directory.
        /// </summary>
        IDirectoryInfo Directory { get; }

        /// <summary>
        /// Gets a string representing the directory's full path.
        /// </summary>
        string DirectoryName { get; }

        /// <summary>
        /// Gets a value indicating whether a file exists. 
        /// </summary>
        bool Exists { get; }

        /// <summary>
        /// Gets a value indicating whether a file exists and that it is accessible. 
        /// </summary>
        bool IsAccessible { get; }
        /// <summary>
        /// Gets the string representing the extension part of the file.
        /// </summary>
        string Extension { get; }

        /// <summary>
        /// Gets <see cref="T:System.IO.FileInfo"/> object.
        /// </summary>
        [Obsolete("This isn't obsolete just shouldn't be used unless the interface doesn't provide what you need.")]
        FileInfo FileInfoInstance { get; }

        /// <summary>
        /// Gets the full path of the directory or file.
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// Gets the uri to reference this file from the web
        /// </summary>
        Uri Uri { get; }

        /// <summary>
        /// Gets or sets the root domain to use for the uri generation
        /// </summary>
        string HostName { get; set; }

        /// <summary>
        /// Gets the size, in bytes, of the current file.
        /// </summary>
        long Length { get; }

        /// <summary>
        /// Gets the name of the file. 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the name of the file without the extension. 
        /// </summary>
        string NameNoExtension { get; }

        DateTime CreationTime { get; }

        bool AppendChunk(Stream chunkStream, int byteOffset);

        Stream OpenStream();

        List<FileParameter> Parameters { get; set; }
    }
}