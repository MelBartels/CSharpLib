using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GenLib.Helper;

namespace GenLib.View
{
    public class ResizeComponentProportionalStrategy
    {
        public ResizeComponentProportionalStrategy() : this(new EMath())
        {
        }

        public ResizeComponentProportionalStrategy(EMath eMath)
        {
            EMath = eMath;
            ListControlResizeParms = new List<ControlResizeParms>();
        }

        private EMath EMath { get; set; }
        private int FormWidth { get; set; }
        private int FormHeight { get; set; }
        private List<ControlResizeParms> ListControlResizeParms { get; set; }

        public void StoreFormParms(int width, int height)
        {
            FormWidth = width;
            FormHeight = height;
        }

        public void AddControl(Control control)
        {
            ListControlResizeParms.Add(new ControlResizeParms
                                           {
                                               Location = new Point(control.Location.X, control.Location.Y),
                                               Size = new Size(control.Size.Width, control.Size.Height),
                                               Control = control
                                           }
                );
        }

        public void Resize(int width, int height)
        {
            var widthRatio = (double) width/FormWidth;
            var heightRatio = (double) height/FormHeight;
            ListControlResizeParms.ForEach(crp => ResizeControl(crp, widthRatio, heightRatio));
        }

        private void ResizeControl(ControlResizeParms crp, double widthRatio, double heightRatio)
        {
            crp.Control.Location = new Point(EMath.RInt(crp.Location.X*widthRatio), EMath.RInt(crp.Location.Y*heightRatio));
            crp.Control.Size = new Size(EMath.RInt(crp.Size.Width*widthRatio), EMath.RInt(crp.Size.Height*heightRatio));
        }

        #region Nested type: ControlResizeParms

        private class ControlResizeParms
        {
            public Point Location { get; set; }
            public Size Size { get; set; }
            public Control Control { get; set; }
        }

        #endregion
    }
}