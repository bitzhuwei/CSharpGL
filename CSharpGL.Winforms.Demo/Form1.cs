using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Winforms.Demo
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        private float rotation;
        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Init GL
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            // first resize
            glCanvas1_Resize(this.glCanvas1, e);
        }

        private void glCanvas1_OpenGLDraw(object sender, RenderEventArgs e)
        {

            //  Clear the color and depth buffer.
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            //  Load the identity matrix.
            GL.LoadIdentity();

            //  Rotate around the Y axis.
            GL.Rotate(rotation, 0.0f, 1.0f, 0.0f);

            //  Draw a coloured pyramid.
            GL.Begin(GL.GL_TRIANGLES);
            GL.Color(1.0f, 0.0f, 0.0f);
            GL.Vertex(0.0f, 1.0f, 0.0f);
            GL.Color(0.0f, 1.0f, 0.0f);
            GL.Vertex(-1.0f, -1.0f, 1.0f);
            GL.Color(0.0f, 0.0f, 1.0f);
            GL.Vertex(1.0f, -1.0f, 1.0f);
            GL.Color(1.0f, 0.0f, 0.0f);
            GL.Vertex(0.0f, 1.0f, 0.0f);
            GL.Color(0.0f, 0.0f, 1.0f);
            GL.Vertex(1.0f, -1.0f, 1.0f);
            GL.Color(0.0f, 1.0f, 0.0f);
            GL.Vertex(1.0f, -1.0f, -1.0f);
            GL.Color(1.0f, 0.0f, 0.0f);
            GL.Vertex(0.0f, 1.0f, 0.0f);
            GL.Color(0.0f, 1.0f, 0.0f);
            GL.Vertex(1.0f, -1.0f, -1.0f);
            GL.Color(0.0f, 0.0f, 1.0f);
            GL.Vertex(-1.0f, -1.0f, -1.0f);
            GL.Color(1.0f, 0.0f, 0.0f);
            GL.Vertex(0.0f, 1.0f, 0.0f);
            GL.Color(0.0f, 0.0f, 1.0f);
            GL.Vertex(-1.0f, -1.0f, -1.0f);
            GL.Color(0.0f, 1.0f, 0.0f);
            GL.Vertex(-1.0f, -1.0f, 1.0f);
            GL.End();

            //  Nudge the rotation.
            rotation += 3.0f;

        }

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            //  Set the projection matrix.
            GL.MatrixMode(GL.GL_PROJECTION);

            //  Load the identity.
            GL.LoadIdentity();

            //  Create a perspective transformation.
            GL.gluPerspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            //  Use the 'look at' helper function to position and aim the camera.
            GL.gluLookAt(-5, 5, -5, 0, 0, 0, 0, 1, 0);

            //  Set the modelview matrix.
            GL.MatrixMode(GL.GL_MODELVIEW);
        }

      
    }
}
