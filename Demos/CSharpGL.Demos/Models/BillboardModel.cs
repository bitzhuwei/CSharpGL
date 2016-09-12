namespace CSharpGL.Demos
{
    internal class BillboardModel : IBufferable
    {
        public const string strPosition = "position";
        private VertexAttributeBufferPtr positionBuffer;

        private static readonly float[] positions =
        {
		    -0.5f, -0.5f, 0.0f,
		    0.5f, -0.5f, 0.0f,
		    -0.5f,  0.5f, 0.0f,
		    0.5f,  0.5f, 0.0f,
        };

        public VertexAttributeBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBuffer == null)
                {
                    using (var buffer = new VertexAttributeBuffer<float>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.DynamicDraw))
                    {
                        buffer.Create(positions.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < positions.Length; i++)
                            {
                                array[i] = positions[i];
                            }
                        }
                        positionBuffer = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
                    }
                }
                return positionBuffer;
            }
            else
            {
                return null;
            }
        }

        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(DrawMode.TriangleStrip, 0, 4))
                {
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;
        /// <summary>
        /// Uses <see cref="ZeroIndexBufferPtr"/> or <see cref="OneIndexBufferPtr"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBufferPtr() { return true; }

    }
}