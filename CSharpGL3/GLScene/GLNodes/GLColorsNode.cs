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
    public sealed class GLColorsNode : GLNode
    {
        private VertexBuffer vertexBuffer;
        private vec3[] array;

        private static readonly Type type = typeof(GLColorsNode);
        internal override Type SelfTypeCache { get { return type; } }

        public GLColorsNode(vec3[] array)
        {
            this.array = array;
        }

        internal VertexBuffer GetVertexAttributeBuffer()
        {
            if (this.vertexBuffer == null)
            {
                this.vertexBuffer = this.array.GenVertexBuffer(VBOConfig.Vec3, "in_Color", BufferUsage.StaticDraw);
            }

            return this.vertexBuffer;
        }
    }
}
