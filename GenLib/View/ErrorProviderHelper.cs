using System.Windows.Forms;

namespace GenLib.View
{
    public class ErrorProviderHelper
    {
        public void Clear(ErrorProvider errorProvider, Control control)
        {
            errorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
            // moves icon in from the right 
            errorProvider.SetIconPadding(control, -10);
            // w/o this, icon never clears 
            errorProvider.SetError(control, "");
        }
    }
}