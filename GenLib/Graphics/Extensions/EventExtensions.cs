using System;

namespace Atlas.Extensions
{
    public static class EventExtensions
    {
        /// <summary>
        /// <para>Event Extension.</para>
        /// <para>Hides null check</para>
        /// <para>Syntactical sugar: </para>
        /// <para>eg, myEvent.Raise() as opposed to if (myEvent != null) myEvent()</para>
        /// </summary>
        public static void Raise<T>(this EventHandler<T> handler, object sender, T args) where T : EventArgs
        {
            if (handler != null) handler(sender, args);
        }

        /// <summary>
        /// <para>Event Extension.</para>
        /// <para>Hides null check</para>
        /// <para>Syntactical sugar: </para>
        /// <para>eg, myEvent.Raise() as opposed to if (myEvent != null) myEvent()</para>
        /// </summary>
        public static void Raise(this EventHandler handler, object sender, EventArgs args)
        {
            if (handler != null) handler(sender, args);
        }

        /// <summary>
        /// <para>Event Extension.</para>
        /// <para>Hides null check</para>
        /// <para>Syntactical sugar: </para>
        /// <para>eg, myEvent.Raise() as opposed to if (myEvent != null) myEvent()</para>
        /// </summary>
        public static void Raise(this EventHandler handler)
        {
            if (handler != null) handler(new object(), EventArgs.Empty);
        }
    }
}