namespace CSharpGL.Demos
{
    internal class TexturedRectangleModel : IBufferable
    {
        public const string strPosition = "position";
        private PropertyBufferPtr positionBufferPtr;

        private static readonly float[] positions =
        {
		    -0.5f, -0.5f, 0.0f,
		    0.5f, -0.5f, 0.0f,
		    -0.5f,  0.5f, 0.0f,
		    0.5f,  0.5f, 0.0f,
        };

        public const string strTexCoord = "texCoord";
        private PropertyBufferPtr texCoordBufferPtr;

        private static readonly float[] texCoords =
        {
            0,0,
            1,0,
            0,1,
            1,1,
        };

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<float>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.DynamicDraw))
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
                        positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return positionBufferPtr;
            }
            else if (bufferName == strTexCoord)
            {
                if (texCoordBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<float>(varNameInShader, 2, OpenGL.GL_FLOAT, BufferUsage.DynamicDraw))
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
                        texCoordBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
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
        /// Uses <see cref="ZeroIndexBufferPtr"/> or <see cref="OneIndexBufferPtr"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBufferPtr() { return true; }

    }
}