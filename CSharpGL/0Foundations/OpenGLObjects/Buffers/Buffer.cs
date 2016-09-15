using System;

namespace CSharpGL
{
    /// <summary>
    /// Vertex Buffer Object.
    /// </summary>
    public abstract partial class Buffer : IDisposable
    {
        /// <summary>
        ///
        /// </summary>
        protected static OpenGL.glGenBuffers glGenBuffers;

        /// <summary>
        ///
        /// </summary>
        protected static OpenGL.glBindBuffer glBindBuffer;

        /// <summary>
        ///
        /// </summary>
        protected static OpenGL.glBufferData glBufferData;

        /// <summary>
        ///
        /// </summary>
        protected UnmanagedArrayBase array = null;

        /// <summary>
        /// 此VBO中的数据在内存中的起始地址
        /// <para>Start position of this buffer; first element's position of this buffer.</para>
        /// <para>Similar to <code>array</code> in <code>int array[Length];</code></para>
        /// </summary>
        public IntPtr Header
        {
            get
            {
                UnmanagedArrayBase array = this.array;
                return (array == null) ? IntPtr.Zero : array.Header;
            }
        }

        /// <summary>
        /// 此VBO中的数据在内存中占用多少个字节？（元素的总数 * 单个元素的字节数）
        /// <para>How many bytes in this buffer?</para>
        /// <para>Length * elementSize</para>
        /// </summary>
        public int ByteLength
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
        /// <para>Similar to <code>Length</code> in <code>int array[Length];</code></para>
        /// </summary>
        public int Length
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
            this.Usage = usage;
        }

        /// <summary>
        /// 申请指定元素数目的非托管数组。
        /// <para>create an unmanaged array to store data for this buffer.</para>
        /// </summary>
        /// <param name="elementCount">数组元素的数目。<para>How many elements?</para></param>
        public abstract void Create(int elementCount);

        /// <summary>
        /// 将此Buffer的数据上传到GPU内存，并获取在GPU上的指针。执行此方法后，此对象中的非托管内存即可释放掉，不再占用CPU内存。
        /// Uploads this buffer to GPU memory and gets its pointer.
        /// It's totally OK to free memory of unmanaged array stored in this buffer object after this method invoked.
        /// </summary>
        /// <returns></returns>
        protected abstract BufferPtr Upload2GPU();

        private BufferPtr bufferPtr = null;

        /// <summary>
        /// 将此Buffer的数据上传到GPU内存，并获取在GPU上的指针。执行此方法后，此对象中的非托管内存即可释放掉，不再占用CPU内存。
        /// Uploads this buffer to GPU memory and gets its pointer.
        /// It's totally OK to free memory of unmanaged array stored in this buffer object after this method invoked.
        /// </summary>
        /// <returns></returns>
        public BufferPtr GetBufferPtr()
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
        public override string ToString()
        {
            return string.Format("VBO: {0}, usage: {1}", this.array, Usage);
        }
    }
}