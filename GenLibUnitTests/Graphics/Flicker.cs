using System;
using System.Drawing;
using System.Threading;
using GenLib.Graphics;
using GenLib.View;
using Xunit;

namespace GenLibUnitTests.Graphics
{
    public class Flicker
    {
        private TestForm TestForm { get; set; }

        private void ShowTestForm()
        {
            TestForm = new TestForm
                           {
                               UserCtrl =
                                   {
                                       Renderer = new FlickerRenderer()
                                   }
                           };
            TestForm.ShowDialog();
        }

        [Fact]
        public void TestFlicker()
        {
            new Thread(ShowTestForm).Start();
            Thread.Sleep(new Pause().MilliSec);
            TestForm.Close();
        }

        #region Nested type: FlickerRenderer

        private class FlickerRenderer : IRenderer
        {
            private bool Rendering { get; set; }

            private int Count { get; set; }

            #region IRenderer Members

            public string ToolTip
            {
                get { return "tool tip activated"; }
                set { throw new NotImplementedException(); }
            }

            public object Model { get; set; }

            public void Render(System.Drawing.Graphics g, int width, int height)
            {
                if (Rendering)
                {
                    Console.WriteLine("overrunning renderer");
                    return;
                }
                Rendering = true;

                // fixup
                if (width == 0)
                    width = 1;
                if (height == 0)
                    height = 1;

                // fill graphics background every so often
                if (++Count > 5)
                {
                    Count = 0;
                    g.FillRectangle(Brushes.Black, 0, 0, width, height);
                }

                // random ellipses
                var rnd = new Random();
                for (var i = 0; i < 100; i++)
                {
                    var px = rnd.Next(0, width);
                    var py = rnd.Next(0, height);
                    g.DrawEllipse(new Pen(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)), 1),
                                  px, py, px + rnd.Next(0, width - px), py + rnd.Next(0, height - py));
                }

                g.DrawString("hello from renderer 12345687901234568790", new Font("Arial", 8), Brushes.White, 10, 10);
                Rendering = false;
            }

            #endregion
        }

        #endregion
    }
}