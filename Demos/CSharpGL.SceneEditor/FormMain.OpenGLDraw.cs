using System.Drawing;

using System.Windows.Forms;

namespace CSharpGL.SceneEditor
{
    public partial class FormMain
    {
        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            //Color clearColor = this.scene.ClearColor;
            //OpenGL.ClearColor(clearColor.R / 255.0f, clearColor.G / 255.0f, clearColor.B / 255.0f, clearColor.A / 255.0f);
            //OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            this.scene.Render(RenderModes.Render, this.glCanvas1.ClientRectangle);
            //this.glCanvas1.PointToClient(Control.MousePosition));
        }
    }
}