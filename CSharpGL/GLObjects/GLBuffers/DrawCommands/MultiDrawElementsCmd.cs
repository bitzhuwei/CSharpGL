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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="indices"></param>
        /// <param name="type">type of <paramref name="indices"/>' element.</param>
        internal MultiDrawElementsCmd(DrawMode mode, int[] count, Array[] indices, IndexBufferElementType type)
        {
            if (indices == null || count == null) { throw new System.ArgumentNullException(); }
            if (indices.Length != count.Length) { throw new System.ArgumentException(); }

            this.type = type;

            this.Mode = mode;
            this.Count = count;
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
        }

        /// <summary>
        /// 执行此VBO的渲染操作。
        /// <para>Render using this VBO.</para>
        /// </summary>
        /// <param name="controlMode">index buffer is accessable randomly or only by frame.</param>
        public void Draw(ControlMode controlMode)
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
                    break;
            }
        }
    }
}
