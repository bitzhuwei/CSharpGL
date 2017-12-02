using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace NormalMapping
{
    class NormalMappingModel : IBufferSource
    {
        private Teapot teapot = new Teapot();

        public const string strPosition = "position";
        public const string strTexCoord = "texCoord";
        public const string strNormal = "normal";
        public const string strTangent = "tangent";

        public NormalMappingModel()
        {
        }

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
