using SixLabors.ImageSharp.Memory;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSharpGL {
    public static unsafe partial class Data2Buffer {
        /// <summary>
        /// Generates an atomic counter buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static AtomicCounterBuffer GenAtomicCounterBuffer<T>(this T[] array, GLBuffer.Usage usage) where T : struct {
            var buffer = GenBuffer(array, IndependentBufferTarget.AtomicCounterBuffer, usage) as AtomicCounterBuffer;
            Debug.Assert(buffer != null);
            return buffer;
        }

        /// <summary>
        /// Generates an pixel pack buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelPackBuffer GenPixelPackBuffer<T>(this T[] array, GLBuffer.Usage usage) where T : struct {
            var buffer = GenBuffer(array, IndependentBufferTarget.PixelPackBuffer, usage) as PixelPackBuffer;
            Debug.Assert(buffer != null);
            return buffer;
        }

        /// <summary>
        /// Generates an pixel unpack buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelUnpackBuffer GenPixelUnpackBuffer<T>(this T[] array, GLBuffer.Usage usage) where T : struct {
            var buffer = GenBuffer(array, IndependentBufferTarget.PixelUnpackBuffer, usage) as PixelUnpackBuffer;
            Debug.Assert(buffer != null);
            return buffer;
        }

        /// <summary>
        /// Generates an shader storage buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static ShaderStorageBuffer GenShaderStorageBuffer<T>(this T[] array, GLBuffer.Usage usage) where T : struct {
            var buffer = GenBuffer(array, IndependentBufferTarget.ShaderStorageBuffer, usage) as ShaderStorageBuffer;
            Debug.Assert(buffer != null);
            return buffer;
        }

        /// <summary>
        /// Generates an texture buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TextureBuffer GenTextureBuffer<T>(this T[] array, GLBuffer.Usage usage) where T : struct {
            var buffer = GenBuffer(array, IndependentBufferTarget.TextureBuffer, usage) as TextureBuffer;
            Debug.Assert(buffer != null);
            return buffer;
        }

        /// <summary>
        /// Generates an uniform buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static UniformBuffer GenUniformBuffer<T>(this T[] array, GLBuffer.Usage usage) where T : struct {
            var buffer = GenBuffer(array, IndependentBufferTarget.UniformBuffer, usage) as UniformBuffer;
            Debug.Assert(buffer != null);
            return buffer;
        }

        /// <summary>
        /// Generates an uniform buffer.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TransformFeedbackBuffer GenTransformFeedbackBuffer<T>(this T[] array, GLBuffer.Usage usage) where T : struct {
            var buffer = GenBuffer(array, IndependentBufferTarget.TransformFeedbackBuffer, usage) as TransformFeedbackBuffer;
            Debug.Assert(buffer != null);
            return buffer;
        }

        /// <summary>
        /// Generates an independent buffer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="target"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        private static GLBuffer GenBuffer<T>(this T[] array, IndependentBufferTarget target, GLBuffer.Usage usage) where T : struct {
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = pinned.AddrOfPinnedObject();
            // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            //UnmanagedArrayBase unmanagedArray = new TempUnmanagedArray<T>(header, array.Length);// It's not necessary to call Dispose() for this unmanaged array.
            var elementCount = array.Length;
            var byteLength = Marshal.SizeOf(typeof(T)) * elementCount;
            var buffer = GenIndependentBuffer(header, elementCount, byteLength, target, usage);
            pinned.Free();

            return buffer;
        }

    }
}