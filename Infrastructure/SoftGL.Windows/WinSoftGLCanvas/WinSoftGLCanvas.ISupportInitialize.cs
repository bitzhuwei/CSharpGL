using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL
{

    public partial class WinSoftGLCanvas
    {
        #region ISupportInitialize 成员

        void ISupportInitialize.BeginInit()
        {
        }

        void ISupportInitialize.EndInit()
        {
            try
            {
                int width = this.Width, height = this.Height;

                if (this.designMode)
                {
                    //this.assist.Resize(width, height);
                }
                else
                {
                    this.KeyPress += WinSoftGLCanvas_KeyPress;
                    this.MouseDown += WinSoftGLCanvas_MouseDown;
                    this.MouseMove += WinSoftGLCanvas_MouseMove;
                    this.MouseUp += WinSoftGLCanvas_MouseUp;
                    this.MouseWheel += WinSoftGLCanvas_MouseWheel;
                    this.KeyDown += WinSoftGLCanvas_KeyDown;
                    this.KeyUp += WinSoftGLCanvas_KeyUp;
                }

                // Create the render context.
                ContextGenerationParams parameters = null;
                if (this.designMode)
                {
                    parameters = new ContextGenerationParams();
                    parameters.UpdateContextVersion = false;
                }
                else
                {
                    parameters = this.parameters;
                }
                var renderContext = new SoftGLRenderContext(width, height, parameters);
                renderContext.MakeCurrent();
                this.renderContext = renderContext;

                // Set the most basic OpenGL styles.
                GL.Instance.ShadeModel(GL.GL_SMOOTH);
                GL.Instance.ClearDepth(1.0f);
                GL.Instance.Enable(GL.GL_DEPTH_TEST);// depth test is disabled by default.
                GL.Instance.DepthFunc(GL.GL_LEQUAL);
                GL.Instance.Hint(GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST);
            }
            catch (Exception)
            {
            }
        }

        #endregion ISupportInitialize 成员

        void WinSoftGLCanvas_KeyPress(object sender, KeyPressEventArgs e)
        {
            GLEventHandler<GLKeyPressEventArgs> KeyPress = this.glKeyPress;
            if (KeyPress != null)
            {
                GLKeyPressEventArgs arg = e.Translate();
                KeyPress(sender, arg);
            }
        }

        void WinSoftGLCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            GLEventHandler<GLMouseEventArgs> MouseDown = this.glMouseDown;
            if (MouseDown != null)
            {
                GLMouseEventArgs arg = e.Translate();
                MouseDown(sender, arg);
            }
        }

        void WinSoftGLCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            GLEventHandler<GLMouseEventArgs> MouseMove = this.glMouseMove;
            if (MouseMove != null)
            {
                GLMouseEventArgs arg = e.Translate();
                MouseMove(sender, arg);
            }
        }

        void WinSoftGLCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            GLEventHandler<GLMouseEventArgs> MouseUp = this.glMouseUp;
            if (MouseUp != null)
            {
                GLMouseEventArgs arg = e.Translate();
                MouseUp(sender, arg);
            }
        }

        void WinSoftGLCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            GLEventHandler<GLMouseEventArgs> MouseWheel = this.glMouseWheel;
            if (MouseWheel != null)
            {
                GLMouseEventArgs arg = e.Translate();
                MouseWheel(sender, arg);
            }
        }

        void WinSoftGLCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            GLEventHandler<GLKeyEventArgs> keyDown = this.glKeyDown;
            if (keyDown != null)
            {
                GLKeyEventArgs arg = e.Translate();
                keyDown(sender, arg);
            }
        }

        void WinSoftGLCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            GLEventHandler<GLKeyEventArgs> keyUp = this.glKeyUp;
            if (keyUp != null)
            {
                GLKeyEventArgs arg = e.Translate();
                keyUp(sender, arg);
            }
        }

    }
}