using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using GenLib.Extensions;

namespace GenLib.Services
{
    public class DirectoryFile
    {
        private const int MaxIncrFilename = 999;

        public string GetFullyQualifiedDirectory(string filename)
        {
            return Path.GetDirectoryName(Path.GetFullPath(filename));
        }

        public void CreateDirectory(string filename)
        {
            GetFullyQualifiedDirectory(filename)
                .If(d => !Directory.Exists(d))
                .Do(d => Directory.CreateDirectory(d));
        }

        public void DeleteDirectory(string filename)
        {
            GetFullyQualifiedDirectory(filename)
                .If(Directory.Exists)
                .Do(Directory.Delete);
        }

        public void DeleteDirectoryWithFiles(string directory)
        {
            Directory.Exists(directory)
                .Then(() =>
                          {
                              DeleteFilesInDirectory(directory);
                              Directory.Delete(directory);
                          });
        }

        private static void DeleteFilesInDirectory(string directory)
        {
            var files = new ReadOnlyCollection<string>(Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories));
            new List<string>(files).ForEach(File.Delete);
        }

        public void DeleteFileAndDirectory(string filename)
        {
            FileExists(filename)
                .Then(() =>
                          {
                              File.Delete(filename);
                              DeleteDirectory(filename);
                          });
        }

        public bool FileExists(string filename)
        {
            return File.Exists(filename);
        }

        public string GetIncrementedFilename(string filename)
        {
            var incr = 0;
            var incrementedFilename = filename;
            while (File.Exists(incrementedFilename) && incr < MaxIncrFilename)
            {
                incrementedFilename = IncrementFilename(filename, incr++);
            }
            return incrementedFilename;
        }

        public string IncrementFilename(string filename, Int32 increment)
        {
            if (increment < 1)
                return filename;
            var sb = new StringBuilder();
            sb.Append(Path.GetDirectoryName(filename));
            sb.Append("\\");
            sb.Append(Path.GetFileNameWithoutExtension(filename));
            sb.Append("_");
            sb.Append(PrependZeroes(MaxIncrFilename.ToString().Length, increment.ToString()));
            sb.Append(Path.GetExtension(filename));
            return sb.ToString();
        }

        public string PrependZeroes(int stringLength, string str)
        {
            var sb = new StringBuilder();
            for (var ix = 0; ix < stringLength; ix++)
            {
                sb.Append("0");
            }
            sb.Append(str);
            var startIx = sb.Length - stringLength;
            if (startIx < 0)
                startIx = 0;
            return sb.ToString().Substring(startIx, stringLength);
        }

        public void RunFile(string filename)
        {
            Process.Start(filename);
        }
    }
}