using System;

namespace CSharpGL
{
    public partial class VertexAttributeBuffer<T>
    {
        /// <summary>
        /// Crates a <see cref="VertexAttributeBufferPtr"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="byteLength"></param>
        /// <param name="usage"></param>
        /// <param name="varNameInVertexShader"></param>
        /// <param name="config"></param>
        /// <param name="length"></param>
        /// <param name="instanceDivisor"></param>
        /// <param name="patchVertexes"></param>
        /// <returns></returns>
        public static VertexAttributeBufferPtr Create(int byteLength, BufferUsage usage, string varNameInVertexShader, VertexAttributeConfig config, int length, uint instanceDivisor, int patchVertexes)
        {
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            const uint target = OpenGL.GL_ARRAY_BUFFER;
            glBindBuffer(target, buffers[0]);
            glBufferData(target, byteLength, IntPtr.Zero, (uint)usage);
            glBindBuffer(target, 0);

            var bufferPtr = new VertexAttributeBufferPtr(
                varNameInVertexShader, buffers[0], config, length, byteLength, instanceDivisor, patchVertexes);

            return bufferPtr;
        }
    }
}