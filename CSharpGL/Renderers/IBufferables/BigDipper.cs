using System;

namespace CSharpGL
{
    /// <summary>
    /// 北斗七星
    /// <para>使用<see cref="ZeroIndexBuffer"/></para>
    /// </summary>
    public class BigDipper : IBufferable
    {
        /// <summary>
        ///
        /// </summary>
        public const string position = "position";

        /// <summary>
        ///
        /// </summary>
        public const string color = "color";

        private VertexAttributeBuffer positionBufferPtr;
        private VertexAttributeBuffer colorBufferPtr;

        /// <summary>
        ///
        /// </summary>
        public BigDipper()
        {
            this.Lengths = BigDipperModel.Length;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public VertexAttributeBuffer GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == position)
            {
                if (positionBufferPtr == null)
                {
                    int length = BigDipperModel.positions.Length;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer.ToPointer();
                        for (int i = 0; i < BigDipperModel.positions.Length; i++)
                        {
                            array[i] = BigDipperModel.positions[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.positionBufferPtr = bufferPtr;
                }
                return this.positionBufferPtr;
            }
            else if (bufferName == color)
            {
                if (colorBufferPtr == null)
                {
                    int length = BigDipperModel.colors.Length;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer.ToPointer();
                        for (int i = 0; i < BigDipperModel.colors.Length; i++)
                        {
                            array[i] = BigDipperModel.colors[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.colorBufferPtr = bufferPtr;
                }
                return this.colorBufferPtr;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IndexBuffer GetIndexBufferPtr()
        {
            if (indexBufferPtr == null)
            {
                ZeroIndexBuffer bufferPtr = ZeroIndexBuffer.Create(DrawMode.LineStrip, 0, BigDipperModel.positions.Length);

                this.indexBufferPtr = bufferPtr;
            }

            return indexBufferPtr;
        }

        private IndexBuffer indexBufferPtr = null;

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }

        /// <summary>
        ///
        /// </summary>
        public vec3 Lengths { get; private set; }
    }
}