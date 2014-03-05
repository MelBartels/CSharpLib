using System;
using System.ComponentModel;
using System.Threading;
using GenLib.Extensions;
using GenLib.Progress.BackgroundWorker;
using Xunit;

namespace GenLibUnitTests.Progress
{
    public class BackgroundWorker
    {
        [Fact]
        public void Run()
        {
            var view = new GenLib.Progress.BackgroundWorker.View(new Mediator(new ViewModel()));
            var lrt = new LongRunningTask();

            // all features
            view.SetParms("Progress Test", "Testing progress framework using background worker", lrt.Execute, true, 4000);

            // no cancel
            //view.SetParms("Progress Test", "Testing progress framework", lrt.Execute, false, 4000);

            // no cancel, no delay
            //view.SetParms("Progress Test", "Testing progress framework", lrt.Execute, false, 0);

            var vpt = new Thread(view.ShowDialog) {Name = "BackgroundWorker"};
            vpt.Start();
            vpt.Join();
            Console.WriteLine(@"BackgroundWorker state is " + view.Mediator.BackgroundWorkerEndingState.Description);
            Assert.NotEqual(view.Mediator.BackgroundWorkerEndingState, BackgroundWorkerEndingState.NotSet);

            Assert.True(true);
        }

        #region Nested type: LongRunningTask

        public class LongRunningTask
        {
            public bool Execute(object sender, DoWorkEventArgs e)
            {
                var success = false;
                sender
                    .CastSafe<System.ComponentModel.BackgroundWorker>()
                    .Do(bw =>
                            {
                                // if needed, args passed via e.Argument
                                const int maxStep = 22;
                                var step = 0;
                                bw.ReportProgress(100*++step/maxStep, "LongRunningTask starting...");
                                while (step < maxStep - 1)
                                {
                                    if (bw.CancellationPending)
                                    {
                                        e.Cancel = true;
                                        bw.ReportProgress(100*++step/maxStep, "LongRunningTask cancelled");
                                        return;
                                    }
                                    bw.ReportProgress(100*++step/maxStep, "LongRunningTask step " + step);
                                    // a chunk of work
                                    Console.WriteLine(step + @" of " + maxStep);
                                    Thread.Sleep(100);
                                }
                                bw.ReportProgress(100*++step/maxStep, "LongRunningTask finished");
                                success = true;
                            });
                return success;
            }
        }

        #endregion
    }
}