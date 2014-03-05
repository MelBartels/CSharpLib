using System.Drawing;
using System.Drawing.Drawing2D;

namespace GenLib.View
{
    public class LinearGradientBrushBuilder
    {
        public LinearGradientBrushBuilder()
        {
            ColorChange = 64;
        }

        public int ColorChange { get; set; }

        public LinearGradientBrush GetBrush(Color color, Rectangle rectangle)
        {
            return new LinearGradientBrush(rectangle, 
                                           GetLightColor(color, ColorChange),
                                           GetDarkColor(color, ColorChange), 
                                           LinearGradientMode.ForwardDiagonal);
        }

        protected static Color GetDarkColor(Color color, int dark)
        {
            return Color.FromArgb(Darken(color.R, dark), Darken(color.G, dark), Darken(color.B, dark));
        }

        protected static Color GetLightColor(Color color, int light)
        {
            return Color.FromArgb(Lighten(color.R, light), Lighten(color.G, light), Lighten(color.B, light));
        }

        protected static int Darken(int colorComponent, int darken)
        {
            return colorComponent - darken > 0 ? colorComponent - darken : 0;
        }

        protected static int Lighten(int colorComponent, int lighten)
        {
            return colorComponent + lighten < 255 ? colorComponent + lighten : 255;
        }
    }
}