using System.Drawing;
using System.Threading;
using GenLib.View;
using Xunit;

namespace GenLibUnitTests.Startup
{
    public class AboutScreen
    {
        [Fact]
        public void Show()
        {
            var aboutScreen = new GenLib.Startup.AboutScreen();
            aboutScreen.ViewModel.SetProperties(@"TestFiles\TestAboutScreen.png", Color.Black);

            new Thread(() => aboutScreen.ShowDialog()).Start();
            Thread.Sleep(new Pause().MilliSec);
            aboutScreen.Close();

            Assert.True(true);
        }
    }
}