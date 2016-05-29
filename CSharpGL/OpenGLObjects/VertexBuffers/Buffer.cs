using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 顶点缓存（VBO）
    /// </summary>
    ///// <typeparam name="T">此buffer存储的是哪种struct的数据？</typeparam>
    public abstract class Buffer : IDisposable //where T : struct
    {
        protected static OpenGL.glGenBuffers glGenBuffers;
        protected static OpenGL.glBindBuffer glBindBuffer;
        protected static OpenGL.glBufferData glBufferData;

        private UnmanagedArrayBase array = null;

        /// <summary>
        /// 此VBO中的数据在内存中的起始地址
        /// </summary>
        public IntPtr Header
        {
            get { return (this.array == null) ? IntPtr.Zero : this.array.Header; }
        }

        /// <summary>
        /// 获取此VBO的内存首地址。用于快速读写。
        /// </summary>
        /// <returns></returns>
        public unsafe void* FirstElement()
        {
            UnmanagedArrayBase array = this.array;
            if (array == null) { return (void*)0; }
            else
            {
                return array.Header.ToPointer();
            }
        }

        /// <summary>
        /// 此VBO中的数据在内存中占用多少个字节？
        /// </summary>
        public int ByteLength
        {
            get { return (this.array == null) ? 0 : this.array.ByteLength; }

        }

        /// <summary>
        /// 此VBO含有多个个元素？
        /// </summary>
        public int Length
        {
            get { return (this.array == null) ? 0 : this.array.Length; }
        }

        /// <summary>
        /// usage in glBufferData(uint target, int size, IntPtr data, uint usage);
        /// </summary>
        public BufferUsage Usage { get; private set; }

        /// <summary>
        /// 顶点缓存（VBO）
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
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("VBO: {0}, usage: {1}", this.array, Usage);
        }

        /// <summary>
        /// 根据buffer内存放的具体的结构类型创建非托管数组。
        /// </summary>
        /// <param name="elementCount">数组元素的数目。</param>
        /// <returns></returns>
        protected abstract UnmanagedArrayBase CreateElements(int elementCount);

        /// <summary>
        /// 申请指定长度的非托管数组。
        /// </summary>
        /// <param name="elementCount">数组元素的数目。</param>
        public void Alloc(int elementCount)
        {
            this.array = CreateElements(elementCount);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

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


        /// <summary>
        /// 获取一个可渲染此VBO的渲染器。
        /// </summary>
        /// <returns></returns>
        protected abstract BufferPtr Upload2GPU();

        private BufferPtr bufferPtr = null;

        /// <summary>
        /// 获取一个可渲染此VBO的渲染器。
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
    }

}
