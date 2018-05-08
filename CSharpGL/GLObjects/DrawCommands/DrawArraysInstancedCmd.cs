using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    // 没有显式索引时的渲染方法。
    /// <summary>
    /// Wraps void glDrawArraysInstanced(uint mode​, int first​, int count​, int primcount​);
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public class DrawArraysInstancedCmd : IDrawCommand
    {
        private const string strDrawArraysInstancedCmd = "DrawArraysInstancedCmd";

        /// <summary>
        /// Wraps void glDrawArraysInstanced(uint mode​, int first​, int count​, int primcount​);
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）</param>
        /// <param name="maxVertexCount">一共有多少个元素？<para>How many vertexes in total?</para></param>
        /// <param name="instanceCount">primCount in instanced rendering.</param>
        public DrawArraysInstancedCmd(DrawMode mode, int maxVertexCount, int instanceCount)
            : this(mode, maxVertexCount, 0, maxVertexCount, instanceCount)
        { }

        /// <summary>
        /// Wraps void glDrawArraysInstanced(uint mode​, int first​, int count​, int primcount​);
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）</param>
        /// <param name="maxVertexCount">一共有多少个元素？<para>How many vertexes in total?</para></param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="vertexCount">要渲染多少个元素？<para>How many vertexes to be rendered?</para></param>
        /// <param name="instanceCount">primCount in instanced rendering.</param>
        public DrawArraysInstancedCmd(DrawMode mode, int maxVertexCount, int firstVertex, int vertexCount, int instanceCount)
        {
            if (instanceCount < 1) { throw new Exception("error: instanceCount is less than 1."); }

            this.Mode = mode;
            this.CurrentMode = mode;
            this.MaxVertexCount = maxVertexCount;
            this.FirstVertex = firstVertex;
            this.VertexCount = vertexCount;
            this.InstanceCount = instanceCount;
        }

        /// <summary>
        /// 此VBO含有多少个元素？
        /// <para>How many elements in thie buffer?</para>
        /// </summary>
        [Category(strDrawArraysInstancedCmd)]
        public int MaxVertexCount { get; private set; }

        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>
        /// </summary>
        [Category(strDrawArraysInstancedCmd)]
        public int FirstVertex { get; set; }

        /// <summary>
        /// 要渲染多少个元素？<para>How many vertexes to be rendered?</para>
        /// </summary>
        [Category(strDrawArraysInstancedCmd)]
        public int VertexCount { get; set; }

        /// <summary>
        /// primCount in instanced rendering.
        /// </summary>
        [Category(strDrawArraysInstancedCmd)]
        public int InstanceCount { get; private set; }

        #region IDrawCommand

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        [Category(strDrawArraysInstancedCmd)]
        public DrawMode Mode { get; private set; }

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        [Category(strDrawArraysInstancedCmd)]
        public DrawMode CurrentMode { get; set; }

        /// <summary>
        /// </summary>
        public void Draw()
        {
            uint mode = (uint)this.CurrentMode;

            int instanceCount = this.InstanceCount;

            int first = this.FirstVertex;
            int count = this.MaxVertexCount;
            int primcount = this.InstanceCount;
            glDrawArraysInstanced(mode, first, count, primcount);
        }

        #endregion IDrawCommand

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("glDrawArraysInstanced(mode: {0}, first: {1}, count: {2}, primCount: {3});", this.CurrentMode, this.FirstVertex, this.MaxVertexCount, this.InstanceCount);
        }

        /// <summary>
        /// void glDrawArraysInstanced(GLenum mode​, GLint first​, GLsizei count​, GLsizei primcount​);
        /// <para>mode: Specifies what kind of primitives to render. Symbolic constants GL_POINTS, GL_LINE_STRIP, GL_LINE_LOOP, GL_LINES, GL_TRIANGLE_STRIP, GL_TRIANGLE_FAN, GL_TRIANGLES, GL_LINES_ADJACENCY, GL_LINE_STRIP_ADJACENCY, GL_TRIANGLES_ADJACENCY, GL_TRIANGLE_STRIP_ADJACENCY and GL_PATCHES are accepted.</para>
        /// <para>first: Specifies the starting index in the enabled arrays.</para>
        /// <para>count: Specifies the number of indices to be rendered.</para>
        /// <para>primcount: Specifies the number of instances of the specified range of indices to be rendered.</para>
        /// </summary>
        internal static readonly GLDelegates.void_uint_int_int_int glDrawArraysInstanced;

        static DrawArraysInstancedCmd()
        {
            glDrawArraysInstanced = GL.Instance.GetDelegateFor("glDrawArraysInstanced", GLDelegates.typeof_void_uint_int_int_int) as GLDelegates.void_uint_int_int_int;
        }
    }
}