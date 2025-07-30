namespace CSharpGL {
    public static partial class ICameraHelper {
        /// <summary>
        /// Run legacy projection and view transform.(from world space to clip space)
        /// </summary>
        /// <param name="camera"></param>
        public unsafe static void LegacyProjection(this ICamera camera) {
            var gl = GL.current; if (gl == null) { return; }

            if (camera == null) { throw new System.ArgumentNullException("camera"); }
            // projection and view matrix.(gluPerspective() and gluLookAt())
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();

            //  Set the projection matrix.(projection and view matrix actually.)
            gl.glMultMatrixf((projection * view).ToArray());
        }
    }
}