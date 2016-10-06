namespace CSharpGL
{
    /// <summary>
    /// Rendering something using GLSL shader and VBO(VAO).
    /// </summary>
    public partial class Renderer : RendererBase
    {
        // data structure for rendering.

        /// <summary>
        /// Vertex Array Object.
        /// </summary>
        protected VertexArrayObject vertexArrayObject;

        /// <summary>
        /// Vertex attribute buffers.
        /// </summary>
        protected VertexAttributeBufferPtr[] vertexAttributeBufferPtrs;

        /// <summary>
        ///
        /// </summary>
        protected IndexBufferPtr indexBufferPtr;

        /// <summary>
        ///
        /// </summary>
        protected GLSwitchList switchList = new GLSwitchList();

        /// <summary>
        /// All shader codes needed for this renderer.
        /// </summary>
        protected ShaderCode[] shaderCodes;

        /// <summary>
        /// Mapping relations between 'in' variables in vertex shader and buffers in <see cref="Model"/>.
        /// </summary>
        protected AttributeMap attributeMap;

        /// <summary>
        /// Rendering something using GLSL shader and VBO(VAO).
        /// </summary>
        /// <param name="model">model data that can be transfermed into OpenGL Buffer's pointer.</param>
        /// <param name="shaderCodes">All shader codes needed for this renderer.</param>
        /// <param name="attributeMap">Mapping relations between 'in' variables in vertex shader in <see cref="shaderCodes"/> and buffers in <see cref="Model"/>.</param>
        ///<param name="switches">OpenGL switches.</param>
        public Renderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
        {
            this.Model = model;
            this.shaderCodes = shaderCodes;
            this.attributeMap = attributeMap;
            this.switchList.AddRange(switches);
        }
    }
}