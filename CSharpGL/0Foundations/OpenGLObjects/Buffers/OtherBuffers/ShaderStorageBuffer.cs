using System;

namespace CSharpGL
{
    /// <summary>
    /// Buffer object that not work as input variable in shader.
    /// </summary>
    public partial class ShaderStorageBuffer : Buffer
    {
        private static OpenGL.glShaderStorageBlockBinding glShaderStorageBlockBinding;
        private static OpenGL.glGetProgramResourceIndex glGetProgramResourceIndex;
        private static OpenGL.glBindBufferBase glBindBufferBase;

        /// <summary>
        /// Target that this buffer should bind to.
        /// </summary>
        public override BufferTarget Target
        {
            get { return BufferTarget.ShaderStorageBuffer; }
        }

        /// <summary>
        /// pixel unpack buffer's pointer.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal ShaderStorageBuffer(
            uint bufferId, int length, int byteLength)
            : base(bufferId, length, byteLength)
        {
            if (glShaderStorageBlockBinding == null)
            {
                glShaderStorageBlockBinding = OpenGL.GetDelegateFor<OpenGL.glShaderStorageBlockBinding>();
                glGetProgramResourceIndex = OpenGL.GetDelegateFor<OpenGL.glGetProgramResourceIndex>();
                glBindBufferBase = OpenGL.GetDelegateFor<OpenGL.glBindBufferBase>();
            }
        }

        /// <summary>
        /// Bind this uniform buffer object and a uniform block to the same binding point.
        /// </summary>
        /// <param name="program">shader program.</param>
        /// <param name="storageBlockName">name of buffer block in shader.</param>
        /// <param name="storageBlockBindingPoint">binding point maintained by OpenGL context.</param>
        public void Binding(ShaderProgram program, string storageBlockName, uint storageBlockBindingPoint)
        {
            uint storageBlockIndex = glGetProgramResourceIndex(program.ProgramId, OpenGL.GL_SHADER_STORAGE_BLOCK, storageBlockName);
            glBindBufferBase(OpenGL.GL_SHADER_STORAGE_BUFFER, storageBlockBindingPoint, this.BufferId);
            glShaderStorageBlockBinding(program.ProgramId, storageBlockIndex, storageBlockBindingPoint);
        }

        /// <summary>
        /// Creates a <see cref="ShaderStorageBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ShaderStorageBuffer Create(Type elementType, BufferUsage usage, int length)
        {
            return (Buffer.Create(IndependentBufferTarget.ShaderStorageBuffer, elementType, usage, length) as ShaderStorageBuffer);
        }
    }
}