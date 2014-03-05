using System;
using System.Threading;
using GenLib.View;
using Ninject;
using Xunit;

namespace GenLibUnitTests.Startup
{
    public class Startup
    {
        private int VisibleCount { get; set; }

        [Fact]
        public void FormWithAboutScreen()
        {
            var kernel = new StandardKernel(new NinjectSettings {LoadExtensions = true});
            var startup = kernel.Get<GenLib.Startup.Startup>();

            new Thread(() => startup.StartForm<MainForm>("en-US", @"TestFiles\TestAboutScreen.png", MainFormVisible))
                {Name = "FormWithAboutScreen unit test"}
                .Start();

            //Thread.Sleep(100000);
            Thread.Sleep(new Pause().MilliSec);

            kernel.Get<MainForm>().Close();
            Assert.Equal(1, VisibleCount);

            Assert.True(true);
        }

        private EventArgs MainFormVisible()
        {
            VisibleCount++;
            return new EventArgs();
        }
    }
}