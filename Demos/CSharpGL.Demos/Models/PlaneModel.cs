using System;

namespace CSharpGL.Demos
{
    /// <summary>
    /// 地面？
    /// </summary>
    internal class PlaneModel : IBufferable
    {
        //uint numberVertices = 4;
        //uint numberIndices = 6;
        private static float[] xy_vertices = { -1.0f, -1.0f, 0.0f, +1.0f, +1.0f, -1.0f, 0.0f, +1.0f, -1.0f, +1.0f, 0.0f, +1.0f, +1.0f, +1.0f, 0.0f, +1.0f };

        private static float[] xy_normals = { 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f };
        private static float[] xy_tangents = { 1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f };
        private static float[] xy_texCoords = { 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f };
        private static uint[] xy_indices = { 0, 1, 2, 1, 3, 2 };

        private float halfExtent;

        public PlaneModel(float halfExtend)
        {
            this.halfExtent = halfExtend;
        }

        public const string strPosition = "position";
        private VertexAttributeBufferPtr positionBufferPtr;
        public const string strNormal = "normal";
        private VertexAttributeBufferPtr normalBufferPtr;
        public const string strTangent = "tangent";
        private VertexAttributeBufferPtr tangentBufferPtr;
        public const string strTexCoord = "texCoord";
        private VertexAttributeBufferPtr texCoordBufferPtr;

        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<float>(
                        varNameInShader, VertexAttributeConfig.Vec4, BufferUsage.StaticDraw))
                    {
                        buffer.DoAlloc(xy_vertices.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < xy_vertices.Length; i++)
                            {
                                array[i] = xy_vertices[i] * this.halfExtent;
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
                    using (var buffer = new VertexAttributeBuffer<float>(
                        varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.DoAlloc(xy_normals.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < xy_normals.Length; i++)
                            {
                                array[i] = xy_normals[i];
                            }
                        }

                        normalBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return normalBufferPtr;
            }
            else if (bufferName == strTangent)
            {
                if (tangentBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<float>(
                        varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.DoAlloc(xy_tangents.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < xy_tangents.Length; i++)
                            {
                                array[i] = xy_tangents[i];
                            }
                        }

                        tangentBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return tangentBufferPtr;
            }
            else if (bufferName == strTexCoord)
            {
                if (texCoordBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<float>(
                        varNameInShader, VertexAttributeConfig.Vec2, BufferUsage.StaticDraw))
                    {
                        buffer.DoAlloc(xy_texCoords.Length);
                        unsafe
                        {
                            var array = (float*)buffer.Header.ToPointer();
                            for (int i = 0; i < xy_texCoords.Length; i++)
                            {
                                array[i] = xy_texCoords[i];
                            }
                        }

                        texCoordBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return texCoordBufferPtr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.Triangles, BufferUsage.StaticDraw))
                {
                    buffer.DoAlloc(xy_indices.Length);
                    unsafe
                    {
                        var array = (uint*)buffer.Header.ToPointer();
                        for (int i = 0; i < xy_indices.Length; i++)
                        {
                            array[i] = xy_indices[i];
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
    }
}