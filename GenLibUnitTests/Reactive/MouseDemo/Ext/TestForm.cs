using System.Windows.Forms;
using GenLib.Extensions;

namespace GenLibUnitTests.Reactive.MouseDemo.Ext
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            ShowStartAndCurrent();
            DragMouseExtension();
            MouseDragDeltaExtension();
        }

        private void ShowStartAndCurrent()
        {
            ((Control) this).GetMouseDragStartCurrent(
                (s, c) => label1.Text = @"mouse started at " + s.ToString() + @", now at " + c.ToString());
        }

        private void DragMouseExtension()
        {
            ((Control) this).GetMouseDrag(point => label2.Text = @"mouse position is " + point.ToString());
        }

        private void MouseDragDeltaExtension()
        {
            ((Control) this).GetMouseDragDelta(size => label3.Text = @"change in mouse position is " + size.ToString());
        }
    }
}