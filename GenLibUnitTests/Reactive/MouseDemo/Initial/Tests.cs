using System.Threading;
using GenLib.View;
using Xunit;

namespace GenLibUnitTests.Reactive.MouseDemo.Initial
{
    public class Tests
    {
        [Fact]
        public void ShowForm()
        {
            var reactiveForm = new TestForm();
            new Thread(() => reactiveForm.ShowDialog()).Start();

            Thread.Sleep(new Pause().MilliSec);
            reactiveForm.Close();

            Assert.True(true);
        }
    }
}