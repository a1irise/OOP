using System.Collections.Generic;
using lab4.RestorePoints;

namespace lab4.RestorePointCreators
{
    public class FullRestorePointCreator : IRestorePointCreator
    {
        public RestorePoint Create(List<FileInfo> files)
        {
            return new FullRestorePoint(files);
        }
    }
}