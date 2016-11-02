using System;
namespace CSharpGL
{
    /// <summary>
    /// Cube.
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_CubeModel.jpg
    /// <para>Uses <see cref="OneIndexBuffer"/></para>
    /// </summary>
    public class Cube : IBufferable
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
        public Cube()
            : this(new vec3(2, 2, 2))
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lengths"></param>
        public Cube(vec3 lengths)
        {
            this.Lengths = lengths;
        }

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
                    int length = 1;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(CubeModel.CubePosition), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.ReadWrite);
                        {
                            var array = (CubeModel.CubePosition*)pointer;
                            array[0] = CubeModel.position;
                        }
                        {
                            var array = (vec3*)pointer;
                            for (int i = 0; i < 24; i++)
                            {
                                array[i] = array[i] / 2 * Lengths;
                            }
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
                    int length = 1;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(CubeModel.CubeColor), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (CubeModel.CubeColor*)pointer;
                        array[0] = CubeModel.color;
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
                    int length = 1;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(CubeModel.CubeNormal), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (CubeModel.CubeNormal*)pointer;
                        array[0] = CubeModel.normal;
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
                int length = CubeModel.index.Length;
                OneIndexBufferPtr bufferPtr = OneIndexBufferPtr.Create(BufferUsage.StaticDraw, DrawMode.Triangles, IndexElementType.UByte, length);
                unsafe
                {
                    IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                    var array = (byte*)pointer;
                    for (int i = 0; i < CubeModel.index.Length; i++)
                    {
                        array[i] = CubeModel.index[i];
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
        public vec3 Lengths { get; private set; }
    }
}