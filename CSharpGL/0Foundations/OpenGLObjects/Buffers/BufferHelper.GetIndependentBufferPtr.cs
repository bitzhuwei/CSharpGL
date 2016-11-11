using System;

namespace CSharpGL
{
    /// <summary>
    /// Vertex Buffer Object.
    /// </summary>
    public static partial class BufferHelper
    {
        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static AtomicCounterBufferPtr GetAtomicCounterBufferPtr<T>(this UnmanagedArray<T> array, VertexAttributeConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBufferPtr(array, IndependentBufferTarget.AtomicCounterBuffer, config, usage) as AtomicCounterBufferPtr;
        }

        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelPackBufferPtr GetPixelPackBufferPtr<T>(this UnmanagedArray<T> array, VertexAttributeConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBufferPtr(array, IndependentBufferTarget.PixelPackBuffer, config, usage) as PixelPackBufferPtr;
        }

        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelUnpackBufferPtr GetPixelUnpackBufferPtr<T>(this UnmanagedArray<T> array, VertexAttributeConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBufferPtr(array, IndependentBufferTarget.PixelUnpackBuffer, config, usage) as PixelUnpackBufferPtr;
        }

        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static ShaderStorageBufferPtr GetShaderStorageBufferPtr<T>(this UnmanagedArray<T> array, VertexAttributeConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBufferPtr(array, IndependentBufferTarget.ShaderStorageBuffer, config, usage) as ShaderStorageBufferPtr;
        }

        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TextureBufferPtr GetTextureBufferPtr<T>(this UnmanagedArray<T> array, VertexAttributeConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBufferPtr(array, IndependentBufferTarget.TextureBuffer, config, usage) as TextureBufferPtr;
        }

        /// <summary>
        /// <para>Note: If <typeparamref name="T"/> matches one of this.Config's value, then (Ptr.ByteLength / (Ptr.DataSize * Ptr.DataTypeByteLength)) equals (Ptr.Length).</para>
        /// </summary>
        /// <para><typeparamref name="T"/> is type of element of this array in application level.</para>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static UniformBufferPtr GetUniformBufferPtr<T>(this UnmanagedArray<T> array, VertexAttributeConfig config, BufferUsage usage) where T : struct
        {
            return GetIndependentBufferPtr(array, IndependentBufferTarget.UniformBuffer, config, usage) as UniformBufferPtr;
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
        public static IndependentBufferPtr GetIndependentBufferPtr<T>(this UnmanagedArray<T> array, IndependentBufferTarget bufferTarget, VertexAttributeConfig config, BufferUsage usage) where T : struct
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

            IndependentBufferPtr bufferPtr = null;
            switch (bufferTarget)
            {
                case IndependentBufferTarget.AtomicCounterBuffer:
                    bufferPtr = new AtomicCounterBufferPtr(buffers[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.PixelPackBuffer:
                    bufferPtr = new PixelPackBufferPtr(buffers[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.PixelUnpackBuffer:
                    bufferPtr = new PixelUnpackBufferPtr(buffers[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.ShaderStorageBuffer:
                    bufferPtr = new ShaderStorageBufferPtr(buffers[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.TextureBuffer:
                    bufferPtr = new TextureBufferPtr(buffers[0], array.Length, array.ByteLength);
                    break;

                case IndependentBufferTarget.UniformBuffer:
                    bufferPtr = new UniformBufferPtr(buffers[0], array.Length, array.ByteLength);
                    break;

                default:
                    throw new NotImplementedException();
            }

            return bufferPtr;
        }
    }
}