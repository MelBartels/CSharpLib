using GenLib.Messaging;

namespace AstroLib.ObjectLibrary.SAC
{
    public class RecordMessage : IMessage
    {
        public DisplayRecord DisplayRecord { get; set; }
    }
}