namespace CSharpGL
{
    /// <summary>
    /// Work with compute shader.
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
        /// Work with compute shader.
        /// </summary>
        /// <param name="shaderCodes">All shader codes needed for this renderer.</param>
        public ComputeRenderer(ShaderCode[] shaderCodes)
        {
            this.shaderCodes = shaderCodes;
        }
    }
}