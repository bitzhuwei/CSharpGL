
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    static class GLCanvasHelper
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
        static readonly mat4 viewMatrix = glm.lookAt(new vec3(-2, 2, -2), new vec3(0, 0, 0), new vec3(0, 1, 0));
        public static void ResizeGL(double width, double height)
        {
            //  Set the projection matrix.
            OpenGL.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            OpenGL.LoadIdentity();
            ////  Create a perspective transformation.
            //OpenGL.gluPerspective(60.0f, width / height, 0.01, 100.0);
            mat4 projectionMatrix = glm.perspective(glm.radians(60.0f), (float)(width / height), 0.01f, 100.0f);
            OpenGL.MultMatrixf((projectionMatrix * viewMatrix).to_array());

            ////  Use the 'look at' helper function to position and aim the camera.
            //OpenGL.gluLookAt(-2, 2, -2, 0, 0, 0, 0, 1, 0);

            //  Set the modelview matrix.
            OpenGL.MatrixMode(OpenGL.GL_MODELVIEW);
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
            //  Load the identity matrix.
            OpenGL.LoadIdentity();

            //  Rotate around the Y axis.
            OpenGL.Rotatef(rotation, 0.0f, 1.0f, 0.0f);

            //  Draw a coloured pyramid.
            OpenGL.Begin(OpenGL.GL_TRIANGLES);
            for (int i = 0; i < pyramidPosition.Count; i++)
            {
                vec3 color = pyramidColor[i];
                OpenGL.Color3f(color.x, color.y, color.z);
                vec3 position = pyramidPosition[i];
                OpenGL.Vertex3f(position.x, position.y, position.z);
            }
            OpenGL.End();

            rotation += 3.0f;
        }

        private static float rotation;
    }
}
