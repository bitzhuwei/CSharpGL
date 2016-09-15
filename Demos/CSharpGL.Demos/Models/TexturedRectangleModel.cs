namespace CSharpGL.Demos
{
    internal class TexturedRectangleModel : IBufferable
    {
        public const string strPosition = "position";
        private VertexAttributeBufferPtr positionBufferPtr;

        private static readonly float[] positions =
        {
		    -0.5f, -0.5f, 0.0f,
		    0.5f, -0.5f, 0.0f,
		    -0.5f,  0.5f, 0.0f,
		    0.5f,  0.5f, 0.0f,
        };

        public const string strTexCoord = "texCoord";
        private VertexAttributeBufferPtr texCoordBufferPtr;

        private static readonly float[] texCoords =
        {
            0,0,
            1,0,
            0,1,
            1,1,
        };

        public VertexAttributeBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
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
                        positionBufferPtr = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
                    }
                }
                return positionBufferPtr;
            }
            else if (bufferName == strTexCoord)
            {
                if (texCoordBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<float>(varNameInShader, VertexAttributeConfig.Vec2, BufferUsage.DynamicDraw))
                    {
                        buffer.Create(texCoords.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < texCoords.Length; i++)
                            {
                                array[i] = texCoords[i];
                            }
                        }
                        texCoordBufferPtr = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
                    }
                }
                return texCoordBufferPtr;
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
        /// UsesUses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }

    }
}