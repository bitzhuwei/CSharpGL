namespace CSharpGL
{
    /// <summary>
    /// Use this for perspective view matrix.
    /// <para>Typical usage: projection * view * model in GLSL.</para>
    /// </summary>
    public interface IPerspectiveViewCamera : IPerspectiveCamera, IViewCamera
    {
    }
}
