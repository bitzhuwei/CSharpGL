using System;

namespace CSharpGL
{
    public static partial class Array2Buffer
    {
        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static AtomicCounterBuffer GetAtomicCounterBuffer(this UnmanagedArrayBase array, VBOConfig config, BufferUsage usage)
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.AtomicCounterBuffer, config, usage) as AtomicCounterBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelPackBuffer GetPixelPackBuffer(this UnmanagedArrayBase array, VBOConfig config, BufferUsage usage)
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.PixelPackBuffer, config, usage) as PixelPackBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelUnpackBuffer GetPixelUnpackBuffer(this UnmanagedArrayBase array, VBOConfig config, BufferUsage usage)
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.PixelUnpackBuffer, config, usage) as PixelUnpackBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static ShaderStorageBuffer GetShaderStorageBuffer(this UnmanagedArrayBase array, VBOConfig config, BufferUsage usage)
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.ShaderStorageBuffer, config, usage) as ShaderStorageBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TextureBuffer GetTextureBuffer(this UnmanagedArrayBase array, VBOConfig config, BufferUsage usage)
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.TextureBuffer, config, usage) as TextureBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static UniformBuffer GetUniformBuffer(this UnmanagedArrayBase array, VBOConfig config, BufferUsage usage)
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.UniformBuffer, config, usage) as UniformBuffer;
        }

        /// <summary>
        /// 获取某种独立的Buffer。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="bufferTarget"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static Buffer GetIndependentBuffer(this UnmanagedArrayBase array, IndependentBufferTarget bufferTarget, VBOConfig config, BufferUsage usage)
        {
            if (glGenBuffers == null)
            {
                InitFunctions();
            }

            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            var target = (uint)bufferTarget;
            glBindBuffer(target, buffers[0]);
            glBufferData(target, array.ByteLength, array.Header, (uint)usage);
            glBindBuffer(target, 0);

            Buffer buffer = null;
            switch (bufferTarget)
            {
                case IndependentBufferTarget.AtomicCounterBuffer:
                    buffer = new AtomicCounterBuffer(buffers[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.PixelPackBuffer:
                    buffer = new PixelPackBuffer(buffers[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.PixelUnpackBuffer:
                    buffer = new PixelUnpackBuffer(buffers[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.ShaderStorageBuffer:
                    buffer = new ShaderStorageBuffer(buffers[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.TextureBuffer:
                    buffer = new TextureBuffer(buffers[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.UniformBuffer:
                    buffer = new UniformBuffer(buffers[0], array.Length, array.ByteLength);
                    break;

                default:
                    throw new NotImplementedException();
            }

            return buffer;
        }
    }
}