using System.Collections.Generic;
using lab4.CleanupAlgorithms;
using lab4.RestorePointCreators;
using lab4.SaveAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab4.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var backup = new Backup(new ArchiveSaveAlgorithm("G\\Backup"),
                new List<string>());
            backup.Files.Add(new FileInfo ("G\\test1.txt", 100 ));
            backup.Files.Add(new FileInfo("G\\test2.txt", 100 ));
            Assert.AreEqual(200, backup.BackupSize);
            backup.AddRestorePoint(new FullRestorePointCreator());
            backup.CleanupAlgorithm = new AmountCleanupAlgorithm(1);
            backup.CleanupRestorePoints();
            Assert.AreEqual(1, backup.RestorePoints.Count);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var backup = new Backup(new ArchiveSaveAlgorithm("G\\Backup"),
                new List<string>());
            backup.Files.Add(new FileInfo("G\\test1.txt", 100));
            backup.Files.Add(new FileInfo("G\\test2.txt", 100));
            backup.AddRestorePoint(new FullRestorePointCreator());
            Assert.AreEqual(2, backup.RestorePoints.Count);
            backup.CleanupAlgorithm = new SizeCleanupAlgorithm(150);
            backup.CleanupRestorePoints();
            Assert.AreEqual(1, backup.RestorePoints.Count);
        }
    }
}
