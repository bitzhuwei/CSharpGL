namespace CSharpGL
{
    /// <summary>
    /// Rendering something using GLSL shader and VBO(VAO).
    /// </summary>
    public abstract partial class Renderer : SceneNodeBase, IRenderable
    {
        // data structure for rendering.

        /// <summary>
        /// Vertex Array Object.
        /// </summary>
        protected VertexArrayObject vertexArrayObject;

        /// <summary>
        /// all 'in type varName;' in vertex shader.
        /// </summary>
        protected VertexShaderAttribute[] vertexShaderAttribute;

        /// <summary>
        ///
        /// </summary>
        protected IndexBuffer indexBuffer;

        /// <summary>
        ///
        /// </summary>
        protected GLStateList stateList = new GLStateList();

        /// <summary>
        /// Provides shader program for this renderer.
        /// </summary>
        protected IShaderProgramProvider shaderProgramProvider;

        /// <summary>
        /// Mapping relations between 'in' variables in vertex shader and buffers in <see cref="DataSource"/>.
        /// </summary>
        protected AttributeMap attributeMap;

        /// <summary>
        /// Rendering something using GLSL shader and VBO(VAO).
        /// </summary>
        /// <param name="model">model data that can be transfermed into OpenGL Buffer's pointer.</param>
        /// <param name="shaderProgramProvider">All shader codes needed for this renderer.</param>
        /// <param name="attributeMap">Mapping relations between 'in' variables in vertex shader in <see cref="shaderProgramProvider"/> and buffers in <see cref="DataSource"/>.</param>
        ///<param name="switches">OpenGL switches.</param>
        public Renderer(IBufferable model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, params GLState[] switches)
        {
            this.DataSource = model;
            this.shaderProgramProvider = shaderProgramProvider;
            this.attributeMap = attributeMap;
            this.stateList.AddRange(switches);
        }
    }
}