using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// map to 'in vec3 inPosition;' in vertex shader.
    /// </summary>
    public sealed class GLVertexNode : GLNode
    {
        private static readonly Type type = typeof(GLVertexNode);
        internal override Type ThisTypeCache
        {
            get { return type; }
        }

        internal VertexBuffer GetVertexAttributeBuffer()
        {
            throw new NotImplementedException();
        }
    }
}
