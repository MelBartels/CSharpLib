using System;

namespace GenLib.Messaging
{
    public class StringMessage : IMessage
    {
        public Object Token { get; set; }
        public String Value { get; set; }
    }
}