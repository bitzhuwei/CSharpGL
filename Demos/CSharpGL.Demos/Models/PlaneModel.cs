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
        private VertexAttributeBuffer positionBuffer;
        public const string strNormal = "normal";
        private VertexAttributeBuffer normalBuffer;
        public const string strTangent = "tangent";
        private VertexAttributeBuffer tangentBuffer;
        public const string strTexCoord = "texCoord";
        private VertexAttributeBuffer texCoordBuffer;

        public VertexAttributeBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    int length = xy_vertices.Length;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(float), length, VertexAttributeConfig.Vec4, BufferUsage.StaticDraw, varNameInShader);
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
                    this.positionBuffer = bufferPtr;
                }
                return this.positionBuffer;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBuffer == null)
                {
                    int length = xy_normals.Length;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(float), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
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
                    this.normalBuffer = bufferPtr;
                }
                return this.normalBuffer;
            }
            else if (bufferName == strTangent)
            {
                if (this.tangentBuffer == null)
                {
                    int length = xy_tangents.Length;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(float), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
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
                    this.tangentBuffer = bufferPtr;
                }
                return this.tangentBuffer;
            }
            else if (bufferName == strTexCoord)
            {
                if (this.texCoordBuffer == null)
                {
                    int length = xy_texCoords.Length;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(float), length, VertexAttributeConfig.Vec2, BufferUsage.StaticDraw, varNameInShader);
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
                    this.texCoordBuffer = bufferPtr;
                }
                return this.texCoordBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                int length = xy_indices.Length;
                OneIndexBuffer bufferPtr = OneIndexBuffer.Create(BufferUsage.StaticDraw, DrawMode.Triangles, IndexElementType.UInt, length);
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
                this.indexBuffer = bufferPtr;
            }

            return this.indexBuffer;
        }

        private IndexBuffer indexBuffer = null;

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return false; }
    }
}