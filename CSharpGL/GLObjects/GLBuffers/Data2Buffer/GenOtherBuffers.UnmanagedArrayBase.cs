using System;
using System.Runtime.InteropServices;

namespace CSharpGL {
    public static unsafe partial class Data2Buffer {

        ///// <summary>
        ///// Generates an atomic counter buffer.
        ///// </summary>
        ///// <param name="array"></param>
        ///// <param name="usage"></param>
        ///// <returns></returns>
        //public static AtomicCounterBuffer GenAtomicCounterBuffer(this UnmanagedArrayBase array, GLBuffer.BufferUsage usage)
        //{
        //    return GenIndependentBuffer(array, IndependentBufferTarget.AtomicCounterBuffer, usage) as AtomicCounterBuffer;
        //}

        ///// <summary>
        ///// Generates a pixel pack buffer.
        ///// </summary>
        ///// <param name="array"></param>
        ///// <param name="usage"></param>
        ///// <returns></returns>
        //public static PixelPackBuffer GenPixelPackBuffer(this UnmanagedArrayBase array, GLBuffer.BufferUsage usage)
        //{
        //    return GenIndependentBuffer(array, IndependentBufferTarget.PixelPackBuffer, usage) as PixelPackBuffer;
        //}

        ///// <summary>
        ///// Generates a pixel unpack buffer.
        ///// </summary>
        ///// <param name="array"></param>
        ///// <param name="usage"></param>
        ///// <returns></returns>
        //public static PixelUnpackBuffer GenPixelUnpackBuffer(this UnmanagedArrayBase array, GLBuffer.BufferUsage usage)
        //{
        //    return GenIndependentBuffer(array, IndependentBufferTarget.PixelUnpackBuffer, usage) as PixelUnpackBuffer;
        //}

        ///// <summary>
        ///// Generates a shader storage buffer.
        ///// </summary>
        ///// <param name="array"></param>
        ///// <param name="usage"></param>
        ///// <returns></returns>
        //public static ShaderStorageBuffer GenShaderStorageBuffer(this UnmanagedArrayBase array, GLBuffer.BufferUsage usage)
        //{
        //    return GenIndependentBuffer(array, IndependentBufferTarget.ShaderStorageBuffer, usage) as ShaderStorageBuffer;
        //}

        ///// <summary>
        ///// Generates a texture buffer.
        ///// </summary>
        ///// <param name="array"></param>
        ///// <param name="usage"></param>
        ///// <returns></returns>
        //public static TextureBuffer GenTextureBuffer(this UnmanagedArrayBase array, GLBuffer.BufferUsage usage)
        //{
        //    return GenIndependentBuffer(array, IndependentBufferTarget.TextureBuffer, usage) as TextureBuffer;
        //}

        ///// <summary>
        ///// Generates an uniform buffer.
        ///// </summary>
        ///// <param name="array"></param>
        ///// <param name="usage"></param>
        ///// <returns></returns>
        //public static UniformBuffer GenUniformBuffer(this UnmanagedArrayBase array, GLBuffer.BufferUsage usage)
        //{
        //    return GenIndependentBuffer(array, IndependentBufferTarget.UniformBuffer, usage) as UniformBuffer;
        //}

        /// <summary>
        /// Generates an independent buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="bufferTarget"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        private static GLBuffer GenIndependentBuffer(/*this UnmanagedArrayBase array*/IntPtr header, int count, GLsizeiptr byteLength, IndependentBufferTarget bufferTarget, GLBuffer.Usage usage) {
            var bufferId = GLBuffer.CallGL((GLenum)bufferTarget, byteLength, header, usage);

            GLBuffer buffer;
            switch (bufferTarget) {
            case IndependentBufferTarget.AtomicCounterBuffer:
            buffer = new AtomicCounterBuffer(bufferId, count, byteLength, usage);
            break;

            case IndependentBufferTarget.PixelPackBuffer:
            buffer = new PixelPackBuffer(bufferId, count, byteLength, usage);
            break;

            case IndependentBufferTarget.PixelUnpackBuffer:
            buffer = new PixelUnpackBuffer(bufferId, count, byteLength, usage);
            break;

            case IndependentBufferTarget.ShaderStorageBuffer:
            buffer = new ShaderStorageBuffer(bufferId, count, byteLength, usage);
            break;

            case IndependentBufferTarget.TextureBuffer:
            buffer = new TextureBuffer(bufferId, count, byteLength, usage);
            break;

            case IndependentBufferTarget.UniformBuffer:
            buffer = new UniformBuffer(bufferId, count, byteLength, usage);
            break;

            case IndependentBufferTarget.TransformFeedbackBuffer:
            buffer = new TransformFeedbackBuffer(bufferId, count, byteLength, usage);
            break;

            default:
            throw new NotSupportedException(bufferTarget.ToString());
            }

            return buffer;
        }
    }
}