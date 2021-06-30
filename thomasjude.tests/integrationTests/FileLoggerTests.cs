using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThomasJude.Core.Logging;

namespace ThomasJude.Tests.IntegrationTests
{
    [TestClass]
    public class FileLoggerTests
    {
        private static string logDir;

        public FileLoggerTests()
        {
            string tmpDir = Path.GetTempPath();
            string dirName = $"tj-csharp-core-{Guid.NewGuid()}";
            logDir = Path.Join(tmpDir, dirName);
            Directory.CreateDirectory(logDir);
        }
        
        [ClassCleanup]
        public static void classCleanup()
        {
            Directory.Delete(logDir, true);
        }

        [TestCleanup]
        public void testCleanup()
        {
            var files = Directory.GetFiles(logDir);
            foreach(var file in files)
            {
                File.Delete(file);
            }
        }

        [TestMethod]
        public void Log_ValidMessageAndPath_NoErrors()
        {
            // arrange
            string logFile = Path.Join(logDir, "fileLoggerTests.log");
            ILogger logger = new FileLogger(logFile);

            // act
            logger.Log("test1");

            // assert
            Assert.AreEqual(true, File.Exists(logFile));
            Assert.AreEqual($"test1{Environment.NewLine}", File.ReadAllText(logFile));
        }
    }
}
