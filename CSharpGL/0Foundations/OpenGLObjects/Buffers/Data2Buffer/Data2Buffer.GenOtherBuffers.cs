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
        public static AtomicCounterBuffer GenAtomicCounterBuffer<T>(this T data, BufferUsage usage) where T : struct
        {
            var array = new T[] { data };
            return GenAtomicCounterBuffer(array, usage);
        }

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelPackBuffer GenPixelPackBuffer<T>(this T data, BufferUsage usage) where T : struct
        {
            var array = new T[] { data };
            return GenPixelPackBuffer(array, usage);
        }

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelUnpackBuffer GenPixelUnpackBuffer<T>(this T data, BufferUsage usage) where T : struct
        {
            var array = new T[] { data };
            return GenPixelUnpackBuffer(array, usage);
        }

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static ShaderStorageBuffer GenShaderStorageBuffer<T>(this T data, BufferUsage usage) where T : struct
        {
            var array = new T[] { data };
            return GenShaderStorageBuffer(array, usage);
        }

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TextureBuffer GenTextureBuffer<T>(this T data, BufferUsage usage) where T : struct
        {
            var array = new T[] { data };
            return GenTextureBuffer(array, usage);
        }

        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static UniformBuffer GenUniformBuffer<T>(this T data, BufferUsage usage) where T : struct
        {
            var array = new T[] { data };
            return GenUniformBuffer(array, usage);
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static AtomicCounterBuffer GenAtomicCounterBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            return GenIndependentBuffer(array, IndependentBufferTarget.AtomicCounterBuffer, usage) as AtomicCounterBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelPackBuffer GenPixelPackBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            return GenIndependentBuffer(array, IndependentBufferTarget.PixelPackBuffer, usage) as PixelPackBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelUnpackBuffer GenPixelUnpackBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            return GenIndependentBuffer(array, IndependentBufferTarget.PixelUnpackBuffer, usage) as PixelUnpackBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static ShaderStorageBuffer GenShaderStorageBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            return GenIndependentBuffer(array, IndependentBufferTarget.ShaderStorageBuffer, usage) as ShaderStorageBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TextureBuffer GenTextureBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            return GenIndependentBuffer(array, IndependentBufferTarget.TextureBuffer, usage) as TextureBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static UniformBuffer GenUniformBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            return GenIndependentBuffer(array, IndependentBufferTarget.UniformBuffer, usage) as UniformBuffer;
        }

        private static Buffer GenIndependentBuffer<T>(this T[] array, IndependentBufferTarget target, BufferUsage usage) where T : struct
        {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            var unmanagedArray = new UnmanagedArray<T>(header, array.Length);// It's not neecessary to call Dispose() for this unmanaged array.
            Buffer buffer = GenIndependentBuffer(unmanagedArray, target, usage);
            pinned.Free();

            return buffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static AtomicCounterBuffer GenAtomicCounterBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        {
            return GenIndependentBuffer(array, IndependentBufferTarget.AtomicCounterBuffer, usage) as AtomicCounterBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelPackBuffer GenPixelPackBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        {
            return GenIndependentBuffer(array, IndependentBufferTarget.PixelPackBuffer, usage) as PixelPackBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelUnpackBuffer GenPixelUnpackBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        {
            return GenIndependentBuffer(array, IndependentBufferTarget.PixelUnpackBuffer, usage) as PixelUnpackBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static ShaderStorageBuffer GenShaderStorageBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        {
            return GenIndependentBuffer(array, IndependentBufferTarget.ShaderStorageBuffer, usage) as ShaderStorageBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TextureBuffer GenTextureBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        {
            return GenIndependentBuffer(array, IndependentBufferTarget.TextureBuffer, usage) as TextureBuffer;
        }

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static UniformBuffer GenUniformBuffer(this UnmanagedArrayBase array, BufferUsage usage)
        {
            return GenIndependentBuffer(array, IndependentBufferTarget.UniformBuffer, usage) as UniformBuffer;
        }

        /// <summary>
        /// 生成某种独立的Buffer。
        /// </summary>
        /// <param name="array"></param>
        /// <param name="bufferTarget"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        private static Buffer GenIndependentBuffer(this UnmanagedArrayBase array, IndependentBufferTarget bufferTarget, BufferUsage usage)
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