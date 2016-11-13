using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class Data2Buffer
    {
        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static AtomicCounterBuffer GetAtomicCounterBuffer<T>(this T data, BufferUsage usage) where T : struct
        {
            var array = new T[] { data };
            return GetAtomicCounterBuffer(array, usage);
        }

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelPackBuffer GetPixelPackBuffer<T>(this T data, BufferUsage usage) where T : struct
        {
            var array = new T[] { data };
            return GetPixelPackBuffer(array, usage);
        }

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelUnpackBuffer GetPixelUnpackBuffer<T>(this T data, BufferUsage usage) where T : struct
        {
            var array = new T[] { data };
            return GetPixelUnpackBuffer(array, usage);
        }

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static ShaderStorageBuffer GetShaderStorageBuffer<T>(this T data, BufferUsage usage) where T : struct
        {
            var array = new T[] { data };
            return GetShaderStorageBuffer(array, usage);
        }

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TextureBuffer GetTextureBuffer<T>(this T data, BufferUsage usage) where T : struct
        {
            var array = new T[] { data };
            return GetTextureBuffer(array, usage);
        }

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static UniformBuffer GetUniformBuffer<T>(this T data, BufferUsage usage) where T : struct
        {
            var array = new T[] { data };
            return GetUniformBuffer(array, usage);
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static AtomicCounterBuffer GetAtomicCounterBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            var unmanagedArray = new UnmanagedArray<T>(header, array.Length);
            AtomicCounterBuffer buffer = GetIndependentBuffer(unmanagedArray, IndependentBufferTarget.AtomicCounterBuffer, usage) as AtomicCounterBuffer;
            pinned.Free();

            return buffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelPackBuffer GetPixelPackBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            var unmanagedArray = new UnmanagedArray<T>(header, array.Length);
            PixelPackBuffer buffer = GetIndependentBuffer(unmanagedArray, IndependentBufferTarget.PixelPackBuffer, usage) as PixelPackBuffer;
            pinned.Free();

            return buffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelUnpackBuffer GetPixelUnpackBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            var unmanagedArray = new UnmanagedArray<T>(header, array.Length);
            PixelUnpackBuffer buffer = GetIndependentBuffer(unmanagedArray, IndependentBufferTarget.PixelUnpackBuffer, usage) as PixelUnpackBuffer;
            pinned.Free();

            return buffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static ShaderStorageBuffer GetShaderStorageBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            var unmanagedArray = new UnmanagedArray<T>(header, array.Length);
            ShaderStorageBuffer buffer = GetIndependentBuffer(unmanagedArray, IndependentBufferTarget.ShaderStorageBuffer, usage) as ShaderStorageBuffer;
            pinned.Free();

            return buffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TextureBuffer GetTextureBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            var unmanagedArray = new UnmanagedArray<T>(header, array.Length);
            TextureBuffer buffer = GetIndependentBuffer(unmanagedArray, IndependentBufferTarget.TextureBuffer, usage) as TextureBuffer;
            pinned.Free();

            return buffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static UniformBuffer GetUniformBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            var unmanagedArray = new UnmanagedArray<T>(header, array.Length);
            UniformBuffer buffer = GetIndependentBuffer(unmanagedArray, IndependentBufferTarget.UniformBuffer, usage) as UniformBuffer;
            pinned.Free();

            return buffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static AtomicCounterBuffer GetAtomicCounterBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.AtomicCounterBuffer, usage) as AtomicCounterBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelPackBuffer GetPixelPackBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.PixelPackBuffer, usage) as PixelPackBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelUnpackBuffer GetPixelUnpackBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.PixelUnpackBuffer, usage) as PixelUnpackBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static ShaderStorageBuffer GetShaderStorageBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.ShaderStorageBuffer, usage) as ShaderStorageBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TextureBuffer GetTextureBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.TextureBuffer, usage) as TextureBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static UniformBuffer GetUniformBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        {
            return GetIndependentBuffer(array, IndependentBufferTarget.UniformBuffer, usage) as UniformBuffer;
        }

        /// <summary>
        /// 获取某种独立的Buffer。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="bufferTarget"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        private static Buffer GetIndependentBuffer(this UnmanagedArrayBase array, IndependentBufferTarget bufferTarget, BufferUsage usage)
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