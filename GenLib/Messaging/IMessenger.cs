using System;

namespace GenLib.Messaging
{
    public interface IMessenger : IObservable<IMessage>
    {
        void Send(IMessage message);
    }
}