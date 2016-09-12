namespace CSharpGL
{
    /// <summary>
    /// Rendering something using GLSL shader and VBO(VAO).
    /// </summary>
    public partial class ComputeRenderer : RendererBase
    {
        /// <summary>
        /// algorithm for rendering.
        /// </summary>
        public ShaderProgram Program { get; protected set; }

        /// <summary>
        /// All shader codes needed for this renderer.
        /// </summary>
        protected ShaderCode[] shaderCodes;

        /// <summary>
        /// Rendering something using GLSL shader and VBO(VAO).
        /// </summary>
        /// <param name="shaderCodes">All shader codes needed for this renderer.</param>
        public ComputeRenderer(ShaderCode[] shaderCodes)
        {
            this.shaderCodes = shaderCodes;
        }
    }
}