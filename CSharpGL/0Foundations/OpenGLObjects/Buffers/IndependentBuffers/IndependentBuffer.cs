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
        protected override UnmanagedArrayBase DoAlloc(int elementCount)
        {
            bool autoAlloc = !this.noDataCopyed;
            return new UnmanagedArray<T>(elementCount, autoAlloc);
        }

        /// <summary>
        /// 将此Buffer的数据上传到GPU内存，并获取在GPU上的指针。执行此方法后，此对象中的非托管内存即可释放掉，不再占用CPU内存。
        /// Uploads this buffer to GPU memory and gets its pointer.
        /// It's totally OK to free memory of unmanaged array stored in this buffer object after this method invoked.
        /// </summary>
        /// <returns></returns>
        protected abstract IndependentBufferPtr Upload2GPU();

        private IndependentBufferPtr bufferPtr = null;

        /// <summary>
        /// 将此Buffer的数据上传到GPU内存，并获取在GPU上的指针。执行此方法后，此对象中的非托管内存即可释放掉，不再占用CPU内存。
        /// Uploads this buffer to GPU memory and gets its pointer.
        /// It's totally OK to free memory of unmanaged array stored in this buffer object after this method invoked.
        /// </summary>
        /// <returns></returns>
        public IndependentBufferPtr GetBufferPtr()
        {
            if (bufferPtr == null)
            {
                if (glGenBuffers == null)
                {
                    glGenBuffers = OpenGL.GetDelegateFor<OpenGL.glGenBuffers>();
                    glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>();
                    glBufferData = OpenGL.GetDelegateFor<OpenGL.glBufferData>();
                }

                bufferPtr = Upload2GPU();
            }

            return bufferPtr;
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