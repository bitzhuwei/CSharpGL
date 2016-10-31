//using System;

//namespace CSharpGL
//{
//    public partial class OneIndexBuffer
//    {
//        /// <summary>
//        /// Crates a <see cref="VertexAttributeBufferPtr"/> object directly in server side(GPU) without initializing its value.
//        /// </summary>
//        /// <param name="byteLength"></param>
//        /// <param name="usage"></param>
//        /// <param name="mode"></param>
//        /// <param name="type"></param>
//        /// <param name="length"></param>
//        /// <param name="instanceDivisor"></param>
//        /// <param name="patchVertexes"></param>
//        /// <returns></returns>
//        public static OneIndexBufferPtr Create(int byteLength, BufferUsage usage, DrawMode mode, IndexElementType type, int length, uint instanceDivisor, int patchVertexes)
//        {
//            uint[] buffers = new uint[1];
//            glGenBuffers(1, buffers);
//            const uint target = OpenGL.GL_ELEMENT_ARRAY_BUFFER;
//            glBindBuffer(target, buffers[0]);
//            glBufferData(target, byteLength, IntPtr.Zero, (uint)usage);
//            glBindBuffer(target, 0);

//            var bufferPtr = new OneIndexBufferPtr(
//                 buffers[0], mode, type, length, byteLength);

//            return bufferPtr;
//        }
//    }
//}