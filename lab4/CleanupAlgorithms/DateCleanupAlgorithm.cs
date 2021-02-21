using System;
using System.Collections.Generic;
using lab4.RestorePoints;

namespace lab4.CleanupAlgorithms
{
    public class DateCleanupAlgorithm : CleanupAlgorithm
    {
        public DateTime MaxDate { get; set; }

        public DateCleanupAlgorithm(DateTime date)
        {
            MaxDate = date;
        }

        public override void Cleanup(List<RestorePoint> restorePoints)
        {
            while (restorePoints[0].CreationTime < MaxDate)
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