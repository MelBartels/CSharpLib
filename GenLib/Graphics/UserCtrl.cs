using System;
using System.Drawing;
using System.Windows.Forms;
using GenLib.Extensions;

namespace GenLib.Graphics
{
    public partial class UserCtrl : UserControl, IUserCtrlGraphics
    {
        public UserCtrl()
        {
            InitializeComponent();
        }

        private BufferedGraphicsContext BufferedGraphicsContext { get; set; }
        private BufferedGraphics BufferedGraphics { get; set; }
        private bool ToolTipSet { get; set; }

        #region IUserCtrlGraphics Members

        public IRenderer Renderer { get; set; }

        public void Render()
        {
            RenderToBuffer();
            WriteBufferedGraphicsTo(CreateGraphics());
        }

        #endregion

        private void UserCtrl_Load(object sender, EventArgs e)
        {
            InitGraphics();
        }

        private void UserCtrl_Resize(object sender, EventArgs e)
        {
            // graphics context may not have been built yet, eg when resize occurs during parent's initialization
            BufferedGraphicsContext.Do(_ =>
                                           {
                                               CreateBufferGraphics();
                                               RenderToBuffer();
                                               //raises OnPaint()
                                               Refresh();
                                           });
        }

        // UserCtrl_Resize() and UserCtrl_VisibleChanged() cause OnPaint() to fire

        private void UserCtrl_VisibleChanged(object sender, EventArgs e)
        {
            //ShowDialog() raises OnPaint()
            RenderToBuffer();
        }

        private void UserCtrl_MouseEnter(object sender, EventArgs e)
        {
            SetToolTip();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            WriteBufferedGraphicsTo(e.Graphics);
        }

        // call from load: don't put in constructor because parent's load event may not fire
        private void InitGraphics()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            BufferedGraphicsContext = BufferedGraphicsManager.Current;
            CreateBufferGraphics();
        }

        // called from UserCtrl_Resize() and InitGraphics()
        private void CreateBufferGraphics()
        {
            if (Width == 0)
                Width = 1;
            if (Height == 0)
                Height = 1;

            BufferedGraphicsContext.MaximumBuffer = new Size(Width + 1, Height + 1);
            BufferedGraphics.Do(_ => ClearBufferedGraphicsInstance());
            BufferedGraphics = BufferedGraphicsContext.Allocate(CreateGraphics(), new Rectangle(0, 0, Width, Height));
        }

        // called from CreateBufferGraphics() and ultimately from UserCtrl_Resize() and InitGraphics()
        private void ClearBufferedGraphicsInstance()
        {
            BufferedGraphics.Dispose();
            BufferedGraphics = null;
        }

        // called form Render(), UserCtrl_Resize() and UserCtrl_VisibleChanged()
        private void RenderToBuffer()
        {
            Visible.Then(() => Renderer.Do(r => r.Render(BufferedGraphics.Graphics, Width, Height)));
        }

        // called from Render() and OnPaint()
        private void WriteBufferedGraphicsTo(System.Drawing.Graphics g)
        {
            BufferedGraphics.Render(g);
        }

        protected void SetToolTip()
        {
            ToolTipSet.Else(() => Renderer.With(r => r.ToolTip).Do(UpdateToolTip));
        }

        private void UpdateToolTip(string tt)
        {
            ToolTip.SetToolTip(this, tt);
            ToolTip.IsBalloon = true;
            ToolTipSet = true;
        }

        private void ProcessDispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}