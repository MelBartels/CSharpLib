using System;
using System.Collections.Generic;

namespace Atlas.Extensions
{
    public static class DebugExtension
    {
        public static bool ShowWhiteSpace { get; set; }

        public static IEnumerable<T> Dump<T>(this IEnumerable<T> input) 
        {
            return Dump(input, item => item != null ? item.ToString() : "(null)");
        }

        public static IEnumerable<T> Dump<T>(this IEnumerable<T> input, Func<T, string> toString)
        {
            foreach (var item in input)
            {
                Console.WriteLine(ShowWhiteSpace ? '[' + toString(item) + ']' : toString(item));
                yield return item;
            }
        }
    }
}