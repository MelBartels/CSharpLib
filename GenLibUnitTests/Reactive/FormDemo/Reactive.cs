using System.Threading;
using GenLib.View;
using Xunit;

namespace GenLibUnitTests.Reactive.FormDemo
{
    public class Reactive
    {
        [Fact]
        public void Demo()
        {
            var reactiveForm = new ReactiveForm();
            new Thread(() => reactiveForm.ShowDialog()).Start();

            Thread.Sleep(new Pause().MilliSec);
            reactiveForm.Close();

            Assert.True(true);
        }
    }
}