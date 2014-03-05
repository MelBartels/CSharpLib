using System;
using GenLib.Extensions;
using GenLib.View;

namespace GenLibUnitTests.Startup
{
    public partial class MainForm : ViewBase
    {
        public MainForm() : this(new GenLib.Startup.AboutScreen())
        {
        }

        public MainForm(GenLib.Startup.AboutScreen aboutScreen)
        {
            InitializeComponent();

            AboutScreen = aboutScreen;
            Subscribe();
        }

        private GenLib.Startup.AboutScreen AboutScreen { get; set; }

        public override sealed void Subscribe()
        {
            exitToolStripMenuItem.GetClick().Subscribe(_ => Close());
            aboutToolStripMenuItem.GetClick().Subscribe(_ => AboutScreen.ShowDialog());
        }
    }
}