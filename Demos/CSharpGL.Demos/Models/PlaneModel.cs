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
                if (this.positionBufferPtr == null)
                {
                    int length = xy_vertices.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(float), length, VertexAttributeConfig.Vec4, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (float*)pointer;
                        for (int i = 0; i < xy_vertices.Length; i++)
                        {
                            array[i] = xy_vertices[i] * this.halfExtent;
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.positionBufferPtr = bufferPtr;
                }
                return this.positionBufferPtr;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBufferPtr == null)
                {
                    int length = xy_normals.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(float), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (float*)pointer;
                        for (int i = 0; i < xy_normals.Length; i++)
                        {
                            array[i] = xy_normals[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.normalBufferPtr = bufferPtr;
                }
                return this.normalBufferPtr;
            }
            else if (bufferName == strTangent)
            {
                if (this.tangentBufferPtr == null)
                {
                    int length = xy_tangents.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(float), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (float*)pointer;
                        for (int i = 0; i < xy_tangents.Length; i++)
                        {
                            array[i] = xy_tangents[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.tangentBufferPtr = bufferPtr;
                }
                return this.tangentBufferPtr;
            }
            else if (bufferName == strTexCoord)
            {
                if (this.texCoordBufferPtr == null)
                {
                    int length = xy_texCoords.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(float), length, VertexAttributeConfig.Vec2, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (float*)pointer;
                        for (int i = 0; i < xy_texCoords.Length; i++)
                        {
                            array[i] = xy_texCoords[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.texCoordBufferPtr = bufferPtr;
                }
                return this.texCoordBufferPtr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (this.indexBufferPtr == null)
            {
                int length = xy_indices.Length;
                OneIndexBufferPtr bufferPtr = OneIndexBufferPtr.Create(BufferUsage.StaticDraw, DrawMode.Triangles, IndexElementType.UInt, length);
                unsafe
                {
                    IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                    var array = (uint*)pointer;
                    for (int i = 0; i < xy_indices.Length; i++)
                    {
                        array[i] = xy_indices[i];
                    }
                    bufferPtr.UnmapBuffer();
                }
                this.indexBufferPtr = bufferPtr;
            }

            return this.indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return false; }
    }
}