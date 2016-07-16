
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    static class GLCanvasHelper
    {

        ////  Use the 'look at' helper function to position and aim the camera.
        //OpenGL.gluLookAt(-2, 2, -2, 0, 0, 0, 0, 1, 0);
        static readonly mat4 viewMatrix = glm.lookAt(new vec3(0, 0, 2), new vec3(0, 0, 0), new vec3(0, 1, 0));
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

            //  Set the modelview matrix.
            OpenGL.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        static readonly BoundedClockRenderer clockRenderer = new BoundedClockRenderer();
     
        public static void DrawClock()
        {
            clockRenderer.Render(null);
        }

    }
}
