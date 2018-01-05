using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DeferredShading
{
    class FullScreenModel : IBufferSource
    {
        private IndexBuffer indexBuffer;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            // no vertex attribute needed.
            throw new ArgumentException();
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
