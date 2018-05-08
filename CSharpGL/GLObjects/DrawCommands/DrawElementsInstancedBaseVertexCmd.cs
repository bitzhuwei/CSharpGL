using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Wraps glDrawElementsInstancedBaseVertex(uint mode, int vertexCount, uint type, IntPtr offset, int instanceCount, int baseVertex);
    /// </summary>
    [Editor(typeof(DrawElementsCmdEditor), typeof(UITypeEditor))]
    public class DrawElementsInstancedBaseVertexCmd : IDrawCommand//, IHasIndexBuffer
    {
        private const string strDrawElementsInstancedBaseVertexCmd = "DrawElementsInstancedBaseVertexCmd";

        //#region IHasIndexBuffer

        private IndexBuffer indexBuffer;
        /// <summary>
        /// 
        /// </summary>
        [Category(strDrawElementsInstancedBaseVertexCmd)]
        public IndexBuffer IndexBufferObject { get { return this.indexBuffer; } }

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
            : this(indexBuffer, mode, frameVertexCount, 0, instanceCount, 0, primitiveRestartIndex)
        { }

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
        public DrawElementsInstancedBaseVertexCmd(IndexBuffer indexBuffer, DrawMode mode, int frameVertexCount, int firstVertex, int instanceCount, int baseVertex, uint primitiveRestartIndex = 0)
        {
            if (indexBuffer == null) { throw new ArgumentNullException("indexBuffer"); }
            if (instanceCount < 1) { throw new Exception("error: instanceCount is less than 1."); }
            if (baseVertex <= 0) { throw new ArgumentException("baseVertex"); }

            this.indexBuffer = indexBuffer;
            this.Mode = mode;
            this.CurrentMode = mode;
            this.FrameVertexCount = frameVertexCount;
            this.FirstVertex = firstVertex;
            this.InstanceCount = instanceCount;
            this.BaseVertex = baseVertex;
            this.PrimitiveRestartIndex = primitiveRestartIndex;
        }

        /// <summary>
        /// 要渲染多少个元素？<para>How many vertexes to be rendered?</para>
        /// </summary>
        [Category(strDrawElementsInstancedBaseVertexCmd)]
        public int FrameVertexCount { get; set; }

        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>.
        /// </summary>
        [Category(strDrawElementsInstancedBaseVertexCmd)]
        public int FirstVertex { get; set; }

        /// <summary>
        /// i: Index of current frame you want to render. baseVertex = i * <see cref="FrameVertexCount"/>.
        /// </summary>
        [Category(strDrawElementsInstancedBaseVertexCmd)]
        public int BaseVertex { get; set; }

        // RULE: CSharpGL takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care of this rule when designing a model's index buffer.
        /// <summary>
        /// usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.
        /// </summary>
        [Category(strDrawElementsInstancedBaseVertexCmd)]
        public uint PrimitiveRestartIndex { get; set; }

        /// <summary>
        /// primCount in instanced rendering.
        /// </summary>
        [Category(strDrawElementsInstancedBaseVertexCmd)]
        public int InstanceCount { get; private set; }

        #region IDrawCommand

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        [Category(strDrawElementsInstancedBaseVertexCmd)]
        public DrawMode Mode { get; private set; }

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        [Category(strDrawElementsInstancedBaseVertexCmd)]
        public DrawMode CurrentMode { get; set; }

        /// <summary>
        ///
        /// </summary>
        public void Draw()
        {
            int instanceCount = this.InstanceCount;
            uint mode = (uint)this.CurrentMode;
            IndexBuffer indexBuffer = this.indexBuffer;
            IndexBufferElementType elementType = indexBuffer.ElementType;
            IntPtr offset = GetOffset(elementType, this.FirstVertex);

            uint rs = this.PrimitiveRestartIndex;
            if (rs != 0)
            {
                GL.Instance.Enable(GL.GL_PRIMITIVE_RESTART);
                glPrimitiveRestartIndex(rs);
            }
            GLBuffer.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, indexBuffer.BufferId);
            glDrawElementsInstancedBaseVertex(mode, this.FrameVertexCount, (uint)elementType, offset, instanceCount, this.BaseVertex);
            GLBuffer.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, 0);
            if (rs != 0)
            {
                GL.Instance.Disable(GL.GL_PRIMITIVE_RESTART);
            }
        }

        private IntPtr GetOffset(IndexBufferElementType elementType, int firstIndex)
        {
            IntPtr offset;
            switch (elementType)
            {
                case IndexBufferElementType.UByte:
                    offset = new IntPtr(firstIndex * sizeof(byte));
                    break;

                case IndexBufferElementType.UShort:
                    offset = new IntPtr(firstIndex * sizeof(ushort));
                    break;

                case IndexBufferElementType.UInt:
                    offset = new IntPtr(firstIndex * sizeof(uint));
                    break;

                default:
                    throw new NotDealWithNewEnumItemException(typeof(IndexBufferElementType));
            }
            return offset;
        }

        #endregion IDrawCommand

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            int instanceCount = this.InstanceCount;
            uint mode = (uint)this.CurrentMode;
            IndexBufferElementType elementType = indexBuffer.ElementType;
            IntPtr offset = GetOffset(elementType, this.FirstVertex);

            return string.Format("glDrawElementsInstancedBaseVertex(mode: {0}, frameVertexCount: {1}, type: {2}, offset: {3}, instanceCount: {4}, baseVertex: {5});", mode, this.FrameVertexCount, elementType, offset, instanceCount, this.BaseVertex);
        }

        private static GLDelegates.void_uint glPrimitiveRestartIndex;
        // glDrawElementsInstancedBaseVertex(uint mode, int vertexCount, uint type, IntPtr offset, int instanceCount, int baseVertex);
        internal static readonly GLDelegates.void_uint_int_uint_IntPtr_int_int glDrawElementsInstancedBaseVertex;
        static DrawElementsInstancedBaseVertexCmd()
        {
            glPrimitiveRestartIndex = GL.Instance.GetDelegateFor("glPrimitiveRestartIndex", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glDrawElementsInstancedBaseVertex = GL.Instance.GetDelegateFor("glDrawElementsInstancedBaseVertex", GLDelegates.typeof_void_uint_int_uint_IntPtr_int_int) as GLDelegates.void_uint_int_uint_IntPtr_int_int;
        }

    }
}