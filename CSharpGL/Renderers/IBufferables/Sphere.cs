namespace CSharpGL
{
    /// <summary>
    /// Sphere.
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_sphere.jpg
    /// <para>Uses <see cref="OneIndexBuffer"/></para>
    /// </summary>
    public class Sphere : IBufferable
    {
        private SphereModel model;

        /// <summary>
        /// 一个球体的模型。
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="latitudeParts">用纬线把地球切割为几块。</param>
        /// <param name="longitudeParts">用经线把地球切割为几块。</param>
        public Sphere(float radius = 1.0f, int latitudeParts = 10, int longitudeParts = 40)
        {
            this.model = new SphereModel(radius, latitudeParts, longitudeParts);
            this.Lengths = new vec3(radius * 2, radius * 2, radius * 2);
        }

        /// <summary>
        ///
        /// </summary>
        public const string strPosition = "position";

        /// <summary>
        ///
        /// </summary>
        public const string strNormal = "normal";

        /// <summary>
        ///
        /// </summary>
        public const string strColor = "color";

        /// <summary>
        ///
        /// </summary>
        public const string strUV = "uv";

        private VertexAttributeBufferPtr positionBufferPtr;
        private VertexAttributeBufferPtr normalBufferPtr;
        private VertexAttributeBufferPtr colorBufferPtr;
        private VertexAttributeBufferPtr uvBufferPtr;
        private IndexBufferPtr indexBufferPtr = null;

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
                        buffer.Alloc(model.positions.Length);
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
            else if (bufferName == strNormal)
            {
                if (normalBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.normals.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.normals.Length; i++)
                            {
                                array[i] = model.normals[i];
                            }
                        }
                        normalBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return normalBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (colorBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.colors.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.colors.Length; i++)
                            {
                                array[i] = model.colors[i];
                            }
                        }
                        colorBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return colorBufferPtr;
            }
            else if (bufferName == strUV)
            {
                if (uvBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec2>(varNameInShader, VertexAttributeConfig.Vec2, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.uv.Length);
                        unsafe
                        {
                            var array = (vec2*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.uv.Length; i++)
                            {
                                array[i] = model.uv[i];
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
                if (model.positions.Length < byte.MaxValue)
                {
                    using (var buffer = new OneIndexBuffer(IndexElementType.UByte, DrawMode.TriangleStrip, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.indexes.Length);
                        unsafe
                        {
                            var indexArray = (byte*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.indexes.Length; i++)
                            {
                                if (model.indexes[i] == uint.MaxValue)
                                { indexArray[i] = byte.MaxValue; }
                                else
                                { indexArray[i] = (byte)model.indexes[i]; }
                            }
                        }

                        indexBufferPtr = buffer.GetBufferPtr();
                    }
                }
                else if (model.positions.Length < ushort.MaxValue)
                {
                    using (var buffer = new OneIndexBuffer(IndexElementType.UShort, DrawMode.TriangleStrip, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.indexes.Length);
                        unsafe
                        {
                            var indexArray = (ushort*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.indexes.Length; i++)
                            {
                                if (model.indexes[i] == uint.MaxValue)
                                { indexArray[i] = ushort.MaxValue; }
                                else
                                { indexArray[i] = (ushort)model.indexes[i]; }
                            }
                        }

                        indexBufferPtr = buffer.GetBufferPtr();
                    }
                }
                else
                {
                    using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.TriangleStrip, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.indexes.Length);
                        unsafe
                        {
                            var indexArray = (uint*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.indexes.Length; i++)
                            {
                                indexArray[i] = model.indexes[i];
                            }
                        }

                        indexBufferPtr = buffer.GetBufferPtr();
                    }
                }
            }

            return indexBufferPtr;
        }

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