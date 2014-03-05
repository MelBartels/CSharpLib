using System;
using System.ComponentModel;
using System.Windows.Forms;
using GenLib.Extensions;

namespace GenLib.View
{
    public class ViewBase : Form, IView
    {
        #region IView Members

        public virtual void OnSetTitle(StringEventArgs args)
        {
            SetTitle(null, args);
        }

        public virtual void OnShowDialog()
        {
            ShowDialog();
        }

        public virtual void OnClose()
        {
            Close();
        }

        public virtual void Subscribe()
        {
        }

        #endregion

        protected void SetTitle(object sender, StringEventArgs args)
        {
            this.InvokeExt(_ => Text = args.Message);
        }

        public new void ShowDialog()
        {
            this.InvokeExt(_ => BaseShowDialog());
        }

        private DialogResult BaseShowDialog()
        {
            return base.ShowDialog();
        }

        public new void Close()
        {
            try
            {
                this.InvokeExt(_ => BaseClose());
            }
            catch (ObjectDisposedException)
            {
                // if form disposed, then it is also closed 
            }
            catch (InvalidAsynchronousStateException)
            {
                // form may have been closed and thread concluded during marshalling of Invoke
            }
        }

        private void BaseClose()
        {
            base.Close();
        }
    }
}