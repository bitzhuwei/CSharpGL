using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace GPURaycasting
{
    class RaycastingModel : IBufferSource
    {
        public const string position = "position";
        private VertexBuffer slicesBuffer;

        private IndexBuffer indexBuffer;

        /// <summary>
        /// unit cube vertices 
        /// </summary>
        private static readonly vec3[] vertices = new vec3[8]
        {	
            new vec3(-0.5f,-0.5f,-0.5f),
            new vec3( 0.5f,-0.5f,-0.5f),
            new vec3( 0.5f, 0.5f,-0.5f),
            new vec3(-0.5f, 0.5f,-0.5f),
            new vec3(-0.5f,-0.5f, 0.5f),
            new vec3( 0.5f,-0.5f, 0.5f),
            new vec3( 0.5f, 0.5f, 0.5f),
            new vec3(-0.5f, 0.5f, 0.5f)
        };

        //unit cube indices
        private static readonly ushort[] cubeIndices = new ushort[36] { 0, 5, 4, 5, 0, 1, 3, 7, 6, 3, 6, 2, 7, 4, 6, 6, 4, 5, 2, 1, 3, 3, 1, 0, 3, 0, 7, 7, 0, 4, 6, 5, 2, 2, 5, 1 };

        #region IBufferSource 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == position)
            {
                if (this.slicesBuffer == null)
                {
                    this.slicesBuffer = vertices.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                return this.slicesBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                this.indexBuffer = cubeIndices.GenIndexBuffer(DrawMode.Triangles, BufferUsage.StaticDraw);
            }

            return this.indexBuffer;
        }

        #endregion
    }
}
