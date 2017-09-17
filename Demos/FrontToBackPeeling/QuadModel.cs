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
