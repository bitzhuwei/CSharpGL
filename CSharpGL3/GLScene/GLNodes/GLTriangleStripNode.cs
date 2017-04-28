using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// complex node. commonly used shape.
    /// </summary>
    public class GLTriangleStripNode : GLShaderNode
    {
        private static readonly Type type = typeof(GLTriangleStripNode);
        internal override Type ThisTypeCache
        {
            get { return type; }
        }

        private VertexArrayObject vertexArrayObject;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="vertexBuffers"></param>
        /// <returns></returns>
        public VertexArrayObject GetVertexArrayObject(IndexBuffer indexBuffer, VertexBuffer[] vertexBuffers)
        {
            if (this.vertexArrayObject == null)
            {
                this.vertexArrayObject = new VertexArrayObject(indexBuffer, vertexBuffers);
            }

            return this.vertexArrayObject;
        }
    }
}
