using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GenLib.Extensions;

namespace GenLib.Startup
{
    public partial class AboutScreen : Form
    {
        private const double OpacityIntervalSec = .01;

        public AboutScreen() : this(new ViewModel(new ApplicationDataModel()))
        {
        }

        public AboutScreen(ViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;
            viewModelBindingSource.DataSource = ViewModel;

            this.GetLoad().Subscribe(_ => SetLoadState());
            this.GetFormClosing().Subscribe(FormClosingTasks);
        }

        public ViewModel ViewModel { get; set; }
        private Image Image { get; set; }

        private void SetLoadState()
        {
            Image = Image.FromFile(ViewModel.ImageFilename);

            lblTitle.ForeColor = ViewModel.TextColor;
            lblVersion.ForeColor = ViewModel.TextColor;
            lblCopyright.ForeColor = ViewModel.TextColor;
            lblCompany.ForeColor = ViewModel.TextColor;
            lblDescription.ForeColor = ViewModel.TextColor;

            Opacity = 0;
            FadeInTimer.Enabled = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Image, 0, 0, Width, Height);
        }

        private void FormClosingTasks(IEvent<FormClosingEventArgs> e)
        {
            if (FadeInTimer.Enabled)
                FadeInTimer.Enabled = false;

            FadeOutTimer.Enabled = e.EventArgs.Cancel = Opacity > 0;
        }

        private void FadeInTimerTick(object sender, EventArgs e)
        {
            Opacity += OpacityIntervalSec;
            if (Opacity >= 1)
                FadeInTimer.Enabled = false;
        }

        private void FadeOutTimerTick(object sender, EventArgs e)
        {
            Opacity -= OpacityIntervalSec;
            if (Opacity <= 0)
                Close();
        }
    }
}