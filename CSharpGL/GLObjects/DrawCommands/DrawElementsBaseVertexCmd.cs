using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL {
    // NOTE: glDrawElements(..) has the same parameters with glDrawArrays(..).
    // Is glDrawElementsBaseVertex(..) a simplified way of using glDrawElements(..) ?
    /// <summary>
    /// Wraps glDrawElementsBaseVertex(uint mode, int vertexCount, uint type, IntPtr offset, int baseVertex);
    /// </summary>

    public unsafe class DrawElementsBaseVertexCmd : IDrawCommand//, IHasIndexBuffer
    {

        /// <summary>
        /// 要渲染多少个元素？<para>How many vertexes to be rendered?</para>
        /// </summary>
        public readonly int frameVertexCount;

        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>.
        /// </summary>
        public int firstVertex;

        /// <summary>
        /// i: Index of current frame you want to render. baseVertex = i * <see cref="frameVertexCount"/>.
        /// </summary>
        public readonly int baseVertex;

        // RULE: CSharpGL takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care of this rule when designing a model's index buffer.
        /// <summary>
        /// usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.
        /// </summary>
        public readonly uint primitiveRestartIndex;

        //#region IHasIndexBuffer

        /// <summary>
        /// 
        /// </summary>
        public readonly IndexBuffer indexBuffer;

        //#endregion IHasIndexBuffer
        /// <summary>
        /// Wraps glDrawElementsBaseVertex(uint mode, int frameVertexCount, uint type, IntPtr offset, int baseVertex);
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="mode"></param>
        /// <param name="frameVertexCount">How many vertexes to construct a frame?</param>
        /// <param name="primitiveRestartIndex">usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.</param>
        public DrawElementsBaseVertexCmd(IndexBuffer indexBuffer, DrawMode mode, int frameVertexCount, uint primitiveRestartIndex = 0)
            : this(indexBuffer, mode, frameVertexCount, 0, 0, primitiveRestartIndex) { }

        /// <summary>
        /// Wraps glDrawElementsBaseVertex(uint mode, int frameVertexCount, uint type, IntPtr offset, int baseVertex);
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="mode"></param>
        /// <param name="frameVertexCount">How many vertexes to construct a frame?</param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="baseVertex">i: Index of current frame you want to render. baseVertex = i * <paramref name="frameVertexCount"/>.</param>
        /// <param name="primitiveRestartIndex">usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.</param>
        public DrawElementsBaseVertexCmd(IndexBuffer indexBuffer, DrawMode mode, int frameVertexCount, int firstVertex, int baseVertex, uint primitiveRestartIndex = 0) {
            ArgumentNullException.ThrowIfNull(indexBuffer);
            //if (baseVertex <= 0) { throw new ArgumentException("baseVertex"); }

            this.indexBuffer = indexBuffer;
            this.Mode = mode;
            this.frameVertexCount = frameVertexCount;
            this.firstVertex = firstVertex;
            this.baseVertex = baseVertex;
            this.primitiveRestartIndex = primitiveRestartIndex;
        }

        #region IDrawCommand

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }
        public void Draw() {
            var gl = GL.current; if (gl == null) { return; }
            var offset = new IntPtr(IndexBuffer.sizeOf[indexBuffer.elementType] * this.firstVertex);

            uint rs = this.primitiveRestartIndex;
            if (rs != 0) {
                gl.glEnable(GL.GL_PRIMITIVE_RESTART);
                gl.glPrimitiveRestartIndex(rs);
            }
            gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, indexBuffer.bufferId);
            gl.glDrawElementsBaseVertex((GLenum)this.Mode, this.frameVertexCount, (GLenum)indexBuffer.elementType, offset, this.baseVertex);
            gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, 0);
            if (rs != 0) {
                gl.glDisable(GL.GL_PRIMITIVE_RESTART);
            }
        }

        #endregion IDrawCommand

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            var offset = new IntPtr(IndexBuffer.sizeOf[indexBuffer.elementType] * this.firstVertex);

            return string.Format("glDrawElementsBaseVertex(mode: {0}, frameVertexCount: {1}, type: {2}, offset: {3}, baseVertex: {4});", this.Mode, this.frameVertexCount, this.indexBuffer.elementType, offset, this.baseVertex);
        }

        //private static GLDelegates.void_uint glPrimitiveRestartIndex;
        //// glDrawElementsBaseVertex(uint mode, int frameVertexCount, uint type, IntPtr offset, int baseVertex);
        //internal static readonly GLDelegates.void_uint_int_uint_IntPtr_int glDrawElementsBaseVertex;
        //static DrawElementsBaseVertexCmd() {
        //    glPrimitiveRestartIndex = gl.glGetDelegateFor("glPrimitiveRestartIndex", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        //    glDrawElementsBaseVertex = gl.glGetDelegateFor("glDrawElementsBaseVertex", GLDelegates.typeof_void_uint_int_uint_IntPtr_int) as GLDelegates.void_uint_int_uint_IntPtr_int;
        //}

    }
}