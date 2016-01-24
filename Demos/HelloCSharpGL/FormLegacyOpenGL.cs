using CSharpGL;
using GLM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharpGL
{
    public partial class FormLegacyOpenGL : Form
    {
        private double rotation;
        private PyramidModel model;

        public FormLegacyOpenGL()
        {
            InitializeComponent();

            this.model = new PyramidModel();
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            //  Clear the color and depth buffer.
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            DrawPyramid();

            this.Text = string.Format("FormLegacyOpenGL FPS: {0}", this.glCanvas1.FPS);
        }

        public void DrawPyramid()
        {
            //  Load the identity matrix.
            GL.LoadIdentity();

            //  Rotate around the Y axis.
            GL.Rotate(rotation, 0.0f, 1.0f, 0.0f);

            //  Draw a coloured pyramid.
            GL.Begin(GL.GL_TRIANGLES);
            for (int i = 0; i < this.model.positions.Length; i++)
            {
                vec3 color = this.model.colors[i];
                GL.Color(color.x, color.y, color.z);
                vec3 position = this.model.positions[i];
                GL.Vertex(position.x, position.y, position.z);
            }
            GL.End();

            rotation += 3.0f;
        }

        
        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            ResizeGL(glCanvas1.Width, glCanvas1.Height);
        }
        void ResizeGL(double width, double height)
        {
            //  Set the projection matrix.
            GL.MatrixMode(GL.GL_PROJECTION);

            //  Load the identity.
            GL.LoadIdentity();

            //  Create a perspective transformation.
            GL.gluPerspective(60.0f, width / height, 0.01, 100.0);

            //  Use the 'look at' helper function to position and aim the camera.
            GL.gluLookAt(-5, 5, -5, 0, 0, 0, 0, 1, 0);

            //  Set the modelview matrix.
            GL.MatrixMode(GL.GL_MODELVIEW);
        }
    }
}
