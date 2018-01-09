using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class Data2Buffer
    {

        ///// <summary>
        ///// Generates an atomic counter buffer.
        ///// </summary>
        ///// <param name="array"></param>
        ///// <param name="usage"></param>
        ///// <returns></returns>
        //public static AtomicCounterBuffer GenAtomicCounterBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        //{
        //    return GenIndependentBuffer(array, IndependentBufferTarget.AtomicCounterBuffer, usage) as AtomicCounterBuffer;
        //}

        ///// <summary>
        ///// Generates a pixel pack buffer.
        ///// </summary>
        ///// <param name="array"></param>
        ///// <param name="usage"></param>
        ///// <returns></returns>
        //public static PixelPackBuffer GenPixelPackBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        //{
        //    return GenIndependentBuffer(array, IndependentBufferTarget.PixelPackBuffer, usage) as PixelPackBuffer;
        //}

        ///// <summary>
        ///// Generates a pixel unpack buffer.
        ///// </summary>
        ///// <param name="array"></param>
        ///// <param name="usage"></param>
        ///// <returns></returns>
        //public static PixelUnpackBuffer GenPixelUnpackBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        //{
        //    return GenIndependentBuffer(array, IndependentBufferTarget.PixelUnpackBuffer, usage) as PixelUnpackBuffer;
        //}

        ///// <summary>
        ///// Generates a shader storage buffer.
        ///// </summary>
        ///// <param name="array"></param>
        ///// <param name="usage"></param>
        ///// <returns></returns>
        //public static ShaderStorageBuffer GenShaderStorageBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        //{
        //    return GenIndependentBuffer(array, IndependentBufferTarget.ShaderStorageBuffer, usage) as ShaderStorageBuffer;
        //}

        ///// <summary>
        ///// Generates a texture buffer.
        ///// </summary>
        ///// <param name="array"></param>
        ///// <param name="usage"></param>
        ///// <returns></returns>
        //public static TextureBuffer GenTextureBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        //{
        //    return GenIndependentBuffer(array, IndependentBufferTarget.TextureBuffer, usage) as TextureBuffer;
        //}

        ///// <summary>
        ///// Generates an uniform buffer.
        ///// </summary>
        ///// <param name="array"></param>
        ///// <param name="usage"></param>
        ///// <returns></returns>
        //public static UniformBuffer GenUniformBuffer(this UnmanagedArrayBase array, BufferUsage usage)
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
        private static GLBuffer GenIndependentBuffer(this UnmanagedArrayBase array, IndependentBufferTarget bufferTarget, BufferUsage usage)
        {
            uint[] ids = new uint[1];
            {
                glGenBuffers(1, ids);
                var target = (uint)bufferTarget;
                glBindBuffer(target, ids[0]);
                glBufferData(target, array.ByteLength, array.Header, (uint)usage);
                glBindBuffer(target, 0);
            }

            GLBuffer buffer = null;
            switch (bufferTarget)
            {
                case IndependentBufferTarget.AtomicCounterBuffer:
                    buffer = new AtomicCounterBuffer(ids[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.PixelPackBuffer:
                    buffer = new PixelPackBuffer(ids[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.PixelUnpackBuffer:
                    buffer = new PixelUnpackBuffer(ids[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.ShaderStorageBuffer:
                    buffer = new ShaderStorageBuffer(ids[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.TextureBuffer:
                    buffer = new TextureBuffer(ids[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.UniformBuffer:
                    buffer = new UniformBuffer(ids[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.TransformFeedbackBuffer:
                    buffer = new TransformFeedbackBuffer(ids[0], array.Length, array.ByteLength);
                    break;

                default:
                    throw new NotDealWithNewEnumItemException(typeof(IndependentBufferTarget));
            }

            return buffer;
        }
    }
}