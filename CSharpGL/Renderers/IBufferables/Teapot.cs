namespace CSharpGL
{
    /// <summary>
    /// Teapot.
    /// <para>Uses <see cref="OneIndexBuffer"/></para>
    /// </summary>
    public class Teapot : IBufferable
    {
        /// <summary>
        ///
        /// </summary>
        public Teapot()
        {
            this.model = new TeapotModel();
        }

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

        private TeapotModel model;
        private VertexAttributeBufferPtr positionBufferPtr;
        private VertexAttributeBufferPtr colorBufferPtr;
        private VertexAttributeBufferPtr normalBufferPtr;

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
                    using (var buffer = new VertexAttributeBuffer<float>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        float[] positions = model.GetPositions();
                        //List<vec3> pos = new List<vec3>();
                        //for (int i = 0; i < positions.Length; i += 3)
                        //{
                        //    pos.Add(new vec3(positions[i], positions[i + 1], positions[i + 2]));
                        //}
                        //IBoundingBox box = pos.Move2Center();
                        //vec3 lengths = box.MaxPosition - box.MinPosition;
                        buffer.DoAlloc(positions.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < positions.Length; i++)
                            {
                                array[i] = positions[i];
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
                    using (var buffer = new VertexAttributeBuffer<float>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        float[] normals = model.GetNormals();
                        buffer.DoAlloc(normals.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < normals.Length; i++)
                            {
                                array[i] = normals[i];
                            }
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
                    using (var buffer = new VertexAttributeBuffer<float>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        float[] normals = model.GetNormals();
                        buffer.DoAlloc(normals.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < normals.Length; i++)
                            {
                                array[i] = normals[i];
                            }
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
                using (var buffer = new OneIndexBuffer(IndexElementType.UShort, DrawMode.Triangles, BufferUsage.StaticDraw))
                {
                    ushort[] faces = model.GetFaces();
                    buffer.DoAlloc(faces.Length);
                    unsafe
                    {
                        var array = (ushort*)buffer.Header.ToPointer();
                        for (int i = 0; i < faces.Length; i++)
                        {
                            array[i] = (ushort)(faces[i] - 1);
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
        public vec3 Lengths { get { return new vec3(6.42963028f, 3.15f, 4.0f); } }
    }
}