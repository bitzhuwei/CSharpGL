using System;

namespace CSharpGL
{
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
    public partial class ShaderStorageBuffer : GLBuffer
    {
        GLDelegates.uint_uint_uint_string glGetProgramResourceIndex;
        GLDelegates.void_uint_uint_uint glBindBufferBase;
        GLDelegates.void_uint_uint_uint glShaderStorageBlockBinding;

        /// <summary>
        /// pixel unpack buffer's pointer.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此buffer含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此buffer中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal ShaderStorageBuffer(
            uint bufferId, int length, int byteLength)
            : base(bufferId, length, byteLength)
        {
            this.Target = BufferTarget.ShaderStorageBuffer;
        }

        /// <summary>
        /// Bind this uniform buffer object and a uniform block to the same binding point.
        /// </summary>
        /// <param name="program">shader program.</param>
        /// <param name="storageBlockName">name of buffer block in shader.</param>
        /// <param name="storageBlockBindingPoint">binding point maintained by OpenGL context.</param>
        public void Binding(ShaderProgram program, string storageBlockName, uint storageBlockBindingPoint)
        {
            if (glGetProgramResourceIndex == null) { glGetProgramResourceIndex = GL.Instance.GetDelegateFor("glGetProgramResourceIndex", GLDelegates.typeof_uint_uint_uint_string) as GLDelegates.uint_uint_uint_string; }
            if (glBindBufferBase == null) { glBindBufferBase = GL.Instance.GetDelegateFor("glBindBufferBase", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint; }
            if (glShaderStorageBlockBinding == null) { glShaderStorageBlockBinding = GL.Instance.GetDelegateFor("glShaderStorageBlockBinding", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint; }

            uint storageBlockIndex = glGetProgramResourceIndex(program.ProgramId, GL.GL_SHADER_STORAGE_BLOCK, storageBlockName);
            glBindBufferBase(GL.GL_SHADER_STORAGE_BUFFER, storageBlockBindingPoint, this.BufferId);
            glShaderStorageBlockBinding(program.ProgramId, storageBlockIndex, storageBlockBindingPoint);
        }

        /// <summary>
        /// Creates a <see cref="ShaderStorageBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ShaderStorageBuffer Create(Type elementType, int length, BufferUsage usage)
        {
            return (GLBuffer.Create(IndependentBufferTarget.ShaderStorageBuffer, elementType, length, usage) as ShaderStorageBuffer);
        }
    }
}