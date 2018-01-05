using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroAttributeInVertexShader
{

    /// <summary>
    /// Bufferable model with zero vertex attribute.
    /// </summary>
    public class ZeroAttributeModel : IBufferSource
    {
        /// <summary>
        /// 用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; private set; }

        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>
        /// </summary>
        public int FirstVertex { get; private set; }

        /// <summary>
        /// 要渲染多少个元素？<para>How many vertexes to be rendered?</para>
        /// </summary>
        public int VertexCount { get; private set; }

        /// <summary>
        /// primCount in instanced rendering.
        /// </summary>
        public int PrimCount { get; private set; }

        /// <summary>
        /// Bufferable model with zero vertex attribute.
        /// </summary>
        /// <param name="mode">渲染模式。</param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="vertexCount">要渲染多少个元素？<para>How many vertexes to be rendered?</para></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        public ZeroAttributeModel(DrawMode mode, int firstVertex, int vertexCount, int primCount = 1)
        {
            this.Mode = mode;
            this.FirstVertex = firstVertex;
            this.VertexCount = vertexCount;
            this.PrimCount = primCount;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            throw new Exception("No vertex attribute buffer for this model!");
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IndexBuffer> GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                ZeroIndexBuffer buffer = ZeroIndexBuffer.Create(this.Mode, this.FirstVertex, this.VertexCount, this.PrimCount);
                this.indexBuffer = buffer;
            }

            return this.indexBuffer;
        }

        private IndexBuffer indexBuffer;

    }
}
