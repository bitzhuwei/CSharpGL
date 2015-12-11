using CSharpGL.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.VertexBuffers
{
    /// <summary>
    /// 顶点缓存（VBO）
    /// </summary>
    public abstract class VertexBuffer : IDisposable
    {
        protected UnmanagedArrayBase array = null;

        /// <summary>
        /// 此VBO中的数据在内存中的起始地址
        /// </summary>
        public IntPtr Data
        {
            get { return (this.array == null) ? IntPtr.Zero : this.array.Header; }
        }


        /// <summary>
        /// 此VBO中的数据在内存中的内存大小（单位：字节）
        /// </summary>
        public int SizeInBytes
        {
            get { return (this.array == null) ? 0 : this.array.ByteLength; }

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

        ~VertexBuffer()
        {
            this.Dispose(false);
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {

            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.

                }

                // Dispose unmanaged resources.

                if (this.array != null)
                {
                    this.array.Dispose();
                    this.array = null;
                }
            }

            this.disposedValue = true;
        }
    }

}
