using System.Collections.Generic;
using lab4.RestorePoints;

namespace lab4.CleanupAlgorithms
{
    public class AmountCleanupAlgorithm : CleanupAlgorithm
    {
        public int MaxAmount { get; set; }

        public AmountCleanupAlgorithm(int maxAmount)
        {
            MaxAmount = maxAmount;
        }

        public override void Cleanup(List<RestorePoint> restorePoints)
        {
            while (restorePoints.Count > MaxAmount)
            {
                if (!CanClean(restorePoints))
                    throw new UnableToClearRestorePointsException();

                restorePoints.RemoveAt(0);
                while (restorePoints[0].GetType() != typeof(FullRestorePoint))
                    restorePoints.RemoveAt(0);
            }
        }
    }
}