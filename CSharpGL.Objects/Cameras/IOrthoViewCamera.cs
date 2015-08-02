namespace CSharpGL.Objects.Cameras
{
    /// <summary>
    /// Use thsi for ortho projection * view matrix.
    /// <para>Typical usage: projection * view * model in GLSL.</para>
    /// </summary>
    public interface IOrthoViewCamera : IOrthoCamera, IViewCamera
    {
    }
}
