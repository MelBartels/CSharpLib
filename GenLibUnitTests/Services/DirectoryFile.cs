using System;
using System.IO;
using Xunit;

namespace GenLibUnitTests.Services
{
    public class DirectoryFile
    {
        [Fact]
        public void CreateDeleteDirectoryFileExists()
        {
            var dfs = new GenLib.Services.DirectoryFile();

            const string testFilename = "C:\\DirectoryFileServicesTest\\testFilename.txt";
            dfs.DeleteFileAndDirectory(testFilename);
            Assert.False(dfs.FileExists(testFilename));

            dfs.CreateDirectory(testFilename);
            var fs = File.Create(testFilename);
            Assert.True(dfs.FileExists(testFilename));

            // must dispose of file handle otherwise delete will fail 
            fs.Dispose();
            dfs.DeleteFileAndDirectory(testFilename);
            Assert.False(dfs.FileExists(testFilename));

            Assert.True(true);
        }

        [Fact]
        public void DeleteDirectoryWithFiles()
        {
            var dfs = new GenLib.Services.DirectoryFile();

            const string testDirectory = "C:\\DirectoryFileServicesTest\\";
            const string testFilename = "testFilename.txt";
            const string fullPathFilename = testDirectory + testFilename;

            dfs.DeleteDirectoryWithFiles(testDirectory);
            Assert.False(Directory.Exists(testDirectory));

            dfs.CreateDirectory(testDirectory);
            var fs = File.Create(fullPathFilename);
            fs.Dispose();
            Assert.True(dfs.FileExists(fullPathFilename));

            dfs.DeleteDirectoryWithFiles(testDirectory);
            Assert.False(Directory.Exists(testDirectory));

            Assert.True(true);
        }

        [Fact]
        public void GetFullyQualifiedDirectory()
        {
            var dfs = new GenLib.Services.DirectoryFile();

            Assert.Equal("C:\\TestGetFullyQualifiedDirectory",
                         dfs.GetFullyQualifiedDirectory(
                             "C:\\TestGetFullyQualifiedDirectory\\filename"));

            Assert.True(true);
        }

        [Fact]
        public void GetIncrementedFilename()
        {
            var dfs = new GenLib.Services.DirectoryFile();

            const string testFilename = "C:\\DirectoryFileServicesTest\\testFilename.txt";
            Assert.Equal(testFilename, dfs.IncrementFilename(testFilename, 0));
            Assert.Equal("C:\\DirectoryFileServicesTest\\testFilename_001.txt", dfs.IncrementFilename(testFilename, 1));
            Assert.Equal("C:\\DirectoryFileServicesTest\\testFilename_002.txt", dfs.IncrementFilename(testFilename, 2));

            Assert.True(true);
        }

        [Fact]
        public void PrependZeroesToString()
        {
            var dfs = new GenLib.Services.DirectoryFile();

            Assert.Equal(dfs.PrependZeroes(2, "5"), "05");
            Assert.Equal(dfs.PrependZeroes(3, "35"), "035");
            Assert.Equal(dfs.PrependZeroes(2, "35"), "35");
            Assert.Equal(dfs.PrependZeroes(2, "357"), "57");

            Assert.True(true);
        }

        [Fact]
        public void RunFile()
        {
            var dfs = new GenLib.Services.DirectoryFile();

            const string filename = @"TestFiles\shellexecute.txt";
            Console.WriteLine("shell executing on file " + filename + " in " + dfs.GetFullyQualifiedDirectory(filename));
            dfs.RunFile(filename);
            Assert.True(true);
        }
    }
}