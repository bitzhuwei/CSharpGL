using System;

namespace CSharpGL
{
    // 用glDrawElements()执行一个索引buffer的渲染操作。
    /// <summary>
    /// Wraps glDrawElements(uint mode, int count, uint type, IntPtr indices).
    /// </summary>
    public sealed class OneIndexBufferPtr : IndexBufferPtr
    {
        private static OpenGL.glDrawElementsInstanced glDrawElementsInstanced;

        /// <summary>
        /// Wraps glDrawElements(uint mode, int count, uint type, IntPtr indices).
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="firstIndex">要渲染的第一个索引的位置。<para>First index to be rendered.</para></param>
        /// <param name="elementCount">索引数组中有多少个元素。<para>How many indexes to be rendered?</para></param>
        /// <param name="type">type in glDrawElements(uint mode, int count, uint type, IntPtr indices);
        /// <para>表示第3个参数，表示索引元素的类型。</para></param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        internal OneIndexBufferPtr(uint bufferId, DrawMode mode, int firstIndex, int elementCount,
            IndexElementType type, int length, int byteLength, int primCount = 1)
            : base(BufferTarget.ElementArrayBuffer, mode, bufferId, length, byteLength, primCount)
        {
            if (glDrawElementsInstanced == null)
            { glDrawElementsInstanced = OpenGL.GetDelegateFor<OpenGL.glDrawElementsInstanced>(); }

            this.FirstIndex = firstIndex;
            this.ElementCount = elementCount;
            this.OriginalElementCount = elementCount;
            this.Type = type;
        }

        /// <summary>
        /// 要渲染的第一个索引的位置。
        /// <para>First index to be rendered.</para>
        /// </summary>
        public int FirstIndex { get; set; }

        /// <summary>
        /// 要渲染多少个索引。
        /// <para>How many indexes to be rendered?</para>
        /// </summary>
        public int ElementCount { get; set; }

        /// <summary>
        /// How many indexes are there in total?
        /// </summary>
        public int OriginalElementCount { get; private set; }

        /// <summary>
        /// type in GL.DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// </summary>
        public IndexElementType Type { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        public override void Render(RenderEventArgs arg)
        {
            IntPtr offset;
            switch (this.Type)
            {
                case IndexElementType.UnsignedByte:
                    offset = new IntPtr(this.FirstIndex * sizeof(byte));
                    break;

                case IndexElementType.UnsighedShort:
                    offset = new IntPtr(this.FirstIndex * sizeof(ushort));
                    break;

                case IndexElementType.UnsignedInt:
                    offset = new IntPtr(this.FirstIndex * sizeof(uint));
                    break;

                default:
                    throw new NotImplementedException();
            }
            glBindBuffer(OpenGL.GL_ELEMENT_ARRAY_BUFFER, this.BufferId);
            uint mode = 0;
            if (arg.RenderMode == RenderModes.ColorCodedPicking
                && arg.PickingGeometryType == GeometryType.Point
                && this.Mode.ToGeometryType() == GeometryType.Line)// picking point from a line
            {
                // this may render points that should not appear.
                // so need to select by another picking.
                mode = (uint)DrawMode.Points;
            }
            else
            {
                mode = (uint)this.Mode;
            }

            int primCount = this.PrimCount;
            if (primCount < 1) { throw new Exception("error: primCount is less than 1."); }
            else if (primCount == 1)
            {
                OpenGL.DrawElements(mode, this.ElementCount, (uint)this.Type, offset);
            }
            else
            {
                glDrawElementsInstanced(mode, this.ElementCount, (uint)this.Type, offset, primCount);
            }

            glBindBuffer(OpenGL.GL_ELEMENT_ARRAY_BUFFER, 0);
        }


        /// <summary>
        /// Start to read/write buffer.
        /// </summary>
        /// <param name="access"></param>
        /// <param name="bind"></param>
        /// <returns></returns>
        public IntPtr MapBuffer(MapBufferAccess access, bool bind = true)
        {
            if (bind)
            {
                glBindBuffer(OpenGL.GL_ELEMENT_ARRAY_BUFFER, this.BufferId);
            }
            IntPtr pointer = glMapBuffer(OpenGL.GL_ELEMENT_ARRAY_BUFFER, (uint)access);
            return pointer;
        }

        /// <summary>
        /// Start to read/write buffer.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="access"></param>
        /// <param name="bind"></param>
        /// <returns></returns>
        public IntPtr MapBufferRange(int offset, int length, MapBufferRangeAccess access, bool bind = true)
        {
            if (bind)
            {
                glBindBuffer(OpenGL.GL_ELEMENT_ARRAY_BUFFER, this.BufferId);
            }
            return glMapBufferRange(OpenGL.GL_ELEMENT_ARRAY_BUFFER, offset, length, (uint)access);
        }

        /// <summary>
        /// Stop reading/writing buffer.
        /// </summary>
        /// <param name="unbind"></param>
        public void UnmapBuffer(bool unbind = true)
        {
            glUnmapBuffer(OpenGL.GL_ELEMENT_ARRAY_BUFFER);
            if (unbind)
            {
                glBindBuffer(OpenGL.GL_ELEMENT_ARRAY_BUFFER, 0);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string type = string.Empty;
            switch (this.Type)
            {
                case IndexElementType.UnsignedByte:
                    type = "byte";
                    break;

                case IndexElementType.UnsighedShort:
                    type = "ushort";
                    break;

                case IndexElementType.UnsignedInt:
                    type = "uint";
                    break;

                default:
                    throw new NotImplementedException();
            }
            int primCount = this.PrimCount;
            if (primCount < 1)
            {
                return string.Format("error: primCount is less than 1.");
            }
            else if (primCount == 1)
            {
                return string.Format("glDrawElements({0}, {1}, {2}, new IntPtr({3} * sizeof({4}))",
                    this.Mode, this.ElementCount, this.Type, this.FirstIndex, type);
            }
            else
            {
                return string.Format("glDrawElementsInstanced({0}, {1}, {2}, new IntPtr({3} * sizeof({4}), {5})",
                    this.Mode, this.ElementCount, this.Type, this.FirstIndex, type, primCount);
            }
        }
    }
}