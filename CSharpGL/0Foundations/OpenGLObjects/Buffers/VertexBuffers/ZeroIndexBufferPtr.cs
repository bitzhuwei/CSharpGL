using System;

namespace CSharpGL
{
    // 没有显式索引时的渲染方法。
    /// <summary>
    /// Wraps glDrawArrays(uint mode, int first, int count).
    /// </summary>
    public sealed class ZeroIndexBufferPtr : IndexBufferPtr
    {
        private static OpenGL.glDrawArraysInstanced glDrawArraysInstanced;

        /// <summary>
        /// Invalid for <see cref="ZeroIndexBufferPtr"/>.
        /// </summary>
        public override BufferTarget Target
        {
            get { return BufferTarget.InvalidTarget; }
        }

        /// <summary>
        /// Wraps glDrawArrays(uint mode, int first, int count).
        /// </summary>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="vertexCount">要渲染多少个元素？<para>How many vertexes to be rendered?</para></param>
        /// <param name="primCount">primCount in instanced rendering.</param>
        internal ZeroIndexBufferPtr(DrawMode mode, int firstVertex, int vertexCount, int primCount = 1)
            : base(mode, 0, vertexCount, vertexCount * sizeof(uint), primCount)
        {
            if (glDrawArraysInstanced == null)
            { glDrawArraysInstanced = OpenGL.GetDelegateFor<OpenGL.glDrawArraysInstanced>(); }

            this.FirstVertex = firstVertex;
            this.RenderingVertexCount = vertexCount;
            //this.OriginalVertexCount = vertexCount;
        }

        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>
        /// </summary>
        public int FirstVertex { get; set; }

        /// <summary>
        /// 要渲染多少个元素？<para>How many vertexes to be rendered?</para>
        /// </summary>
        public int RenderingVertexCount { get; set; }

        ///// <summary>
        ///// 总共有多少个元素？<para>How many vertexes are there in total?</para>
        ///// </summary>
        //public int OriginalVertexCount { get; private set; }

        /// <summary>
        /// need to do nothing.
        /// </summary>
        public override void Bind()
        {
            // need to do nothing.
        }

        /// <summary>
        /// need to do nothing.
        /// </summary>
        public override void Unbind()
        {
            // need to do nothing.
        }

        /// <summary>
        /// Start to read/write buffer.
        /// <para>This will returns IntPtr.Zero as this buffer allocates no data in memory.</para>
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="access"></param>
        /// <param name="bind"></param>
        /// <returns></returns>
        public override IntPtr MapBufferRange(int offset, int length, MapBufferRangeAccess access, bool bind = true)
        {
            return IntPtr.Zero;
        }

        /// <summary>
        /// Start to read/write buffer.
        /// <para>This will returns IntPtr.Zero as this buffer allocates no data in memory.</para>
        /// </summary>
        /// <param name="access"></param>
        /// <param name="bind"></param>
        /// <returns></returns>
        public override IntPtr MapBuffer(MapBufferAccess access, bool bind = true)
        {
            return IntPtr.Zero;
        }

        /// <summary>
        /// Stop reading/writing buffer.
        /// <para>need to do nothing.</para>
        /// </summary>
        /// <param name="unbind"></param>
        public override bool UnmapBuffer(bool unbind = true)
        {
            // need to do nothing.
            return true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        public override void Render(RenderEventArgs arg)
        {
            uint mode = 0;
            if (arg.PickingGeometryType == PickingGeometryType.Point
                && this.Mode.ToGeometryType() == PickingGeometryType.Line)// picking point from a line
            {
                // this maybe render points that should not appear.
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
                OpenGL.DrawArrays(mode, this.FirstVertex, this.RenderingVertexCount);
            }
            else
            {
                glDrawArraysInstanced(mode, this.FirstVertex, this.RenderingVertexCount, primCount);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            int primCount = this.PrimCount;
            if (primCount < 1)
            {
                return string.Format("error: primCount is less than 1.");
            }
            else if (primCount == 1)
            {
                return string.Format("OpenGL.DrawArrays({0}, {1}, {2})",
                    this.Mode, this.FirstVertex, this.RenderingVertexCount);
            }
            else
            {
                return string.Format("OpenGL.glDrawArraysInstanced({0}, {1}, {2}, {3})",
                    this.Mode, this.FirstVertex, this.RenderingVertexCount, this.PrimCount);
            }
        }
    }
}