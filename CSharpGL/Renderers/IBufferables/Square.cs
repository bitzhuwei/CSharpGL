namespace CSharpGL
{
    /// <summary>
    /// Square.
    /// <para>Uses <see cref="ZeroIndexBuffer"/></para>
    /// </summary>
    public class Square : IBufferable
    {
        private SquareModel model;

        /// <summary>
        /// Square.
        /// </summary>
        public Square()
        {
            this.model = new SquareModel();
        }

        /// <summary>
        ///
        /// </summary>
        public const string strPosition = "position";

        /// <summary>
        ///
        /// </summary>
        public const string strTexCoord = "texCoord";

        private VertexAttributeBufferPtr positionBufferPtr;
        private VertexAttributeBufferPtr uvBufferPtr;
        private IndexBufferPtr indexBufferPtr;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.DoAlloc(model.positions.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.positions.Length; i++)
                            {
                                array[i] = model.positions[i];
                            }
                        }
                        positionBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return positionBufferPtr;
            }
            else if (bufferName == strTexCoord)
            {
                if (uvBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec2>(varNameInShader, VertexAttributeConfig.Vec2, BufferUsage.StaticDraw))
                    {
                        buffer.DoAlloc(model.texCoords.Length);
                        unsafe
                        {
                            var array = (vec2*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.texCoords.Length; i++)
                            {
                                array[i] = model.texCoords[i];
                            }
                        }
                        uvBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return uvBufferPtr;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(this.model.GetDrawModel(), 0, this.model.positions.Length))
                {
                    indexBufferPtr = buffer.GetBufferPtr();
                }
            }

            return indexBufferPtr;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }
    }
}