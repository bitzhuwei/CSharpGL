using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public abstract partial class Buffer
    {
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

    /// <summary>
    ///
    /// </summary>
    public enum IndependentBufferTarget
    {
        /// <summary>
        ///
        /// </summary>
        AtomicCounterBuffer,

        /// <summary>
        ///
        /// </summary>
        PixelPackBuffer,

        /// <summary>
        ///
        /// </summary>
        PixelUnpackBuffer,

        /// <summary>
        ///
        /// </summary>
        ShaderStorageBuffer,

        /// <summary>
        ///
        /// </summary>
        TextureBuffer,

        /// <summary>
        ///
        /// </summary>
        UniformBuffer,
    }
}