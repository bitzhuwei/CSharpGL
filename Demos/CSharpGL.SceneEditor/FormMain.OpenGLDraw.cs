using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.SceneEditor
{
    public partial class FormMain 
    {

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            Color clearColor = this.ClearColor;
            OpenGL.ClearColor(clearColor.R / 255.0f, clearColor.G / 255.0f, clearColor.B / 255.0f, clearColor.A / 255.0f);
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            var arg = new RenderEventArgs(RenderModes.Render, this.glCanvas1.ClientRectangle, this.Camera);
            foreach (var sceneObject in this.sceneObjectList)
            {
                foreach (var obj in sceneObject)
                {
                    obj.Render(arg);
                }
            }
        }
    }
}
