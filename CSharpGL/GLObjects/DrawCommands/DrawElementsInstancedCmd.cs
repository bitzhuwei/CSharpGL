using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL {
    /// <summary>
    /// Wraps glDrawElementsInstanced(uint mode, int vertexCount, uint type, IntPtr offset, int primCount);
    /// </summary>

    public unsafe class DrawElementsInstancedCmd : IDrawCommand//, IHasIndexBuffer
    {

        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>
        /// </summary>
        public int firstVertex;

        /// <summary>
        /// 要渲染多少个顶点？<para>How many vertexes to be rendered?</para>
        /// </summary>
        public int vertexCount;

        /// <summary>
        /// primCount in instanced rendering.
        /// </summary>
        public int instanceCount;

        // RULE: CSharpGL takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care of this rule when designing a model's index buffer.
        /// <summary>
        /// usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.
        /// </summary>
        public readonly uint primitiveRestartIndex;



        //#region IHasIndexBuffer

        public readonly IndexBuffer indexBuffer;

        //#endregion IHasIndexBuffer

        /// <summary>
        /// Wraps glDrawElementsInstanced(uint mode, int vertexCount, uint type, IntPtr offset, int primCount);
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="mode"></param>
        /// <param name="instanceCount">primCount in instanced rendering.</param>
        /// <param name="primitiveRestartIndex">usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.</param>
        public DrawElementsInstancedCmd(IndexBuffer indexBuffer, DrawMode mode, int instanceCount, uint primitiveRestartIndex = 0)
            : this(indexBuffer, mode, 0, indexBuffer.count, instanceCount, primitiveRestartIndex) { }

        /// <summary>
        /// Wraps glDrawElementsInstanced(uint mode, int vertexCount, uint type, IntPtr offset, int primCount);
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="mode"></param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="vertexCount">要渲染多少个顶点？<para>How many vertexes to be rendered?</para></param>
        /// <param name="instanceCount">primCount in instanced rendering.</param>
        /// <param name="primitiveRestartIndex">usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.</param>
        public DrawElementsInstancedCmd(IndexBuffer indexBuffer, DrawMode mode, int firstVertex, int vertexCount, int instanceCount, uint primitiveRestartIndex = 0) {
            if (indexBuffer == null) { throw new ArgumentNullException("indexBuffer"); }
            //if (instanceCount < 0) { throw new Exception("error: instanceCount(primCount) is less than 0."); }

            this.indexBuffer = indexBuffer;
            this.Mode = mode;
            this.firstVertex = firstVertex;
            this.vertexCount = vertexCount;
            this.instanceCount = instanceCount;
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

            IndexBuffer indexBuffer = this.indexBuffer;
            int vertexCount = indexBuffer.count;
            var elementType = indexBuffer.elementType;
            var offset = new IntPtr(IndexBuffer.sizeOf[elementType] * this.firstVertex);
            uint rs = this.primitiveRestartIndex;
            if (rs != 0) {
                gl.glEnable(GL.GL_PRIMITIVE_RESTART);
                gl.glPrimitiveRestartIndex(rs);
            }
            gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, indexBuffer.bufferId);
            gl.glDrawElementsInstanced((GLenum)this.Mode, this.vertexCount, (GLenum)elementType, offset, this.instanceCount);
            gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, 0);
            if (rs != 0) {
                gl.glDisable(GL.GL_PRIMITIVE_RESTART);
            }
        }

        #endregion IDrawCommand

        public override string ToString() {
            IndexBuffer indexBuffer = this.indexBuffer;
            var elementType = indexBuffer.elementType;
            var offset = new IntPtr(IndexBuffer.sizeOf[elementType] * this.firstVertex);

            return string.Format("glDrawElementsInstanced(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, primCount: {4});", this.Mode, indexBuffer.count, elementType, offset, this.instanceCount);
        }

        //private static GLDelegates.void_uint glPrimitiveRestartIndex;
        ///// <summary>
        ///// glDrawElementsInstanced(uint mode, int vertexCount, uint type, IntPtr offset, int primCount);
        ///// </summary>
        //internal static readonly GLDelegates.void_uint_int_uint_IntPtr_int glDrawElementsInstanced;
        //static DrawElementsInstancedCmd()
        //{
        //    glPrimitiveRestartIndex = gl.glGetDelegateFor("glPrimitiveRestartIndex", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        //    glDrawElementsInstanced = gl.glGetDelegateFor("glDrawElementsInstanced", GLDelegates.typeof_void_uint_int_uint_IntPtr_int) as GLDelegates.void_uint_int_uint_IntPtr_int;
        //}

    }
}