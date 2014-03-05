using System;
using System.ComponentModel;
using GenLib.Constants;
using GenLib.View;

namespace GenLib.Progress.BackgroundWorker
{
    public class ViewModel : IViewModel
    {
        public Action Update;

        // bound properties
        public string DisplayText { get; set; }
        public int ProgressBarValue { get; set; }

        #region IViewModel Members

        public void Subscribe()
        {
        }

        #endregion

        public void Cancel()
        {
            DisplayText += "Cancelling. Please wait..." + General.NewLine;
            Update();
        }

        public void UpdateProgress(ProgressChangedEventArgs e)
        {
            DisplayText += e.UserState + General.NewLine;
            ProgressBarValue = e.ProgressPercentage;
            Update();
        }
    }
}