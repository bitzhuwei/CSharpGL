using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public partial class VertexAttributeBufferPtr
    {
        /// <summary>
        /// Creates a <see cref="VertexAttributeBufferPtr"/> object(actually an array) directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType">element's type of this 'array'.</param>
        /// <param name="length">How many elements are there?</param>
        /// <param name="config">mapping to vertex shader's 'in' type.</param>
        /// <param name="usage"></param>
        /// <param name="varNameInVertexShader">mapping to vertex shader's 'in' name.</param>
        /// <param name="instanceDivisor"></param>
        /// <param name="patchVertexes"></param>
        /// <returns></returns>
        public static VertexAttributeBufferPtr Create(Type elementType, int length, VertexAttributeConfig config, BufferUsage usage, string varNameInVertexShader, uint instanceDivisor = 0, int patchVertexes = 0)
        {
            if (!elementType.IsValueType) { throw new ArgumentException(string.Format("{0} must be a value type!", elementType)); }

            if (glGenBuffers == null)
            {
                glGenBuffers = OpenGL.GetDelegateFor<OpenGL.glGenBuffers>();
                glBufferData = OpenGL.GetDelegateFor<OpenGL.glBufferData>();
            }

            if (glBindBuffer == null)
            {
                glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>();
            }

            int byteLength = Marshal.SizeOf(elementType) * length;
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