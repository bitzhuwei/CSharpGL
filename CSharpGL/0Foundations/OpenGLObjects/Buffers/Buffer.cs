using System;

namespace CSharpGL
{
    /// <summary>
    /// Vertex Buffer Object.
    /// </summary>
    public abstract class Buffer : IDisposable
    {
        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glGenBuffers glGenBuffers;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glBindBuffer glBindBuffer;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glBufferData glBufferData;

        /// <summary>
        ///
        /// </summary>
        protected UnmanagedArrayBase array = null;

        /// <summary>
        /// 此VBO中的数据在内存中的起始地址
        /// <para>Start position of this buffer; first element's position of this buffer.</para>
        /// </summary>
        public virtual IntPtr Header
        {
            get
            {
                UnmanagedArrayBase array = this.array;
                return (array == null) ? IntPtr.Zero : array.Header;
            }
        }

        /// <summary>
        /// 此VBO中的数据在内存中占用多少个字节？
        /// <para>How many bytes in this buffer?</para>
        /// </summary>
        public virtual int ByteLength
        {
            get
            {
                UnmanagedArrayBase array = this.array;
                return (array == null) ? 0 : array.ByteLength;
            }
        }

        /// <summary>
        /// 此VBO含有多个个元素？
        /// <para>How many elements?</para>
        /// </summary>
        public virtual int Length
        {
            get
            {
                UnmanagedArrayBase array = this.array;
                return (array == null) ? 0 : array.Length;
            }
        }

        /// <summary>
        /// usage in glBufferData(uint target, int size, IntPtr data, uint usage);
        /// </summary>
        public BufferUsage Usage { get; private set; }

        /// <summary>
        /// Vertex Buffer Object.
        /// </summary>
        /// <param name="usage"></param>
        public Buffer(BufferUsage usage)
        {
            if (glGenBuffers == null)
            {
                glGenBuffers = OpenGL.GetDelegateFor<OpenGL.glGenBuffers>();
                glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>();
                glBufferData = OpenGL.GetDelegateFor<OpenGL.glBufferData>();
            }

            this.Usage = usage;
        }

        /// <summary>
        /// 申请指定长度的非托管数组。
        /// <para>create an unmanaged array to store data for this buffer.</para>
        /// </summary>
        /// <param name="elementCount">数组元素的数目。<para>How many elements?</para></param>
        public abstract void Create(int elementCount);

        /// <summary>
        /// 获取一个可渲染此VBO的渲染器。执行此方法后，此对象中的非托管内存即可释放掉，不再占用CPU内存。
        /// Uploads this buffer to GPU memory and gets its pointer.
        /// It's totally OK to free memory of unmanaged array stored in this buffer object after this method invoked.
        /// </summary>
        /// <returns></returns>
        protected abstract BufferPtr Upload2GPU();

        private BufferPtr bufferPtr = null;

        /// <summary>
        /// 获取一个可渲染此VBO的渲染器。执行此方法后，此对象中的非托管内存即可释放掉，不再占用CPU内存。
        /// Uploads this buffer to GPU memory and gets its pointer.
        /// It's totally OK to free memory of unmanaged array stored in this buffer object after this method invoked.
        /// </summary>
        /// <returns></returns>
        public BufferPtr GetBufferPtr()
        {
            if (bufferPtr == null)
            {
                bufferPtr = Upload2GPU();
            }

            return bufferPtr;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            return string.Format("VBO: {0}, usage: {1}", this.array, Usage);
        }

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///
        /// </summary>
        ~Buffer()
        {
            this.Dispose(false);
        }

        private bool disposedValue = false;

        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                }

                // Dispose unmanaged resources.
                UnmanagedArrayBase array = this.array;
                this.array = null;
                if (array != null)
                {
                    array.Dispose();
                }
            }

            this.disposedValue = true;
        }
    }
}