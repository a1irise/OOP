using System.Collections.Generic;
using lab4.RestorePoints;

namespace lab4.SaveAlgorithms
{
    public interface ISaveAlgorithm
    {
        public void Save(RestorePoint restorePoint);
    }
}