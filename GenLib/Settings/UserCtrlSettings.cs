using System;
using System.Windows.Forms;

namespace GenLib.Settings
{
    public partial class UserCtrlSettings : UserControl
    {
        public UserCtrlSettings()
        {
            InitializeComponent();

            SetToolTip();
        }

        private void SetToolTip()
        {
            toolTip.SetToolTip(BtnLoad, ToolTips.LoadToolTip);
            toolTip.SetToolTip(BtnSave, ToolTips.SaveToolTip);
            toolTip.SetToolTip(BtnAccept, ToolTips.AcceptToolTip);
            toolTip.SetToolTip(BtnOk, ToolTips.OkToolTip);
            toolTip.SetToolTip(BtnCancel, ToolTips.CancelToolTip);
            toolTip.SetToolTip(BtnDefault, ToolTips.DefaultToolTip);
            toolTip.SetToolTip(BtnReset, ToolTips.ResetToolTip);
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void BtnDefault_Click(object sender, EventArgs e)
        {

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {

        }
    }
}