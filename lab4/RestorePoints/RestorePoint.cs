using System;
using System.Collections.Generic;

namespace lab4.RestorePoints
{
    public abstract class RestorePoint
    {
        public DateTime CreationTime { get; }
        public List<FileInfo> Files { get; }
        public List<FileInfo> Backups { get; }
        public long Size
        {
            get
            {
                long size = 0;
                foreach (var file in Files)
                    size += file.Size;
                return size;
            }
        }

        protected RestorePoint(List<FileInfo> files)
        {
            CreationTime = DateTime.Now;
            Files = files;
            Backups = new List<FileInfo>();
        }
    }
}