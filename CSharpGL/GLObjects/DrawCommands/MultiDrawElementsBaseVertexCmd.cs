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
    public class MultiDrawElementsBaseVertexCmd : IDrawCommand
    {
        private const string strMultiDrawElementsBaseVertexCmd = "MultiDrawElementsBaseVertexCmd";
        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        [Category(strMultiDrawElementsBaseVertexCmd)]
        public DrawMode Mode { get; private set; }

        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        [Category(strMultiDrawElementsBaseVertexCmd)]
        public DrawMode CurrentMode { get; set; }

        private int[] count;
        private Array allIndices;
        private IndexBufferElementType type;
        private int[] baseVertex;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="allIndices"></param>
        /// <param name="baseVertex"></param>
        public MultiDrawElementsBaseVertexCmd(DrawMode mode, int[] count, uint[] allIndices, int[] baseVertex = null)
            : this(mode, count, IndexBufferElementType.UInt, baseVertex)
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
        public MultiDrawElementsBaseVertexCmd(DrawMode mode, int[] count, ushort[] allIndices, int[] baseVertex = null)
            : this(mode, count, IndexBufferElementType.UShort, baseVertex)
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
        public MultiDrawElementsBaseVertexCmd(DrawMode mode, int[] count, byte[] allIndices, int[] baseVertex = null)
            : this(mode, count, IndexBufferElementType.UByte, baseVertex)
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
        /// <param name="baseVertex"></param>
        private MultiDrawElementsBaseVertexCmd(DrawMode mode, int[] count, IndexBufferElementType type, int[] baseVertex = null)
        {
            if (this.baseVertex == null) { throw new ArgumentNullException("baseVertex"); }

            this.Mode = mode;
            this.CurrentMode = mode;
            this.count = count;
            this.type = type;
            this.baseVertex = baseVertex;
        }

        /// <summary>
        /// </summary>
        public void Draw()
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
            glMultiDrawElementsBaseVertex((uint)this.CurrentMode, this.count, (uint)this.type, header, this.count.Length, this.baseVertex);
            pinIndices.Free();
            pinAll.Free();
        }

        /// <summary>
        /// void glMultiDrawElementsBaseVertex(uint mode​, int[] count​, uint type​, uint[][] indices​, int drawcount​, int[] basevertex​);
        /// </summary>
        private static readonly GLDelegates.void_uint_intN_uint_IntPtr_int_intN glMultiDrawElementsBaseVertex;
        static MultiDrawElementsBaseVertexCmd()
        {
            glMultiDrawElementsBaseVertex = GL.Instance.GetDelegateFor("glMultiDrawElementsBaseVertex", GLDelegates.typeof_void_uint_intN_uint_IntPtr_int_intN) as GLDelegates.void_uint_intN_uint_IntPtr_int_intN;
        }

    }
}
