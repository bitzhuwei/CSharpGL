using CSharpGL.OBJFile;
using System;

namespace CSharpGL.OBJFileViewer
{
    internal class OBJModelAdpater : IBufferable
    {
        private OBJModel model;

        public OBJModelAdpater(OBJModel model)
        {
            this.model = model;
        }

        public const string strin_Position = "in_Position";
        private VertexAttributeBufferPtr positionBufferRenderer;

        public const string strin_Color = "in_Color";
        private VertexAttributeBufferPtr colorBufferRenderer;

        public const string strin_Normal = "in_Normal";
        private VertexAttributeBufferPtr normalBufferRenderer;

        private IndexBufferPtr indexBufferRenderer;

        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            throw new NotImplementedException();
        }

        public IndexBufferPtr GetIndexBufferPtr()
        {
            throw new NotImplementedException();
        }

        public bool UsesZeroIndexBuffer()
        {
            return false;
        }
    }
}