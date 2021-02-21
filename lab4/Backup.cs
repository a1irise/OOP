using System;
using System.Collections.Generic;
using System.IO;
using lab4.RestorePoints;
using lab4.RestorePointCreators;
using lab4.SaveAlgorithms;
using lab4.CleanupAlgorithms;

namespace lab4
{
    public class Backup
    {
        public string Id { get; }
        public DateTime CreationTime { get; }
        public List<FileInfo> Files { get; set; }
        public List<RestorePoint> RestorePoints { get; }
        public ISaveAlgorithm SaveAlgorithm { get; }
        public CleanupAlgorithm CleanupAlgorithm { get; set; } = new AmountCleanupAlgorithm(10);
        public long BackupSize
        {
            get
            {
                long size = 0;
                foreach (var restorePoint in RestorePoints)
                    size += restorePoint.Size;
                return size;
            }
        }

        public Backup(ISaveAlgorithm saveAlgorithm, List<string> filesToBackup)
        {
            Id = Guid.NewGuid().ToString();
            CreationTime = DateTime.Now;
            RestorePoints = new List<RestorePoint>();
            SaveAlgorithm = saveAlgorithm;

            Files = new List<FileInfo>();
            foreach (var file in filesToBackup)
                AddFile(file);

            AddRestorePoint(new FullRestorePointCreator());
        }

        public void AddFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            bool exists = false;

            foreach (var file in Files)
            {
                if (file.Path != path)
                    continue;

                exists = true;
                break;
            }

            if (!exists)
                Files.Add(new FileInfo(path));
        }

        public void RemoveFile(string path)
        {
            foreach (var file in Files)
            {
                if (file.Path != path)
                    continue;

                Files.Remove(file);
                break;
            }
        }

        public void AddRestorePoint(IRestorePointCreator creator)
        {
            var restorePoint = creator.Create(Files);
            SaveAlgorithm.Save(restorePoint);
            RestorePoints.Add(restorePoint);
            CleanupAlgorithm.Cleanup(RestorePoints);
        }

        public void CleanupRestorePoints()
        {
            CleanupAlgorithm.Cleanup(RestorePoints);
        }
    }
}