using System;
using System.IO;
using GenLib.Observer;
using GenLib.Services;
using Xunit;

namespace GenLibUnitTests.Observer
{
    public class LoggingObserver
    {
        [Fact]
        public void Observe()
        {
            var loggingObserver = new GenLib.Observer.LoggingObserver();
            Assert.False((loggingObserver.Alert(null, null)));

            var observed = new Observed();
            observed.Observers.Add(loggingObserver.Alert);

            // clear out old test
            loggingObserver.CreateDefaultFilename();
            new DirectoryFile().DeleteDirectoryWithFiles(
                new DirectoryFile().GetFullyQualifiedDirectory(loggingObserver.Filename));

            loggingObserver.Open();
            Assert.True((loggingObserver.Alert(this, new ObserverEventArgs
                                                         {
                                                             Arg = string.Empty
                                                         })));
            Console.WriteLine(loggingObserver.Filename);
            const string testMsg = "testMsg";
            observed.Alert(testMsg);
            loggingObserver.Close();

            var sr = new StreamReader(loggingObserver.Filename);
            var contents = sr.ReadLine();
            sr.Close();
            Assert.Equal(testMsg, contents);

            observed.Observers.Remove(loggingObserver.Alert);

            Assert.True(true);
        }

        [Fact]
        public void IncrFilename()
        {
            var loggingObserver = new GenLib.Observer.LoggingObserver();

            // clear out old test
            loggingObserver.CreateDefaultFilename();
            new DirectoryFile().DeleteDirectoryWithFiles(
                new DirectoryFile().GetFullyQualifiedDirectory(loggingObserver.Filename));

            loggingObserver.Open();
            var firstFilename = loggingObserver.Filename;
            Console.WriteLine("firstFilename " + firstFilename);
            loggingObserver.Close();

            loggingObserver = new GenLib.Observer.LoggingObserver();
            loggingObserver.Open();
            var secondFilename = loggingObserver.Filename;
            Console.WriteLine("secondFilename " + secondFilename);
            loggingObserver.Close();

            loggingObserver = new GenLib.Observer.LoggingObserver();
            loggingObserver.Open();
            var thirdFilename = loggingObserver.Filename;
            Console.WriteLine("thirdFilename " + thirdFilename);
            loggingObserver.Close();

            Assert.NotEqual(secondFilename, firstFilename);
            Assert.NotEqual(thirdFilename, secondFilename);

            Assert.True(true);
        }

        #region Nested type: Observed

        private class Observed
        {
            public readonly Observers Observers = new Observers();

            public void Alert(string msg)
            {
                Observers.Alert(this, new ObserverEventArgs {Arg = msg});
            }
        }

        #endregion
    }
}