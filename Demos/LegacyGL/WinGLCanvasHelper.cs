namespace CSharpGL
{
    internal static class WinGLCanvasHelper
    {
        ////  Use the 'look at' helper function to position and aim the camera.
        //OpenGL.gluLookAt(-2, 2, -2, 0, 0, 0, 0, 1, 0);
        private static readonly mat4 viewMatrix = glm.lookAt(new vec3(0, 0, 2.5f), new vec3(0, 0, 0), new vec3(0, 1, 0));

        public static void ResizeGL(double width, double height)
        {
            //  Set the projection matrix.
            GL.Instance.MatrixMode(GL.GL_PROJECTION);

            //  Load the identity.
            GL.Instance.LoadIdentity();
            ////  Create a perspective transformation.
            //OpenGL.gluPerspective(60.0f, width / height, 0.01, 100.0);
            mat4 projectionMatrix = glm.perspective(glm.radians(60.0f), (float)(width / height), 0.01f, 100.0f);
            GL.Instance.MultMatrixf((projectionMatrix * viewMatrix).ToArray());

            //  Set the modelview matrix.
            GL.Instance.MatrixMode(GL.GL_MODELVIEW);
        }

        private static readonly BoundedClockRenderer clockRenderer = new BoundedClockRenderer();

        public static void DrawClock()
        {
            clockRenderer.Render(null);
        }
    }
}