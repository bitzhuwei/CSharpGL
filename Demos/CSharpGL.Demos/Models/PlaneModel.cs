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
        private VertexBuffer positionBuffer;
        public const string strNormal = "normal";
        private VertexBuffer normalBuffer;
        public const string strTangent = "tangent";
        private VertexBuffer tangentBuffer;
        public const string strTexCoord = "texCoord";
        private VertexBuffer texCoordBuffer;

        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    int length = xy_vertices.Length;
                    VertexBuffer buffer = VertexBuffer.Create(typeof(float), length, VBOConfig.Vec4, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (float*)pointer;
                        for (int i = 0; i < xy_vertices.Length; i++)
                        {
                            array[i] = xy_vertices[i] * this.halfExtent;
                        }
                        buffer.UnmapBuffer();
                    }
                    this.positionBuffer = buffer;
                }
                return this.positionBuffer;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBuffer == null)
                {
                    //int length = xy_normals.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(float), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    //unsafe
                    //{
                    //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    //    var array = (float*)pointer;
                    //    for (int i = 0; i < xy_normals.Length; i++)
                    //    {
                    //        array[i] = xy_normals[i];
                    //    }
                    //    buffer.UnmapBuffer();
                    //}
                    //this.normalBuffer = buffer;
                    this.normalBuffer = xy_normals.GetVertexBuffer(VBOConfig.Vec3, varNameInShader, BufferUsage.StaticDraw);
                }
                return this.normalBuffer;
            }
            else if (bufferName == strTangent)
            {
                if (this.tangentBuffer == null)
                {
                    //int length = xy_tangents.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(float), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    //unsafe
                    //{
                    //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    //    var array = (float*)pointer;
                    //    for (int i = 0; i < xy_tangents.Length; i++)
                    //    {
                    //        array[i] = xy_tangents[i];
                    //    }
                    //    buffer.UnmapBuffer();
                    //}
                    //this.tangentBuffer = buffer;
                    this.tangentBuffer = xy_tangents.GetVertexBuffer(VBOConfig.Vec3, varNameInShader, BufferUsage.StaticDraw);
                }
                return this.tangentBuffer;
            }
            else if (bufferName == strTexCoord)
            {
                if (this.texCoordBuffer == null)
                {
                    //int length = xy_texCoords.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(float), length, VBOConfig.Vec2, BufferUsage.StaticDraw, varNameInShader);
                    //unsafe
                    //{
                    //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    //    var array = (float*)pointer;
                    //    for (int i = 0; i < xy_texCoords.Length; i++)
                    //    {
                    //        array[i] = xy_texCoords[i];
                    //    }
                    //    buffer.UnmapBuffer();
                    //}
                    //this.texCoordBuffer = buffer;
                    this.texCoordBuffer = xy_texCoords.GetVertexBuffer(VBOConfig.Vec2, varNameInShader, BufferUsage.StaticDraw);
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
                //int length = xy_indices.Length;
                //OneIndexBuffer buffer = CSharpGL.Buffer.Create(IndexElementType.UInt, length, DrawMode.Triangles, BufferUsage.StaticDraw);
                //unsafe
                //{
                //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                //    var array = (uint*)pointer;
                //    for (int i = 0; i < xy_indices.Length; i++)
                //    {
                //        array[i] = xy_indices[i];
                //    }
                //    buffer.UnmapBuffer();
                //}
                //this.indexBuffer = buffer;
                this.indexBuffer = xy_indices.GetOneIndexBuffer(DrawMode.Triangles, BufferUsage.StaticDraw);
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