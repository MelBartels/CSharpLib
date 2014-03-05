using System.Windows.Forms;

namespace GenLibUnitTests.Examples.MVVM.Messaging.Auxiliary
{
    public partial class View : Form
    {
        public View() : this(new ViewModel())
        {
        }

        public View(ViewModel viewModel)
        {
            InitializeComponent();

            viewModelBindingSource.DataSource = viewModel;
            viewModel.Update = () => viewModelBindingSource.CurrencyManager.Refresh();
        }
    }
}