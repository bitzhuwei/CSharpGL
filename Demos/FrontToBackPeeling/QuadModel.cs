using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FrontToBackPeeling
{
    class QuadModel : IBufferSource
    {

        private static readonly vec2[] quadVerts = new vec2[4] { new vec2(0, 0), new vec2(1, 0), new vec2(1, 1), new vec2(0, 1), };
        private static readonly ushort[] quadIndices = new ushort[] { 0, 1, 2, 0, 2, 3 };

        public const string positions = "positions";
        private VertexBuffer positionBuffer;

        private IndexBuffer indexBuffer;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            if (positions == bufferName)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = quadVerts.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }

                return this.positionBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IndexBuffer> GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                this.indexBuffer = quadIndices.GenIndexBuffer(DrawMode.Triangles, BufferUsage.StaticDraw);
            }

            return this.indexBuffer;
        }

        #endregion
    }
}
