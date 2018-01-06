using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Render something using 'glMultiDrawArrays'.
    /// </summary>
    [Browsable(true)]
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public abstract class MultiDrawElementsCmd : IDrawCommand
    {
        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public int[] First { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int[] Count { get; private set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public Array[] Indices { get; private set; }
        private byte[][] byteIndices;
        private ushort[][] ushortIndices;
        private uint[][] uintIndices;

        private IndexBufferElementType type;
        private int[] baseVertex;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="type">type of <paramref name="indices"/>' element.</param>
        /// <param name="indices"></param>
        /// <param name="baseVertex"></param>
        internal MultiDrawElementsCmd(DrawMode mode, int[] count, IndexBufferElementType type, Array[] indices, int[] baseVertex = null)
        {
            if (indices == null || count == null) { throw new System.ArgumentNullException(); }
            if (indices.Length != count.Length) { throw new System.ArgumentException(); }

            switch (type)
            {
                case IndexBufferElementType.UByte:
                    {
                        var result = indices as byte[][];
                        if (result == null) { throw new ArgumentException(); }
                        this.byteIndices = result;
                    }
                    break;
                case IndexBufferElementType.UShort:
                    {
                        var result = indices as ushort[][];
                        if (result == null) { throw new ArgumentException(); }
                        this.ushortIndices = result;
                    }
                    break;
                case IndexBufferElementType.UInt:
                    {
                        var result = indices as uint[][];
                        if (result == null) { throw new ArgumentException(); }
                        this.uintIndices = result;
                    }
                    break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(IndexBufferElementType));
            }

            this.type = type;
            this.Mode = mode;
            this.Count = count;
            this.baseVertex = baseVertex;
        }

        /// <summary>
        /// 执行此VBO的渲染操作。
        /// <para>Render using this VBO.</para>
        /// </summary>
        /// <param name="controlMode">index buffer is accessable randomly or only by frame.</param>
        public void Draw(ControlMode controlMode)
        {
            if (this.baseVertex == null)
            {
                switch (this.type)
                {
                    case IndexBufferElementType.UByte:
                        GL.Instance.MultiDrawElements((uint)this.Mode, this.Count, this.byteIndices, this.Count.Length);
                        break;
                    case IndexBufferElementType.UShort:
                        GL.Instance.MultiDrawElements((uint)this.Mode, this.Count, this.ushortIndices, this.Count.Length);
                        break;
                    case IndexBufferElementType.UInt:
                        GL.Instance.MultiDrawElements((uint)this.Mode, this.Count, this.uintIndices, this.Count.Length);
                        break;
                    default:
                        throw new NotDealWithNewEnumItemException(typeof(IndexBufferElementType));
                }
            }
            else
            {
                switch (this.type)
                {
                    case IndexBufferElementType.UByte:
                        glMultiDrawElementsBaseVertex_byteNN((uint)this.Mode, this.Count, (uint)this.type, this.byteIndices, this.Count.Length, this.baseVertex);
                        break;
                    case IndexBufferElementType.UShort:
                        glMultiDrawElementsBaseVertex_ushortNN((uint)this.Mode, this.Count, (uint)this.type, this.ushortIndices, this.Count.Length, this.baseVertex);
                        break;
                    case IndexBufferElementType.UInt:
                        glMultiDrawElementsBaseVertex_uintNN((uint)this.Mode, this.Count, (uint)this.type, this.uintIndices, this.Count.Length, this.baseVertex);
                        break;
                    default:
                        throw new NotDealWithNewEnumItemException(typeof(IndexBufferElementType));
                }
            }
        }

        /// <summary>
        /// void glMultiDrawElementsBaseVertex(uint mode​, int[] count​, uint type​, uint[][] indices​, int drawcount​, int[] basevertex​);
        /// </summary>
        private static readonly GLDelegates.void_uint_intN_uint_IntPtr_int_intN glMultiDrawElementsBaseVertex;
        private static readonly GLDelegates.void_uint_intN_uint_uintNN_int_intN glMultiDrawElementsBaseVertex_uintNN;
        private static readonly GLDelegates.void_uint_intN_uint_ushortNN_int_intN glMultiDrawElementsBaseVertex_ushortNN;
        private static readonly GLDelegates.void_uint_intN_uint_byteNN_int_intN glMultiDrawElementsBaseVertex_byteNN;
        static MultiDrawElementsCmd()
        {
            glMultiDrawElementsBaseVertex = GL.Instance.GetDelegateFor("glMultiDrawElementsBaseVertex", GLDelegates.typeof_void_uint_intN_uint_IntPtr_int_intN) as GLDelegates.void_uint_intN_uint_IntPtr_int_intN;
            glMultiDrawElementsBaseVertex_uintNN = GL.Instance.GetDelegateFor("glMultiDrawElementsBaseVertex", GLDelegates.typeof_void_uint_intN_uint_uintNN_int_intN) as GLDelegates.void_uint_intN_uint_uintNN_int_intN;
            glMultiDrawElementsBaseVertex_ushortNN = GL.Instance.GetDelegateFor("glMultiDrawElementsBaseVertex", GLDelegates.typeof_void_uint_intN_uint_ushortNN_int_intN) as GLDelegates.void_uint_intN_uint_ushortNN_int_intN;
            glMultiDrawElementsBaseVertex_byteNN = GL.Instance.GetDelegateFor("glMultiDrawElementsBaseVertex", GLDelegates.typeof_void_uint_intN_uint_byteNN_int_intN) as GLDelegates.void_uint_intN_uint_byteNN_int_intN;
        }
    }
}
