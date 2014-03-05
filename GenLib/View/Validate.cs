using System.IO;
using System.Windows.Forms;

namespace GenLib.View
{
    public class Validate
    {
        public Validate() : this(new ErrorProviderHelper())
        {
        }

        public Validate(ErrorProviderHelper errorProviderHelper)
        {
            ErrorProviderHelper = errorProviderHelper;
        }

        private ErrorProviderHelper ErrorProviderHelper { get; set; }

        public bool ValidateInt(ErrorProvider errorProvider, TextBox textBox)
        {
            ErrorProviderHelper.Clear(errorProvider, textBox);

            int value;
            if (int.TryParse(textBox.Text, out value))
                return true;

            ShowNonNumeric(errorProvider, textBox);
            return false;
        }

        public bool ValidateDouble(ErrorProvider errorProvider, TextBox textBox)
        {
            ErrorProviderHelper.Clear(errorProvider, textBox);

            double value;
            if (double.TryParse(textBox.Text, out value))
                return true;

            ShowNonNumeric(errorProvider, textBox);
            return false;
        }

        public bool ValidateDir(ErrorProvider errorProvider, TextBox textBox)
        {
            ErrorProviderHelper.Clear(errorProvider, textBox);

            if (Directory.Exists(textBox.Text))
                return true;

            ShowNonExistent(errorProvider, textBox);
            return false;
        }

        public bool ValidateFile(ErrorProvider errorProvider, TextBox textBox)
        {
            ErrorProviderHelper.Clear(errorProvider, textBox);

            if (File.Exists(textBox.Text))
                return true;

            ShowNonExistent(errorProvider, textBox);
            return false;
        }

        public bool ValidateDirFile(ErrorProvider errorProvider, TextBox textBox)
        {
            ErrorProviderHelper.Clear(errorProvider, textBox);

            if (Directory.Exists(textBox.Text) || File.Exists(textBox.Text))
                return true;

            ShowNonExistent(errorProvider, textBox);
            return false;
        }

        private static void ShowNonNumeric(ErrorProvider errorProvider, Control control)
        {
            errorProvider.SetError(control, "Error: ' " + control.Text + " ' is not numeric.");
        }

        private static void ShowNonExistent(ErrorProvider errorProvider, Control control)
        {
            errorProvider.SetError(control, "Error: ' " + control.Text + " ' does not exist or is not accessible.");
        }
    }
}