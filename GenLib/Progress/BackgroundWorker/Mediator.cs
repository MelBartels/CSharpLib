using System.ComponentModel;
using GenLib.Messaging;
using GenLib.SFT;

namespace GenLib.Progress.BackgroundWorker
{
    public class Mediator
    {
        #region Delegates

        public delegate bool Callback(object sender, DoWorkEventArgs e);

        #endregion

        public Mediator(ViewModel viewModel)
        {
            ViewModel = viewModel;

            BackgroundWorkerEndingState = Progress.BackgroundWorker.BackgroundWorkerEndingState.NotSet;
            BuildBackgroundWorker();
        }

        // used by the long running task
        public System.ComponentModel.BackgroundWorker BackgroundWorker { get; set; }
        public Callback CallbackMethod { get; set; }
        public ISFT BackgroundWorkerEndingState { get; set; }
        public ViewModel ViewModel { get; set; }
        public MessageToken BackgroundWorkFinishedToken { get; set; }

        public void Execute()
        {
            BackgroundWorker.RunWorkerAsync();
        }

        public void Cancel()
        {
            ViewModel.Cancel();
            BackgroundWorker.CancelAsync();
        }

        private void BuildBackgroundWorker()
        {
            BackgroundWorker = new System.ComponentModel.BackgroundWorker
                                   {
                                       WorkerSupportsCancellation = true,
                                       WorkerReportsProgress = true
                                   };
            BackgroundWorker.DoWork += BackgroundWorkerDoWork;
            BackgroundWorker.ProgressChanged += BackgroundWorkerProgressChanged;
            BackgroundWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerCompleted;
        }

        // fired by BackgroundWorker.RunWorkerAsync()
        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = CallbackMethod.DynamicInvoke(new[] {sender, e});
            // if background work completes before cancel handled, background worker will not have set CancellationPending;
             if (BackgroundWorker.CancellationPending && !e.Cancel)
                 e.Cancel = true;
        }

        // fired by BackgroundWorker.ReportProgress() 
        private void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ViewModel.UpdateProgress(e);
        }

        // fired when BackgroundWorker concludes (finishes with the CallBackMethod)
        // handling the RunWorkerCompleted event gives access to RunWorkerCompletedEventArgs which has
        // more information than the e.Result that is returned when the CallbackMethod completes in the DoWork event
        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                BackgroundWorkerEndingState = Progress.BackgroundWorker.BackgroundWorkerEndingState.EncounteredError;
            else if (e.Cancelled)
                BackgroundWorkerEndingState = Progress.BackgroundWorker.BackgroundWorkerEndingState.Cancelled;
            else if (e.Result == (object) false)
                BackgroundWorkerEndingState = Progress.BackgroundWorker.BackgroundWorkerEndingState.Failed;
            else
                BackgroundWorkerEndingState = Progress.BackgroundWorker.BackgroundWorkerEndingState.Successful;

            Messenger.Instance().Send(new StringMessage { Token = BackgroundWorkFinishedToken });
        }
    }
}