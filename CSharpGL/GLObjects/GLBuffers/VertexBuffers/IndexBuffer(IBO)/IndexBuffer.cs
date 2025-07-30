using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL {
    /// <summary>
    /// The indexes in which order the rendering command renders vertexes.
    /// </summary>
    public unsafe class IndexBuffer : GLBuffer {

        /// <summary>
        /// type in glDrawElements(GLenum mode, GLsizei count, GLenum type, IntPtr indices);
        /// </summary>
        public readonly ElementType elementType;

        /// <summary>
        /// The indexes in which order the rendering command renders vertexes.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="elementType">type in glDrawElements(uint mode, int count, uint type, IntPtr indices);</param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer</para></param>
        internal IndexBuffer(GLuint bufferId, ElementType elementType, int byteLength)
            : base(Target.ElementArrayBuffer, bufferId, byteLength / IndexBuffer.sizeOf[elementType], byteLength, Usage.DynamicDraw/*invalid param*/) {
            this.elementType = elementType;
        }


        /// <summary>
        ///
        /// </summary>
        public enum ElementType : GLuint {
            /// <summary>
            /// byte
            /// </summary>
            UByte = GL.GL_UNSIGNED_BYTE,

            /// <summary>
            /// ushort
            /// </summary>
            UShort = GL.GL_UNSIGNED_SHORT,

            /// <summary>
            /// uint
            /// </summary>
            UInt = GL.GL_UNSIGNED_INT,

        }

        /// <summary>
        /// how many bytes is the specified <see cref="ElementType"/>
        /// </summary>
        public static readonly IReadOnlyDictionary<ElementType, int> sizeOf = new Dictionary<ElementType, int>() {
            { ElementType.UByte, sizeof(byte) },
            { ElementType.UShort, sizeof(ushort) },
            { ElementType.UInt, sizeof(uint) },
        };

        //public static int GetSize(ElementType type) {
        //    int result = 0;
        //    switch (type) {
        //    case ElementType.UByte:
        //    result = sizeof(byte);
        //    break;

        //    case ElementType.UShort:
        //    result = sizeof(ushort);
        //    break;

        //    case ElementType.UInt:
        //    result = sizeof(uint);
        //    break;

        //    default:
        //    throw new NotSupportedException(type.ToString());
        //    }

        //    return result;
        //}

    }
}