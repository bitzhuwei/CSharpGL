using System;
using System.Runtime.InteropServices;

namespace CSharpGL {
    // http://blog.csdn.net/csxiaoshui/article/details/32101977
    /// <summary>
    /// Buffer object that not work as input variable in shader.
    /// </summary>
    public unsafe partial class UniformBuffer : GLBuffer {
        /// <summary>
        /// pixel unpack buffer's pointer.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此buffer含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此buffer中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal UniformBuffer(
            GLuint bufferId, int length, int byteLength, Usage usage)
            : base(Target.UniformBuffer, bufferId, length, byteLength, usage) {
        }

        /// <summary>
        /// Creates a <see cref="UniformBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="count">how many elements?</param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static UniformBuffer Create(Type elementType, int count, GLBuffer.Usage usage) {
            if (!elementType.IsValueType) { throw new ArgumentException(string.Format("{0} must be a value type!", elementType)); }

            var byteLength = Marshal.SizeOf(elementType) * count;
            var bufferId = CallGL((GLenum)IndependentBufferTarget.UniformBuffer, byteLength, IntPtr.Zero, usage);

            var buffer = new UniformBuffer(bufferId, count, byteLength, usage);
            return buffer;
        }

        //internal static GLDelegates.void_uint_uint_uint glBindBufferBase;
        //internal static GLDelegates.void_uint_uint_uint glUniformBlockBinding;

        /// <summary>
        /// Bind this uniform buffer object and a uniform block to the same binding point.
        /// </summary>
        /// <param name="uniformBlockIndex">index of uniform block got by (glGetUniformBlockIndex).</param>
        /// <param name="uniformBlockBindingPoint">binding point maintained by OpenGL context.</param>
        /// <param name="program">shader program.</param>
        public void Binding(GLProgram program, uint uniformBlockIndex, uint uniformBlockBindingPoint) {
            //if (glBindBufferBase == null) { glBindBufferBase = gl.glGetDelegateFor("glBindBufferBase", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint; }
            //if (glUniformBlockBinding == null) { glUniformBlockBinding = gl.glGetDelegateFor("glUniformBlockBinding", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint; }

            var gl = GL.current; if (gl == null) { return; }
            gl.glUniformBlockBinding(program.programId, uniformBlockIndex, uniformBlockBindingPoint);
            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, uniformBlockBindingPoint, this.bufferId);
        }

    }
}