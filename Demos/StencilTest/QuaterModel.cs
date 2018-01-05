using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace StencilTest
{
    /// <summary>
    /// Displays on quater of canvas.
    /// </summary>
    class QuaterModel : IBufferSource
    {
        private IndexBuffer indexBuffer;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            throw new Exception("vertex buffer is not needed.");
        }

        public IEnumerable<IndexBuffer> GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Quads, 0, 4);
            }

            return this.indexBuffer;
        }

        #endregion
    }
}
