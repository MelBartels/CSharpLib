using System;
using System.Windows.Forms;

namespace GenLib.View
{
    public class WaitCursor : IDisposable
    {
        public WaitCursor(Control control)
        {
            Control = control;
            Cursor = Control.Cursor;
            Control.Cursor = Cursors.WaitCursor;
        }

        public WaitCursor()
        {
            Control = null;
            Cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
        }

        private Control Control { get; set; }

        private Cursor Cursor { get; set; }

        #region IDisposable Members

        public void Dispose()
        {
            if (Control == null)
                Cursor.Current = Cursor;
            else
                Control.Cursor = Cursor;
        }

        #endregion
    }
}