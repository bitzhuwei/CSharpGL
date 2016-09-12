namespace CSharpGL
{
    /// <summary>
    /// Tetrahedron.
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_tetrahedron.jpg
    /// <para>Uses <see cref="OneIndexBufferPtr"/></para>
    /// </summary>
    public class Tetrahedron : IBufferable
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
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public VertexAttributeBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Create(TetrahedronModel.position.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < TetrahedronModel.position.Length; i++)
                            {
                                array[i] = TetrahedronModel.position[i];
                            }
                        }

                        positionBufferPtr = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
                    }
                }
                return positionBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (colorBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Create(TetrahedronModel.color.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < TetrahedronModel.color.Length; i++)
                            {
                                array[i] = TetrahedronModel.color[i];
                            }
                        }

                        colorBufferPtr = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
                    }
                }
                return colorBufferPtr;
            }
            else if (bufferName == strNormal)
            {
                if (normalBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Create(TetrahedronModel.normal.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < TetrahedronModel.normal.Length; i++)
                            {
                                array[i] = TetrahedronModel.normal[i];
                            }
                        }

                        normalBufferPtr = buffer.GetBufferPtr() as VertexAttributeBufferPtr;
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
        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new OneIndexBuffer<byte>(DrawMode.Triangles, BufferUsage.StaticDraw))
                {
                    buffer.Create(TetrahedronModel.index.Length);
                    unsafe
                    {
                        var array = (byte*)buffer.Header.ToPointer();
                        for (int i = 0; i < TetrahedronModel.index.Length; i++)
                        {
                            array[i] = TetrahedronModel.index[i];
                        }
                    }

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
        public bool UsesZeroIndexBufferPtr() { return false; }

        /// <summary>
        /// 
        /// </summary>
        public vec3 Lengths { get { return new vec3(1.73205078f, 1.63299322f, 2.0f); } }
    }
}