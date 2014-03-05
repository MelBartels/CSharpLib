using System;

namespace GenLib.Extensions
{
    public static class TupleExtension
    {
        /// <summary>
        /// <para>Tuple Extension.</para>
        /// <para>Returns a new Tuple incorporating the added item</para>
        /// <para>Syntactical sugar: </para>
        /// <para>eg, nums = 5.Combine(10) replaces nums = new Tuple&lt;int, int&gt;(5, 10)</para>
        /// </summary>
        public static Tuple<T, TAdd> Combine<TAdd, T>(this T item, TAdd addItem)
        {
            return new Tuple<T, TAdd>(item, addItem);
        }

        /// <summary>
        /// <para>Tuple Extension.</para>
        /// <para>Returns a new Tuple incorporating the evaluated function</para>
        /// <para>Syntactical sugar: </para>
        /// <para>eg, nums = 5.Combine(i => i*10) replaces nums = new Tuple&lt;int, int&gt;(5, 5*10)</para>
        /// </summary>
        public static Tuple<T, TAdd> Combine<TAdd, T>(this T item, Func<T, TAdd> add)
        {
            return new Tuple<T, TAdd>(item, add(item));
        }

        /// <summary>
        /// <para>Tuple Extension.</para>
        /// <para>Returns a new Tuple incorporating the added item</para>
        /// <para>Syntactical sugar: </para>
        /// <para>eg, var obj = 5.Combine(true).Combine("A string");</para>
        /// </summary>
        public static Tuple<T1, T2, TAdd> Combine<TAdd, T1, T2>(this Tuple<T1, T2> tuple, TAdd addItem)
        {
            return new Tuple<T1, T2, TAdd>(tuple.Item1, tuple.Item2, addItem);
        }

        /// <summary>
        /// <para>Tuple Extension.</para>
        /// <para>Returns a new Tuple incorporating the evaluated function</para>
        /// <para>Syntactical sugar: </para>
        /// <para>eg, nums = 5.Combine(i => i*10) replaces nums = new Tuple&lt;int, int&gt;(5, 5*10)</para>
        /// </summary>
        public static Tuple<T1, T2, TAdd> Combine<TAdd, T1, T2>(this Tuple<T1, T2> tuple, Func<Tuple<T1, T2>, TAdd> add)
        {
            return new Tuple<T1, T2, TAdd>(tuple.Item1, tuple.Item2, add(tuple));
        }

        /// <summary>
        /// <para>Tuple Extension.</para>
        /// <para>Returns a new Tuple incorporating the added item</para>
        /// <para>Syntactical sugar: </para>
        /// <para>eg, var obj = 5.Combine(true).Combine("A string").Combine(6.7);</para>
        /// </summary>
        public static Tuple<T1, T2, T3, TAdd> Combine<TAdd, T1, T2, T3>(this Tuple<T1, T2, T3> tuple, TAdd addItem)
        {
            return new Tuple<T1, T2, T3, TAdd>(tuple.Item1, tuple.Item2, tuple.Item3, addItem);
        }

        /// <summary>
        /// <para>Tuple Extension.</para>
        /// <para>Returns a new Tuple incorporating the evaluated function</para>
        /// <para>Syntactical sugar: </para>
        /// <para>eg, nums = 5.Combine(i => i*10) replaces nums = new Tuple&lt;int, int&gt;(5, 5*10)</para>
        /// </summary>
        public static Tuple<T1, T2, T3, TAdd> Combine<TAdd, T1, T2, T3>(this Tuple<T1, T2, T3> tuple,
                                                                        Func<Tuple<T1, T2, T3>, TAdd> add)
        {
            return new Tuple<T1, T2, T3, TAdd>(tuple.Item1, tuple.Item2, tuple.Item3, add(tuple));
        }
    }
}