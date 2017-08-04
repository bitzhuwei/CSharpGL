using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// 位于服务器端（GPU内存）的定长数组。
    /// <para>An array at server side (GPU memory) with fixed length.</para>
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class TransformFeedbackBuffer : GLBuffer, IDisposable
    {
        /// <summary>
        /// 位于服务器端（GPU内存）的定长数组。
        /// <para>An array at server side (GPU memory) with fixed length.</para>
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此VBO含有多少个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal TransformFeedbackBuffer(uint bufferId, int length, int byteLength)
            : base(bufferId, length, byteLength)
        {
            this.Target = BufferTarget.TransformFeedbackBuffer;
        }

        public override void Bind()
        {
            glBindTransformFeedback((uint)this.Target, this.BufferId);
        }

        public override void Unbind()
        {
            glBindTransformFeedback((uint)this.Target, 0);
        }

        public override IntPtr MapBuffer(MapBufferAccess access, bool bind = true)
        {
            return base.MapBuffer(access, bind);
        }

        public override IntPtr MapBufferRange(int offset, int length, MapBufferRangeAccess access, bool bind = true)
        {
            return base.MapBufferRange(offset, length, access, bind);
        }

        public override bool UnmapBuffer(bool unbind = true)
        {
            return base.UnmapBuffer(unbind);
        }

        /// <summary>
        /// Creates a <see cref="TransformFeedbackBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="byteLength"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TransformFeedbackBuffer Create(int byteLength, BufferUsage usage)
        {
            return (GLBuffer.Create(byteLength, usage) as TransformFeedbackBuffer);
        }
    }
}
