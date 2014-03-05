using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GenLibUnitTests.Examples
{
    public class FizzBuzz
    {
        [Fact]
        public void UsingLinq()
        {
            var result = ConvertNums(new List<int> {1, 3, 5, 10, 15}, 3, 5);
            Assert.Equal("None, Fizz, Buzz, Buzz, FizzBuzz", String.Join(", ", result.Select(r => r.Value)));

            Assert.True(true);
        }

        public static IList<KeyValuePair<int, String>> ConvertNums(IList<int> numbers, int fizzNumber, int buzzNumber)
        {
            var fb = numbers
                .Where(WhereBothDivisible(fizzNumber, buzzNumber))
                .Select(NewKeyValuePair("FizzBuzz"));

            var b = numbers
                .Where(WhereOnlyBuzzDivisable(fizzNumber, buzzNumber))
                .Select(NewKeyValuePair("Buzz"));

            var f = numbers
                .Where(WhereOnlyFizzDivisable(fizzNumber, buzzNumber))
                .Select(NewKeyValuePair("Fizz"));

            var n = numbers
                .Where(WhereNoneDivisable(fizzNumber, buzzNumber))
                .Select(NewKeyValuePair("None"));

            return new List<IEnumerable<KeyValuePair<int, string>>> {fb, b, f, n}
                .SelectMany(i => i)
                .OrderBy(i => i.Key)
                .ToList();
        }

        private static Func<int, KeyValuePair<int, String>> NewKeyValuePair(String value)
        {
            return i => new KeyValuePair<int, String>(i, value);
        }

        private static Func<int, Boolean> WhereBothDivisible(int fizzNumber, int buzzNumber)
        {
            return i => IsDivisible(i, fizzNumber) && IsDivisible(i, buzzNumber);
        }

        private static Func<int, Boolean> WhereOnlyFizzDivisable(int fizzNumber, int buzzNumber)
        {
            return i => IsDivisible(i, fizzNumber) && !IsDivisible(i, buzzNumber);
        }

        private static Func<int, Boolean> WhereOnlyBuzzDivisable(int fizzNumber, int buzzNumber)
        {
            return i => !IsDivisible(i, fizzNumber) && IsDivisible(i, buzzNumber);
        }

        private static Func<int, Boolean> WhereNoneDivisable(int fizzNumber, int buzzNumber)
        {
            return i => !IsDivisible(i, fizzNumber) && !IsDivisible(i, buzzNumber);
        }

        private static bool IsDivisible(int numerator, int denominator)
        {
            return numerator%denominator == 0;
        }
    }
}