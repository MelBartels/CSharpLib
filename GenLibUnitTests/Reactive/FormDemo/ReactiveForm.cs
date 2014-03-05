using System;
using System.Windows.Forms;

namespace GenLibUnitTests.Reactive.FormDemo
{
    public partial class ReactiveForm : Form
    {
        public ReactiveForm()
        {
            InitializeComponent();

            Build();
        }

        private void Build()
        {
            this.GetLoad().Subscribe(ea => UpdateLabel("form loaded"));

            var clickCount = 0;
            BtnClickMe.GetClicks().Subscribe(ea => UpdateLabel("clicked " + ++clickCount + " times"));
        }

        private void UpdateLabel(string text)
        {
            label1.Text = text;
        }
    }
}