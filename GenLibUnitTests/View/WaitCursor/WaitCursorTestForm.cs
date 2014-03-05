using System;
using System.Threading;
using System.Windows.Forms;

namespace GenLibUnitTests.View.WaitCursor
{
    public partial class WaitCursorTestForm : Form
    {
        public WaitCursorTestForm()
        {
            InitializeComponent();
        }

        private void WriteLine(string text)
        {
            textBox1.AppendText(text + Environment.NewLine);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (new GenLib.View.WaitCursor())
            {
                WriteLine("Beginning long running task.");
                Thread.Sleep(4000);
                WriteLine("Long running task ended.");
            }
            WriteLine("WaitCursor disposed.");
        }

        private void WaitCursorTestForm_Load(object sender, EventArgs e)
        {
            WriteLine("Waiting for button click...");
        }
    }
}