﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace StencilTest
{
    //
    /// <summary>
    /// 
    /// </summary>
    class StencilTestModel : IBufferSource
    {
        static readonly vec3[] positions = new vec3[] 
        {
            new vec3(1, -1, 0), new vec3(1, 1, 0), new vec3(-1, 1, 0), 
            new vec3(1, -1, 0), new vec3(-1, 1, 0), new vec3(-1, -1, 0) 
        };

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        private IndexBuffer indexBuffer;

        #region IBufferSource 成员

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
            else
            {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IndexBuffer> GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Triangles, 0, positions.Length);
            }

            return this.indexBuffer;
        }

        #endregion
    }
}
