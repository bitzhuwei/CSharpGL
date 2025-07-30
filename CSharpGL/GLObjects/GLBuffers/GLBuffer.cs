using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL {
    /// <summary>
    /// 位于服务器端（GPU内存）的定长数组。
    /// <para>An array at server side (GPU memory) with fixed length.</para>
    /// </summary>

    public abstract unsafe partial class GLBuffer : IDisposable {

        /// <summary>
        /// Target that this buffer should bind to.
        /// </summary>
        public readonly Target target;

        /// <summary>
        /// 用glGenBuffers()得到的VBO的Id。
        /// <para>id got from glGenBuffers();</para>
        /// </summary>
        public readonly GLuint bufferId;

        /// <summary>
        /// 此VBO含有多少个元素？
        /// <para>How many elements in thie buffer?</para>
        /// </summary>
        public readonly int count;

        /// <summary>
        /// 此VBO中的数据在内存中占用多少个字节？
        /// <para>How many bytes in this buffer?</para>
        /// </summary>
        public readonly int byteLength;

        /// <summary>
        /// 
        /// </summary>
        public readonly Usage usage;

        /// <summary>
        /// 位于服务器端（GPU内存）的定长数组。
        /// <para>An array at server side (GPU memory) with fixed length.</para>
        /// </summary>
        /// <param name="target">Target that this buffer should bind to.</param>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="count">此VBO含有多少个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        /// <param name="usage"></param>
        protected GLBuffer(Target target, GLuint bufferId, int count, int byteLength, Usage usage) {
            this.target = target;
            this.bufferId = bufferId;
            this.count = count;
            this.byteLength = byteLength;
            this.usage = usage;
        }


        /// <summary>
        ///Bind this buffer.
        /// </summary>
        public virtual void Bind() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glBindBuffer((GLenum)this.target, this.bufferId);
        }

        /// <summary>
        /// Unind this buffer.
        /// </summary>
        public virtual void Unbind() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glBindBuffer((GLenum)this.target, 0);
        }

        /// <summary>
        /// Start to read/write buffer.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="access"></param>
        /// <param name="bind"></param>
        /// <returns></returns>
        public virtual IntPtr MapBufferRange(GLintptr offset, GLsizeiptr length, MapBufferRangeAccess access, bool bind = true) {
            var gl = GL.current; if (gl == null) { return IntPtr.Zero; }
            if (bind) {
                gl.glBindBuffer((GLenum)this.target, this.bufferId);
            }

            var pointer = gl.glMapBufferRange((GLenum)this.target, offset, length, (GLbitfield)access);
            return pointer;
        }

        /// <summary>
        /// Start to read/write buffer.
        /// </summary>
        /// <param name="access"></param>
        /// <param name="bind"></param>
        /// <returns></returns>
        public virtual IntPtr MapBuffer(MapBufferAccess access, bool bind = true) {
            var gl = GL.current; if (gl == null) { return IntPtr.Zero; }
            if (bind) {
                gl.glBindBuffer((GLenum)this.target, this.bufferId);
            }

            var pointer = gl.glMapBuffer((GLenum)this.target, (GLenum)access);
            return pointer;
        }

        /// <summary>
        /// Stop reading/writing buffer.
        /// </summary>
        /// <param name="unbind"></param>
        public virtual bool UnmapBuffer(bool unbind = true) {
            var gl = GL.current; if (gl == null) { return false; }
            bool result = gl.glUnmapBuffer((GLenum)this.target);
            if (unbind) {
                gl.glBindBuffer((GLenum)this.target, 0);
            }

            return result;
        }

        public override string ToString() {
            return string.Format("id:[{0}], {1}, length:[{2}]", this.bufferId, this.target, this.count);
        }

        public enum Target : GLenum {
            /// <summary>
            /// vertex attribute buffer object.
            /// </summary>
            ArrayBuffer = GL.GL_ARRAY_BUFFER,
            /// <summary>
            /// glDrawElements().
            /// </summary>
            ElementArrayBuffer = GL.GL_ELEMENT_ARRAY_BUFFER,

            UniformBuffer = GL.GL_UNIFORM_BUFFER,
            TransformFeedbackBuffer = GL.GL_TRANSFORM_FEEDBACK_BUFFER,
            PixelUnpackBuffer = GL.GL_PIXEL_UNPACK_BUFFER,
            PixelPackBuffer = GL.GL_PIXEL_PACK_BUFFER,
            AtomicCounterBuffer = GL.GL_ATOMIC_COUNTER_BUFFER,
            TextureBuffer = GL.GL_TEXTURE_BUFFER,
            ShaderStorageBuffer = GL.GL_SHADER_STORAGE_BUFFER,
        }

        ///// <summary>
        ///// STREAM: You should use STREAM_DRAW when the data store contents will be modified once and used at most a few times.
        ///// <para>STATIC: Use STATIC_DRAW when the data store contents will be modified once and used many times.</para>
        ///// <para>DYNAMIC: Use DYNAMIC_DRAW when the data store contents will be modified repeatedly and used many times.</para>
        ///// </summary>
        /// <summary>
        /// <para>Static-只需要一次指定缓冲区对象中的数据,但使用次数很多.</para>
        /// <para>Dynamic-数据不仅需要时常更新,使用次数也很多.</para>
        /// <para>Stream-缓冲区的对象需要时常更新,但使用次数很少.</para>
        /// <para>Draw-数据作为顶点数据,用于渲染.</para>
        /// <para>Read-数据从一个OpenGL缓冲区(桢缓冲区之类的)读取,并在程序中与渲染并不直接相关的各种计算过程中使用.</para>
        /// <para>Copy-数据从一个OpenGL缓冲区读取,然后作为顶点数据,用于渲染.</para>
        /// </summary>
        public enum Usage : GLenum {
            StreamDraw = GL.GL_STREAM_DRAW,//= 0x88E0,
            StreamRead = GL.GL_STREAM_READ,//= 0x88E1,
            StreamCopy = GL.GL_STREAM_COPY,//= 0x88E2,
            StaticDraw = GL.GL_STATIC_DRAW,//= 0x88E4,
            StaticRead = GL.GL_STATIC_READ,//= 0x88E5,
            StaticCopy = GL.GL_STATIC_COPY,//= 0x88E6,
            DynamicDraw = GL.GL_DYNAMIC_DRAW,//= 0x88E8,
            DynamicRead = GL.GL_DYNAMIC_READ,//= 0x88E9,
            DynamicCopy = GL.GL_DYNAMIC_COPY,//= 0x88EA,
        }
    }
}