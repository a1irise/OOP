using System.Collections.Generic;
using lab4.RestorePoints;

namespace lab4.RestorePointCreators
{
    public interface IRestorePointCreator
    {
        public RestorePoint Create(List<FileInfo> files);
    }
}