namespace CSharpGL.Objects.Cameras
{
    /// <summary>
    /// Use this for perspective/ortho view matrix.
    /// <para>Typical usage: projection * view * model in GLSL.</para>
    /// </summary>
    public interface IScientificCamera : IPerspectiveViewCamera, IOrthoViewCamera, IViewCamera, IPerspectiveCamera, IOrthoCamera
    {
        /// <summary>
        /// camera's perspective type.
        /// </summary>
        CameraTypes CameraType { get; set; }
    }
}
