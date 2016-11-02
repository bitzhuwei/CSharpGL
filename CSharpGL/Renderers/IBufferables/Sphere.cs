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
                if (this.positionBufferPtr == null)
                {
                    int length = model.positions.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
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
                    this.positionBufferPtr = bufferPtr;
                }
                return this.positionBufferPtr;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBufferPtr == null)
                {
                    int length = model.normals.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
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
                    this.normalBufferPtr = bufferPtr;
                }
                return this.normalBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBufferPtr == null)
                {
                    int length = model.colors.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
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
                    this.colorBufferPtr = bufferPtr;
                }
                return this.colorBufferPtr;
            }
            else if (bufferName == strUV)
            {
                if (this.uvBufferPtr == null)
                {
                    int length = model.uv.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec2), length, VertexAttributeConfig.Vec2, BufferUsage.StaticDraw, varNameInShader);
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
                    this.uvBufferPtr = bufferPtr;
                }
                return this.uvBufferPtr;
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
            if (this.indexBufferPtr == null)
            {
                int length = model.indexes.Length;
                if (model.positions.Length < byte.MaxValue)
                {
                    OneIndexBufferPtr bufferPtr = OneIndexBufferPtr.Create(BufferUsage.StaticDraw, DrawMode.TriangleStrip, IndexElementType.UByte, length);
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
                    this.indexBufferPtr = bufferPtr;
                }
                else if (model.positions.Length < ushort.MaxValue)
                {
                    OneIndexBufferPtr bufferPtr = OneIndexBufferPtr.Create(BufferUsage.StaticDraw, DrawMode.TriangleStrip, IndexElementType.UShort, length);
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
                    this.indexBufferPtr = bufferPtr;
                }
                else
                {
                    OneIndexBufferPtr bufferPtr = OneIndexBufferPtr.Create(BufferUsage.StaticDraw, DrawMode.TriangleStrip, IndexElementType.UInt, length);
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
                    this.indexBufferPtr = bufferPtr;
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