using CSharpGL;
using System;

namespace ArmadaTank
{
    /// <summary>
    /// Represents a model in a *.dtm file.
    /// </summary>
    internal class DTMModel : IBufferable
    {
        /// <summary>
        /// Load model from dtm file.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static DTMModel Load(string filename)
        {
            throw new NotImplementedException();
        }

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
            throw new NotImplementedException();
        }
    }
}