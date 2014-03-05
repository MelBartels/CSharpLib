using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using GenLib.Extensions;
using Xunit;

namespace GenLibUnitTests.Extension
{
    public class EnumerableExtensions
    {
        private static int _count;

        private static void IncrCount()
        {
            _count++;
        }

        [Fact]
        public void CancellableProgressReporting()
        {
            var cancelled = false;

            Func<int, bool> shouldCancel = percent =>
                                               {
                                                   cancelled = percent > 50;
                                                   return cancelled;
                                               };

            var largest = 1.To(100).AsCancelable(shouldCancel)
                .Select(i => i*10).ToList();

            Assert.True(cancelled);
            Assert.Equal(510, largest.Max());

            Assert.True(true);
        }

        [Fact]
        public void Each()
        {
            var list = new List<NumBox> {new NumBox {Num = -1}, new NumBox {Num = -1}};
            list.Each((n, i) => n.Num = i);

            Assert.Equal(0, list[0].Num);
            Assert.Equal(1, list[1].Num);

            Assert.True(true);
        }

        [Fact]
        public void Each2()
        {
            var list = new List<NumBox> {new NumBox {Num = -1}, new NumBox {Num = -1}};
            list.Each((n, i) => n.Num = i, 2);

            Assert.Equal(2, list[0].Num);
            Assert.Equal(3, list[1].Num);

            Assert.True(true);
        }

        [Fact]
        public void ExcludeNulls()
        {
            var airplanes = new List<Airplane> { new Airplane(), null };
            Assert.Equal(1, airplanes.ExcludeNulls(x => x).Count());

            airplanes[0].Engine = new Engine();
            Assert.Equal(1, airplanes.ExcludeNulls(x => x.Engine).Count());
            Assert.Equal(0, airplanes.ExcludeNulls(x => x.Engine)
                                .ExcludeNulls(x => x.Engine.FuelType).Count());

            airplanes[0].Engine.FuelType = "123";
            Assert.Equal(1, airplanes.ExcludeNulls(x => x.Engine.FuelType).Count());

            Assert.True(true);
        }

        [Fact]
        public void AnyReturn()
        {
            var nums = 1.To(5).ToList();
            Assert.Equal(3, nums.Any().Return(3, 10));
            Assert.Equal(3, nums.ReturnAny(3, 10));

            nums.Clear();
            Assert.Equal(10, nums.ReturnAny(3, 10));

            nums = null;
            Assert.Equal(10, nums.ReturnAny(3, 10));

            Assert.True(true);
        }

        [Fact]
        public void AnyReturnFunc()
        {
            var nums = 1.To(5).ToList();
            Assert.Equal(1, nums.ReturnAny(n => n == 3, 1, 2));

            nums.Clear();
            Assert.Equal(2, nums.ReturnAny(n => n == 3, 1, 2));

            nums = null;
            Assert.Equal(2, nums.ReturnAny(n => n == 3, 1, 2));

            Assert.True(true);
        }

        [Fact]
        public void IfAny()
        {
            var nums = 1.To(5).ToList();
            var result = 0;
            nums.IfAny(() => result = 1, () => result = 2);
            Assert.Equal(1, result);

            nums.Clear();
            nums.IfAny(() => result = 1, () => result = 2);
            Assert.Equal(2, result);

            nums = null;
            nums.IfAny(() => result = 1, () => result = 2);
            Assert.Equal(2, result);

            Assert.True(true);
        }

        [Fact]
        public void IfAnyFunc()
        {
            var nums = 1.To(5).ToList();
            var result = 0;
            nums.IfAny(n => n == 3, () => result = 1, () => result = 2);
            Assert.Equal(1, result);

            nums.IfAny(n => n == 10, () => result = 1, () => result = 2);
            Assert.Equal(2, result);

            nums = null;
            nums.IfAny(n => n == 10, () => result = 1, () => result = 2);
            Assert.Equal(2, result);
            
            Assert.True(true);
        }

        [Fact]
        public void Progress()
        {
            var progress = 0;
            const int max = 101;
            var worker = new BackgroundWorker {WorkerReportsProgress = true};
            worker.DoWork += (sender, e) => 1.To(max).WithProgress(i =>
                                                                       {
                                                                           worker.ReportProgress(i);
                                                                           progress++;
                                                                           Thread.Sleep(10);
                                                                       }).ToList();
            // worker's report progress handled here
            worker.ProgressChanged += (sender, e) => Console.WriteLine(e.ProgressPercentage);

            worker.RunWorkerAsync();

            while (progress < max)
                Thread.Sleep(10);

            Assert.True(true);
        }

        [Fact]
        public void Run()
        {
            _count = 5;
            var actions = new List<Action> {IncrCount, IncrCount, IncrCount};
            actions.Run();
            Assert.Equal(8, _count);

            Assert.True(true);
        }

        [Fact]
        public void CreateListFromTradition()
        {
            var kvps = new List<KeyValuePair<int, string>>();
            1.To(5).ForEach(i => kvps.Add(new KeyValuePair<int, string>(i, 1.ToString())));
            Assert.Equal(5, kvps.Count);

            Assert.True(true);
        }

        [Fact]
        public void CreateListFromTradition2()
        {
            var newInts = new List<int>();
            var ints = new List<int> {1, 2, 3, 4, 5};
            ints.ForEach(i => newInts.Add(i*10));
            Assert.Equal(5, newInts.Count);
            Assert.Equal(10, newInts[0]);

            Assert.True(true);
        }

        [Fact]
        public void CreateListFrom()
        {
            var kvps = 1.To(5).CreateListFrom(i => new KeyValuePair<int, string>(i, 1.ToString()));
            Assert.Equal(5, kvps.Count);

            Assert.True(true);
        }

        [Fact]
        public void CreateListFrom2()
        {
            var kvps = 1.To(5).CreateListFrom(i => i*10);
            Assert.Equal(5, kvps.Count);
            Assert.Equal(10, kvps[0]);

            Assert.True(true);
        }

        [Fact]
        public void CreateListFrom3()
        {
            var ints = new List<int> {1, 2, 3, 4, 5};
            var newInts = ints.CreateListFrom(i => i*10);
            Assert.Equal(5, newInts.Count);
            Assert.Equal(10, newInts[0]);

            Assert.True(true);
        }

        #region Nested type: NumBox

        private class NumBox
        {
            public int Num { get; set; }
        }

        #endregion
    }
}