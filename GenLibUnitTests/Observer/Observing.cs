using GenLib.Observer;
using Xunit;

namespace GenLibUnitTests.Observer
{
    public class Observing
    {
        private class Observed
        {
            public readonly Observers Observers = new Observers();

            public void Alert()
            {
                Observers.Alert(this, null);
            }
        }

        private class Observer
        {
            public bool Processed;

            public bool ProcessAlert(object sender, ObserverEventArgs oea)
            {
                Processed = true;
                return true;
            }
        }

        [Fact]
        public void Observe()
        {
            var observed = new Observed();
            var observer = new Observer();
            observed.Observers.Add(observer.ProcessAlert);

            observed.Alert();
            Assert.True(observer.Processed);

            observed.Observers.Remove(observer.ProcessAlert);

            Assert.True(true);
        }
    }
}