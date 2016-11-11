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
        public static AtomicCounterBuffer GetAtomicCounterBufferPtr<T>(this UnmanagedArray<T> array, VertexAttributeConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBufferPtr(array, IndependentBufferTarget.AtomicCounterBuffer, config, usage) as AtomicCounterBuffer;
        }

        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelPackBuffer GetPixelPackBufferPtr<T>(this UnmanagedArray<T> array, VertexAttributeConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBufferPtr(array, IndependentBufferTarget.PixelPackBuffer, config, usage) as PixelPackBuffer;
        }

        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelUnpackBuffer GetPixelUnpackBufferPtr<T>(this UnmanagedArray<T> array, VertexAttributeConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBufferPtr(array, IndependentBufferTarget.PixelUnpackBuffer, config, usage) as PixelUnpackBuffer;
        }

        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static ShaderStorageBuffer GetShaderStorageBufferPtr<T>(this UnmanagedArray<T> array, VertexAttributeConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBufferPtr(array, IndependentBufferTarget.ShaderStorageBuffer, config, usage) as ShaderStorageBuffer;
        }

        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TextureBuffer GetTextureBufferPtr<T>(this UnmanagedArray<T> array, VertexAttributeConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBufferPtr(array, IndependentBufferTarget.TextureBuffer, config, usage) as TextureBuffer;
        }

        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static UniformBuffer GetUniformBufferPtr<T>(this UnmanagedArray<T> array, VertexAttributeConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBufferPtr(array, IndependentBufferTarget.UniformBuffer, config, usage) as UniformBuffer;
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
        public static IndependentBuffer GetIndependentBufferPtr<T>(this UnmanagedArray<T> array, IndependentBufferTarget bufferTarget, VertexAttributeConfig config, BufferUsage usage) where T : struct
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

            IndependentBuffer bufferPtr = null;
            switch (bufferTarget)
            {
                case IndependentBufferTarget.AtomicCounterBuffer:
                    bufferPtr = new AtomicCounterBuffer(buffers[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.PixelPackBuffer:
                    bufferPtr = new PixelPackBuffer(buffers[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.PixelUnpackBuffer:
                    bufferPtr = new PixelUnpackBuffer(buffers[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.ShaderStorageBuffer:
                    bufferPtr = new ShaderStorageBuffer(buffers[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.TextureBuffer:
                    bufferPtr = new TextureBuffer(buffers[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.UniformBuffer:
                    bufferPtr = new UniformBuffer(buffers[0], array.Length, array.ByteLength);
                    break;

                default:
                    throw new NotImplementedException();
            }

            return bufferPtr;
        }
    }
}