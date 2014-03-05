using GenLib.Messaging;

namespace AstroLib.VisualDetection
{
    public class SkyBkgndBrightnessMessage : IMessage
    {
        public double Brightness{ get; set; }
    }
}