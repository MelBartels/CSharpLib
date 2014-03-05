using System;
using System.Linq;
using System.Threading;
using GenLib.Extensions;
using GenLib.Messaging;
using GenLib.View;

namespace GenLib.Progress.BackgroundWorker
{
    public partial class View : ViewBase
    {
        public View() : this(new Mediator(new ViewModel()))
        {
        }

        public View(Mediator mediator)
        {
            InitializeComponent();

            Mediator = mediator;
            viewModelBindingSource.DataSource = mediator.ViewModel;
            Subscribe();
        }

        public Mediator Mediator { get; set; }
        private int CloseAfterWorkCompletedTimeMilliSec { get; set; }

        public void SetParms(string title,
                             string description,
                             Mediator.Callback callbackMethod,
                             bool canCancel,
                             int closeAfterWorkCompletedTimeMilliSec)
        {
            CloseAfterWorkCompletedTimeMilliSec = closeAfterWorkCompletedTimeMilliSec;
            Mediator.CallbackMethod = callbackMethod;

            Text = title;
            LblDescription.Text = description;
            BtnAction.Visible = canCancel;
        }

        public override sealed void Subscribe()
        {
            Mediator.ViewModel.Update = () =>
                                            {
                                                viewModelBindingSource.CurrencyManager.Refresh();
                                                DisplayText.MoveCursorToEnd();
                                            };

            BtnAction.GetClick()
                .Where(_ => BtnAction.Visible)
                .Where(_ => Mediator.BackgroundWorkerEndingState == BackgroundWorkerEndingState.NotSet)
                .Subscribe(_ => Mediator.Cancel());

            BtnAction.GetClick()
                .Where(_ => Mediator.BackgroundWorkerEndingState != BackgroundWorkerEndingState.NotSet)
                .Subscribe(_ => Close());

            this.GetVisibleChanged()
                .Where(_ => Visible)
                .Subscribe(_ => Mediator.Execute());

            Mediator.BackgroundWorkFinishedToken = new MessageToken();
            Messenger.Instance().OfType<StringMessage>()
                .Where(sp => sp.Token == Mediator.BackgroundWorkFinishedToken)
                .Subscribe(sp => PauseThenClose());
        }

        private void PauseThenClose()
        {
            BtnAction.Visible = true;
            BtnAction.Text = @"OK";
            BtnAction.Refresh();
            new Timer(_ => Close(), null, CloseAfterWorkCompletedTimeMilliSec, Timeout.Infinite);
        }

        #region IView implementation

        #endregion
    }
}