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

        private VertexAttributeBuffer positionBuffer;
        private VertexAttributeBuffer colorBuffer;
        private VertexAttributeBuffer normalBuffer;

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
        public VertexAttributeBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    int length = 1;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(CubeModel.CubePosition), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
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
                    this.positionBuffer = bufferPtr;
                }
                return this.positionBuffer;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBuffer == null)
                {
                    int length = 1;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(CubeModel.CubeColor), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (CubeModel.CubeColor*)pointer;
                        array[0] = CubeModel.color;
                        bufferPtr.UnmapBuffer();
                    }
                    this.colorBuffer = bufferPtr;
                }
                return this.colorBuffer;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBuffer == null)
                {
                    int length = 1;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(CubeModel.CubeNormal), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (CubeModel.CubeNormal*)pointer;
                        array[0] = CubeModel.normal;
                        bufferPtr.UnmapBuffer();
                    }
                    this.normalBuffer = bufferPtr;
                }
                return this.normalBuffer;
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
                int length = CubeModel.index.Length;
                OneIndexBuffer bufferPtr = OneIndexBuffer.Create(BufferUsage.StaticDraw, DrawMode.Triangles, IndexElementType.UByte, length);
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

        /// <summary>
        ///
        /// </summary>
        public vec3 Lengths { get; private set; }
    }
}