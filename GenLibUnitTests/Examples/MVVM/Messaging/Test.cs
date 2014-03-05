using System.Threading;
using GenLib.Messaging;
using GenLib.View;
using GenLibUnitTests.Examples.MVVM.Messaging.Main;
using Xunit;

namespace GenLibUnitTests.Examples.MVVM.Messaging
{
    public class Test
    {
        [Fact]
        public void Run()
        {
            // view models
            var mainViewModel = new ViewModel();
            var auxViewModel = new Auxiliary.ViewModel();

            // views
            var mainView = new Main.View(mainViewModel);
            var auxiliaryView = new Auxiliary.View(auxViewModel);

            // message token
            var titleToken = new MessageToken();
            mainViewModel.TitleToken = titleToken;
            auxViewModel.TitleToken = titleToken;

            // subscribe
            mainViewModel.Subscribe();
            auxViewModel.Subscribe();

            // show forms
            new Thread(() => mainView.ShowDialog()).Start();
            new Thread(() => auxiliaryView.ShowDialog()).Start();

            //Thread.Sleep(100000); 
            Thread.Sleep(new Pause().MilliSec);

            // shutdown
            mainView.Close();
            auxiliaryView.Close();
        }
    }
}