using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL {
    // 没有显式索引时的渲染方法。
    /// <summary>
    /// Wraps void glDrawArraysInstanced(uint mode​, int first​, int count​, int primcount​);
    /// </summary>

    public unsafe class DrawArraysInstancedCmd : IDrawCommand {

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
        /// Wraps void glDrawArraysInstanced(uint mode​, int first​, int count​, int primcount​);
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）</param>
        /// <param name="maxVertexCount">一共有多少个元素？<para>How many vertexes in total?</para></param>
        /// <param name="instanceCount">primCount in instanced rendering.</param>
        public DrawArraysInstancedCmd(DrawMode mode, int maxVertexCount, int instanceCount)
            : this(mode, maxVertexCount, 0, maxVertexCount, instanceCount) { }

        /// <summary>
        /// Wraps void glDrawArraysInstanced(uint mode​, int first​, int count​, int primcount​);
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）</param>
        /// <param name="maxVertexCount">一共有多少个元素？<para>How many vertexes in total?</para></param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="vertexCount">要渲染多少个元素？<para>How many vertexes to be rendered?</para></param>
        /// <param name="instanceCount">primCount in instanced rendering.</param>
        public DrawArraysInstancedCmd(DrawMode mode, int maxVertexCount, int firstVertex, int vertexCount, int instanceCount) {
            //if (instanceCount < 0) { throw new Exception("error: instanceCount is less than 0."); }

            this.Mode = mode;
            this.maxVertexCount = maxVertexCount;
            this.firstVertex = firstVertex;
            this.vertexCount = vertexCount;
            this.instanceCount = instanceCount;
        }

        /// <summary>
        /// primCount in instanced rendering.
        /// </summary>
        public readonly int instanceCount;

        #region IDrawCommand

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }

        /// <summary>
        /// </summary>
        public void Draw() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glDrawArraysInstanced((GLenum)this.Mode, this.firstVertex, this.vertexCount, this.instanceCount);
        }

        #endregion IDrawCommand

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("glDrawArraysInstanced(mode: {0}, first: {1}, count: {2}, primCount: {3});", this.Mode, this.firstVertex, this.maxVertexCount, this.instanceCount);
        }

        ///// <summary>
        ///// void glDrawArraysInstanced(GLenum mode​, GLint first​, GLsizei count​, GLsizei primcount​);
        ///// <para>mode: Specifies what kind of primitives to render. Symbolic constants GL_POINTS, GL_LINE_STRIP, GL_LINE_LOOP, GL_LINES, GL_TRIANGLE_STRIP, GL_TRIANGLE_FAN, GL_TRIANGLES, GL_LINES_ADJACENCY, GL_LINE_STRIP_ADJACENCY, GL_TRIANGLES_ADJACENCY, GL_TRIANGLE_STRIP_ADJACENCY and GL_PATCHES are accepted.</para>
        ///// <para>first: Specifies the starting index in the enabled arrays.</para>
        ///// <para>count: Specifies the number of indices to be rendered.</para>
        ///// <para>primcount: Specifies the number of instances of the specified range of indices to be rendered.</para>
        ///// </summary>
        //internal static readonly GLDelegates.void_uint_int_int_int glDrawArraysInstanced;

        //static DrawArraysInstancedCmd()
        //{
        //    glDrawArraysInstanced = gl.glGetDelegateFor("glDrawArraysInstanced", GLDelegates.typeof_void_uint_int_int_int) as GLDelegates.void_uint_int_int_int;
        //}
    }
}