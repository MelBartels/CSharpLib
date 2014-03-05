using System;
using System.Threading;
using System.Windows.Forms;
using GenLib.Extensions;
using Xunit;
using Timer = System.Threading.Timer;

namespace GenLibUnitTests.Progress
{
    public class Manual
    {
        private const int StepMilliSec = 1000;

        [Fact]
        public void Run()
        {
            var view = new GenLib.Progress.Manual.View();
            view.SetParms("Progress Test", "Testing progress framework with manual calls");
            view.GetVisibleChanged().Subscribe(_ => ReadyToBegin(view));

            var viewThread = new Thread(() => view.ShowDialog()) {Name = "ViaManual"};
            viewThread.Start();
            viewThread.Join();

            Assert.True(true);
        }

        private static void ReadyToBegin(GenLib.Progress.Manual.View view)
        {
            view.UpdateProgress("ready to begin", 0);
            TestingTesting(view);
        }

        private static void TestingTesting(GenLib.Progress.Manual.View view)
        {
            new Timer(_ =>
                          {
                              view.UpdateProgress("testing testing", 33);
                              OneTwoThree(view);
                          }, null, StepMilliSec, 0);
        }

        private static void OneTwoThree(GenLib.Progress.Manual.View view)
        {
            new Timer(_ =>
                          {
                              view.UpdateProgress("123 123", 67);
                              Finished(view);
                          }, null, StepMilliSec, 0);
        }

        private static void Finished(GenLib.Progress.Manual.View view)
        {
            new Timer(_ =>
                          {
                              view.UpdateProgress("finished", 100);
                              Close(view);
                          }, null, StepMilliSec, 0);
        }

        private static void Close(Form view)
        {
            new Timer(_ => view.Close(), null, StepMilliSec, 0);
        }
    }
}