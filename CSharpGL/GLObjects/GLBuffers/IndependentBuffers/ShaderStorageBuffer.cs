using System;
using System.Runtime.InteropServices;
using static CSharpGL.GLBuffer;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpGL {
    // 运用GLSL的struct和数组方式来定义Buffer布局。
    /// <summary>
    /// buffer block in shader.
    /// ```
    /// buffer BuffrObject {
    ///     int mode;
    ///     vec4 points[];
    /// };
    /// ```
    /// </summary>
    public unsafe partial class ShaderStorageBuffer : GLBuffer {
        //GLDelegates.uint_uint_uint_string glGetProgramResourceIndex;
        //GLDelegates.void_uint_uint_uint glBindBufferBase;
        //GLDelegates.void_uint_uint_uint glShaderStorageBlockBinding;

        /// <summary>
        /// pixel unpack buffer's pointer.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此buffer含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此buffer中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal ShaderStorageBuffer(
            GLuint bufferId, int length, int byteLength, Usage usage)
            : base(Target.ShaderStorageBuffer, bufferId, length, byteLength, usage) {
        }

        /// <summary>
        /// Bind this uniform buffer object and a uniform block to the same binding point.
        /// </summary>
        /// <param name="program">shader program.</param>
        /// <param name="storageBlockName">name of buffer block in shader.</param>
        /// <param name="storageBlockBindingPoint">binding point maintained by OpenGL context.</param>
        public void Binding(GLProgram program, string storageBlockName, uint storageBlockBindingPoint) {
            //if (glGetProgramResourceIndex == null) { glGetProgramResourceIndex = gl.glGetDelegateFor("glGetProgramResourceIndex", GLDelegates.typeof_uint_uint_uint_string) as GLDelegates.uint_uint_uint_string; }
            //if (glBindBufferBase == null) { glBindBufferBase = gl.glGetDelegateFor("glBindBufferBase", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint; }
            //if (glShaderStorageBlockBinding == null) { glShaderStorageBlockBinding = gl.glGetDelegateFor("glShaderStorageBlockBinding", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint; }
            var gl = GL.current; if (gl == null) { return; }

            uint storageBlockIndex = gl.glGetProgramResourceIndex(program.programId, GL.GL_SHADER_STORAGE_BLOCK, storageBlockName);
            gl.glBindBufferBase(GL.GL_SHADER_STORAGE_BUFFER, storageBlockBindingPoint, this.bufferId);
            gl.glShaderStorageBlockBinding(program.programId, storageBlockIndex, storageBlockBindingPoint);
        }

        /// <summary>
        /// Creates a <see cref="ShaderStorageBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="count">how many elements?</param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static ShaderStorageBuffer Create(Type elementType, int count, GLBuffer.Usage usage) {
            if (!elementType.IsValueType) { throw new ArgumentException(string.Format("{0} must be a value type!", elementType)); }

            var byteLength = Marshal.SizeOf(elementType) * count;
            var bufferId = CallGL((GLenum)IndependentBufferTarget.ShaderStorageBuffer, byteLength, IntPtr.Zero, usage);

            var buffer = new ShaderStorageBuffer(bufferId, count, byteLength, usage);
            return buffer;
        }

        public bool UpdateData(IntPtr data, int byteLength) {
            if (data == IntPtr.Zero) { return false; }

            var gl = GL.current; if (gl == null) { throw new Exception("openGL context is not ready or current."); }

            gl.glBindBuffer((GLenum)this.target, this.bufferId);
            gl.glBufferData((GLenum)this.target, byteLength, data, (GLenum)this.usage);
            gl.glBindBuffer((GLenum)this.target, 0);

            return true;
        }
    }
}