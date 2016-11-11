using System;
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

        private VertexAttributeBuffer positionBuffer;
        private VertexAttributeBuffer normalBuffer;
        private VertexAttributeBuffer colorBuffer;
        private VertexAttributeBuffer uvBuffer;
        private IndexBuffer indexBuffer = null;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public VertexAttributeBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    int length = model.positions.Length;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < model.positions.Length; i++)
                        {
                            array[i] = model.positions[i];
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
                    int length = model.normals.Length;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < model.normals.Length; i++)
                        {
                            array[i] = model.normals[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.normalBuffer = bufferPtr;
                }
                return this.normalBuffer;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBuffer == null)
                {
                    int length = model.colors.Length;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < model.colors.Length; i++)
                        {
                            array[i] = model.colors[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.colorBuffer = bufferPtr;
                }
                return this.colorBuffer;
            }
            else if (bufferName == strUV)
            {
                if (this.uvBuffer == null)
                {
                    int length = model.uv.Length;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(vec2), length, VertexAttributeConfig.Vec2, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec2*)pointer;
                        for (int i = 0; i < model.uv.Length; i++)
                        {
                            array[i] = model.uv[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.uvBuffer = bufferPtr;
                }
                return this.uvBuffer;
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
        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                int length = model.indexes.Length;
                if (model.positions.Length < byte.MaxValue)
                {
                    OneIndexBuffer bufferPtr = OneIndexBuffer.Create(BufferUsage.StaticDraw, DrawMode.TriangleStrip, IndexElementType.UByte, length);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (byte*)pointer;
                        for (int i = 0; i < model.indexes.Length; i++)
                        {
                            if (model.indexes[i] == uint.MaxValue)
                            { array[i] = byte.MaxValue; }
                            else
                            { array[i] = (byte)model.indexes[i]; }
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.indexBuffer = bufferPtr;
                }
                else if (model.positions.Length < ushort.MaxValue)
                {
                    OneIndexBuffer bufferPtr = OneIndexBuffer.Create(BufferUsage.StaticDraw, DrawMode.TriangleStrip, IndexElementType.UShort, length);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (ushort*)pointer;
                        for (int i = 0; i < model.indexes.Length; i++)
                        {
                            if (model.indexes[i] == uint.MaxValue)
                            { array[i] = ushort.MaxValue; }
                            else
                            { array[i] = (ushort)model.indexes[i]; }
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.indexBuffer = bufferPtr;
                }
                else
                {
                    OneIndexBuffer bufferPtr = OneIndexBuffer.Create(BufferUsage.StaticDraw, DrawMode.TriangleStrip, IndexElementType.UInt, length);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (uint*)pointer;
                        for (int i = 0; i < model.indexes.Length; i++)
                        {
                            array[i] = model.indexes[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.indexBuffer = bufferPtr;
                }
            }

            return indexBuffer;
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