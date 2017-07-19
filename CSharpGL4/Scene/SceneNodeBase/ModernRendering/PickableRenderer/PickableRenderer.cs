using System.ComponentModel;
namespace CSharpGL
{
    /// <summary>
    /// Rendering something using GLSL shader and VBO(VAO).
    /// </summary>
    public abstract partial class PickableRenderer : SceneNodeBase, IRenderable, IPickable
    {
        // data structure for rendering.

        ///// <summary>
        ///// Vertex Array Object.
        ///// </summary>
        //protected VertexArrayObject vertexArrayObject;

        ///// <summary>
        ///// 
        ///// </summary>
        //protected VertexArrayObject pickVertexArrayObject;

        ///// <summary>
        ///// all 'in type varName;' in vertex shader.
        ///// </summary>
        //protected VertexShaderAttribute[] vertexShaderAttributes;

        ///// <summary>
        ///// 
        ///// </summary>
        //protected VertexBuffer positionBuffer;

        ///// <summary>
        /////
        ///// </summary>
        //protected IndexBuffer indexBuffer;

        ///// <summary>
        /////
        ///// </summary>
        //protected GLStateList stateList = new GLStateList();

        ///// <summary>
        ///// Provides shader program for this renderer.
        ///// </summary>
        //protected IShaderProgramProvider renderProgramProvider;

        ///// <summary>
        ///// Provides shader program that rennders something for picking.
        ///// </summary>
        //protected IShaderProgramProvider pickProgramProvider;

        ///// <summary>
        ///// Mapping relations between 'in' variables in vertex shader and buffers in <see cref="DataSource"/>.
        ///// </summary>
        //protected AttributeMap attributeMap;

        ///// <summary>
        /////
        ///// </summary>
        //[Browsable(false)]
        //public string PositionNameInVertexShader { get; private set; }

        private readonly RenderUnitBuilder[] builders;
        private readonly IPickableRenderUnitBuilder pickingBuilder;
        private readonly IBufferable model;
        /// <summary>
        /// 支持"拾取"的渲染器
        /// </summary>
        /// <param name="positionNameInIBufferable">vertex shader种描述顶点位置信息的in变量的名字</param>
        ///<param name="positionNameInIBufferable"></param>
        ///<param name="builders"></param>
        public PickableRenderer(IBufferable model, string positionNameInIBufferable, params RenderUnitBuilder[] builders)
        {
            this.model = model;
            var pickProgramProvider = PickingShaderHelper.GetPickingShaderProgramProvider();
            this.builders = builders;
            this.pickingBuilder = new IPickableRenderUnitBuilder(pickProgramProvider, positionNameInIBufferable);
        }
    }
}