using System.Windows.Forms;
using GenLib.Constants;
using GenLib.Extensions;

namespace GenLib.Progress.Manual
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        public void SetParms(string title, string description)
        {
            Text = title;
            LblDescription.Text = description;
        }

        public void UpdateProgress(string message, int progressBarValue)
        {
            this.InvokeExt(_ =>
                               {
                                   DisplayText.Text += message + General.NewLine;
                                   DisplayText.MoveCursorToEnd();
                                   ProgressBar.Value = progressBarValue;
                               });
        }
    }
}