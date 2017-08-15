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
        VertexShader = GL.GL_VERTEX_SHADER,

        /// <summary>
        ///
        /// </summary>
        GeometryShader = GL.GL_GEOMETRY_SHADER,

        /// <summary>
        /// 
        /// </summary>
        TessControlShader = GL.GL_TESS_CONTROL_SHADER,

        /// <summary>
        /// 
        /// </summary>
        TessEvaluationShader = GL.GL_TESS_EVALUATION_SHADER,

        /// <summary>
        ///
        /// </summary>
        FragmentShader = GL.GL_FRAGMENT_SHADER,

        /// <summary>
        ///
        /// </summary>
        ComputeShader = GL.GL_COMPUTE_SHADER,
    }
}