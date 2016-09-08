namespace CSharpGL
{
    /// <summary>
    /// 没有显式的索引。等价于索引数组的值为[0,1,2,2,3,4,5,6,7,8,9...]
    /// <para>Same effect to <see cref="OneIndexBufferPtr"/> with content: [0,1,2,2,3,4,5,6,7,8,9...].</para>
    /// </summary>
    public sealed class ZeroIndexBuffer : IndexBuffer<byte>
    {
        /// <summary>
        /// 没有显式的索引。等价于索引数组的值为[0,1,2,2,3,4,5,6,7,8,9...]
        /// <para>Same effect to <see cref="OneIndexBuffer&lt;T&gt;"/> with content: [0,1,2,2,3,4,5,6,7,8,9...].</para>
        /// </summary>
        /// <param name="mode">渲染模式。</param>
        /// <param name="firstVertex">要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para></param>
        /// <param name="vertexCount">要渲染多少个元素？<para>How many vertexes to be rendered?</para></param>
        public ZeroIndexBuffer(DrawMode mode, int firstVertex, int vertexCount)
            : base(mode, BufferUsage.StaticDraw)
        {
            this.FirstVertex = firstVertex;
            this.VertexCount = vertexCount;
        }

        /// <summary>
        /// 要渲染的第一个顶点的位置。<para>Index of first vertex to be rendered.</para>
        /// </summary>
        public int FirstVertex { get; private set; }

        /// <summary>
        /// 要渲染多少个元素？<para>How many vertexes to be rendered?</para>
        /// </summary>
        public int VertexCount { get; private set; }

        /// <summary>
        /// 对此buffer，没有必要调用此方法。
        /// <para>No need to invoke this method for <see cref="ZeroIndexBuffer"/>.</para>
        /// </summary>
        /// <param name="elementCount">数组元素的数目。<para>How many elements?</para></param>
        public override void Create(int elementCount)
        {
            // no need to alloc memory for this buffer.
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected override BufferPtr Upload2GPU()
        {
            ZeroIndexBufferPtr bufferPtr = new ZeroIndexBufferPtr(
                 this.Mode, this.FirstVertex, this.VertexCount);

            return bufferPtr;
        }
    }
}