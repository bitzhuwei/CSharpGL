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
    public abstract partial class GLBuffer : IDisposable
    {
        /// <summary>
        /// 用glGenBuffers()得到的VBO的Id。
        /// <para>Id got from glGenBuffers();</para>
        /// </summary>
        public uint BufferId { get; private set; }

        /// <summary>
        /// 此VBO含有多少个元素？
        /// <para>How many elements in thie buffer?</para>
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// 此VBO中的数据在内存中占用多少个字节？
        /// <para>How many bytes in this buffer?</para>
        /// </summary>
        public int ByteLength { get; private set; }

        /// <summary>
        /// Target that this buffer should bind to.
        /// </summary>
        public abstract BufferTarget Target { get; }

        /// <summary>
        ///
        /// </summary>
        internal static readonly GLDelegates.void_int_uintN glGenBuffers;

        /// <summary>
        ///
        /// </summary>
        internal static readonly GLDelegates.void_uint_uint glBindBuffer;

        /// <summary>
        ///
        /// </summary>
        internal static readonly GLDelegates.void_uint_int_IntPtr_uint glBufferData;

        /// <summary>
        ///
        /// </summary>
        internal static readonly GLDelegates.void_int_uintN glDeleteBuffers;

        /// <summary>
        ///
        /// </summary>
        internal static readonly GLDelegates.IntPtr_uint_uint glMapBuffer;

        /// <summary>
        ///
        /// </summary>
        internal static readonly GLDelegates.bool_uint glUnmapBuffer;

        /// <summary>
        ///
        /// </summary>
        internal static readonly GLDelegates.IntPtr_uint_int_int_uint glMapBufferRange;

        /// <summary>
        ///
        /// </summary>
        internal static readonly OpenGL.glClearBufferData glClearBufferData;

        /// <summary>
        ///
        /// </summary>
        internal static readonly OpenGL.glClearBufferSubData glClearBufferSubData;

        ///// <summary>
        /////
        ///// </summary>
        //internal static readonly OpenGL.glCopyBufferSubData glCopyBufferSubData;

        ///// <summary>
        /////
        ///// </summary>
        //internal static readonly OpenGL.glGetBufferSubData glGetBufferSubData;

        static GLBuffer()
        {
            glGenBuffers = OpenGL.GetDelegateFor("glGenBuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glBindBuffer = OpenGL.GetDelegateFor("glBindBuffer", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glBufferData = OpenGL.GetDelegateFor("glBufferData", GLDelegates.typeof_void_uint_int_IntPtr_uint) as GLDelegates.void_uint_int_IntPtr_uint;
            glDeleteBuffers = OpenGL.GetDelegateFor("glDeleteBuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glMapBuffer = OpenGL.GetDelegateFor("glMapBuffer", GLDelegates.typeof_IntPtr_uint_uint) as GLDelegates.IntPtr_uint_uint;
            glUnmapBuffer = OpenGL.GetDelegateFor("glUnmapBuffer", GLDelegates.typeof_bool_uint) as GLDelegates.bool_uint;
            glMapBufferRange = OpenGL.GetDelegateFor("glMapBufferRange", GLDelegates.typeof_IntPtr_uint_int_int_uint) as GLDelegates.IntPtr_uint_int_int_uint;
            glClearBufferData = OpenGL.GetDelegateFor<OpenGL.glClearBufferData>();
            glClearBufferSubData = OpenGL.GetDelegateFor<OpenGL.glClearBufferSubData>();

        }

        /// <summary>
        /// 位于服务器端（GPU内存）的定长数组。
        /// <para>An array at server side (GPU memory) with fixed length.</para>
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此VBO含有多少个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        protected GLBuffer(uint bufferId, int length, int byteLength)
        {
            Debug.Assert(bufferId >= 0);
            Debug.Assert(length >= 0);
            Debug.Assert(byteLength >= 0);

            this.BufferId = bufferId;
            this.Length = length;
            this.ByteLength = byteLength;
        }

        /// <summary>
        ///Bind this buffer.
        /// </summary>
        public virtual void Bind()
        {
            glBindBuffer((uint)this.Target, this.BufferId);
        }

        /// <summary>
        /// Unind this buffer.
        /// </summary>
        public virtual void Unbind()
        {
            glBindBuffer((uint)this.Target, 0);
        }

        /// <summary>
        /// Start to read/write buffer.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="access"></param>
        /// <param name="bind"></param>
        /// <returns></returns>
        public virtual IntPtr MapBufferRange(int offset, int length, MapBufferRangeAccess access, bool bind = true)
        {
            if (bind)
            {
                glBindBuffer((uint)this.Target, this.BufferId);
            }

            IntPtr pointer = glMapBufferRange((uint)this.Target, offset, length, (uint)access);
            return pointer;
        }

        /// <summary>
        /// Start to read/write buffer.
        /// </summary>
        /// <param name="access"></param>
        /// <param name="bind"></param>
        /// <returns></returns>
        public virtual IntPtr MapBuffer(MapBufferAccess access, bool bind = true)
        {
            if (bind)
            {
                glBindBuffer((uint)this.Target, this.BufferId);
            }

            IntPtr pointer = glMapBuffer((uint)this.Target, (uint)access);
            return pointer;
        }

        /// <summary>
        /// Stop reading/writing buffer.
        /// </summary>
        /// <param name="unbind"></param>
        public virtual bool UnmapBuffer(bool unbind = true)
        {
            bool result = glUnmapBuffer((uint)this.Target);
            if (unbind)
            {
                glBindBuffer((uint)this.Target, 0);
            }

            return result;
        }
    }
}