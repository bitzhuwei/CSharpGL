using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    // 没有显式索引时的渲染方法。
    /// <summary>
    /// Wraps glDrawArrays(uint mode, int first, int count).
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public class DrawArraysCmd : IDrawCommand
    {
        private const string strDrawArraysCmd = "DrawArraysCmd";
        /// <summary>
        /// Wraps glDrawArrays(uint mode, int first, int count).
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）</param>
        /// <param name="maxVertexCount">一共有多少个元素？<para>How many vertexes in total?</para></param>
        public DrawArraysCmd(DrawMode mode, int maxVertexCount)
            : this(mode, maxVertexCount, 0, maxVertexCount)
        { }

        /// <summary>
        /// Wraps glDrawArrays(uint mode, int first, int count).
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）</param>
        /// <param name="maxVertexCount">一共有多少个元素？<para>How many vertexes in total?</para></param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="vertexCount">要渲染多少个元素？<para>How many vertexes to be rendered?</para></param>
        public DrawArraysCmd(DrawMode mode, int maxVertexCount, int firstVertex, int vertexCount)
        {
            this.Mode = mode;
            this.CurrentMode = mode;
            this.MaxVertexCount = maxVertexCount;
            this.FirstVertex = firstVertex;
            this.VertexCount = vertexCount;
        }

        /// <summary>
        /// 此VBO含有多少个元素？
        /// <para>How many elements in thie buffer?</para>
        /// </summary>
        [Category(strDrawArraysCmd)]
        public int MaxVertexCount { get; private set; }

        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>
        /// </summary>
        [Category(strDrawArraysCmd)]
        public int FirstVertex { get; set; }

        /// <summary>
        /// 要渲染多少个元素？<para>How many vertexes to be rendered?</para>
        /// </summary>
        [Category(strDrawArraysCmd)]
        public int VertexCount { get; set; }

        #region IDrawCommand

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        [Category(strDrawArraysCmd)]
        public DrawMode Mode { get; private set; }

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        [Category(strDrawArraysCmd)]
        public DrawMode CurrentMode { get; set; }

        /// <summary>
        /// </summary>
        public void Draw()
        {
            uint mode = (uint)this.CurrentMode;
            int first = this.FirstVertex;
            int count = this.VertexCount;
            GL.Instance.DrawArrays(mode, first, count);
        }

        #endregion IDrawCommand

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var mode = this.CurrentMode;
            int first = this.FirstVertex;
            int vertexCount = this.MaxVertexCount;

            return string.Format("glDrawArrays(mode: {0}, first: {1}, count: {2});", mode, first, vertexCount);
        }
    }
}