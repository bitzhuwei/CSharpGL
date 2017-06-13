using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class PickableRenderer
    {
        private const string strRenderer = "Renderer";

        /// <summary>
        /// Shader Program that does the rendering algorithm.
        /// </summary>
        [Category(strRenderer)]
        [Description("Shader Program that does the rendering algorithm.")]
        public ShaderProgram Program { get; protected set; }

        /// <summary>
        /// model data that can be transfermed into OpenGL Buffer Objects.
        /// </summary>
        [Category(strRenderer)]
        [Description("model data that can be transfermed into OpenGL Buffer Objects.")]
        public IBufferable DataSource { get; private set; }

        /// <summary>
        ///
        /// </summary>
        [Category(strRenderer)]
        [Description("OpenGL switches.")]
        public GLStateList StateList { get { return this.stateList; } }

        /// <summary>
        ///
        /// </summary>
        [Category(strRenderer)]
        [Description("index buffer(glDrawArrays or glDrawElements).")]
        public IndexBuffer IndexBuffer { get { return this.indexBuffer; } }

        /// <summary>
        ///  Vertex attribute buffers.
        /// </summary>
        [Category(strRenderer)]
        [Description("Vertex attribute buffers.")]
        //[Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public IEnumerable<VertexShaderAttribute> VertexAttributeBuffers
        {
            get
            {
                return this.vertexShaderAttribute;
            }
        }

        /// <summary>
        /// Vertex Array Object.
        /// </summary>
        [Category(strRenderer)]
        [Description("Vertex Array Object.")]
        public VertexArrayObject VertexArrayObject { get { return this.vertexArrayObject; } }
    }
}