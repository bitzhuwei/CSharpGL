using System;

namespace CSharpGL
{
    public abstract partial class IndependentBufferPtr
    {
        /// <summary>
        /// Creates a sub-type of <see cref="IndependentBufferPtr"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="byteLength"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static IndependentBufferPtr Create(IndependentBufferTarget target, int byteLength, BufferUsage usage, int length)
        {
            if (glGenBuffers == null)
            {
                glGenBuffers = OpenGL.GetDelegateFor<OpenGL.glGenBuffers>();
                glBufferData = OpenGL.GetDelegateFor<OpenGL.glBufferData>();
            }

            if (glBindBuffer == null)
            {
                glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>();
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

            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            glBindBuffer(bufferTarget, buffers[0]);
            glBufferData(bufferTarget, byteLength, IntPtr.Zero, (uint)usage);
            glBindBuffer(bufferTarget, 0);

            IndependentBufferPtr bufferPtr;
            switch (target)
            {
                case IndependentBufferTarget.AtomicCounterBuffer:
                    bufferPtr = new AtomicCounterBufferPtr(buffers[0], length, byteLength);
                    break;

                case IndependentBufferTarget.PixelPackBuffer:
                    bufferPtr = new PixelPackBufferPtr(buffers[0], length, byteLength);
                    break;

                case IndependentBufferTarget.PixelUnpackBuffer:
                    bufferPtr = new PixelUnpackBufferPtr(buffers[0], length, byteLength);
                    break;

                case IndependentBufferTarget.ShaderStorageBuffer:
                    bufferPtr = new ShaderStorageBufferPtr(buffers[0], length, byteLength);
                    break;

                case IndependentBufferTarget.TextureBuffer:
                    bufferPtr = new TextureBufferPtr(buffers[0], length, byteLength);
                    break;

                case IndependentBufferTarget.UniformBuffer:
                    bufferPtr = new UniformBufferPtr(buffers[0], length, byteLength);
                    break;

                default:
                    throw new NotImplementedException();
            }

            return bufferPtr;
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