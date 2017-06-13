using System.ComponentModel;
namespace CSharpGL
{
    /// <summary>
    /// Rendering something using GLSL shader and VBO(VAO).
    /// </summary>
    public partial class PickableRenderer : RendererBase, IRenderable, IPickable
    {
        // data structure for rendering.

        /// <summary>
        /// Vertex Array Object.
        /// </summary>
        protected VertexArrayObject vertexArrayObject;

        /// <summary>
        /// all 'in type varName;' in vertex shader.
        /// </summary>
        protected VertexShaderAttribute[] vertexShaderAttributes;

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
        ///
        /// </summary>
        [Browsable(false)]
        public string PositionNameInIBufferable { get; private set; }

        /// <summary>
        /// 支持"拾取"的渲染器
        /// </summary>
        /// <param name="model">一种渲染方式</param>
        /// <param name="shaderProgramProvider">各种类型的shader代码</param>
        /// <param name="attributeMap">关联<paramref name="model"/>和<paramref name="shaderProgramProvider"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        public PickableRenderer(IBufferable model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLState[] switches)
            : this(model, shaderProgramProvider, attributeMap, positionNameInIBufferable, PickingShaderHelper.GetPickingShaderProgramProvider(), switches)
        {
        }

        /// <summary>
        /// 支持"拾取"的渲染器
        /// </summary>
        /// <param name="model">一种渲染方式</param>
        /// <param name="shaderProgramProvider">各种类型的shader代码</param>
        /// <param name="attributeMap">关联<paramref name="model"/>和<paramref name="shaderProgramProvider"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        /// <param name="pickingProgramProvider"></param>
        ///<param name="switches"></param>
        public PickableRenderer(IBufferable model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, string positionNameInIBufferable, IShaderProgramProvider pickingProgramProvider,
            params GLState[] switches)
        {
            this.PositionNameInIBufferable = positionNameInIBufferable;

            this.DataSource = model;
            this.shaderProgramProvider = shaderProgramProvider;
            this.attributeMap = attributeMap;
            this.stateList.AddRange(switches);
        }
    }
}