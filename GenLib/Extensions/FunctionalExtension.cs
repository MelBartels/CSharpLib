﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GenLib.Extensions
{
    public static class FunctionalExtension
    {
        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Returns the evaluation of the function.</para>
        /// <para>Useful to move about in the hierarchy,</para>
        /// <para>eg, airplane.WithValue(a => a.Engine) returns Engine,</para>
        /// <para>and, airplane.WithValue(a => "123") returns "123"</para>
        /// </summary>
        public static TOut WithValue<TIn, TOut>(this TIn o, Func<TIn, TOut> func) where TIn : class
        {
            return func(o);
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Returns the evaluation of the function unless the input is null, in which case null is returned.</para>
        /// <para>Useful to move about in the hierarchy and not worry about nulls,</para>
        /// <para>eg, airplane.With(a => airplane).With(a => a.Engine) returns Engine even if airplane is null</para>
        /// </summary>
        public static TOut With<TIn, TOut>(this TIn o, Func<TIn, TOut> func) where TIn : class where TOut : class
        {
            return o == null ? null : func(o);
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Add the item if not already added.</para>
        /// <para>eg, myList.AddIfNotContains(x) adds x to myList only if myList doesn't contain x</para>
        /// </summary>
        public static List<T> AddIfNotContains<T>(this List<T> items, T item)
        {
            if (items == null) return null;
            if (items.Contains(item)) return items;
            items.Add(item);
            return items;
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Executes the first Action unless the input is null or false. Input can also be in function form.</para>
        /// <para>Useful to branch based on a conditional, staying in the functional realm.</para>
        /// <para>There are three forms:</para>
        /// <para>1. a.Engine).Branch(_ => hasEngine = "yes", () => hasEngine = "no") sets hasEngine to "yes" if the engine exists; if engine is null then hasEngine is set to "no"</para>
        /// <para>2. a.Engine).HasFuel.Branch(() => hasFuel = "yes", () => hasFuel = "no") sets hasFuel to "yes" if HasFuel is true, otherwise hasFuel is set to "no"</para>
        /// <para>3. a.Engine).Branch(e => e.HasFuel, _ => hasFuel = "yes", _ => hasFuel = "no") sets hasFuel to "yes" if the function e.HasFuel is true, otherwise hasFuel is set to "no"</para>
        /// </summary>
        public static void Branch<T>(this T o, Action<T> pri, Action alt) where T : class
        {
            if (o == null) alt(); else pri(o);
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Executes the first Action unless the input is null or false. Input can also be in function form.</para>
        /// <para>Useful to branch based on a conditional, staying in the functional realm.</para>
        /// <para>There are three forms:</para>
        /// <para>1. a.Engine).Branch(_ => hasEngine = "yes", () => hasEngine = "no") sets hasEngine to "yes" if the engine exists; if engine is null then hasEngine is set to "no"</para>
        /// <para>2. a.Engine).HasFuel.Branch(() => hasFuel = "yes", () => hasFuel = "no") sets hasFuel to "yes" if HasFuel is true, otherwise hasFuel is set to "no"</para>
        /// <para>3. a.Engine).Branch(e => e.HasFuel, _ => hasFuel = "yes", _ => hasFuel = "no") sets hasFuel to "yes" if the function e.HasFuel is true, otherwise hasFuel is set to "no"</para>
        /// </summary>
        public static void Branch(this bool o, Action pri, Action alt)
        {
            if (o) pri(); else alt();
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Executes the first Action unless the input is null or false. Input can also be in function form.</para>
        /// <para>Useful to branch based on a conditional, staying in the functional realm.</para>
        /// <para>There are three forms:</para>
        /// <para>1. a.Engine).Branch(_ => hasEngine = "yes", () => hasEngine = "no") sets hasEngine to "yes" if the engine exists; if engine is null then hasEngine is set to "no"</para>
        /// <para>2. a.Engine).HasFuel.Branch(() => hasFuel = "yes", () => hasFuel = "no") sets hasFuel to "yes" if HasFuel is true, otherwise hasFuel is set to "no"</para>
        /// <para>3. a.Engine).Branch(e => e.HasFuel, _ => hasFuel = "yes", _ => hasFuel = "no") sets hasFuel to "yes" if the function e.HasFuel is true, otherwise hasFuel is set to "no"</para>
        /// </summary>
        public static void Branch<T>(this T o, Func<T, bool> func, Action<T> pri, Action<T> alt) where T : class
        {
            if (func(o)) pri(o); else alt(o);
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Returns the first evaluation unless the input is null, if input is null then the alternative evaluation is returned.</para>
        /// <para>Alternatively returns the first evaluation if the input is true, else the alternative evaluation is returned.</para>
        /// <para>Useful to avoid nesting and branching, staying in the functional realm. Also useful to select between two functions without executing either, then execute the selected function, returning the results</para>
        /// <para>There are five forms:</para>
        /// <para>1. engine.Return(e => e.FuelType, "no fuel") returns FuelType unless engine or FuelType is null, then "no fuel" is returned</para>
        /// <para>2. engine.Return(e => funcHas, funcMissing)("123") where the appropriate function is first selected based on the results of funcHas, then the selected function returns a value using the passed on parameter "123"</para>
        /// <para>3. engine.Return(e => e.FuelType, () => DefaultFuelType) returns FuelType unless engine or FuelType is null, then DefaultFuelType is executed and its results returned</para>
        /// <para>4. engine.HasFuel.Return("123", string.Empty) returns "123" if engine has fuel, otherwise returns string.empty</para>
        /// <para>5. engine.HasFuel.Return(() => "123", () => string.Empty) returns "123" if engine has fuel, otherwise returns string.empty</para>
        /// </summary>
        public static TOut Return<TIn, TOut>(this TIn o, Func<TIn, TOut> pri, TOut alt) where TIn : class
        {
            return o == null ? alt : pri(o);
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Returns the first evaluation unless the input is null, if input is null then the alternative evaluation is returned.</para>
        /// <para>Alternatively returns the first evaluation if the input is true, else the alternative evaluation is returned.</para>
        /// <para>Useful to avoid nesting and branching, staying in the functional realm. Also useful to select between two functions without executing either, then execute the selected function, returning the results</para>
        /// <para>There are five forms:</para>
        /// <para>1. engine.Return(e => e.FuelType, "no fuel") returns FuelType unless engine or FuelType is null, then "no fuel" is returned</para>
        /// <para>2. engine.Return(e => funcHas, funcMissing)("123") where the appropriate function is first selected based on the results of funcHas, then the selected function returns a value using the passed on parameter "123"</para>
        /// <para>3. engine.Return(e => e.FuelType, () => DefaultFuelType) returns FuelType unless engine or FuelType is null, then DefaultFuelType is executed and its results returned</para>
        /// <para>4. engine.HasFuel.Return("123", string.Empty) returns "123" if engine has fuel, otherwise returns string.empty</para>
        /// <para>5. engine.HasFuel.Return(() => "123", () => string.Empty) returns "123" if engine has fuel, otherwise returns string.empty</para>
        /// </summary>
        public static TOut Return<TIn, TOut>(this TIn o, Func<TIn, TOut> pri, Func<TOut> alt) where TIn : class
        {
            return o == null ? alt() : pri(o);
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Returns the first evaluation unless the input is null, if input is null then the alternative evaluation is returned.</para>
        /// <para>Alternatively returns the first evaluation if the input is true, else the alternative evaluation is returned.</para>
        /// <para>Useful to avoid nesting and branching, staying in the functional realm. Also useful to select between two functions without executing either, then execute the selected function, returning the results</para>
        /// <para>There are five forms:</para>
        /// <para>1. engine.Return(e => e.FuelType, "no fuel") returns FuelType unless engine or FuelType is null, then "no fuel" is returned</para>
        /// <para>2. engine.Return(e => funcHas, funcMissing)("123") where the appropriate function is first selected based on the results of funcHas, then the selected function returns a value using the passed on parameter "123"</para>
        /// <para>3. engine.Return(e => e.FuelType, () => DefaultFuelType) returns FuelType unless engine or FuelType is null, then DefaultFuelType is executed and its results returned</para>
        /// <para>4. engine.HasFuel.Return("123", string.Empty) returns "123" if engine has fuel, otherwise returns string.empty</para>
        /// <para>5. engine.HasFuel.Return(() => "123", () => string.Empty) returns "123" if engine has fuel, otherwise returns string.empty</para>
        /// </summary>
        public static T Return<T>(this bool o, T pri, T alt)
        {
            return o ? pri : alt;
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Returns the first evaluation unless the input is null, if input is null then the alternative evaluation is returned.</para>
        /// <para>Alternatively returns the first evaluation if the input is true, else the alternative evaluation is returned.</para>
        /// <para>Useful to avoid nesting and branching, staying in the functional realm. Also useful to select between two functions without executing either, then execute the selected function, returning the results</para>
        /// <para>There are five forms:</para>
        /// <para>1. engine.Return(e => e.FuelType, "no fuel") returns FuelType unless engine or FuelType is null, then "no fuel" is returned</para>
        /// <para>2. engine.Return(e => funcHas, funcMissing)("123") where the appropriate function is first selected based on the results of funcHas, then the selected function returns a value using the passed on parameter "123"</para>
        /// <para>3. engine.Return(e => e.FuelType, () => DefaultFuelType) returns FuelType unless engine or FuelType is null, then DefaultFuelType is executed and its results returned</para>
        /// <para>4. engine.HasFuel.Return("123", string.Empty) returns "123" if engine has fuel, otherwise returns string.empty</para>
        /// <para>5. engine.HasFuel.Return(() => "123", () => string.Empty) returns "123" if engine has fuel, otherwise returns string.empty</para>
        /// </summary>
        public static T Return<T>(this bool o, Func<T> pri, Func<T> alt)
        {
            return o ? pri() : alt();
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Evaluate the expression: if true return the input else return null; if input is null then returns null</para>
        /// <para>Useful to execute an action if condition is true, staying in the functional realm.</para>
        /// <para>eg, engine.If(x => x.HasFuel).Return(x => "flying", "crashing"));</para>
        /// </summary>
        public static T If<T>(this T o, Func<T, bool> func) where T : class
        {
            if (o == null) return null;
            return func(o) ? o : null;
        }
       
        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>If the expression is null, then return the input, else return null.</para>
        /// <para>Wraps null result of an expression so that functional chain continues.</para>
        /// <para>eg, airplane.IfNull(x => x.Engine).Return(x => "missing engine", "has engine") means that if the engine is null, 
        /// then airplane is sent to the Return() where "missing engine" is returned, 
        /// else if the engine is not null, null is sent to Return() where "has engine" is returned"</para>
        /// </summary>
        public static TIn IfNull<TIn, TOut>(this TIn o, Func<TIn, TOut> func) where TIn : class where TOut : class
        {
            return func(o) == null ? o : null;
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Combines If with Return.</para>
        /// <para>Useful when the return varies based on a branch.</para>
        /// <para>Supports the various forms of Return where input is null/not null. Forms of return that are based on a bool do not need this combination function. A null for the conditional results in the alternative evaluation being returned.</para>
        /// <para>1. airplane.IfReturn(a => a.Engine.HasFuel, a => a.Engine.FuelType, string.Empty)</para>
        /// <para>2. engine.IfReturn(e => e.HasFuel, e => funcHas, funcMissing)("123") where the appropriate function is first selected based on if the engine has fuel, then the selected function returns a value using the passed on parameter "123"</para>
        /// <para>3. airplane.IfReturn(a => a.Engine.HasFuel, a => a.Engine.FuelType, () => string.Empty)</para>
        /// </summary>
        public static TOut IfReturn<TIn, TOut>(this TIn o, Func<TIn, bool> func, Func<TIn, TOut> pri, TOut alt) where TIn : class
        {
            return o == null ? alt : func(o) ? o.Return(pri, alt) : alt;
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Combines If with Return.</para>
        /// <para>Useful when the return varies based on a branch.</para>
        /// <para>Supports the various forms of Return where input is null/not null. Forms of return that are based on a bool do not need this combination function. A null for the conditional results in the alternative evaluation being returned.</para>
        /// <para>1. airplane.IfReturn(a => a.Engine.HasFuel, a => a.Engine.FuelType, string.Empty)</para>
        /// <para>2. engine.IfReturn(e => e.HasFuel, e => funcHas, funcMissing)("123") where the appropriate function is first selected based on if the engine has fuel, then the selected function returns a value using the passed on parameter "123"</para>
        /// <para>3. airplane.IfReturn(a => a.Engine.HasFuel, a => a.Engine.FuelType, () => string.Empty)</para>
        /// </summary>
        public static TOut IfReturn<TIn, TOut>(this TIn o, Func<TIn, bool> func, Func<TIn, TOut> pri, Func<TOut> alt) where TIn : class
        {
            return o == null ? alt() : func(o) ? o.Return(pri, alt) : alt();
        }
       
        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>If true, then executes the action, returning the input.</para>
        /// <para>Useful to execute an action if condition is true, staying in the functional realm.</para>
        /// <para>eg, engine.HasFuel.Then(() => engine.FuelType = "123")</para>
        /// </summary>
        public static bool Then(this bool o, Action action)
        {
            if (o) action();
            return o;
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>If false, then executes the action, returning the input.</para>
        /// <para>Useful to execute an action if condition is false, staying in the functional realm.</para>
        /// <para>eg, engine.HasFuel.Else(() => engine.FuelType = "none")</para>
        /// </summary>
        public static bool Else(this bool o, Action action)
        {
            if (!o) action();
            return o;
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>If input is null , then execute the action returning the input (which may be null).</para>
        /// <para>Useful to execute an action if input is null, staying in the functional realm.</para>
        /// <para>eg, plane.DoWhenNull(() => plane = new Airplane()) returns a new Airplane if plane is null, otherwise returns plane</para>
        /// </summary>
        public static T DoWhenNull<T>(this T o, Action action) where T : class
        {
            if (o == null)
                action();
            return o;
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Execute the function and return the input unless the input is true</para>
        /// <para>"Unless you are married, you can date"</para>
        /// <para>eg, engine.Unless(x => x.HasFuel).Return(x => "crashing", "flying")) means that unless it has fuel it's crashing</para>
        /// </summary>
        public static T Unless<T>(this T o, Func<T, bool> func) where T : class
        {
            if (o == null) return null;
            return func(o) ? null : o;
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Execute the function unless input is null</para>
        /// <para>Useful to call an action and not worry if the input is null</para>
        /// <para>eg, engine.Do(FillupAndTestFuelGrade()) executes the method unless engine is null</para>
        /// </summary>
        public static T Do<T>(this T o, Action<T> action) where T : class
        {
            if (o != null)
                action(o);
            return o;
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Invoke the Action unless input is null</para>
        /// <para>Useful to execute an action without worrying if the action is null</para>
        /// <para>eg, container.With(c => c.Action).DoAction(); instead of container.With(c => c.Action).Do(a => a.Invoke()); or container.With(c => c.Action)();</para>
        /// </summary>
        public static Action DoAction(this Action o)
        {
            if (o != null)
                o.Invoke();
            return o;
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Invoke the Action unless input is null</para>
        /// <para>Useful to execute an action without worrying if the action is null</para>
        /// <para>eg, container.With(c => c.Action).DoAction(parm); instead of container.With(c => c.Action).Do(a => a.Invoke(parm)); or container.With(c => c.Action)(parm);</para>
        /// </summary>
        public static Action<T> DoAction<T>(this Action<T> o, T t)
        {
            if (o != null)
                o.Invoke(t);
            return o;
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Wraps the input in an 'using' statement then executions the function and returns the results</para>
        /// <para>Useful to call a function and not worry if the input is null</para>
        /// <para>eg, contents = new StreamReader(ms).Using(f => f.ReadToEnd())</para>
        /// </summary>
        public static TOut Using<TIn, TOut>(this TIn disposable, Func<TIn, TOut> func) where TIn : IDisposable
        {
            using (disposable)
            {
                return func(disposable);
            }
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Wraps the input in an 'using' statement then executions the action (no return)</para>
        /// <para>Useful to call a function and not worry if the input is null</para>
        /// <para>eg, new StreamReader(ms).Using(f => f.Close())</para>
        /// </summary>
        public static void Using<T>(this T disposable, Action<T> action) where T : IDisposable
        {
            using (disposable)
            {
                action(disposable);
            }
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Returns a safe cast</para>
        /// <para>Syntactical sugar: </para>
        /// <para>eg, airplane.CastSafe&lt;IAirplane&gt;() replaces var myPlane = airplane as IAirplane</para>
        /// </summary>
        public static T CastSafe<T>(this object before) where T : class
        {
            return before as T;
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Copies property values from an object of same type</para>
        /// <para>Properties must have public getter/setters</para>
        /// <para>Syntactical sugar: </para>
        /// <para>eg, MyObject.SetPropertiesFrom(SomeOtherObject)</para>
        /// </summary>
        public static T SetPropertiesFrom<T>(this T to, T from)
        {
            to
                .GetType()
                .GetProperties()
                .ExcludeNulls(pi => pi.GetGetMethod())
                .ExcludeNulls(pi => pi.GetSetMethod())
                .ToList()
                // get values from 'to', using them to set 'from' values
                .ForEach(pi => pi.SetValue(to, pi.GetValue(from, null), null));
            return to;
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Clones and returns an object of same type</para>
        /// <para>eg, return MyObject.Clone()</para>
        /// </summary>
        public static T Clone<T>(this T _) where T : class
        {
            return Activator.CreateInstance<T>();
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Clones and copies property values from an object of same type</para>
        /// <para>Properties must have public getter/setters</para>
        /// <para>Syntactical sugar: </para>
        /// <para>eg, MyObject.CloneAndSetPropertyValuesFrom(SomeOtherObject)</para>
        /// </summary>
        public static T CloneAndSetPropertiesFrom<T>(this T from) where T : class
        {
            return from.Clone().SetPropertiesFrom(from);
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Hides procedural foreach IEnumerable of Actions</para>
        /// <para>Syntactical sugar: </para>
        /// <para>eg, 5.Each().ForEach(x => count++), and, 1.To(101.ForEach(x => ...)</para>
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Creates an IEnumerable ranging from 1 to the input value</para>
        /// <para>Syntactical sugar: </para>
        /// <para>eg, 5.Each() creates an enumeration of integers from 1 to 5</para>
        /// </summary>
        public static IEnumerable<int> Each(this int i)
        {
            return Enumerable.Range(1, i);
        }

        /// <summary>
        /// <para>Functional Extension.</para>
        /// <para>Creates an IEnumerable ranging from begin to end</para>
        /// <para>Syntactical sugar: </para>
        /// <para>eg, (-1).To(9) creates an enumeration of integers from -1 to 9 with 11 values; (1).To(-9) also creates 11 values but in reverse</para>
        /// </summary>
        public static IEnumerable<int> To(this int begin, int end)
        {
            return end >= begin
                       ? Enumerable.Range(begin, end - begin + 1)
                       : Enumerable.Range(end, begin - end + 1).OrderBy(i => -i);
        }
    }
}