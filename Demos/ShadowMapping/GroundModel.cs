using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowMapping
{

    class GroundModel : IBufferSource
    {
        public vec3 ModelSize { get; private set; }

        public GroundModel()
        {
            this.ModelSize = new vec3(xLength * 2, yLength * 2, zLength * 2);
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strNormal = "normal";
        private VertexBuffer normalBuffer;

        private IndexBuffer indexBuffer;

        #region IBufferable 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                return this.positionBuffer;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBuffer == null)
                {
                    this.normalBuffer = normals.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                return this.normalBuffer;
            }

            throw new NotImplementedException();
        }

        public IDrawCommand GetDrawCommand()
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
        private const float zLength = 0.5f;
        /// <summary>
        /// four vertexes.
        /// </summary>
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(+xLength, 0, +zLength),//  0
            new vec3(+xLength, 0, -zLength),//  1
            new vec3(-xLength, 0, -zLength),//  2
            new vec3(-xLength, 0, +zLength),//  3
        };
        /// <summary>
        /// four vertexes.
        /// </summary>
        private static readonly vec3[] normals = new vec3[]
        {
            new vec3(0, 1, 0),//  0
            new vec3(0, 1, 0),//  1
            new vec3(0, 1, 0),//  2
            new vec3(0, 1, 0),//  3
        };
    }
}
