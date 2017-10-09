using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class WinCtrlRoot : CtrlRoot
    {
        /// <summary>
        /// Gwts binding canvas.
        /// </summary>
        public WinGLCanvas BindingCanvas { get; private set; }

        private readonly System.Windows.Forms.MouseEventHandler mouseMove;
        private readonly System.Windows.Forms.MouseEventHandler mouseDown;
        private readonly System.Windows.Forms.MouseEventHandler mouseUp;
        private readonly System.Windows.Forms.KeyEventHandler keyDown;
        private readonly System.Windows.Forms.KeyEventHandler keyUp;
        private readonly System.EventHandler resize;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public WinCtrlRoot(int width, int height)
            : base(width, height)
        {
            this.mouseMove = new System.Windows.Forms.MouseEventHandler(winCanvas_MouseMove);
            this.mouseDown = new System.Windows.Forms.MouseEventHandler(winCanvas_MouseDown);
            this.mouseUp = new System.Windows.Forms.MouseEventHandler(winCanvas_MouseUp);
            this.keyDown = new System.Windows.Forms.KeyEventHandler(winCanvas_KeyDown);
            this.keyUp = new System.Windows.Forms.KeyEventHandler(winCanvas_KeyUp);
            this.resize = new EventHandler(winCanvas_Resize);

            this.EnableRendering = ThreeFlags.Children;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="canvas"></param>
        public override void Bind(IGLCanvas canvas)
        {
            var winCanvas = canvas as WinGLCanvas;
            if (winCanvas == null) { throw new ArgumentException(); }

            winCanvas.MouseMove += mouseMove;
            winCanvas.MouseDown += mouseDown;
            winCanvas.MouseUp += mouseUp;
            winCanvas.KeyDown += keyDown;
            winCanvas.KeyUp += keyUp;
            winCanvas.Resize += resize;

            this.BindingCanvas = winCanvas;
        }

        void winCanvas_Resize(object sender, EventArgs e)
        {
            var control = sender as System.Windows.Forms.Control;
            this.Width = control.Width;
            this.Height = control.Height;
        }

        void winCanvas_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
        }

        void winCanvas_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
        }

        void winCanvas_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        void winCanvas_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        void winCanvas_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Unbind()
        {
            WinGLCanvas winCanvas = this.BindingCanvas;
            if (winCanvas != null)
            {
                winCanvas.MouseMove -= mouseMove;
                winCanvas.MouseDown -= mouseDown;
                winCanvas.MouseUp -= mouseUp;
                winCanvas.KeyDown -= keyDown;
                winCanvas.KeyUp -= keyUp;

                this.BindingCanvas = null;
            }
        }

        public override void RenderBeforeChildren(GUIRenderEventArgs arg)
        {
        }

        public override void RenderAfterChildren(GUIRenderEventArgs arg)
        {
        }
    }
}
