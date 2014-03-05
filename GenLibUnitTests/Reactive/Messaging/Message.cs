using System;
using System.Linq;
using System.Text;
using GenLib.Messaging;
using Xunit;

namespace GenLibUnitTests.Reactive.Messaging
{
    public class Message
    {
        [Fact]
        public void Scratch()
        {
            var sb = new StringBuilder();

            const string helloMsg = "hello";
            const string goodbyeMsg = "goodbye";

            Messenger.Instance()
                .OfType<FooMsg>()
                .Where(dm => dm.Message == helloMsg)
                .Subscribe(m => sb.Append(m.Message));

            Messenger.Instance().Send(new FooMsg {Message = helloMsg});
            Messenger.Instance().Send(new FooMsg {Message = goodbyeMsg});
            Messenger.Instance().Send(new Foo2Msg {Message = helloMsg});
            Assert.Equal(helloMsg, sb.ToString());

            Assert.True(true);
        }
    }

    public class FooMsg : IMessage
    {
        public string Message { get; set; }
    }

    public class Foo2Msg : IMessage
    {
        public string Message { get; set; }
    }
}