using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Texture2DArray
{

    // Y
    // ^
    // |
    // |
    // 1--------------------0
    // |      .             |
    // |      |             |
    // |                    |
    // |    .               |
    // |   .                |
    // |  .                 |
    // | .                  |
    // 2--------------------3 --> X
    //
    /// <summary>
    /// 
    /// </summary>
    class LayeredRectangleModel : IBufferSource
    {
        public vec3 ModelSize { get; private set; }

        public LayeredRectangleModel()
        {
            this.ModelSize = new vec3(xLength * 2, yLength * 2, (xLength + yLength) * 0.02f);
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strUV = "uv";
        private VertexBuffer uvBuffer;

        private IndexBuffer indexBuffer;

        #region IBufferable 成员

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                return this.positionBuffer;
            }
            else if (bufferName == strUV)
            {
                if (this.uvBuffer == null)
                {
                    this.uvBuffer = uvs.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }

                return this.uvBuffer;
            }

            throw new NotImplementedException();
        }

        public IEnumerable<IndexBuffer> GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Quads, 0, positions.Length);
            }

            return this.indexBuffer;
        }

        #endregion

        private const float xLength = 0.5f;
        private const float yLength = 0.5f;
        /// <summary>
        /// four vertexes.
        /// </summary>
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(+xLength, +yLength, 0),// 0
            new vec3(-xLength, +yLength, 0),// 1
            new vec3(-xLength, -yLength, 0),// 2
            new vec3(+xLength, -yLength, 0),// 3
        };
        /// <summary>
        /// four uvs.
        /// </summary>
        private static readonly vec2[] uvs = new vec2[]
        {
            new vec2(1, 1),// 0
            new vec2(0, 1),// 1
            new vec2(0, 0),// 2
            new vec2(1, 0),// 3
        };
    }
}
