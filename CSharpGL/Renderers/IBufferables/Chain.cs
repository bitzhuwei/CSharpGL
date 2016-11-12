using System;
using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// 链条。若干个点用直线连接起来。
    /// <para>使用<see cref="ZeroIndexBuffer"/></para>
    /// </summary>
    public class Chain : IBufferable
    {
        private ChainModel model;

        /// <summary>
        /// 链条。若干个点用直线连接起来。
        /// </summary>
        /// <param name="pointCount">有多少个点</param>
        /// <param name="length">点的范围（长度）</param>
        /// <param name="width">点的范围（宽度）</param>
        /// <param name="height">点的范围（高度）</param>
        public Chain(int pointCount = 10, int length = 5, int width = 5, int height = 5)
        {
            this.model = new ChainModel(pointCount, length, width, height);
            this.Lengths = model.Lengths;
        }

        /// <summary>
        ///
        /// </summary>
        public const string position = "position";
        private VertexBuffer positionBuffer;

        /// <summary>
        ///
        /// </summary>
        public const string color = "color";
        private VertexBuffer colorBuffer;

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
                    int length = model.Positions.Length;
                    VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < model.Positions.Length; i++)
                        {
                            array[i] = model.Positions[i];
                        }
                        buffer.UnmapBuffer();
                    }
                    this.positionBuffer = buffer;
                }
                return this.positionBuffer;
            }
            else if (bufferName == color)
            {
                if (this.colorBuffer == null)
                {
                    int length = model.Colors.Length;
                    VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < model.Colors.Length; i++)
                        {
                            array[i] = model.Colors[i];
                        }
                        buffer.UnmapBuffer();
                    }
                    this.colorBuffer = buffer;
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
            if (this.indexBuffer == null)
            {
                int vertexCount = this.model.Positions.Length;
                ZeroIndexBuffer buffer = ZeroIndexBuffer.Create(DrawMode.LineStrip, 0, vertexCount);
                this.indexBuffer = buffer;
            }

            return this.indexBuffer;
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