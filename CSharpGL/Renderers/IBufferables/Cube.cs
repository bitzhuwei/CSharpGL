namespace CSharpGL
{
    /// <summary>
    /// Cube.
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_CubeModel.jpg
    /// <para>Uses <see cref="OneIndexBuffer"/></para>
    /// </summary>
    public class Cube : IBufferable
    {
        /// <summary>
        ///
        /// </summary>
        public const string strPosition = "position";

        /// <summary>
        ///
        /// </summary>
        public const string strColor = "color";

        /// <summary>
        ///
        /// </summary>
        public const string strNormal = "normal";

        private VertexAttributeBufferPtr positionBufferPtr;
        private VertexAttributeBufferPtr colorBufferPtr;
        private VertexAttributeBufferPtr normalBufferPtr;

        /// <summary>
        ///
        /// </summary>
        public Cube()
            : this(new vec3(2, 2, 2))
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lengths"></param>
        public Cube(vec3 lengths)
        {
            this.Lengths = lengths;
        }

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
                    using (var buffer = new VertexAttributeBuffer<CubeModel.CubePosition>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.DoAlloc(1);
                        unsafe
                        {
                            var positionArray = (CubeModel.CubePosition*)buffer.Header.ToPointer();
                            positionArray[0] = CubeModel.position;
                        }
                        unsafe
                        {
                            var positionArray = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < 24; i++)
                            {
                                positionArray[i] = positionArray[i] / 2 * Lengths;
                            }
                        }

                        positionBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return positionBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (colorBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<CubeModel.CubeColor>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.DoAlloc(1);
                        unsafe
                        {
                            var colorArray = (CubeModel.CubeColor*)buffer.Header.ToPointer();
                            colorArray[0] = CubeModel.color;
                        }

                        colorBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return colorBufferPtr;
            }
            else if (bufferName == strNormal)
            {
                if (normalBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<CubeModel.CubeNormal>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.DoAlloc(1);
                        unsafe
                        {
                            var normalArray = (CubeModel.CubeNormal*)buffer.Header.ToPointer();
                            normalArray[0] = CubeModel.normal;
                        }

                        normalBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return normalBufferPtr;
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
                using (var buffer = new OneIndexBuffer(IndexElementType.UByte, DrawMode.Triangles, BufferUsage.StaticDraw))
                {
                    buffer.DoAlloc(CubeModel.index.Length);
                    unsafe
                    {
                        var array = (byte*)buffer.Header.ToPointer();
                        for (int i = 0; i < CubeModel.index.Length; i++)
                        {
                            array[i] = CubeModel.index[i];
                        }
                    }

                    indexBufferPtr = buffer.GetBufferPtr();
                }
            }

            return indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return false; }

        /// <summary>
        ///
        /// </summary>
        public vec3 Lengths { get; private set; }
    }
}