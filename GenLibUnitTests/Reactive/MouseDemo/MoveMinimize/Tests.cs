using System.Threading;
using GenLib.View;
using Xunit;

namespace GenLibUnitTests.Reactive.MouseDemo.MoveMinimize
{
    public class Tests
    {
        [Fact]
        public void ShowForm()
        {
            var moveForm = new TestForm();
            new Thread(() => moveForm.ShowDialog()).Start();

            Thread.Sleep(new Pause().MilliSec);
            moveForm.Close();

            Assert.True(true);
        }
    }
}