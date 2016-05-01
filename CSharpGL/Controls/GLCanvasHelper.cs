
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Windows
{
    public static class GLCanvasHelper
    {
        //static PyramidVAOElement pyramidVAOElement = new PyramidVAOElement();
        //static GLCanvasHelper()
        //{
        //    pyramidVAOElement.Initialize();
        //}

        //public static void DrawWithElement()
        //{
        //    pyramidVAOElement.Render(new RenderEventArgs(RenderModes.Render, this.camera));
        //}

        public static void ResizeGL(double width, double height)
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

        static readonly List<vec3> pyramidPosition = new List<vec3>();
        static readonly List<vec3> pyramidColor = new List<vec3>();
        static GLCanvasHelper()
        {
            pyramidColor.Add(new vec3(1.0f, 0.0f, 0.0f));
            pyramidPosition.Add(new vec3(0.0f, 1.0f, 0.0f));
            pyramidColor.Add(new vec3(0.0f, 1.0f, 0.0f));
            pyramidPosition.Add(new vec3(-1.0f, -1.0f, 1.0f));
            pyramidColor.Add(new vec3(0.0f, 0.0f, 1.0f));
            pyramidPosition.Add(new vec3(1.0f, -1.0f, 1.0f));
            pyramidColor.Add(new vec3(1.0f, 0.0f, 0.0f));
            pyramidPosition.Add(new vec3(0.0f, 1.0f, 0.0f));
            pyramidColor.Add(new vec3(0.0f, 0.0f, 1.0f));
            pyramidPosition.Add(new vec3(1.0f, -1.0f, 1.0f));
            pyramidColor.Add(new vec3(0.0f, 1.0f, 0.0f));
            pyramidPosition.Add(new vec3(1.0f, -1.0f, -1.0f));
            pyramidColor.Add(new vec3(1.0f, 0.0f, 0.0f));
            pyramidPosition.Add(new vec3(0.0f, 1.0f, 0.0f));
            pyramidColor.Add(new vec3(0.0f, 1.0f, 0.0f));
            pyramidPosition.Add(new vec3(1.0f, -1.0f, -1.0f));
            pyramidColor.Add(new vec3(0.0f, 0.0f, 1.0f));
            pyramidPosition.Add(new vec3(-1.0f, -1.0f, -1.0f));
            pyramidColor.Add(new vec3(1.0f, 0.0f, 0.0f));
            pyramidPosition.Add(new vec3(0.0f, 1.0f, 0.0f));
            pyramidColor.Add(new vec3(0.0f, 0.0f, 1.0f));
            pyramidPosition.Add(new vec3(-1.0f, -1.0f, -1.0f));
            pyramidColor.Add(new vec3(0.0f, 1.0f, 0.0f));
            pyramidPosition.Add(new vec3(-1.0f, -1.0f, 1.0f));
        }

        public static void DrawPyramid()
        {
            //  Clear the color and depth buffer.
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            //  Load the identity matrix.
            GL.LoadIdentity();

            //  Rotate around the Y axis.
            GL.Rotate(rotation, 0.0f, 1.0f, 0.0f);

            //  Draw a coloured pyramid.
            GL.Begin(GL.GL_TRIANGLES);
            for (int i = 0; i < pyramidPosition.Count; i++)
            {
                vec3 color = pyramidColor[i];
                GL.Color(color.x, color.y, color.z);
                vec3 position = pyramidPosition[i];
                GL.Vertex(position.x, position.y, position.z);
            }
            GL.End();

            rotation += 3.0f;
        }

        private static double rotation;
    }
}
