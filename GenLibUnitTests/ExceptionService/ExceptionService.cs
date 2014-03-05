using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using GenLib.Constants;
using GenLib.ExceptionService;
using GenLib.Services;
using GenLib.View;
using Xunit;

namespace GenLibUnitTests.ExceptionService
{
    public class ExceptionService
    {
        private const string TestExceptionMsg = "Test exception message";
        private const string TestThrowingExceptionMsg = "Test throwing an exception message";
        private const string CustomMsg = "Test custom message";
        private const string TestThrowingExceptionCustomMsg = "Test throwing exception with custom message";
        private const string InnerExceptionMsg = "Test inner exception message";

        private static void TestMessageLogging()
        {
            var lf = new LogToFile();
            var eh = new ExceptionHandlerLog(new ExceptionMsg(), lf);
            eh.Notify(TestExceptionMsg);
            Assert.True(File.Exists(lf.GetFullPathFilename()));
        }

        private static void ThrowException()
        {
            try
            {
                throw new Exception(TestThrowingExceptionMsg);
            }
            catch (Exception ex)
            {
                new ExceptionHandlerLog().Notify(ex);
            }
        }

        private static void ThrowExceptionWithCustomMsg()
        {
            try
            {
                throw new Exception(TestThrowingExceptionCustomMsg);
            }
            catch (Exception ex)
            {
                new ExceptionHandlerLog().Notify(ex, CustomMsg);
            }
        }

        private static void ThrowExceptionInner()
        {
            try
            {
                throw new Exception(TestThrowingExceptionMsg, new Exception(InnerExceptionMsg));
            }
            catch (Exception ex)
            {
                new ExceptionHandlerLog().Notify(ex);
            }
        }

        [Fact]
        public void Mock()
        {
            new ExceptionServiceMock().Notify(null, "mock");

            Assert.True(true);
        }

        [Fact]
        public void ExceptionVariants()
        {
            var dir = new DirectoryFile().GetFullyQualifiedDirectory(new LogToFile().GetFullPathFilename());
            Debug.WriteLine("TestException() directory is " + dir);
            new DirectoryFile().DeleteDirectoryWithFiles(dir);
            // verify that directory has been deleted 
            Assert.False(Directory.Exists(dir));

            TestMessageLogging();
            ThrowException();
            ThrowExceptionWithCustomMsg();
            ThrowExceptionInner();

            var text = File.ReadAllText(Path.Combine(dir, General.ExceptionFilename));
            Assert.True(text.IndexOf(TestExceptionMsg) > -1);
            Assert.True(text.IndexOf(TestThrowingExceptionMsg) > -1);
            Assert.True(text.IndexOf(CustomMsg) > -1);
            Assert.True(text.IndexOf(TestThrowingExceptionCustomMsg) > -1);
            Assert.True(text.IndexOf(InnerExceptionMsg) > -1);

            Assert.True(true);
        }

        [Fact]
        public void MessageBox()
        {
            new Thread(() => new ExceptionHandlerMessageBox().Notify(null, "Testing exception handling using a message box"))
                        {Name = "ExceptionService MessageBox"}
                        .Start();

            Thread.Sleep(new Pause().MilliSec);

            Assert.True(true);
        }

        #region Nested type: ExceptionServiceMock

        public class ExceptionServiceMock : ExceptionHandlerBase
        {
            public ExceptionServiceMock(ExceptionMsg exceptionMsg, LogToFile logToFile)
                : base(exceptionMsg, logToFile)
            {
            }

            public ExceptionServiceMock() : this(new ExceptionMsg(), new LogToFile())
            {
            }

            public override bool Notify(Exception ex, string humaneMsg)
            {
                Console.WriteLine(@"Hello from ExceptionServiceMock");
                return true;
            }
        }

        #endregion
    }
}