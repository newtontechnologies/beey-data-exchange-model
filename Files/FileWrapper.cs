using Backend.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable nullable
namespace BeeyApi.POCO.Files
{
    public partial class FileWrapper : EntityBase
    {
        [Obsolete("do not use directly use filewrapper.CreateX")]
        public FileWrapper()
        {

        }

        private FileWrapper(string filename, long size)
        {
            Name = filename;
            Size = size;
        }
        [JsonIgnoreWebDeserialize]
        public string Name { get; set; }
        [JsonIgnoreWebDeserialize]
        public long Size { get; set; }
        /// <summary>
        /// this field identifies how is the file stored .. in database, on disk, somwhere in cloud?
        /// Values: Filesystem,
        /// </summary>
        [JsonIgnoreWeb]
        public string Storage { get; set; }
        [JsonIgnoreWeb]
        public bool IsDeletable => Storage == s_filesystem;

        private const string s_filesystem = "Filesystem";

        public static FileWrapper CreateFilesystemWrapper(string filename, long size = -1)
        {
            return new FileWrapper(filename, size)
            {
                Storage = s_filesystem,
            };
        }

        private const string s_persistentfilesystem = "PersistentFilesystem";
        public static FileWrapper CreatePersistantFilesystemWrapper(string filename, long size = -1)
        {
            return new FileWrapper(filename, size)
            {
                Storage = s_persistentfilesystem,
            };
        }

        //TODO: other storages than files
        [JsonIgnore]
        public string FilePath
        {
            get
            {
                switch (Storage)
                {
                    case s_filesystem:
                        return Path.Combine(Path.GetFullPath("uploads"), Name);
                    case s_persistentfilesystem:
                        return Name;
                }

                throw new NotImplementedException();
            }
        }

        public bool FileExists => File.Exists(FilePath);


        public Stream OpenRead() => File.Open(FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        public Stream Open()
        {
            if (!IsDeletable)
                throw new InvalidOperationException("Cannot create/reset Nondeletable File");

            return File.Open(FilePath, FileMode.Open, FileAccess.Write, FileShare.Read);
        }

        public Stream Create()
        {
            if (!IsDeletable)
                throw new InvalidOperationException("Cannot create/reset Nondeletable File");

            return File.Open(FilePath, FileMode.Create, FileAccess.Write, FileShare.Read);
        }

        public Stream CreateOrOpen() => (FileExists) ? Open() : Create();

        public void LoadFromFile()
        {
            Size = -1;
            if (!FileExists)
                return;

            Size = new FileInfo(FilePath).Length;
        }

        public async Task Delete(bool retryIndefinitely = false)
        {
            while (FileExists && IsDeletable)
            {
                try
                {
                    File.Delete(FilePath);
                    return;
                }
                catch
                {
                    if (!retryIndefinitely)
                        throw;
                }
                await Task.Delay(1000);
            }
        }

        public string FileName => Path.GetFileName(FilePath);
    }
}
