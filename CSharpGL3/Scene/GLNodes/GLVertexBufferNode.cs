using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public sealed class GLVertexBufferNode : GLNode
    {
        private static readonly Type type = typeof(GLVertexBufferNode);
        internal override Type ThisTypeCache
        {
            get { return type; }
        }
    }
}
