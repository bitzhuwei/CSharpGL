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

        event MouseEventHandler IGLCanvas.MouseDown
        {
            add { this.MouseDown += value; }
            remove { this.MouseDown -= value; }
        }

        event MouseEventHandler IGLCanvas.MouseMove
        {
            add { this.MouseMove += value; }
            remove { this.MouseMove -= value; }
        }

        event MouseEventHandler IGLCanvas.MouseUp
        {
            add { this.MouseUp += value; }
            remove { this.MouseUp -= value; }
        }

        event MouseEventHandler IGLCanvas.MouseWheel
        {
            add { this.MouseWheel += value; }
            remove { this.MouseWheel -= value; }
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