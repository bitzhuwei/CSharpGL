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
    public static partial class ICameraHelper { }
}