namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public enum ShaderType : uint
    {
        /// <summary>
        ///
        /// </summary>
        VertexShader = OpenGL.GL_VERTEX_SHADER,

        /// <summary>
        ///
        /// </summary>
        GeometryShader = OpenGL.GL_GEOMETRY_SHADER,

        /// <summary>
        ///
        /// </summary>
        FragmentShader = OpenGL.GL_FRAGMENT_SHADER,

        /// <summary>
        ///
        /// </summary>
        ComputeShader = OpenGL.GL_COMPUTE_SHADER,
    }
}