using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL {
    // 用glDrawElements()执行一个索引buffer的渲染操作。
    /// <summary>
    /// Wraps glDrawElements(uint mode, int count, uint type, IntPtr indices).
    /// </summary>

    public unsafe class DrawElementsCmd : IDrawCommand//, IHasIndexBuffer
    {

        // RULE: CSharpGL takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care of this rule when designing a model's index buffer.
        /// <summary>
        /// usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.
        /// </summary>
        public readonly uint primitiveRestartIndex;

        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>
        /// </summary>
        public int firstVertex;

        /// <summary>
        /// 要渲染多少个顶点？<para>How many vertexes to be rendered?</para>
        /// </summary>
        public int vertexCount;

        //#region IHasIndexBuffer

        public readonly IndexBuffer indexBuffer;

        //#endregion IHasIndexBuffer

        /// <summary>
        /// Wraps glDrawElements(uint mode, int count, uint type, IntPtr indices).
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="mode"></param>
        /// <param name="primitiveRestartIndex">usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.</param>
        public DrawElementsCmd(IndexBuffer indexBuffer, DrawMode mode, uint primitiveRestartIndex = 0)
            : this(indexBuffer, mode, 0, indexBuffer.count, primitiveRestartIndex) { }

        /// <summary>
        /// Wraps glDrawElements(uint mode, int count, uint type, IntPtr indices).
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="mode"></param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="vertexCount">要渲染多少个顶点？<para>How many vertexes to be rendered?</para></param>
        /// <param name="primitiveRestartIndex">usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.</param>
        public DrawElementsCmd(IndexBuffer indexBuffer, DrawMode mode, int firstVertex, int vertexCount, uint primitiveRestartIndex = 0) {
            if (indexBuffer == null) { throw new ArgumentNullException("indexBuffer"); }

            this.indexBuffer = indexBuffer;
            this.Mode = mode;
            this.firstVertex = firstVertex;
            this.vertexCount = vertexCount;
            this.primitiveRestartIndex = primitiveRestartIndex;
        }

        #region IDrawCommand

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }

        /// <summary>
        ///
        /// </summary>
        public void Draw() {
            var gl = GL.current; if (gl == null) { return; }
            var elementType = this.indexBuffer.elementType;
            var offset = new IntPtr(IndexBuffer.sizeOf[elementType] * this.firstVertex);

            uint rs = this.primitiveRestartIndex;
            if (rs != 0) {
                gl.glEnable(GL.GL_PRIMITIVE_RESTART);
                gl.glPrimitiveRestartIndex(rs);
            }
            gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, this.indexBuffer.bufferId);
            gl.glDrawElements((GLenum)this.Mode, this.vertexCount, (GLenum)elementType, offset);
            gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, 0);
            if (rs != 0) {
                gl.glDisable(GL.GL_PRIMITIVE_RESTART);
            }
        }

        #endregion IDrawCommand

        public override string ToString() {
            int vertexCount = this.indexBuffer.count;// max vertex count
            var elementType = this.indexBuffer.elementType;
            var offset = new IntPtr(IndexBuffer.sizeOf[elementType] * this.firstVertex);

            return string.Format("glDrawElements(mode: {0}, vertexCount: {1}, type: {2}, offset: {3});", this.Mode, vertexCount, elementType, offset);
        }

        //private static GLDelegates.void_uint glPrimitiveRestartIndex;
        //static DrawElementsCmd() {
        //    glPrimitiveRestartIndex = gl.glGetDelegateFor("glPrimitiveRestartIndex", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        //}

    }
}