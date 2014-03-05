using System;
using System.Collections.Generic;

namespace GenLib.Messaging
{
    public class Messenger : IMessenger
    {
        private readonly Subject<IMessage> _subject = new Subject<IMessage>();

        private Messenger()
        {
        }

        #region IMessenger Members

        public IDisposable Subscribe(IObserver<IMessage> observer)
        {
            return _subject.Subscribe(observer);
        }

        public void Send(IMessage message)
        {
            _subject.OnNext(message);
        }

        #endregion

        public static Messenger Instance()
        {
            return Nested.NestedInstance;
        }

        #region Nested type: Nested

        private class Nested
        {
            internal static readonly Messenger NestedInstance = new Messenger();

            // explicit constructor informs compiler not to mark type as beforefieldinit

// ReSharper disable EmptyConstructor
            static Nested()
            {
            }

// ReSharper restore EmptyConstructor
        }

        #endregion
    }
}