using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class RenderActionContext
    {
        /// <summary>
        /// 
        /// </summary>
        public ShaderProgram shaderProgram;
        /// <summary>
        /// 
        /// </summary>
        public List<VertexBuffer> vertexAttributeBuffers = new List<VertexBuffer>();
        /// <summary>
        /// 
        /// </summary>
        public IndexBuffer indexBuffer;
        /// <summary>
        /// 
        /// </summary>
        public VertexArrayObject vertexArrayObject;
        /// <summary>
        /// 
        /// </summary>
        public List<GLState> glStateList = new List<GLState>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            if (shaderProgram == null) { throw new Exception("shader program is null!"); }
            if (vertexAttributeBuffers == null) { throw new Exception("vertex attribute buffer list is null!"); }
            if (indexBuffer == null) { throw new Exception("index buffer is null!"); }
            if (vertexArrayObject == null) { throw new Exception("vertex array object is null!"); }
            if (glStateList == null) { throw new Exception("gl-state list is null!"); }

            return true;
        }
    }
}
