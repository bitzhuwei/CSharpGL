using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Wraps glDrawElementsInstanced(uint mode, int vertexCount, uint type, IntPtr offset, int primCount);
    /// </summary>
    [Editor(typeof(DrawElementsCmdEditor), typeof(UITypeEditor))]
    public class DrawElementsInstancedCmd : IDrawCommand//, IHasIndexBuffer
    {
        private const string strDrawElementsInstancedCmd = "DrawElementsInstancedCmd";
        //#region IHasIndexBuffer

        private IndexBuffer indexBuffer;
        /// <summary>
        /// 
        /// </summary>
        [Category(strDrawElementsInstancedCmd)]
        public IndexBuffer IndexBufferObject { get { return this.indexBuffer; } }

        //#endregion IHasIndexBuffer

        /// <summary>
        /// Wraps glDrawElementsInstanced(uint mode, int vertexCount, uint type, IntPtr offset, int primCount);
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="mode"></param>
        /// <param name="instanceCount">primCount in instanced rendering.</param>
        /// <param name="primitiveRestartIndex">usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.</param>
        public DrawElementsInstancedCmd(IndexBuffer indexBuffer, DrawMode mode, int instanceCount, uint primitiveRestartIndex = 0)
            : this(indexBuffer, mode, 0, indexBuffer.Length, instanceCount, primitiveRestartIndex)
        { }

        /// <summary>
        /// Wraps glDrawElementsInstanced(uint mode, int vertexCount, uint type, IntPtr offset, int primCount);
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="mode"></param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="vertexCount">要渲染多少个顶点？<para>How many vertexes to be rendered?</para></param>
        /// <param name="instanceCount">primCount in instanced rendering.</param>
        /// <param name="primitiveRestartIndex">usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.</param>
        public DrawElementsInstancedCmd(IndexBuffer indexBuffer, DrawMode mode, int firstVertex, int vertexCount, int instanceCount, uint primitiveRestartIndex = 0)
        {
            if (indexBuffer == null) { throw new ArgumentNullException("indexBuffer"); }
            if (instanceCount < 1) { throw new Exception("error: instanceCount(primCount) is less than 1."); }

            this.indexBuffer = indexBuffer;
            this.Mode = mode;
            this.CurrentMode = mode;
            this.FirstVertex = firstVertex;
            this.VertexCount = vertexCount;
            this.InstanceCount = instanceCount;
            this.PrimitiveRestartIndex = primitiveRestartIndex;
        }

        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>
        /// </summary>
        [Category(strDrawElementsInstancedCmd)]
        public int FirstVertex { get; set; }

        /// <summary>
        /// 要渲染多少个顶点？<para>How many vertexes to be rendered?</para>
        /// </summary>
        [Category(strDrawElementsInstancedCmd)]
        public int VertexCount { get; set; }

        /// <summary>
        /// primCount in instanced rendering.
        /// </summary>
        [Category(strDrawElementsInstancedCmd)]
        public int InstanceCount { get; private set; }

        // RULE: CSharpGL takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care of this rule when designing a model's index buffer.
        /// <summary>
        /// usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.
        /// </summary>
        [Category(strDrawElementsInstancedCmd)]
        public uint PrimitiveRestartIndex { get; set; }

        #region IDrawCommand

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        [Category(strDrawElementsInstancedCmd)]
        public DrawMode Mode { get; private set; }

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        [Category(strDrawElementsInstancedCmd)]
        public DrawMode CurrentMode { get; set; }

        /// <summary>
        ///
        /// </summary>
        public void Draw()
        {
            int instanceCount = this.InstanceCount;

            uint mode = (uint)this.CurrentMode;
            IndexBuffer indexBuffer = this.indexBuffer;
            int vertexCount = indexBuffer.Length;
            IndexBufferElementType elementType = indexBuffer.ElementType;
            IntPtr offset = GetOffset(elementType, this.FirstVertex);

            uint rs = this.PrimitiveRestartIndex;
            if (rs != 0)
            {
                GL.Instance.Enable(GL.GL_PRIMITIVE_RESTART);
                glPrimitiveRestartIndex(rs);
            }
            GLBuffer.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, indexBuffer.BufferId);
            glDrawElementsInstanced(mode, this.VertexCount, (uint)elementType, offset, instanceCount);
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
            var mode = this.CurrentMode;
            IndexBuffer indexBuffer = this.indexBuffer;
            IndexBufferElementType elementType = indexBuffer.ElementType;
            IntPtr offset = GetOffset(elementType, this.FirstVertex);

            return string.Format("glDrawElementsInstanced(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, primCount: {4});", mode, this.VertexCount, elementType, offset, this.InstanceCount);
        }

        private static GLDelegates.void_uint glPrimitiveRestartIndex;
        /// <summary>
        /// glDrawElementsInstanced(uint mode, int vertexCount, uint type, IntPtr offset, int primCount);
        /// </summary>
        internal static readonly GLDelegates.void_uint_int_uint_IntPtr_int glDrawElementsInstanced;
        static DrawElementsInstancedCmd()
        {
            glPrimitiveRestartIndex = GL.Instance.GetDelegateFor("glPrimitiveRestartIndex", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glDrawElementsInstanced = GL.Instance.GetDelegateFor("glDrawElementsInstanced", GLDelegates.typeof_void_uint_int_uint_IntPtr_int) as GLDelegates.void_uint_int_uint_IntPtr_int;
        }

    }
}