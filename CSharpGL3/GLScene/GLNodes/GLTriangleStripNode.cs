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



        internal VertexArrayObject GetVertexArrayObject(RenderActionContext renderActionContext)
        {
            throw new NotImplementedException();
        }
    }
}
