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
        private VertexAttributeBufferPtr positionBufferPtr;

        /// <summary>
        ///
        /// </summary>
        public const string color = "color";
        private VertexAttributeBufferPtr colorBufferPtr;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == position)
            {
                if (this.positionBufferPtr == null)
                {
                    int length = model.Positions.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < model.Positions.Length; i++)
                        {
                            array[i] = model.Positions[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.positionBufferPtr = bufferPtr;
                }
                return this.positionBufferPtr;
            }
            else if (bufferName == color)
            {
                if (this.colorBufferPtr == null)
                {
                    int length = model.Colors.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < model.Colors.Length; i++)
                        {
                            array[i] = model.Colors[i];
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
        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (this.indexBufferPtr == null)
            {
                int vertexCount = this.model.Positions.Length;
                ZeroIndexBufferPtr bufferPtr = ZeroIndexBufferPtr.Create(DrawMode.LineStrip, 0, vertexCount);
                this.indexBufferPtr = bufferPtr;
            }

            return this.indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;

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