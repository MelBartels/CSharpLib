using System.Windows.Forms;
using GenLib.Extensions;

namespace GenLibUnitTests.Reactive.MouseDemo.MoveMinimize
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            this.RepositionByDraggingOn(this);
            this.MinimizeOn(this.GetDoubleClick());
        }
    }
}