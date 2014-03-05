using System;
using System.IO;
using System.Reflection;
using GenLib.Extensions;

namespace GenLib.Services
{
    public class LogToFile
    {
        public LogToFile(DirectoryFile directoryFile)
        {
            DirectoryFile = directoryFile;
            SetLogFileLocationToEntryAssembly();
        }

        public LogToFile() : this(new DirectoryFile())
        {
        }

        private DirectoryFile DirectoryFile { get; set; }

        public string LogFileLocation { get; set; }

        public bool WriteMsg(string msg)
        {
            DirectoryFile.CreateDirectory(GetFullPathFilename());
            File.Exists(GetFullPathFilename()).Else(CreateLogFile);

            var fs = new FileStream(GetFullPathFilename(), FileMode.Append);
            var sw = new StreamWriter(fs);
            sw.Write("Logging message at: ");
            sw.WriteLine(DateTime.Now.ToString());
            sw.WriteLine(msg);
            sw.WriteLine("=============================================================");
            sw.Close();
            fs.Close();

            return true;
        }

        private void CreateLogFile()
        {
            var fs = new FileStream(GetFullPathFilename(), FileMode.Create);
            var sw = new StreamWriter(fs);
            sw.Close();
            fs.Close();
        }

        public void SetLogFileLocationToEntryAssembly()
        {
            Assembly.GetEntryAssembly()
                .With(a => a.Location)
                .If(l => l.Length > 0)
                .Do(l => LogFileLocation = Path.GetDirectoryName(l));
        }

        public void SetLogFileLocationToLocalAppData(string applicationName)
        {
            LogFileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                           applicationName);
        }

        public string GetFullPathFilename()
        {
            var logPath = Path.Combine(Constants.General.ExceptionsSubdir, Constants.General.ExceptionFilename);
            return string.IsNullOrEmpty(LogFileLocation) ? logPath : Path.Combine(LogFileLocation, logPath);
        }
    }
}