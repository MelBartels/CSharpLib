using System.Threading;
using GenLib.View;
using Xunit;

namespace GenLibUnitTests.Reactive.MouseDemo.Ext
{
    public class Tests
    {
        [Fact]
        public void ShowForm()
        {
            var reactiveFormUsingExt = new TestForm();
            new Thread(() => reactiveFormUsingExt.ShowDialog()).Start();

            Thread.Sleep(new Pause().MilliSec);
            reactiveFormUsingExt.Close();

            Assert.True(true);
        }
    }
}