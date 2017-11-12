using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL
{
    // IGLCanvas
    public partial class WinGLCanvas
    {

        //#region IGLCanvas 成员

        ///// <summary>
        ///// repaint this canvas' content.
        ///// </summary>
        //public void Repaint()
        //{
        //    this.Invalidate();
        //}

        //[Category(strWinGLCanvas)]
        //[Description("OpenGL Render Context.")]
        //public GLRenderContext RenderContext { get; private set; }

        //#endregion
        int IGLCanvas.Width
        {
            get { return this.Width; }
            set { this.Width = value; }
        }

        int IGLCanvas.Height
        {
            get { return this.Height; }
            set { this.Height = value; }
        }

        //Rectangle IGLCanvas.ClientRectangle
        //{
        //get { return this.ClientRectangle; }
        //}

        void IGLCanvas.Repaint()
        {
            this.Invalidate();
        }

        private GLRenderContext renderContext;
        GLRenderContext IGLCanvas.RenderContext { get { return this.renderContext; } }

        event KeyPressEventHandler IGLCanvas.KeyPress
        {
            add { this.KeyPress += value; }
            remove { this.KeyPress -= value; }
        }

        private event GLEventHandler<GLMouseEventArgs> glMouseDown;
        event GLEventHandler<GLMouseEventArgs> IGLCanvas.MouseDown
        {
            add { this.glMouseDown += value; }
            remove { this.glMouseDown -= value; }
        }
        private event GLEventHandler<GLMouseEventArgs> glMouseMove;
        event GLEventHandler<GLMouseEventArgs> IGLCanvas.MouseMove
        {
            add { this.glMouseMove += value; }
            remove { this.glMouseMove -= value; }
        }

        private event GLEventHandler<GLMouseEventArgs> glMouseUp;
        event GLEventHandler<GLMouseEventArgs> IGLCanvas.MouseUp
        {
            add { this.glMouseUp += value; }
            remove { this.glMouseUp -= value; }
        }

        private event GLEventHandler<GLMouseEventArgs> glMouseWheel;
        event GLEventHandler<GLMouseEventArgs> IGLCanvas.MouseWheel
        {
            add { this.glMouseWheel += value; }
            remove { this.glMouseWheel -= value; }
        }

        private event GLEventHandler<GLKeyEventArgs> glKeyDown;
        event GLEventHandler<GLKeyEventArgs> IGLCanvas.KeyDown
        {
            add { this.glKeyDown += value; }
            remove { this.glKeyDown -= value; }
        }

        private event GLEventHandler<GLKeyEventArgs> glKeyUp;
        event GLEventHandler<GLKeyEventArgs> IGLCanvas.KeyUp
        {
            add { this.glKeyUp += value; }
            remove { this.glKeyUp -= value; }
        }

        event EventHandler IGLCanvas.Resize
        {
            add { this.Resize += value; }
            remove { this.Resize -= value; }
        }

        bool IGLCanvas.IsDisposed
        {
            get { return this.IsDisposed; }
        }
    }
}