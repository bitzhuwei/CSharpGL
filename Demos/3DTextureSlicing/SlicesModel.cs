using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace _3DTextureSlicing
{
    class SlicesModel : IBufferSource
    {
        public const string position = "position";
        private VertexBuffer slicesBuffer;

        private IndexBuffer indexBuffer;

        #region IBufferSource 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            throw new NotImplementedException();
        }

        public IndexBuffer GetIndexBuffer()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
