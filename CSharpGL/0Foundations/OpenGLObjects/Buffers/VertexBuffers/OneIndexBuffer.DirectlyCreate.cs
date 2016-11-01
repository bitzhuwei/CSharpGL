using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public sealed partial class OneIndexBufferPtr
    {
        /// <summary>
        /// Creates a <see cref="OneIndexBufferPtr"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="usage"></param>
        /// <param name="mode"></param>
        /// <param name="type"></param>
        /// <param name="length">How many indexes are there?(How many uint/ushort/bytes?)</param>
        /// <returns></returns>
        public static OneIndexBufferPtr Create(BufferUsage usage, DrawMode mode, IndexElementType type, int length)
        {
            if (glGenBuffers == null)
            {
                glGenBuffers = OpenGL.GetDelegateFor<OpenGL.glGenBuffers>();
                glBufferData = OpenGL.GetDelegateFor<OpenGL.glBufferData>();
            }

            if (glBindBuffer == null)
            {
                glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>();
            }

            int byteLength = GetSize(type) * length;
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            const uint target = OpenGL.GL_ELEMENT_ARRAY_BUFFER;
            glBindBuffer(target, buffers[0]);
            glBufferData(target, byteLength, IntPtr.Zero, (uint)usage);
            glBindBuffer(target, 0);

            var bufferPtr = new OneIndexBufferPtr(
                 buffers[0], mode, type, length, byteLength);

            return bufferPtr;
        }

        private static int GetSize(IndexElementType type)
        {
            int result = 0;
            switch (type)
            {
                case IndexElementType.UByte:
                    result = sizeof(byte);
                    break;

                case IndexElementType.UShort:
                    result = sizeof(ushort);
                    break;

                case IndexElementType.UInt:
                    result = sizeof(uint);
                    break;

                default:
                    break;
            }

            return result;
        }
    }
}