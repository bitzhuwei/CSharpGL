using System;
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
        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBufferPtr == null)
                {
                    int length = TetrahedronModel.position.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < TetrahedronModel.position.Length; i++)
                        {
                            array[i] = TetrahedronModel.position[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.positionBufferPtr = bufferPtr;
                }
                return this.positionBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBufferPtr == null)
                {
                    int length = TetrahedronModel.color.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < TetrahedronModel.color.Length; i++)
                        {
                            array[i] = TetrahedronModel.color[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.colorBufferPtr = bufferPtr;
                }
                return this.colorBufferPtr;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBufferPtr == null)
                {
                    int length = TetrahedronModel.normal.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < TetrahedronModel.normal.Length; i++)
                        {
                            array[i] = TetrahedronModel.normal[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.normalBufferPtr = bufferPtr;
                }
                return this.normalBufferPtr;
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
                int length = TetrahedronModel.index.Length;
                OneIndexBufferPtr bufferPtr = OneIndexBufferPtr.Create(BufferUsage.StaticDraw, DrawMode.Triangles, IndexElementType.UByte, length);
                unsafe
                {
                    IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                    var array = (byte*)pointer;
                    for (int i = 0; i < TetrahedronModel.index.Length; i++)
                    {
                        array[i] = TetrahedronModel.index[i];
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

        /// <summary>
        ///
        /// </summary>
        public vec3 Lengths { get { return new vec3(1.73205078f, 1.63299322f, 2.0f); } }
    }
}