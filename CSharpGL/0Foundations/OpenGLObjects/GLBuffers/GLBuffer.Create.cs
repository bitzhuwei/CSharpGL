using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public partial class GLBuffer
    {
        /// <summary>
        /// Creates a <see cref="VertexBuffer"/> object(actually an array) directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType">element's type of this 'array'.</param>
        /// <param name="length">How many elements are there?</param>
        /// <param name="config">mapping to vertex shader's 'in' type.</param>
        /// <param name="varNameInVertexShader">mapping to vertex shader's 'in' name.</param>
        /// <param name="usage"></param>
        /// <param name="instanceDivisor"></param>
        /// <param name="patchVertexes"></param>
        /// <returns></returns>
        public static VertexBuffer Create(Type elementType, int length, VBOConfig config, string varNameInVertexShader, BufferUsage usage, uint instanceDivisor = 0, int patchVertexes = 0)
        {
            if (!elementType.IsValueType) { throw new ArgumentException(string.Format("{0} must be a value type!", elementType)); }

            int byteLength = Marshal.SizeOf(elementType) * length;
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            const uint target = OpenGL.GL_ARRAY_BUFFER;
            glBindBuffer(target, buffers[0]);
            glBufferData(target, byteLength, IntPtr.Zero, (uint)usage);
            glBindBuffer(target, 0);

            var buffer = new VertexBuffer(
                 buffers[0], config, length, byteLength, instanceDivisor, patchVertexes);

            return buffer;
        }

        /// <summary>
        /// Creates a <see cref="ZeroIndexBuffer"/> object directly in server side(GPU) without initializing its value.
        /// <para><see cref="ZeroIndexBuffer"/> is not a real buffer like <see cref="OneIndexBuffer"/>.</para>
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="firstVertex"></param>
        /// <param name="vertexCount"></param>
        /// <param name="primCount"></param>
        /// <returns></returns>
        public static ZeroIndexBuffer Create(DrawMode mode, int firstVertex, int vertexCount, int primCount = 1)
        {
            ZeroIndexBuffer buffer = new ZeroIndexBuffer(mode, firstVertex, vertexCount, primCount);

            return buffer;
        }

        /// <summary>
        /// Creates a <see cref="OneIndexBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="length">How many indexes are there?(How many uint/ushort/bytes?)</param>
        /// <param name="mode"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static OneIndexBuffer Create(IndexBufferElementType type, int length, DrawMode mode, BufferUsage usage)
        {
            int byteLength = GetSize(type) * length;
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            const uint target = OpenGL.GL_ELEMENT_ARRAY_BUFFER;
            glBindBuffer(target, buffers[0]);
            glBufferData(target, byteLength, IntPtr.Zero, (uint)usage);
            glBindBuffer(target, 0);

            var buffer = new OneIndexBuffer(
                 buffers[0], mode, type, length, byteLength);

            return buffer;
        }

        private static int GetSize(IndexBufferElementType type)
        {
            int result = 0;
            switch (type)
            {
                case IndexBufferElementType.UByte:
                    result = sizeof(byte);
                    break;

                case IndexBufferElementType.UShort:
                    result = sizeof(ushort);
                    break;

                case IndexBufferElementType.UInt:
                    result = sizeof(uint);
                    break;

                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        /// <summary>
        /// Creates a sub-type of <see cref="GLBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="elementType"></param>
        /// <param name="length"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static GLBuffer Create(IndependentBufferTarget target, Type elementType, int length, BufferUsage usage)
        {
            if (!elementType.IsValueType) { throw new ArgumentException(string.Format("{0} must be a value type!", elementType)); }

            uint bufferTarget = (uint)target;
            int byteLength = Marshal.SizeOf(elementType) * length;
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            glBindBuffer(bufferTarget, buffers[0]);
            glBufferData(bufferTarget, byteLength, IntPtr.Zero, (uint)usage);
            glBindBuffer(bufferTarget, 0);

            GLBuffer buffer;
            switch (target)
            {
                case IndependentBufferTarget.AtomicCounterBuffer:
                    buffer = new AtomicCounterBuffer(buffers[0], length, byteLength);
                    break;

                case IndependentBufferTarget.PixelPackBuffer:
                    buffer = new PixelPackBuffer(buffers[0], length, byteLength);
                    break;

                case IndependentBufferTarget.PixelUnpackBuffer:
                    buffer = new PixelUnpackBuffer(buffers[0], length, byteLength);
                    break;

                case IndependentBufferTarget.ShaderStorageBuffer:
                    buffer = new ShaderStorageBuffer(buffers[0], length, byteLength);
                    break;

                case IndependentBufferTarget.TextureBuffer:
                    buffer = new TextureBuffer(buffers[0], length, byteLength);
                    break;

                case IndependentBufferTarget.UniformBuffer:
                    buffer = new UniformBuffer(buffers[0], length, byteLength);
                    break;

                default:
                    throw new NotImplementedException();
            }

            return buffer;
        }
    }
}