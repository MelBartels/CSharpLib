using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace GenLib.View
{
    public class ResizeComponentBorderStrategy
    {
        private Hashtable Borders { get; set; }

        public void SetBorders(Control control, int width, int height)
        {
            Borders = new Hashtable
                          {
                              {"left", control.Location.X},
                              {"top", control.Location.Y},
                              {"right", width - control.Width - control.Location.X},
                              {"bottom", height - control.Height - control.Location.Y},
                          };
        }

        public void Resize(Control control, int width, int height)
        {
            var newWidth = ValidateComponentSize(width - (int) Borders["left"] - (int) Borders["right"]);
            var newHeight = ValidateComponentSize(height - (int) Borders["top"] - (int) Borders["bottom"]);
            control.Location = new Point((int) Borders["left"], (int) Borders["top"]);
            control.Size = new Size(newWidth, newHeight);
        }

        public static int ValidateComponentSize(int size)
        {
            return size < 1 ? 1 : size;
        }
    }
}