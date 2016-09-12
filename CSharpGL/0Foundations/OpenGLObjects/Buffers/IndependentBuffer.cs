namespace CSharpGL
{
    /// <summary>
    /// Buffer object that not work as input variable in shader.
    /// </summary>
    /// <typeparam name="T">此buffer存储的是哪种struct的数据？<para>type of index value.</para></typeparam>
    public abstract class IndependentBuffer<T> : Buffer where T : struct
    {
        /// <summary>
        /// No data copyed from CPU memory to GPU memory.
        /// </summary>
        private bool noDataCopyed;

        /// <summary>
        /// </summary>
        /// <param name="usage"></param>
        /// <param name="noDataCopyed">No data copyed from CPU memory to GPU memory.</param>
        public IndependentBuffer(BufferUsage usage, bool noDataCopyed)
            : base(usage)
        {
            this.noDataCopyed = noDataCopyed;
        }

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
            return string.Format("ByteLength: {0}, Header: {1}", this.ByteLength, this.Header);
        }
    }
}