using System.Windows.Forms;

namespace GenLib.MessageBox
{
    public class AppMessageBox
    {
        public static DialogResult Show(string msg)
        {
            return System.Windows.Forms.MessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK);
        }
    }
}