namespace CSharpGL
{
    public static partial class ICameraHelper
    {
        /// <summary>
        /// Run legacy projection and view transform.(from world space to clip space)
        /// </summary>
        /// <param name="camera"></param>
        public static void LegacyProjection(this ICamera camera)
        {
            if (camera == null) { throw new System.ArgumentNullException("camera"); }
            // projection and view matrix.(gluPerspective() and gluLookAt())
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();

            //  Set the projection matrix.(projection and view matrix actually.)
            OpenGL.MultMatrixf((projection * view).ToArray());
        }
    }
}