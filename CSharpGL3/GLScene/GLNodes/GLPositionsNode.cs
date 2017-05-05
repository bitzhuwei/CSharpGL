using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// map to 'in vec3 inPosition;' in vertex shader.
    /// </summary>
    public sealed class GLPositionsNode : GLNode
    {
        private VertexBuffer vertexBuffer;
        private vec3[] array;

        private static readonly Type type = typeof(GLPositionsNode);
        internal override Type SelfTypeCache { get { return type; } }

        public GLPositionsNode(vec3[] array)
        {
            this.array = array;
        }

        internal VertexBuffer GetVertexAttributeBuffer()
        {
            if (this.vertexBuffer == null)
            {
                this.vertexBuffer = this.array.GenVertexBuffer(VBOConfig.Vec3, "in_Position", BufferUsage.StaticDraw);
            }

            return this.vertexBuffer;
        }
    }
}
