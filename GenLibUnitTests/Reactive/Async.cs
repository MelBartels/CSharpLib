using System;
using System.Concurrency;
using System.Disposables;
using System.Linq;
using System.Threading;
using Xunit;

namespace GenLibUnitTests.Reactive
{
    public class AysncTestRx
    {
        [Fact]
        public void Async()
        {
            var observable = Observable
                .CreateWithDisposable<int>(o =>
                                               {
                                                   var cancel = new CancellationDisposable();
                                                   Scheduler.NewThread.Schedule(AsyncAction(cancel, o));
                                                   return cancel;
                                               });

            var subscription = observable.Subscribe(Console.WriteLine);
            Thread.Sleep(1000);
            // cause cancel 
            subscription.Dispose();
            Thread.Sleep(100);
            // give background thread time to write the cancel acknowledge message
            Thread.Sleep(1000);
        }

        private static Action AsyncAction(CancellationDisposable cancel, IObserver<int> observer)
        {
            return () =>
                       {
                           var i = 0;
                           for (;;)
                           {
                               // do long running task or part of larger task
                               Thread.Sleep(100);
                               if (cancel.Token.IsCancellationRequested)
                               {
                                   Console.WriteLine(@"Cancel requested");
                                   observer.OnCompleted();
                                   return;
                               }
                               // check cancel token periodically
                               observer.OnNext(i++);
                           }
                       };
        }

        [Fact]
        public void ForkJoin()
        {
            var observable = Observable.ForkJoin(
                Observable.Start(() =>
                                     {
                                         Thread.Sleep(100);
                                         WriteSequenceAndThreadId(1);
                                         return "Result 1";
                                     }),
                Observable.Start(() =>
                                     {
                                         Thread.Sleep(100);
                                         WriteSequenceAndThreadId(2);
                                         return "Result 2";
                                     }),
                Observable.Start(() =>
                                     {
                                         Thread.Sleep(100);
                                         WriteSequenceAndThreadId(3);
                                         return "Result 3";
                                     }),
                Observable.Start(() =>
                                     {
                                         Thread.Sleep(100);
                                         WriteSequenceAndThreadId(4);
                                         return "Result 4";
                                     }),
                Observable.Start(() =>
                                     {
                                         Thread.Sleep(100);
                                         WriteSequenceAndThreadId(5);
                                         return "Result 5";
                                     })
                ).Finally(() => Console.WriteLine(@"Finally called"));

            observable.First().ToList().ForEach(Console.WriteLine);
        }

        private static void WriteSequenceAndThreadId(int sequence)
        {
            Console.WriteLine(@"Executing {0} on Thread: {1}", sequence, Thread.CurrentThread.ManagedThreadId);
        }
    }
}