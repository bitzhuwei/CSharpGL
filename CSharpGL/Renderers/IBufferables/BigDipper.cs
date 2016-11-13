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

        private VertexBuffer positionBuffer;
        private VertexBuffer colorBuffer;

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
        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == position)
            {
                if (this.positionBuffer == null)
                {
                    //int length = BigDipperModel.positions.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    //unsafe
                    //{
                    //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    //    var array = (vec3*)pointer.ToPointer();
                    //    for (int i = 0; i < BigDipperModel.positions.Length; i++)
                    //    {
                    //        array[i] = BigDipperModel.positions[i];
                    //    }
                    //    buffer.UnmapBuffer();
                    //}
                    //this.positionBuffer = buffer;
                    // another way to do this:
                    this.positionBuffer = BigDipperModel.positions.GenVertexBuffer(VBOConfig.Vec3, varNameInShader, BufferUsage.StaticDraw);
                }
                return this.positionBuffer;
            }
            else if (bufferName == color)
            {
                if (this.colorBuffer == null)
                {
                    //int length = BigDipperModel.colors.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    //unsafe
                    //{
                    //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    //    var array = (vec3*)pointer.ToPointer();
                    //    for (int i = 0; i < BigDipperModel.colors.Length; i++)
                    //    {
                    //        array[i] = BigDipperModel.colors[i];
                    //    }
                    //    buffer.UnmapBuffer();
                    //}
                    //this.colorBuffer = buffer;
                    // another way to do this:
                    this.colorBuffer = BigDipperModel.colors.GenVertexBuffer(VBOConfig.Vec3, varNameInShader, BufferUsage.StaticDraw);
                }
                return this.colorBuffer;
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
        public IndexBuffer GetIndexBuffer()
        {
            if (indexBuffer == null)
            {
                ZeroIndexBuffer buffer = ZeroIndexBuffer.Create(DrawMode.LineStrip, 0, BigDipperModel.positions.Length);

                this.indexBuffer = buffer;
            }

            return indexBuffer;
        }

        private IndexBuffer indexBuffer = null;

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