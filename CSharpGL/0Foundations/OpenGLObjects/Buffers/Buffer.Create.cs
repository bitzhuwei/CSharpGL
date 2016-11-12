using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public partial class Buffer
    {
        /// <summary>
        /// Creates a <see cref="VertexBuffer"/> object(actually an array) directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType">element's type of this 'array'.</param>
        /// <param name="length">How many elements are there?</param>
        /// <param name="config">mapping to vertex shader's 'in' type.</param>
        /// <param name="usage"></param>
        /// <param name="varNameInVertexShader">mapping to vertex shader's 'in' name.</param>
        /// <param name="instanceDivisor"></param>
        /// <param name="patchVertexes"></param>
        /// <returns></returns>
        public static VertexBuffer Create(Type elementType, int length, VBOConfig config, BufferUsage usage, string varNameInVertexShader, uint instanceDivisor = 0, int patchVertexes = 0)
        {
            if (!elementType.IsValueType) { throw new ArgumentException(string.Format("{0} must be a value type!", elementType)); }

            if (glGenBuffers == null)
            {
                InitOpenGLCommands();
            }

            int byteLength = Marshal.SizeOf(elementType) * length;
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            const uint target = OpenGL.GL_ARRAY_BUFFER;
            glBindBuffer(target, buffers[0]);
            glBufferData(target, byteLength, IntPtr.Zero, (uint)usage);
            glBindBuffer(target, 0);

            var buffer = new VertexBuffer(
                varNameInVertexShader, buffers[0], config, length, byteLength, instanceDivisor, patchVertexes);

            return buffer;
        }

        /// <summary>
        /// Creates a sub-type of <see cref="Buffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="elementType"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static Buffer Create(IndependentBufferTarget target, Type elementType, BufferUsage usage, int length)
        {
            if (!elementType.IsValueType) { throw new ArgumentException(string.Format("{0} must be a value type!", elementType)); }

            if (glGenBuffers == null)
            {
                InitOpenGLCommands();
            }

            uint bufferTarget = 0;
            switch (target)
            {
                case IndependentBufferTarget.AtomicCounterBuffer:
                    bufferTarget = OpenGL.GL_ATOMIC_COUNTER_BUFFER;
                    break;

                case IndependentBufferTarget.PixelPackBuffer:
                    bufferTarget = OpenGL.GL_PIXEL_PACK_BUFFER;
                    break;

                case IndependentBufferTarget.PixelUnpackBuffer:
                    bufferTarget = OpenGL.GL_PIXEL_UNPACK_BUFFER;
                    break;

                case IndependentBufferTarget.ShaderStorageBuffer:
                    bufferTarget = OpenGL.GL_SHADER_STORAGE_BUFFER;
                    break;

                case IndependentBufferTarget.TextureBuffer:
                    bufferTarget = OpenGL.GL_TEXTURE_BUFFER;
                    break;

                case IndependentBufferTarget.UniformBuffer:
                    bufferTarget = OpenGL.GL_UNIFORM_BUFFER;
                    break;

                default:
                    throw new NotImplementedException();
            }

            int byteLength = Marshal.SizeOf(elementType) * length;
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            glBindBuffer(bufferTarget, buffers[0]);
            glBufferData(bufferTarget, byteLength, IntPtr.Zero, (uint)usage);
            glBindBuffer(bufferTarget, 0);

            Buffer buffer;
            switch (target)
            {
                case IndependentBufferTarget.AtomicCounterBuffer:
                    buffer = new AtomicCounterBuffer(buffers[0], length, byteLength);
                    break;

                case IndependentBufferTarget.PixelPackBuffer:
                    buffer = new PixelPackBuffer(buffers[0], length, byteLength);
                    break;

                case IndependentBufferTarget.PixelUnpackBuffer:
                    buffer = new PixelUnpackBuffer(buffers[0], length, byteLength);
                    break;

                case IndependentBufferTarget.ShaderStorageBuffer:
                    buffer = new ShaderStorageBuffer(buffers[0], length, byteLength);
                    break;

                case IndependentBufferTarget.TextureBuffer:
                    buffer = new TextureBuffer(buffers[0], length, byteLength);
                    break;

                case IndependentBufferTarget.UniformBuffer:
                    buffer = new UniformBuffer(buffers[0], length, byteLength);
                    break;

                default:
                    throw new NotImplementedException();
            }

            return buffer;
        }
    }
}