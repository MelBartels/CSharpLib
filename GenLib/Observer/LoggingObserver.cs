using System.IO;
using GenLib.ExceptionService;
using GenLib.Extensions;
using GenLib.Services;

namespace GenLib.Observer
{
    public class LoggingObserver
    {
        public LoggingObserver(IExceptionHandler exceptionHandler, DirectoryFile directoryFile)
        {
            ExceptionHandler = exceptionHandler;
            DirectoryFile = directoryFile;
        }

        public LoggingObserver(IExceptionHandler exceptionHandler) : this(exceptionHandler, new DirectoryFile())
        {
        }

        public LoggingObserver() : this(new ExceptionHandlerLog())
        {
        }

        private IExceptionHandler ExceptionHandler { get; set; }
        private DirectoryFile DirectoryFile { get; set; }

        private StreamWriter StreamWriter { get; set; }

        public string Filename { get; set; }
        public bool IsOpen { get; set; }
        public bool AppendCrlf { get; set; }

        public bool Alert(object sender, ObserverEventArgs oea)
        {
            return IsOpen.Then(() => WriteToStream(oea));
        }

        private void WriteToStream(ObserverEventArgs oea)
        {
            AppendCrlf
                .Then(() => StreamWriter.WriteLine((string) oea.Arg))
                .Else(() => StreamWriter.Write((string)oea.Arg));
        }

        public void CreateDefaultFilename()
        {
            Filename = Path.Combine(Constants.General.LogSubdir, Constants.General.DefaultLogFilename);
        }

        public bool Open()
        {
            (string.IsNullOrEmpty(Filename)).Then(CreateDefaultFilename);

            DirectoryFile.CreateDirectory(Filename);
            Filename = DirectoryFile.GetIncrementedFilename(Filename);
            StreamWriter = new StreamWriter(Filename);
            IsOpen = true;
            return true;
        }

        public void Close()
        {
            StreamWriter.Do(sw => sw.Close());
            IsOpen = false;
        }
    }
}