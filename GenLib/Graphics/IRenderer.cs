using System;

namespace GenLib.Graphics
{
    public interface IRenderer
    {
        string ToolTip { get; set; }
        object Model { get; set; }
        void Render(System.Drawing.Graphics g, Int32 width, Int32 height);
    }
}