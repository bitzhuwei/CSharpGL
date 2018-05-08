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
    public class DrawElementsCmd : IDrawCommand//, IHasIndexBuffer
    {
        private const string strDrawElementsCmd = "DrawElementsCmd";

        //#region IHasIndexBuffer

        private IndexBuffer indexBuffer;
        /// <summary>
        /// 
        /// </summary>
        [Category(strDrawElementsCmd)]
        public IndexBuffer IndexBufferObject { get { return this.indexBuffer; } }

        //#endregion IHasIndexBuffer

        /// <summary>
        /// Wraps glDrawElements(uint mode, int count, uint type, IntPtr indices).
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="mode"></param>
        /// <param name="primitiveRestartIndex">usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.</param>
        public DrawElementsCmd(IndexBuffer indexBuffer, DrawMode mode, uint primitiveRestartIndex = 0)
            : this(indexBuffer, mode, 0, indexBuffer.Length, primitiveRestartIndex)
        { }

        /// <summary>
        /// Wraps glDrawElements(uint mode, int count, uint type, IntPtr indices).
        /// </summary>
        /// <param name="indexBuffer"></param>
        /// <param name="mode"></param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="vertexCount">要渲染多少个顶点？<para>How many vertexes to be rendered?</para></param>
        /// <param name="primitiveRestartIndex">usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.</param>
        public DrawElementsCmd(IndexBuffer indexBuffer, DrawMode mode, int firstVertex, int vertexCount, uint primitiveRestartIndex = 0)
        {
            if (indexBuffer == null) { throw new ArgumentNullException("indexBuffer"); }

            this.indexBuffer = indexBuffer;
            this.Mode = mode;
            this.CurrentMode = mode;
            this.FirstVertex = firstVertex;
            this.VertexCount = vertexCount;
            this.PrimitiveRestartIndex = primitiveRestartIndex;
        }

        // RULE: CSharpGL takes uint.MaxValue, ushort.MaxValue or byte.MaxValue as PrimitiveRestartIndex. So take care of this rule when designing a model's index buffer.
        /// <summary>
        /// usually uint.MaxValue, ushort.MaxValue or byte.MaxValue. 0 means not need to use `glPrimitiveRestartIndex`.
        /// </summary>
        [Category(strDrawElementsCmd)]
        public uint PrimitiveRestartIndex { get; set; }

        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>
        /// </summary>
        [Category(strDrawElementsCmd)]
        public int FirstVertex { get; set; }

        /// <summary>
        /// 要渲染多少个顶点？<para>How many vertexes to be rendered?</para>
        /// </summary>
        [Category(strDrawElementsCmd)]
        public int VertexCount { get; set; }

        #region IDrawCommand

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        [Category(strDrawElementsCmd)]
        public DrawMode Mode { get; private set; }

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        [Category(strDrawElementsCmd)]
        public DrawMode CurrentMode { get; set; }

        /// <summary>
        ///
        /// </summary>
        public void Draw()
        {
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
            GL.Instance.DrawElements(mode, this.VertexCount, (uint)elementType, offset);
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
            IndexBuffer indexBuffer = this.indexBuffer;
            int vertexCount = indexBuffer.Length;
            IndexBufferElementType elementType = indexBuffer.ElementType;
            IntPtr offset = GetOffset(elementType, this.FirstVertex);

            return string.Format("glDrawElements(mode: {0}, vertexCount: {1}, type: {2}, offset: {3});", this.CurrentMode, this.VertexCount, elementType, offset);
        }

        private static GLDelegates.void_uint glPrimitiveRestartIndex;
        static DrawElementsCmd()
        {
            glPrimitiveRestartIndex = GL.Instance.GetDelegateFor("glPrimitiveRestartIndex", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        }

    }
}