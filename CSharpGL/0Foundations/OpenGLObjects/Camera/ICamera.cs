namespace CSharpGL
{
    /// <summary>
    /// Use this for perspective/ortho view matrix.
    /// <para>Typical usage: projection * view * model in GLSL.</para>
    /// </summary>
    public interface ICamera : IPerspectiveViewCamera, IOrthoViewCamera, IViewCamera, IPerspectiveCamera, IOrthoCamera
    {
        /// <summary>
        /// camera's perspective type.
        /// </summary>
        CameraType CameraType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        mat4 GetProjectionMatrix();
    }

    /// <summary>
    /// 
    /// </summary>
    public static class ICameraHelper
    {

        /// <summary>
        /// opengl控件的大小改变时调整camera.
        /// Adjust camera when OpenGL canvas's size changed.
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void Resize(this ICamera camera, double width, double height)
        {
            double aspectRatio = width / height;

            IPerspectiveCamera perspectiveCamera = camera;
            perspectiveCamera.AspectRatio = aspectRatio;

            IOrthoCamera orthoCamera = camera;

            double lastAspectRatio = perspectiveCamera.AspectRatio;
            if (aspectRatio > lastAspectRatio)
            {
                double top = orthoCamera.Top;
                double newRight = top * aspectRatio;
                orthoCamera.Left = -newRight;
                orthoCamera.Right = newRight;
            }
            else if (aspectRatio < lastAspectRatio)
            {
                double right = orthoCamera.Right;
                double newTop = right / aspectRatio;
                orthoCamera.Bottom = -newTop;
                orthoCamera.Top = newTop;
            }

            //const int factor = 100;
            //if (width / 2 / factor != orthoCamera.Right)
            //{
            //    orthoCamera.Left = -width / 2 / factor;
            //    orthoCamera.Right = width / 2 / factor;
            //}
            //if (height / 2 / factor != orthoCamera.Top)
            //{
            //    orthoCamera.Bottom = -height / 2 / factor;
            //    orthoCamera.Top = height / 2 / factor;
            //}
        }
    }
}
