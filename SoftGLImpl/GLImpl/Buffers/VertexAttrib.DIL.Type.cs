using System.Reflection.Emit;

namespace SoftGLImpl {
    /// <summary>
    /// Default
    /// </summary>
    internal enum VertexAttribType : uint {
        Byte = GL.GL_BYTE,
        UnsignedByte = GL.GL_UNSIGNED_BYTE,
        Short = GL.GL_SHORT,
        UnsignedShort = GL.GL_UNSIGNED_SHORT,
        Int = GL.GL_INT,
        UnsignedInt = GL.GL_UNSIGNED_INT,
        /// <summary>
        /// Half of a float.
        /// </summary>
        HalfFloat = GL.GL_HALF_FLOAT,
        Float = GL.GL_FLOAT,
        Double = GL.GL_DOUBLE,
        /// <summary>
        /// 16:16 int.
        /// </summary>
        Fixed = GL.GL_FIXED,
        Int2101010Rev = GL.GL_INT_2_10_10_10_REV,
        UnsignedInt2101010Rev = GL.GL_UNSIGNED_INT_2_10_10_10_REV,
        UnsignedInt10f11f11fRev = GL.GL_UNSIGNED_INT_10F_11F_11F_REV
    }

    /// <summary>
    /// I
    /// </summary>
    internal enum VertexAttribIType : uint {
        Byte = GL.GL_BYTE,
        UnsignedByte = GL.GL_UNSIGNED_BYTE,
        Short = GL.GL_SHORT,
        UnsignedShort = GL.GL_UNSIGNED_SHORT,
        Int = GL.GL_INT,
        UnsignedInt = GL.GL_UNSIGNED_INT
    }

    /// <summary>
    /// L
    /// </summary>
    internal enum VertexAttribLType : uint {
        Double = GL.GL_DOUBLE
    }

}
