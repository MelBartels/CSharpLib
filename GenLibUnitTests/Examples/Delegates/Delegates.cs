using System;
using System.Collections.Generic;
using Xunit;

namespace GenLibUnitTests.Examples.Delegates
{
    public class DelegateTest
    {
        public interface IDelegateTest
        {
            void RegisterDelegate(Delegate delegateToRun);
        }

        private class Observed : IDelegateTest
        {
            private readonly List<Delegate> _delegates = new List<Delegate>();

            #region IDelegateTest Members

            public void RegisterDelegate(Delegate delegateToRun)
            {
                _delegates.Add(delegateToRun);
            }

            #endregion

            public void RunDelegate()
            {
                foreach (var @delegate in _delegates)
                {
                    @delegate.DynamicInvoke(new object[] {"notifying you"});
                }
            }
        }

        // Observed sends a message to Observer; 
        // this class (Observer) RegisterDelegate calls above class (Observed) RegisterDelegate to add a delegate 
        // declared in this class (TriggerSomethingDelegate) that points to method in this class (TriggerSomething); 
        // when above class (Observed) RunDelegate is invoked, this class (Observer) method TriggerSomething is executed; 
        // notice use of Interface to eliminate explicit reference to Observed in Observer 
        private class Observer
        {
            #region Delegates

            private delegate void TriggerSomethingDelegate(object @object);

            #endregion

            public bool Processed;

            public void RegisterDelegate(IDelegateTest delegateTest)
            {
                delegateTest.RegisterDelegate(new TriggerSomethingDelegate(TriggerSomething));
            }

            private void TriggerSomething(object @object)
            {
                if (((string) @object)=="notifying you")
                    Processed = true;
            }
        }

        [Fact]
        public void TestDelegate()
        {
            var observed = new Observed();
            var observer = new Observer();
            // setup 
            observer.RegisterDelegate(observed);
            // verify that nothing processed 
            Assert.False(observer.Processed);
            // execute delegate 
            observed.RunDelegate();
            // verify that event processed 
            Assert.True(observer.Processed);

            Assert.True(true);
        }
    }
}