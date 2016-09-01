using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T">此buffer存储的是哪种struct的数据？<para>type of index value.</para></typeparam>
    public class IndependentBuffer<T> : Buffer where T : struct
    {

        /// <summary>
        /// </summary>
        /// <param name="target"></param>
        /// <param name="usage"></param>
        public IndependentBuffer(BufferTarget target, BufferUsage usage)
            : base(usage)
        {
            this.Target = target;
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
            glBufferData(target, this.ByteLength, IntPtr.Zero, (uint)this.Usage);
            glBindBuffer(target, 0);

            var bufferPtr = new IndependentBufferPtr(this.Target,
                buffers[0], this.Length, this.ByteLength);

            return bufferPtr;
        }

        /// <summary>
        /// 申请指定长度的非托管数组。
        /// <para>create an unmanaged array to store data for this buffer.</para>
        /// </summary>
        /// <param name="elementCount">数组元素的数目。<para>How many elements?</para></param>
        public override void Create(int elementCount)
        {
            this.array = new UnmanagedArray<T>(elementCount);
        }

        /// <summary>
        /// 
        /// </summary>
        public BufferTarget Target { get; private set; }
    }
}
