using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    // 用glDrawElements()执行一个索引buffer的渲染操作。
    /// <summary>
    /// Wraps glDrawElements(uint mode, int count, uint type, IntPtr indices).
    /// </summary>
    [Editor(typeof(DrawElementsCmdEditor), typeof(UITypeEditor))]
    public class DrawElementsInstancedCmd : IDrawCommand//, IHasIndexBuffer
    {
        //#region IHasIndexBuffer

        private IndexBuffer indexBuffer;
        /// <summary>
        /// 
        /// </summary>
        public IndexBuffer IndexBufferObject { get { return this.indexBuffer; } }

        //#endregion IHasIndexBuffer

        /// <summary>
        /// Wraps glDrawElements(uint mode, int count, uint type, IntPtr indices).
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="mode"></param>
        /// <param name="instanceCount">primCount in instanced rendering.</param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="primitiveRestartIndex">usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.</param>
        public DrawElementsInstancedCmd(IndexBuffer indexBuffer, DrawMode mode, int instanceCount, int firstVertex = 0, uint primitiveRestartIndex = 0)
        //IndexBufferElementType elementType, int vertexCount, int byteLength, int instanceCount = 1, int frameCount = 1)
        //: base(mode, bufferId, 0, vertexCount, byteLength, instanceCount, frameCount)
        {
            if (indexBuffer == null) { throw new ArgumentNullException("indexBuffer"); }

            this.indexBuffer = indexBuffer;
            this.Mode = mode;
            this.InstanceCount = instanceCount;

            this.FirstVertex = firstVertex;
            this.PrimitiveRestartIndex = primitiveRestartIndex;

            this.RenderingVertexCount = indexBuffer.Length;
        }

        // RULE: CSharpGL takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care of this rule when designing a model's index buffer.
        /// <summary>
        /// usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.
        /// </summary>
        public uint PrimitiveRestartIndex { get; set; }

        ///// <summary>
        ///// type in GL.DrawElements(uint mode, int count, uint type, IntPtr indices);
        ///// </summary>
        //public IndexBufferElementType ElementType { get; private set; }

        /// <summary>
        /// Gets or sets index of current frame.
        /// </summary>
        [Category("ControlMode.ByFrame")]
        public int CurrentFrame { get; set; }


        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>
        /// </summary>
        [Category("ControlMode.Random")]
        public int FirstVertex { get; set; }

        /// <summary>
        /// 要渲染多少个元素？<para>How many vertexes to be rendered?</para>
        /// </summary>
        [Category("ControlMode.Random")]
        public int RenderingVertexCount { get; set; }

        /// <summary>
        /// primCount in instanced rendering.
        /// </summary>
        public int InstanceCount { get; private set; }

        #region IDrawCommand

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="indexAccessMode">index buffer is accessable randomly or only by frame.</param>
        public void Draw(IndexAccessMode indexAccessMode)
        {
            int instanceCount = this.InstanceCount;
            if (instanceCount < 1) { throw new Exception("error: instanceCount is less than 1."); }

            uint mode = (uint)this.Mode;
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
            switch (indexAccessMode)
            {
                case IndexAccessMode.ByFrame:
                    glDrawElementsInstanced(mode, vertexCount, (uint)elementType, offset, instanceCount);
                    break;
                case IndexAccessMode.Random:
                    glDrawElementsInstanced(mode, this.RenderingVertexCount, (uint)elementType, offset, instanceCount);
                    break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(IndexAccessMode));
            }

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
            int primCount = this.InstanceCount;
            if (primCount < 1) { return string.Format("error: primCount is less than 1."); }

            var mode = this.Mode;
            IndexBuffer indexBuffer = this.indexBuffer;
            int vertexCount = indexBuffer.Length;
            IndexBufferElementType elementType = indexBuffer.ElementType;
            IntPtr offset = GetOffset(elementType, this.FirstVertex);

            var builder = new System.Text.StringBuilder();

            builder.AppendLine("ControlMode.ByFrame:");
            builder.AppendLine(string.Format("glDrawElementsInstanced(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, primCount: {4});", mode, vertexCount, elementType, offset, primCount));

            builder.AppendLine("ControlMode.Random:");
            builder.AppendLine(string.Format("glDrawElementsInstanced(mode: {0}, vertexCount: {1}, type: {2}, offset: {3}, primCount: {4});", mode, this.RenderingVertexCount, elementType, offset, primCount));

            return builder.ToString();
        }

        private static GLDelegates.void_uint glPrimitiveRestartIndex;
        internal static readonly GLDelegates.void_uint_int_uint_IntPtr_int glDrawElementsInstanced;
        static DrawElementsInstancedCmd()
        {
            glPrimitiveRestartIndex = GL.Instance.GetDelegateFor("glPrimitiveRestartIndex", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glDrawElementsInstanced = GL.Instance.GetDelegateFor("glDrawElementsInstanced", GLDelegates.typeof_void_uint_int_uint_IntPtr_int) as GLDelegates.void_uint_int_uint_IntPtr_int;
        }

    }
}