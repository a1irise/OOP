using System.Collections.Generic;
using lab4.RestorePoints;

namespace lab4.RestorePointCreators
{
    public class IncrementalRestorePointCreator : IRestorePointCreator
    {
        public RestorePoint Create(List<FileInfo> files)
        {
            var changedFiles = new List<FileInfo>();
            foreach (var file in files)
                if (file.Size != new System.IO.FileInfo(file.Path).Length)
                    changedFiles.Add(file);

            if (changedFiles.Count == 0)
                throw new NoNewEditsException();

            return new IncrementalRestorePoint(changedFiles);
        }
    }
}