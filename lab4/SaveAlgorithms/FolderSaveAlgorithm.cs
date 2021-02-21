using System;
using lab4.RestorePoints;

namespace lab4.SaveAlgorithms
{
    public class FolderSaveAlgorithm : ISaveAlgorithm
    {
        public string ArchivePath { get; }

        public FolderSaveAlgorithm(string archivePath)
        {
            ArchivePath = archivePath;
        }

        public void Save(RestorePoint restorePoint)
        {
            foreach (var file in restorePoint.Files)
                restorePoint.Backups.Add(new FileInfo($"{ArchivePath}\\{new System.IO.FileInfo(file.Path).Name}\\{DateTime.Now}", file.Size));
        }
    }
}