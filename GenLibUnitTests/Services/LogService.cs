using System;
using System.IO;
using System.Reflection;
using GenLib.Services;
using Xunit;

namespace GenLibUnitTests.Services
{
    public class LogService
    {
        [Fact]
        public void LogMsg()
        {
            var logService = new LogToFile();
            var dir = new GenLib.Services.DirectoryFile().GetFullyQualifiedDirectory(logService.GetFullPathFilename());
            Console.WriteLine("TestLogMsg() directory is " + dir);
            new GenLib.Services.DirectoryFile().DeleteDirectoryWithFiles(dir);
            // verify that directory has been deleted 
            Assert.False(Directory.Exists(dir));

            // now finally test the message logging 
            logService.WriteMsg("TestLogMsg");
            Assert.True(File.Exists(logService.GetFullPathFilename()));

            Assert.True(true);
        }

        [Fact]
        public void ApplicationDataDir()
        {
            var logService = new LogToFile();
            logService.SetLogFileLocationToLocalAppData(Assembly.GetExecutingAssembly().GetName().Name);
            var dir = Path.GetDirectoryName(logService.GetFullPathFilename());
            Console.WriteLine("TestLogMsg() directory is " + dir);
            new GenLib.Services.DirectoryFile().DeleteDirectoryWithFiles(dir);
            // verify that directory has been deleted 
            Assert.False(Directory.Exists(dir));

            // now finally test the message logging 
            logService.WriteMsg("TestLogMsg");
            Assert.True(File.Exists(logService.GetFullPathFilename()));

            Assert.True(true);
        }
    }
}