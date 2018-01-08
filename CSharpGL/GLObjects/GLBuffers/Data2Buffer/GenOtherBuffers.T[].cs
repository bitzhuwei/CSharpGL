using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class Data2Buffer
    {
        /// <summary>
        /// Generates an atomic counter buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static AtomicCounterBuffer GenAtomicCounterBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            return GenBuffer(array, IndependentBufferTarget.AtomicCounterBuffer, usage) as AtomicCounterBuffer;
        }

        /// <summary>
        /// Generates an pixel pack buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelPackBuffer GenPixelPackBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            return GenBuffer(array, IndependentBufferTarget.PixelPackBuffer, usage) as PixelPackBuffer;
        }

        /// <summary>
        /// Generates an pixel unpack buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelUnpackBuffer GenPixelUnpackBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            return GenBuffer(array, IndependentBufferTarget.PixelUnpackBuffer, usage) as PixelUnpackBuffer;
        }

        /// <summary>
        /// Generates an shader storage buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static ShaderStorageBuffer GenShaderStorageBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            return GenBuffer(array, IndependentBufferTarget.ShaderStorageBuffer, usage) as ShaderStorageBuffer;
        }

        /// <summary>
        /// Generates an texture buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TextureBuffer GenTextureBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            return GenBuffer(array, IndependentBufferTarget.TextureBuffer, usage) as TextureBuffer;
        }

        /// <summary>
        /// Generates an uniform buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static UniformBuffer GenUniformBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            return GenBuffer(array, IndependentBufferTarget.UniformBuffer, usage) as UniformBuffer;
        }

        /// <summary>
        /// Generates an uniform buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TransformFeedbackBuffer GenTransformFeedbackBuffer<T>(this T[] array, BufferUsage usage) where T : struct
        {
            return GenBuffer(array, IndependentBufferTarget.TransformFeedbackBuffer, usage) as TransformFeedbackBuffer;
        }

        /// <summary>
        /// Generates an independent buffer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="target"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        private static GLBuffer GenBuffer<T>(this T[] array, IndependentBufferTarget target, BufferUsage usage) where T : struct
        {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = pinned.AddrOfPinnedObject();
            // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            UnmanagedArrayBase unmanagedArray = new TempUnmanagedArray<T>(header, array.Length);// It's not necessary to call Dispose() for this unmanaged array.
            GLBuffer buffer = GenIndependentBuffer(unmanagedArray, target, usage);
            pinned.Free();

            return buffer;
        }

    }
}