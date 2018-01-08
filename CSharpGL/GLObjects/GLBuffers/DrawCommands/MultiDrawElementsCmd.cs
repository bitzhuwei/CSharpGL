using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Render something using 'glMultiDrawArrays'.
    /// </summary>
    [Browsable(true)]
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public class MultiDrawElementsCmd : IDrawCommand
    {
        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int[] Count { get; private set; }

        private byte[] byteIndices;
        private ushort[] ushortIndices;
        private uint[] uintIndices;

        private IndexBufferElementType type;
        private int[] baseVertex;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="indices"></param>
        /// <param name="baseVertex"></param>
        public MultiDrawElementsCmd(DrawMode mode, int[] count, uint[] indices, int[] baseVertex = null)
            : this(mode, count, IndexBufferElementType.UInt, baseVertex)
        {
            if (indices == null || count == null) { throw new System.ArgumentNullException(); }
            if (indices.Length != count.Length) { throw new System.ArgumentException(); }

            this.uintIndices = indices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="indices"></param>
        /// <param name="baseVertex"></param>
        public MultiDrawElementsCmd(DrawMode mode, int[] count, ushort[] indices, int[] baseVertex = null)
            : this(mode, count, IndexBufferElementType.UShort, baseVertex)
        {
            if (indices == null || count == null) { throw new System.ArgumentNullException(); }
            if (indices.Length != count.Length) { throw new System.ArgumentException(); }

            this.ushortIndices = indices;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="indices"></param>
        /// <param name="baseVertex"></param>
        public MultiDrawElementsCmd(DrawMode mode, int[] count, byte[] indices, int[] baseVertex = null)
            : this(mode, count, IndexBufferElementType.UByte, baseVertex)
        {
            if (indices == null || count == null) { throw new System.ArgumentNullException(); }
            if (indices.Length != count.Length) { throw new System.ArgumentException(); }

            this.byteIndices = indices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="type">type of indices' element.</param>
        /// <param name="baseVertex"></param>
        private MultiDrawElementsCmd(DrawMode mode, int[] count, IndexBufferElementType type, int[] baseVertex = null)
        {
            this.type = type;
            this.Mode = mode;
            this.Count = count;
            this.baseVertex = baseVertex;
        }

        /// <summary>
        /// </summary>
        /// <param name="controlMode">index buffer is accessable randomly or only by frame.</param>
        public void Draw(ControlMode controlMode)
        {
            GCHandle pinned;
            IntPtr header;
            switch (this.type)
            {
                case IndexBufferElementType.UByte:
                    pinned = GCHandle.Alloc(this.byteIndices, GCHandleType.Pinned);
                    break;
                case IndexBufferElementType.UShort:
                    pinned = GCHandle.Alloc(this.ushortIndices, GCHandleType.Pinned);
                    break;
                case IndexBufferElementType.UInt:
                    pinned = GCHandle.Alloc(this.uintIndices, GCHandleType.Pinned);
                    break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(IndexBufferElementType));
            }
            header = pinned.AddrOfPinnedObject();
            // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            if (this.baseVertex == null)
            {
                glMultiDrawElements((uint)this.Mode, this.Count, (uint)this.type, header, this.Count.Length);
            }
            else
            {
                glMultiDrawElementsBaseVertex((uint)this.Mode, this.Count, (uint)this.type, header, this.Count.Length, this.baseVertex);
            }
            pinned.Free();
        }

        /// <summary>
        /// void glMultiDrawElements(GLenum mode​, const GLsizei * count​, GLenum type​, const GLvoid * const * indices​, GLsizei drawcount​);
        /// </summary>
        private static readonly GLDelegates.void_uint_intN_uint_IntPtr_int glMultiDrawElements;
        /// <summary>
        /// void glMultiDrawElementsBaseVertex(uint mode​, int[] count​, uint type​, uint[][] indices​, int drawcount​, int[] basevertex​);
        /// </summary>
        private static readonly GLDelegates.void_uint_intN_uint_IntPtr_int_intN glMultiDrawElementsBaseVertex;
        static MultiDrawElementsCmd()
        {
            glMultiDrawElements = GL.Instance.GetDelegateFor("glMultiDrawElements", GLDelegates.typeof_void_uint_intN_uint_IntPtr_int) as GLDelegates.void_uint_intN_uint_IntPtr_int;
            glMultiDrawElementsBaseVertex = GL.Instance.GetDelegateFor("glMultiDrawElementsBaseVertex", GLDelegates.typeof_void_uint_intN_uint_IntPtr_int_intN) as GLDelegates.void_uint_intN_uint_IntPtr_int_intN;
        }
    }
}
