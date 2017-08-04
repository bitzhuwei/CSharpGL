using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class Data2Buffer
    {
        /// <summary>
        /// Generates an atomic counter buffer.
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
        /// Generates an pixel pack buffer.
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
        /// Generates an pixel unpack buffer.
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
        /// Generates an shader storage buffer.
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
        /// Generates an texture buffer.
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
        /// Generates an uniform buffer.
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
        /// Generates an uniform buffer.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TransformFeedbackBuffer GenTransformFeedbackBuffer<T>(this T data, BufferUsage usage) where T : struct
        {
            var array = new T[] { data };
            return GenTransformFeedbackBuffer(array, usage);
        }
    }
}