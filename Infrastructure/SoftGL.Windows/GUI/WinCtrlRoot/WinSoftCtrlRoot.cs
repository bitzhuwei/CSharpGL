using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Root Control in CSharpGL's scene's GUI system.
    /// </summary>
    public class WinSoftCtrlRoot : CtrlRoot
    {
        /// <summary>
        /// Gets binding canvas.
        /// </summary>
        public WinSoftGLCanvas BindingCanvas { get; private set; }

        private readonly System.Windows.Forms.MouseEventHandler mouseMove;
        private readonly System.Windows.Forms.MouseEventHandler mouseDown;
        private readonly System.Windows.Forms.MouseEventHandler mouseUp;
        private readonly System.Windows.Forms.KeyEventHandler keyDown;
        private readonly System.Windows.Forms.KeyEventHandler keyUp;
        private readonly System.EventHandler resize;

        /// <summary>
        /// Root Control in CSharpGL's scene's GUI system.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public WinSoftCtrlRoot(int width, int height)
            : base(width, height)
        {
            this.mouseMove = new System.Windows.Forms.MouseEventHandler(winCanvas_MouseMove);
            this.mouseDown = new System.Windows.Forms.MouseEventHandler(winCanvas_MouseDown);
            this.mouseUp = new System.Windows.Forms.MouseEventHandler(winCanvas_MouseUp);
            this.keyDown = new System.Windows.Forms.KeyEventHandler(winCanvas_KeyDown);
            this.keyUp = new System.Windows.Forms.KeyEventHandler(winCanvas_KeyUp);
            this.resize = new EventHandler(winCanvas_Resize);

            this.EnableGUIRendering = ThreeFlags.Children;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="canvas"></param>
        public override void Bind(IGLCanvas canvas)
        {
            var winCanvas = canvas as WinSoftGLCanvas;
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
            if (this.currentControl != null)
            {
                GLKeyEventArgs args = e.Translate();
                this.currentControl.InvokeEvent(EventType.KeyUp, args);
            }
        }

        void winCanvas_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (this.currentControl != null)
            {
                GLKeyEventArgs args = e.Translate();
                this.currentControl.InvokeEvent(EventType.KeyDown, args);
            }
        }

        private GLControl currentControl;

        void winCanvas_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.currentControl != null)
            {
                GLMouseEventArgs args = e.Translate();
                this.currentControl.InvokeEvent(EventType.MouseUp, args);
            }
        }

        void winCanvas_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int x = e.X, y = this.BindingCanvas.Height - e.Y - 1;
            GLControl control = GetControlAt(x, y, this);
            this.currentControl = control;
            if (control != null)
            {
                GLMouseEventArgs args = e.Translate();
                control.InvokeEvent(EventType.MouseDown, args);
            }
        }

        /// <summary>
        /// Get the control at specified position.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private GLControl GetControlAt(int x, int y, GLControl control)
        {
            GLControl result = null;
            if (control.ContainsPoint(x, y))
            {
                if (control.AcceptPicking)
                {
                    result = control;
                }

                foreach (var item in control.Children)
                {
                    GLControl child = GetControlAt(x, y, item);
                    if (child != null)
                    {
                        result = child;
                        break;
                    }
                }
            }

            return result;
        }

        void winCanvas_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.currentControl != null)
            {
                GLMouseEventArgs args = e.Translate();
                this.currentControl.InvokeEvent(EventType.MouseMove, args);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Unbind()
        {
            WinSoftGLCanvas winCanvas = this.BindingCanvas;
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

        public override void RenderGUIBeforeChildren(GUIRenderEventArgs arg)
        {
        }

        public override void RenderGUIAfterChildren(GUIRenderEventArgs arg)
        {
        }
    }
}
