using System;

namespace GenLib.Constants
{
    public class General
    {
        public const Int32 NormalExit = 0;
        public const Int32 BadExit = -1;

        public const byte ByteCr = 13;
        public const byte ByteTab = 9;

        public const string NullChar = "\0";
        public const string Cr = "\r";
        public const string CrLf = "\r\n";
        public const string NewLine = CrLf;
        public const string Plus = "+";
        public const string Minus = "-";
        public const string Quote = "\"";
        public const string Tab = "\t";
        public const string Delimiter = " ";
        public string DeltaChar = char.ConvertFromUtf32(0x394);

        public const string ExceptionsSubdir = "Exceptions";
        public const string ExceptionFilename = "Exceptions.txt";

        public const string ErrorMessage = "An error has been caught. Details will be appended to the " + ExceptionFilename + " file.";

        public const string SettingsSubdir = ".\\settings\\";
        public const string SettingsFilename = "settings.xml";

        public const string LogSubdir = ".\\log\\";
        public const string LogExtension = "log";
        public const string DefaultLogFilename = "default" + "." + LogExtension;
    }
}