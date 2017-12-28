namespace CSharpGL
{

    /// <summary>
    ///
    /// </summary>
    public enum IndexBufferElementType : uint
    {
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

    internal static class IndexBufferElementTypeExtension
    {

        public static int GetSize(this IndexBufferElementType type)
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
                    throw new NotDealWithNewEnumItemException(typeof(IndexBufferElementType));
            }

            return result;
        }

    }
}