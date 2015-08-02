namespace CSharpGL.Objects.Cameras
{
    /// <summary>
    /// Use thsi for perspective view matrix.
    /// <para>Typical usage: projection * view * model in GLSL.</para>
    /// </summary>
    public interface IPerspectiveViewCamera : IPerspectiveCamera, IViewCamera
    {
    }
}
