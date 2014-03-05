using System.Threading;
using GenLib.View;
using Xunit;

namespace GenLibUnitTests.View.WaitCursor
{
    public class WaitCursor
    {
        [Fact]
        public void Demo()
        {
            // see WaitCursorTestForm.Button1_Click for how to use WaitCursor()

            var waitCursorTestForm = new WaitCursorTestForm();
            new Thread(() => waitCursorTestForm.ShowDialog()).Start();

            Thread.Sleep(new Pause().MilliSec);
            waitCursorTestForm.Close();

            Assert.True(true);
        }
    }
}