using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Render something using 'glMultiDrawElements'.
    /// </summary>
    [Browsable(true)]
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public class MultiDrawElementsCmd : IDrawCommand
    {
        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }

        private int[] count;
        private Array allIndices;
        private IndexBufferElementType type;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="allIndices"></param>
        /// <param name="baseVertex"></param>
        public MultiDrawElementsCmd(DrawMode mode, int[] count, uint[] allIndices, int[] baseVertex = null)
            : this(mode, count, IndexBufferElementType.UInt)
        {
            if (allIndices == null || count == null) { throw new System.ArgumentNullException(); }

            this.allIndices = allIndices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="allIndices"></param>
        /// <param name="baseVertex"></param>
        public MultiDrawElementsCmd(DrawMode mode, int[] count, ushort[] allIndices, int[] baseVertex = null)
            : this(mode, count, IndexBufferElementType.UShort)
        {
            if (allIndices == null || count == null) { throw new System.ArgumentNullException(); }

            this.allIndices = allIndices;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="allIndices"></param>
        /// <param name="baseVertex"></param>
        public MultiDrawElementsCmd(DrawMode mode, int[] count, byte[] allIndices, int[] baseVertex = null)
            : this(mode, count, IndexBufferElementType.UByte)
        {
            if (allIndices == null || count == null) { throw new System.ArgumentNullException(); }

            this.allIndices = allIndices;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="type">type of indices' element.</param>
        private MultiDrawElementsCmd(DrawMode mode, int[] count, IndexBufferElementType type)
        {
            this.Mode = mode;
            this.count = count;
            this.type = type;
        }

        /// <summary>
        /// </summary>
        /// <param name="indexAccessMode">index buffer is accessable randomly or only by frame.</param>
        public void Draw(IndexAccessMode indexAccessMode)
        {
            GCHandle pinAll = GCHandle.Alloc(this.allIndices, GCHandleType.Pinned);
            var count = this.count;
            var indices = new IntPtr[count.Length];
            int current = 0;
            for (int i = 0; i < indices.Length; i++)
            {
                indices[i] = Marshal.UnsafeAddrOfPinnedArrayElement(allIndices, current);
                current += count[i];
            }
            GCHandle pinIndices = GCHandle.Alloc(indices, GCHandleType.Pinned);
            IntPtr header = pinIndices.AddrOfPinnedObject();
            glMultiDrawElements((uint)this.Mode, this.count, (uint)this.type, header, this.count.Length);
            pinIndices.Free();
            pinAll.Free();
        }

        /// <summary>
        /// void glMultiDrawElements(GLenum mode​, const GLsizei * count​, GLenum type​, const GLvoid * const * indices​, GLsizei drawcount​);
        /// </summary>
        private static readonly GLDelegates.void_uint_intN_uint_IntPtr_int glMultiDrawElements;
        static MultiDrawElementsCmd()
        {
            glMultiDrawElements = GL.Instance.GetDelegateFor("glMultiDrawElements", GLDelegates.typeof_void_uint_intN_uint_IntPtr_int) as GLDelegates.void_uint_intN_uint_IntPtr_int;
        }

    }
}
