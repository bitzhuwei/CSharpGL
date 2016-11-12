using System;

namespace CSharpGL
{
    public static partial class Array2Buffer
    {
        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static AtomicCounterBuffer GetAtomicCounterBuffer<T>(this UnmanagedArray<T> array, VBOConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.AtomicCounterBuffer, config, usage) as AtomicCounterBuffer;
        }

        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelPackBuffer GetPixelPackBuffer<T>(this UnmanagedArray<T> array, VBOConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.PixelPackBuffer, config, usage) as PixelPackBuffer;
        }

        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelUnpackBuffer GetPixelUnpackBuffer<T>(this UnmanagedArray<T> array, VBOConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.PixelUnpackBuffer, config, usage) as PixelUnpackBuffer;
        }

        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static ShaderStorageBuffer GetShaderStorageBuffer<T>(this UnmanagedArray<T> array, VBOConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.ShaderStorageBuffer, config, usage) as ShaderStorageBuffer;
        }

        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TextureBuffer GetTextureBuffer<T>(this UnmanagedArray<T> array, VBOConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.TextureBuffer, config, usage) as TextureBuffer;
        }

        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static UniformBuffer GetUniformBuffer<T>(this UnmanagedArray<T> array, VBOConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.UniformBuffer, config, usage) as UniformBuffer;
        }

        /// <summary>
        /// 获取某种独立的Buffer。
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="bufferTarget"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static Buffer GetIndependentBuffer<T>(this UnmanagedArray<T> array, IndependentBufferTarget bufferTarget, VBOConfig config, BufferUsage usage) where T : struct
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