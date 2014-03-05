using System;
using System.Collections.Generic;
using System.Linq;

namespace GenLib.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// <para>Enumerable Extension.</para>
        /// <para>Creates a closure, incrementing an index for each item in the IEnumerable</para>
        /// <para>Syntactical sugar: hides a closure and increments the value passed to each item.</para>
        /// <para>eg, myList.Each((n, i) => n.Num = i) means that myList first item Num is set to 0, the next item Num is set to 1, and so forth..</para>
        /// </summary>
        public static void Each<T>(this IEnumerable<T> items, Action<T, int> action)
        {
            items.Each(action, 0);
        }

        /// <summary>
        /// <para>Enumerable Extension.</para>
        /// <para>Creates a closure around a seed value, incrementing the seed for each item in the IEnumerable</para>
        /// <para>Syntactical sugar: hides a closure and increments the value passed to each item.</para>
        /// <para>eg, list.Each((n, i) => n.Num = i, 2) means that myList first item Num is set to 2, the next item Num is set to 3, and so forth..</para>
        /// </summary>
        public static void Each<T>(this IEnumerable<T> items, Action<T, int> action, int seed)
        {
            var i = seed;
            foreach (var e in items) action(e, i++);
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Removes null items.</para>
        /// <para>Syntactical sugar: replaces airplanes.Where(a => a != null &amp;&amp; a.Engine != null).Count();</para>
        /// <para>with airplanes.ExcludeNulls(x => x.Engine).Count();</para>
        /// <para>If input is null, then null is returned</para>
        /// </summary>
        public static IEnumerable<TIn> ExcludeNulls<TIn, TOut>(this IEnumerable<TIn> items, Func<TIn, TOut> func)
            where TIn : class
            where TOut : class
        {
            return items == null ? null : items.Where(x => x.With(func) != null);
        }

        /// <summary>
        /// <para>Enumerable Extension.</para>
        /// <para>If any elements, then returns the primary else returns the alternate.</para>
        /// <para>Syntactical sugar: </para>
        /// <para>Combines Any() with Return().</para>
        /// <para>eg, myList.ReturnAny("exists", "empty") returns "exists" if myList has any elements, else returns "empty"</para>
        /// </summary>
        public static TOut ReturnAny<TIn, TOut>(this IEnumerable<TIn> items, TOut pri, TOut alt)
        {
            return items.ReturnAny(_ => true, pri, alt);
        }

        /// <summary>
        /// <para>Enumerable Extension.</para>
        /// <para>If function returns any elements, then returns the primary else returns the alternate.</para>
        /// <para>Syntactical sugar: </para>
        /// <para>Combines Any() with Return().</para>
        /// <para>eg, {1, 2, 3.ReturnAny(n => n == 3, 1, 2)) returns 1</para>
        /// </summary>
        public static TOut ReturnAny<TIn, TOut>(this IEnumerable<TIn> items, Func<TIn, bool> func, TOut pri, TOut alt)
        {
            return items == null ? alt : items.Any(func).Return(pri, alt);
        }

        /// <summary>
        /// <para>Enumerable Extension.</para>
        /// <para>If any elements, then executes the primary action else executes the alternate action.</para>
        /// <para>Syntactical sugar: </para>
        /// <para>Combines Any() with Then() and Else().</para>
        /// <para>eg, {1, 2, 3}.IfAny(() => result = 1, () => result = 2) sets result to 1, if an empty list then result is set to 2</para>
        /// </summary>
        public static void IfAny<T>(this IEnumerable<T> items, Action pri, Action alt)
        {
            items.IfAny(_ => true, pri, alt);
        }

        /// <summary>
        /// <para>Enumerable Extension.</para>
        /// <para>If function any elements, then executes the primary action else executes the alternate action.</para>
        /// <para>Syntactical sugar: </para>
        /// <para>Combines Any() with Then() and Else().</para>
        /// <para>eg, {1, 2, 3}.IfAny(n => n == 3, () => result = 1, () => result = 2) sets result to 1 if there is a 3 in the list, if not, then the result is set to 2</para>
        /// </summary>
        public static void IfAny<T>(this IEnumerable<T> items, Func<T, bool> func, Action pri, Action alt)
        {
            if (items == null) alt();
            else items.Any(func).Then(pri).Else(alt);
        }

        /// <summary>
        /// <para>Enumerable Extension.</para>
        /// <para>Hides null check</para>
        /// <para>Use when progress update to action is required.</para>
        /// <para>eg, IEnumerable.WithProgress(action) means that action will be executed for each items in turn, being passed the progress percentage * 100</para>
        /// </summary>
        public static IEnumerable<T> WithProgress<T>(this IEnumerable<T> items, Action<int> progress)
        {
            if (items == null) return new List<T>();

            var collection = items as ICollection<T> ?? new List<T>(items);
            return collection.WithProgress(collection.Count, progress);
        }

        private static IEnumerable<T> WithProgress<T>(this IEnumerable<T> items, long count, Action<int> action)
        {
            var completed = 0;
            foreach (var item in items)
            {
                yield return item;

                completed++;
                action((int) (((double) completed/count)*100));
            }
        }

        /// <summary>
        /// <para>Enumerable Extension.</para>
        /// <para>Allows enumeration to be truncated.</para>
        /// <para>Use to cancel an enumeration in progress</para>
        /// <para>eg, 1.To(100).AsCancelable(shouldCancel) means that the enumeration will be stopped when shouldCancel returns true, the progress % being passed to the shouldCancel Func</para>
        /// </summary>
        public static IEnumerable<T> AsCancelable<T>(this IEnumerable<T> items, Func<int, bool> shouldCancel)
        {
            // make sure we can find out how many elements are in the items;
            // buffer the entire items
            var collection = items as ICollection<T> ?? new List<T>(items);

            long total = collection.Count;
            return collection.AsCancelable(total, shouldCancel);
        }

        private static IEnumerable<T> AsCancelable<T>(this IEnumerable<T> items, long itemCount, Func<int, bool> shouldCancel)
        {
            long completed = 0;

            foreach (var item in items)
            {
                yield return item;

                completed++;
                if (shouldCancel((int) (((double) completed/itemCount)*100)))
                {
                    yield break;
                }
            }
        }

        /// <summary>
        /// <para>Enumerable Extension.</para>
        /// <para>Runs a list of actions.</para>
        /// <para>Useful to execute a list of actions in a single statement.</para>
        /// <para>eg, myActions.Run(), replaces myActions.ToList().ForEach(a => a())</para>
        /// </summary>
        public static void Run(this IEnumerable<Action> actions)
        {
            actions.ToList().ForEach(a => a());
        }

        /// <summary>
        /// <para>Enumerable Extension.</para>
        /// <para>Creates a list by executing a func over an items.</para>
        /// <para>Syntactical sugar: replaces multiple code lines with one;</para>
        /// <para>eg, 3 lines: var newInts = new List&lt;T&gt;(); myList.ForEach(i => newInts.Add(i*10)); return newInts;</para>
        /// <para>is replaced with 1 line: return myList.CreateListFrom(i => i*10);</para>
        /// </summary>
        public static List<TOut> CreateListFrom<TIn, TOut>(this IEnumerable<TIn> items, Func<TIn, TOut> func)
        {
            return items.Select(func).ToList();
        }
    }
}