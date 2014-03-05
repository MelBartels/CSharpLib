using System;
using GenLib.Extensions;

namespace AstroLib.VisualDetection.Calculator
{
    public class CalcState
    {
        public int HighWaterMark { get; set; }
        public int LowWaterMark { private get; set; }
        public Calc BestCalc { get; set; }
        public bool DisplayConsoleMessages { get; set; }

        public void Init(bool displayConsoleMessages)
        {
            HighWaterMark = 8;
            LowWaterMark = 0;
            BestCalc = null;
            DisplayConsoleMessages = displayConsoleMessages;
        }

        public void IsVisibleReset(Calc c)
        {
            DisplayConsoleMessage("visible");
            BestCalc = c;
            HighWaterMark = (LowWaterMark + HighWaterMark)/2;
        }

        public void NotVisible()
        {
            DisplayConsoleMessage("not visible");
            LowWaterMark = HighWaterMark;
            HighWaterMark *= 2;
        }

        private void DisplayConsoleMessage(string visible)
        {
            DisplayConsoleMessages.Then(() =>
                                            {
                                                Console.Write(@"aperture low " + LowWaterMark + @", high " + HighWaterMark);
                                                Console.WriteLine(@": " + visible);
                                            });
        }
    }
}