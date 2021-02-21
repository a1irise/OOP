using System;
using System.Collections.Generic;
using lab4.RestorePoints;

namespace lab4.CleanupAlgorithms
{
    public class AmountDateCleanupAlgorithm : CleanupAlgorithm
    {
        public int MaxAmount { get; set; }
        public DateTime MaxDate { get; set; }

        public AmountDateCleanupAlgorithm(int maxAmount, DateTime maxDate)
        {
            MaxAmount = maxAmount;
            MaxDate = maxDate;
        }

        public override void Cleanup(List<RestorePoint> restorePoints)
        {
            while (restorePoints.Count > MaxAmount || restorePoints[0].CreationTime < MaxDate)
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