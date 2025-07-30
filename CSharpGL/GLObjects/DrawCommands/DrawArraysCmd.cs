using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL {
    // 没有显式索引时的渲染方法。
    /// <summary>
    /// Wraps glDrawArrays(uint mode, int first, int count).
    /// </summary>

    public unsafe class DrawArraysCmd : IDrawCommand {

        /// <summary>
        /// 此VBO含有多少个元素？
        /// <para>How many elements in thie buffer?</para>
        /// </summary>
        public readonly int maxVertexCount;

        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>
        /// </summary>
        public int firstVertex;
        /// <summary>
        /// 要渲染多少个元素？<para>How many vertexes to be rendered?</para>
        /// </summary>
        public int vertexCount;

        /// <summary>
        /// Wraps glDrawArrays(uint mode, int first, int count).
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）</param>
        /// <param name="maxVertexCount">一共有多少个元素？<para>How many vertexes in total?</para></param>
        public DrawArraysCmd(DrawMode mode, int maxVertexCount)
            : this(mode, maxVertexCount, 0, maxVertexCount) { }

        /// <summary>
        /// Wraps glDrawArrays(uint mode, int first, int count).
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）</param>
        /// <param name="maxVertexCount">一共有多少个元素？<para>How many vertexes in total?</para></param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="vertexCount">要渲染多少个元素？<para>How many vertexes to be rendered?</para></param>
        public DrawArraysCmd(DrawMode mode, int maxVertexCount, int firstVertex, int vertexCount) {
            this.Mode = mode;
            this.maxVertexCount = maxVertexCount;
            this.firstVertex = firstVertex;
            this.vertexCount = vertexCount;
        }

        #region IDrawCommand

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }

        /// <summary>
        /// </summary>
        public void Draw() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glDrawArrays((GLenum)this.Mode, this.firstVertex, this.vertexCount);
        }

        #endregion IDrawCommand

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("glDrawArrays(mode: {0}, first: {1}, count: {2});", this.Mode, this.firstVertex, this.vertexCount);
        }
    }
}