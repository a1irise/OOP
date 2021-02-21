using System;
using lab4.RestorePoints;

namespace lab4.SaveAlgorithms
{
    public class ArchiveSaveAlgorithm : ISaveAlgorithm
    {
        public string ArchivePath { get; }

        public ArchiveSaveAlgorithm(string archivePath)
        {
            ArchivePath = archivePath;
        }

        public void Save(RestorePoint restorePoint)
        {
            foreach (var file in restorePoint.Files)
                restorePoint.Backups.Add(new FileInfo($"{ArchivePath}\\{DateTime.Now}", file.Size));
        }
    }
}