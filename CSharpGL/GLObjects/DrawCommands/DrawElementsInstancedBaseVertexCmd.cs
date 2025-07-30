using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL {
    /// <summary>
    /// Wraps glDrawElementsInstancedBaseVertex(uint mode, int vertexCount, uint type, IntPtr offset, int instanceCount, int baseVertex);
    /// </summary>

    public unsafe class DrawElementsInstancedBaseVertexCmd : IDrawCommand//, IHasIndexBuffer
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
        public int baseVertex;

        // RULE: CSharpGL takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care of this rule when designing a model's index buffer.
        /// <summary>
        /// usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.
        /// </summary>
        public readonly uint primitiveRestartIndex;

        /// <summary>
        /// primCount in instanced rendering.
        /// </summary>
        public int instanceCount;

        //#region IHasIndexBuffer

        public readonly IndexBuffer indexBuffer;

        //#endregion IHasIndexBuffer

        /// <summary>
        /// Wraps glDrawElementsInstancedBaseVertex(uint mode, int vertexCount, uint type, IntPtr offset, int instanceCount, int baseVertex);
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="mode"></param>
        /// <param name="frameVertexCount">How many vertexes to construct a frame?</param>
        /// <param name="instanceCount">primCount in instanced rendering.</param>
        /// <param name="primitiveRestartIndex">usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.</param>
        public DrawElementsInstancedBaseVertexCmd(IndexBuffer indexBuffer, DrawMode mode, int frameVertexCount, int instanceCount, uint primitiveRestartIndex = 0)
            : this(indexBuffer, mode, frameVertexCount, 0, instanceCount, 0, primitiveRestartIndex) { }

        /// <summary>
        /// Wraps glDrawElementsInstancedBaseVertex(uint mode, int vertexCount, uint type, IntPtr offset, int instanceCount, int baseVertex);
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="mode"></param>
        /// <param name="frameVertexCount">How many vertexes to construct a frame?</param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="instanceCount">primCount in instanced rendering.</param>
        /// <param name="baseVertex">i: Index of current frame you want to render. baseVertex = i * <paramref name="frameVertexCount"/>.</param>
        /// <param name="primitiveRestartIndex">usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.</param>
        public DrawElementsInstancedBaseVertexCmd(IndexBuffer indexBuffer, DrawMode mode, int frameVertexCount, int firstVertex, int instanceCount, int baseVertex, uint primitiveRestartIndex = 0) {
            if (indexBuffer == null) { throw new ArgumentNullException("indexBuffer"); }
            //if (instanceCount < 0) { throw new Exception("error: instanceCount is less than 0."); }
            //if (baseVertex <= 0) { throw new ArgumentException("baseVertex"); }

            this.indexBuffer = indexBuffer;
            this.Mode = mode;
            this.frameVertexCount = frameVertexCount;
            this.firstVertex = firstVertex;
            this.instanceCount = instanceCount;
            this.baseVertex = baseVertex;
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
            int instanceCount = this.instanceCount;
            uint mode = (uint)this.Mode;
            IndexBuffer indexBuffer = this.indexBuffer;
            var elementType = indexBuffer.elementType;
            var offset = new IntPtr(IndexBuffer.sizeOf[elementType] * this.firstVertex);

            uint rs = this.primitiveRestartIndex;
            if (rs != 0) {
                gl.glEnable(GL.GL_PRIMITIVE_RESTART);
                gl.glPrimitiveRestartIndex(rs);
            }
            gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, indexBuffer.bufferId);
            gl.glDrawElementsInstancedBaseVertex((GLenum)this.Mode, this.frameVertexCount, (uint)elementType, offset, instanceCount, this.baseVertex);
            gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, 0);
            if (rs != 0) {
                gl.glDisable(GL.GL_PRIMITIVE_RESTART);
            }
        }

        #endregion IDrawCommand

        public override string ToString() {
            IndexBuffer.ElementType elementType = indexBuffer.elementType;
            var offset = new IntPtr(IndexBuffer.sizeOf[elementType] * this.firstVertex);

            return string.Format("glDrawElementsInstancedBaseVertex(mode: {0}, frameVertexCount: {1}, type: {2}, offset: {3}, instanceCount: {4}, baseVertex: {5});", this.Mode, this.frameVertexCount, elementType, offset, this.instanceCount, this.baseVertex);
        }

        //private static GLDelegates.void_uint glPrimitiveRestartIndex;
        //// glDrawElementsInstancedBaseVertex(uint mode, int vertexCount, uint type, IntPtr offset, int instanceCount, int baseVertex);
        //internal static readonly GLDelegates.void_uint_int_uint_IntPtr_int_int glDrawElementsInstancedBaseVertex;
        //static DrawElementsInstancedBaseVertexCmd()
        //{
        //    glPrimitiveRestartIndex = gl.glGetDelegateFor("glPrimitiveRestartIndex", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        //    glDrawElementsInstancedBaseVertex = gl.glGetDelegateFor("glDrawElementsInstancedBaseVertex", GLDelegates.typeof_void_uint_int_uint_IntPtr_int_int) as GLDelegates.void_uint_int_uint_IntPtr_int_int;
        //}

    }
}