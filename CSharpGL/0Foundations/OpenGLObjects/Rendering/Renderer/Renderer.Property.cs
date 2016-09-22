using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class Renderer
    {

        /// <summary>
        /// model data that can be transfermed into OpenGL Buffer Objects.
        /// </summary>
        [Category(strRenderer)]
        [Description("model data that can be transfermed into OpenGL Buffer Objects.")]
        public IBufferable Model { get; private set; }

        /// <summary>
        ///
        /// </summary>
        [Category(strRenderer)]
        [Editor(typeof(UniformVariableListEditor), typeof(UITypeEditor))]
        [Description("maps to uniform variables in shader.")]
        public List<UniformVariable> UniformVariables { get { return uniformVariables; } }

        /// <summary>
        ///
        /// </summary>
        [Category(strRenderer)]
        [Description("OpenGL switches.")]
        public GLSwitchList SwitchList { get { return switchList; } }

        /// <summary>
        ///
        /// </summary>
        [Category(strRenderer)]
        [Description("index buffer(glDrawArrays or glDrawElements).")]
        public IndexBufferPtr IndexBufferPtr { get { return this.indexBufferPtr; } }

        /// <summary>
        ///  Vertex attribute buffers.
        /// </summary>
        [Category(strRenderer)]
        [Description("Vertex attribute buffers.")]
        public IEnumerable<VertexAttributeBufferPtr> VertexAttributeBufferPtrs
        {
            get
            {
                return this.vertexAttributeBufferPtrs;
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