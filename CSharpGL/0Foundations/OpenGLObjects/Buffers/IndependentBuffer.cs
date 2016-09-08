namespace CSharpGL
{
    /// <summary>
    /// Buffer object that not work as input variable in shader.
    /// </summary>
    /// <typeparam name="T">此buffer存储的是哪种struct的数据？<para>type of index value.</para></typeparam>
    public class IndependentBuffer<T> : Buffer where T : struct
    {
        /// <summary>
        /// No data copyed from CPU memory to GPU memory.
        /// </summary>
        private bool noDataCopyed;

        /// <summary>
        /// </summary>
        /// <param name="target"></param>
        /// <param name="usage"></param>
        /// <param name="noDataCopyed">No data copyed from CPU memory to GPU memory.</param>
        public IndependentBuffer(BufferTarget target, BufferUsage usage, bool noDataCopyed)
            : base(usage)
        {
            this.Target = target;
            this.noDataCopyed = noDataCopyed;
        }

        /// <summary>
        ///
        /// </summary>
        public BufferTarget Target { get; private set; }

        /// <summary>
        /// 申请指定长度的非托管数组。
        /// <para>create an unmanaged array to store data for this buffer.</para>
        /// </summary>
        /// <param name="elementCount">数组元素的数目。<para>How many elements?</para></param>
        public override void Create(int elementCount)
        {
            bool autoAlloc = !this.noDataCopyed;
            this.array = new UnmanagedArray<T>(elementCount, autoAlloc);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, ByteLength: {1}, Header: {2}", this.Target, this.ByteLength, this.Header);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected override BufferPtr Upload2GPU()
        {
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            var target = (uint)this.Target;
            glBindBuffer(target, buffers[0]);
            glBufferData(target, this.ByteLength, this.Header, (uint)this.Usage);
            glBindBuffer(target, 0);

            var bufferPtr = new IndependentBufferPtr(this.Target, buffers[0], this.Length, this.ByteLength);

            return bufferPtr;
        }
    }
}