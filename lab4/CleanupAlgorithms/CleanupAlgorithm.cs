using System.Collections.Generic;
using lab4.RestorePoints;

namespace lab4.CleanupAlgorithms
{
    public abstract class CleanupAlgorithm
    {
        public abstract void Cleanup(List<RestorePoint> restorePoints);

        public bool CanClean(List<RestorePoint> restorePoints)
        {
            bool flag = false;

            for (int i = 1; i < restorePoints.Count; i++)
                if (restorePoints[i].GetType() == typeof(FullRestorePoint))
                    flag = true;

            return flag;
        }
    }
}