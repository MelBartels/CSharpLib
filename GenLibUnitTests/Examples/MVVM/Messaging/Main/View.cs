using System;
using System.Windows.Forms;
using GenLib.Extensions;
using GenLib.Messaging;

namespace GenLibUnitTests.Examples.MVVM.Messaging.Main
{
    public partial class View : Form
    {
        public View() : this(new ViewModel())
        {
        }

        public View(ViewModel viewModel)
        {
            InitializeComponent();

            // demonstrates binding viewmodel to view

            // use designer to bind form's text to viewmodel's text (bind to object, then select viewmodel)
            // use designer to bind form's textboxes and labels to viewmodel properties
            // when setting bindings in the designer, be sure to set datasource update mode to OnPropertyChanged

            viewModelBindingSource.DataSource = viewModel;
            viewModel.Update = () => viewModelBindingSource.CurrencyManager.Refresh();            
            BtnCopy.GetClick().Subscribe(
                _ => Messenger.Instance().Send(new CopyTextMessage { Value = viewModel.NewDisplayedText }));

        }
    }
}