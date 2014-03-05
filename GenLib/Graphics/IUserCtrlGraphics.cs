namespace GenLib.Graphics
{
    public interface IUserCtrlGraphics
    {
        IRenderer Renderer { get; set; }
        void Render();
    }
}