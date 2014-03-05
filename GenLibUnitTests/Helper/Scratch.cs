using System;
using System.Collections;
using Xunit;

namespace GenLibUnitTests.Helper
{
    public class Scratch
    {
        [Fact]
        public void TryIt()
        {
            Func<int, int> fib = null;
            fib = n => n > 1 ? fib(n - 1) + fib(n - 2) : n;
            var fibCopy = fib;
            Console.WriteLine(fib(6)); // displays 8
            Console.WriteLine(fibCopy(6)); // displays 8
            fib = n => n*2;
            Console.WriteLine(fib(6)); // displays 12
            Console.WriteLine(fibCopy(6)); // displays 18

            Assert.True(true);
        }

        private static IEnumerable Power(int number, int exponent)
        {
            var counter = 0;
            var result = 1;
            while (counter++ < exponent)
            {
                result = result*number;
                yield return result;
            }
        }

        [Fact]
        public void Yield()
        {
            Power(2, 8).Y<int>(i => Console.Write(i + ", "));
            //Power(2, 8).Do(i => Console.Write(i + ", "));
            // Display powers of 2 up to the exponent 8:))
//            foreach (int i in Power(2, 8))
//            {
//                Console.Write("{0} ", i);
//            }
        }
    }

    public static class X
    {
        public static void Y<T>(this IEnumerable ie, Action<T> action)
        {
            foreach (var e in ie) action((T) e);
        }
    }
}