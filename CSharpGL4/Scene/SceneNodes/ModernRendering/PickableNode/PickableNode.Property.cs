using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class PickableNode
    {
        private const string strPickableRenderer = "PickableRenderer";

        private List<RenderUnit> renderUnits = new List<RenderUnit>();
        [Category(strPickableRenderer)]
        [Description("Each render unit takes care of one way of rendering.")]
        public List<RenderUnit> RenderUnits { get { return this.renderUnits; } }

        [Category(strPickableRenderer)]
        [Description("Takes care of rendering for picking.")]
        public IPickableRenderUnit PickingRenderUnit { get; private set; }
        ///// <summary>
        ///// Shader Program that does the rendering algorithm.
        ///// </summary>
        //[Category(strPickableRenderer)]
        //[Description("Shader Program that does the rendering algorithm.")]
        //public ShaderProgram RenderProgram { get; protected set; }

        ///// <summary>
        ///// Shader Program that does the rendering algorithm.
        ///// </summary>
        //[Category(strPickableRenderer)]
        //[Description("Shader Program that does the picking algorithm.")]
        //public ShaderProgram PickProgram { get; protected set; }

        ///// <summary>
        ///// model data that can be transfermed into OpenGL Buffer Objects.
        ///// </summary>
        //[Category(strPickableRenderer)]
        //[Description("model data that can be transfermed into OpenGL Buffer Objects.")]
        //public IBufferable DataSource { get; private set; }

        ///// <summary>
        /////
        ///// </summary>
        //[Category(strPickableRenderer)]
        //[Description("OpenGL switches.")]
        //public GLStateList StateList { get { return this.stateList; } }

        ///// <summary>
        /////
        ///// </summary>
        //[Category(strPickableRenderer)]
        //[Description("index buffer(glDrawArrays or glDrawElements).")]
        //public IndexBuffer IndexBuffer { get { return this.indexBuffer; } }

        ///// <summary>
        /////  Vertex attribute buffers.
        ///// </summary>
        //[Category(strPickableRenderer)]
        //[Description("Vertex attribute buffers.")]
        //[Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        //public IEnumerable<VertexShaderAttribute> VertexAttributeBuffers { get { return this.vertexShaderAttributes; } }
        ///// <summary>
        ///// 
        ///// </summary>
        //public VertexBuffer PositionBuffer { get { return this.positionBuffer; } }

        ///// <summary>
        ///// Vertex Array Object.
        ///// </summary>
        //[Category(strPickableRenderer)]
        //[Description("Vertex Array Object.")]
        //public VertexArrayObject VertexArrayObject { get { return this.vertexArrayObject; } }

        ///// <summary>
        ///// Vertex Array Object.
        ///// </summary>
        //[Category(strPickableRenderer)]
        //[Description("Vertex Array Object for Picking.")]
        //public VertexArrayObject PickVertexArrayObject { get { return this.pickVertexArrayObject; } }


    }
}