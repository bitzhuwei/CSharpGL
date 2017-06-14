using System.ComponentModel;
namespace CSharpGL
{
    /// <summary>
    /// Rendering something using GLSL shader and VBO(VAO).
    /// </summary>
    public abstract partial class PickableRenderer : RendererBase, IRenderable, IPickable, IWorldSpace
    {
        // data structure for rendering.

        /// <summary>
        /// Vertex Array Object.
        /// </summary>
        protected VertexArrayObject vertexArrayObject;

        /// <summary>
        /// 
        /// </summary>
        protected VertexArrayObject pickVertexArrayObject;

        /// <summary>
        /// all 'in type varName;' in vertex shader.
        /// </summary>
        protected VertexShaderAttribute[] vertexShaderAttributes;

        /// <summary>
        /// 
        /// </summary>
        protected VertexShaderAttribute positionAttribute;

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
        protected IShaderProgramProvider renderProgramProvider;

        /// <summary>
        /// Provides shader program that rennders something for picking.
        /// </summary>
        protected IShaderProgramProvider pickProgramProvider;

        /// <summary>
        /// Mapping relations between 'in' variables in vertex shader and buffers in <see cref="DataSource"/>.
        /// </summary>
        protected AttributeMap attributeMap;

        /// <summary>
        ///
        /// </summary>
        [Browsable(false)]
        public string PositionNameInIBufferable { get; private set; }

        /// <summary>
        /// 支持"拾取"的渲染器
        /// </summary>
        /// <param name="model">一种渲染方式</param>
        /// <param name="renderProgramProvider">各种类型的shader代码</param>
        /// <param name="attributeMap">关联<paramref name="model"/>和<paramref name="shaderProgramProvider"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        public PickableRenderer(IBufferable model, IShaderProgramProvider renderProgramProvider,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLState[] switches)
        {
            this.PositionNameInIBufferable = positionNameInIBufferable;
            this.pickProgramProvider = PickingShaderHelper.GetPickingShaderProgramProvider();

            this.DataSource = model;
            this.renderProgramProvider = renderProgramProvider;
            this.attributeMap = attributeMap;
            this.stateList.AddRange(switches);
        }
    }
}