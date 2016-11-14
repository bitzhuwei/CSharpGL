using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class Data2Buffer
    {
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

    }
}