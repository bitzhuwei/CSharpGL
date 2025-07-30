using System;
using System.Runtime.InteropServices;

namespace CSharpGL {
    unsafe partial class GLBuffer {
        /// <summary>
        /// Creates a <see cref="VertexBuffer"/> object(actually an array) directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType">element's type of this 'array'.</param>
        /// <param name="length">How many elements are there?</param>
        /// <param name="config">mapping to vertex shader's 'in' type.</param>
        /// <param name="usage"></param>
        /// <param name="instanceDivisor"></param>
        /// <param name="patchVertexes"></param>
        /// <returns></returns>
        public static VertexBuffer Create(Type elementType, int length, VBOConfig config, GLBuffer.Usage usage, uint instanceDivisor = 0, int patchVertexes = 0) {
            var gl = GL.current; if (gl == null) { throw new Exception("openGL context is not ready or current."); }
            if (!elementType.IsValueType) { throw new ArgumentException($"{elementType} must be a value type!"); }

            const uint target = GL.GL_ARRAY_BUFFER;
            int byteLength = Marshal.SizeOf(elementType) * length;
            var bufferId = CallGL(target, byteLength, IntPtr.Zero, usage);

            var buffer = new VertexBuffer(
                 bufferId, config, length, byteLength, usage, instanceDivisor, patchVertexes);

            return buffer;
        }

        /// <summary>
        /// Creates a <see cref="IndexBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="length">How many indexes are there?(How many uint/ushort/bytes?)</param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static IndexBuffer Create(IndexBuffer.ElementType type, int length, GLBuffer.Usage usage) {
            var gl = GL.current; if (gl == null) { throw new Exception("openGL context is not ready or current."); }

            const GLenum target = GL.GL_ELEMENT_ARRAY_BUFFER;
            int byteLength = IndexBuffer.sizeOf[type] * length;
            var bufferId = CallGL(target, byteLength, IntPtr.Zero, usage);

            var buffer = new IndexBuffer(bufferId, type, byteLength);

            return buffer;
        }

        /// <summary>
        /// Creates a sub-type of <see cref="GLBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="elementType"></param>
        /// <param name="length"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static GLBuffer Create(IndependentBufferTarget target, Type elementType, int length, GLBuffer.Usage usage) {
            if (!elementType.IsValueType) { throw new ArgumentException(string.Format("{0} must be a value type!", elementType)); }

            int byteLength = Marshal.SizeOf(elementType) * length;
            var bufferId = CallGL((GLenum)target, byteLength, IntPtr.Zero, usage);

            GLBuffer buffer;
            switch (target) {
            case IndependentBufferTarget.AtomicCounterBuffer:
            buffer = new AtomicCounterBuffer(bufferId, length, byteLength, usage);
            break;

            case IndependentBufferTarget.PixelPackBuffer:
            buffer = new PixelPackBuffer(bufferId, length, byteLength, usage);
            break;

            case IndependentBufferTarget.PixelUnpackBuffer:
            buffer = new PixelUnpackBuffer(bufferId, length, byteLength, usage);
            break;

            case IndependentBufferTarget.ShaderStorageBuffer:
            buffer = new ShaderStorageBuffer(bufferId, length, byteLength, usage);
            break;

            case IndependentBufferTarget.TextureBuffer:
            buffer = new TextureBuffer(bufferId, length, byteLength, usage);
            break;

            case IndependentBufferTarget.UniformBuffer:
            buffer = new UniformBuffer(bufferId, length, byteLength, usage);
            break;

            case IndependentBufferTarget.TransformFeedbackBuffer:
            buffer = new TransformFeedbackBuffer(bufferId, length, byteLength, usage);
            break;

            default:
            throw new NotSupportedException(target.ToString());
            }

            return buffer;
        }

        /// <summary>
        /// Creates a buffer object directly in server side(GPU)
        /// </summary>
        /// <param name="target"></param>
        /// <param name="byteLength"></param>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        internal static GLuint CallGL(GLenum target, int byteLength, IntPtr? data, GLBuffer.Usage usage) {
            var gl = GL.current; if (gl == null) { throw new Exception("openGL context is not ready or current."); }

            var buffers = stackalloc uint[1];
            gl.glGenBuffers(1, buffers);
            gl.glBindBuffer(target, buffers[0]);
            if (data != null) {
                gl.glBufferData(target, byteLength, data.Value, (GLenum)usage);
            }
            gl.glBindBuffer(target, 0);

            return buffers[0];
        }
    }
}