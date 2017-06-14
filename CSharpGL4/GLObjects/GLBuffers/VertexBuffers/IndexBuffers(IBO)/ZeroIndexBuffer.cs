using System;

namespace CSharpGL
{
    // 没有显式索引时的渲染方法。
    /// <summary>
    /// Wraps glDrawArrays(uint mode, int first, int count).
    /// </summary>
    public sealed partial class ZeroIndexBuffer : IndexBuffer
    {
        /// <summary>
        /// Invalid for <see cref="ZeroIndexBuffer"/>.
        /// </summary>
        public override BufferTarget Target
        {
            get { return BufferTarget.InvalidTarget; }
        }

        /// <summary>
        /// Wraps glDrawArrays(uint mode, int first, int count).
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）</param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="vertexCount">要渲染多少个元素？<para>How many vertexes to be rendered?</para></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        internal ZeroIndexBuffer(DrawMode mode, int firstVertex, int vertexCount, int primCount = 1)
            : base(mode, 0, vertexCount, vertexCount * sizeof(uint), primCount)
        {
            this.FirstVertex = firstVertex;
            this.RenderingVertexCount = vertexCount;
            //this.OriginalVertexCount = vertexCount;
        }

        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>
        /// </summary>
        public int FirstVertex { get; set; }

        /// <summary>
        /// 要渲染多少个元素？<para>How many vertexes to be rendered?</para>
        /// </summary>
        public int RenderingVertexCount { get; set; }

        ///// <summary>
        ///// 总共有多少个元素？<para>How many vertexes are there in total?</para>
        ///// </summary>
        //public int OriginalVertexCount { get; private set; }


        /// <summary>
        ///
        /// </summary>
        public override void Render()
        {
            uint mode = (uint)this.Mode;

            int primCount = this.PrimCount;
            if (primCount < 1) { throw new Exception("error: primCount is less than 1."); }
            else if (primCount == 1)
            {
                GL.Instance.DrawArrays(mode, this.FirstVertex, this.RenderingVertexCount);
            }
            else
            {
                glDrawArraysInstanced(mode, this.FirstVertex, this.RenderingVertexCount, primCount);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            int primCount = this.PrimCount;
            if (primCount < 1)
            {
                return string.Format("error: primCount is less than 1.");
            }
            else if (primCount == 1)
            {
                return string.Format("OpenGL.DrawArrays({0}, {1}, {2})",
                    this.Mode, this.FirstVertex, this.RenderingVertexCount);
            }
            else
            {
                return string.Format("OpenGL.glDrawArraysInstanced({0}, {1}, {2}, {3})",
                    this.Mode, this.FirstVertex, this.RenderingVertexCount, this.PrimCount);
            }
        }
    }
}