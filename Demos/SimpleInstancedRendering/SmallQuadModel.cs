using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace SimpleInstancedRendering
{
    class SmallQuadModel : IBufferSource
    {
        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;

        private IndexBuffer indexBuffer;

        private const float scale = 0.05f;
        private static readonly vec2[] positions = new vec2[] { new vec2(-1, 1) * scale, new vec2(1, -1) * scale, new vec2(-1, -1) * scale, new vec2(-1, 1) * scale, new vec2(1, -1) * scale, new vec2(1, 1) * scale };
        private static readonly vec3[] colors = new vec3[] { new vec3(1, 0, 0), new vec3(0, 1, 0), new vec3(0, 0, 1), new vec3(1, 0, 0), new vec3(0, 1, 0), new vec3(0, 1, 1) };

        #region IBufferSource 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }

                return this.positionBuffer;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = colors.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                return this.colorBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IDrawCommand GetDrawCommand()
        {
            if (this.indexBuffer == null)
            {
                int primCount = 100;// render 100 instances.
                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Triangles, 0, 6, primCount);
            }

            return this.indexBuffer;
        }

        #endregion
    }
}
