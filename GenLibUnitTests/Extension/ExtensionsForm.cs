using System;
using System.Windows.Forms;
using GenLib.Extensions;
using GenLib.View;

namespace GenLibUnitTests.Extension
{
    public partial class ExtensionsForm : Form
    {
        public ExtensionsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void UpdateText(object sender, StringEventArgs args)
        {
            this.InvokeExt(t => t.textBox1.AppendText(args.Message + Environment.NewLine));
        }

        public string TextBoxText()
        {
            return textBox1.Text;
        }
    }
}