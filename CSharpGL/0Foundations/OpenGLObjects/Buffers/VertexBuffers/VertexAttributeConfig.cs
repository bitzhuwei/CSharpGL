using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public enum VertexAttributeConfig : uint
    {
        /// <summary>
        ///
        /// </summary>
        Byte,

        /// <summary>
        ///
        /// </summary>
        BVec2,

        /// <summary>
        ///
        /// </summary>
        BVec3,

        /// <summary>
        ///
        /// </summary>
        BVec4,

        /// <summary>
        ///
        /// </summary>
        Int,

        /// <summary>
        ///
        /// </summary>
        IVec2,

        /// <summary>
        ///
        /// </summary>
        IVec3,

        /// <summary>
        ///
        /// </summary>
        IVec4,

        /// <summary>
        ///
        /// </summary>
        UInt,

        /// <summary>
        ///
        /// </summary>
        UVec2,

        /// <summary>
        ///
        /// </summary>
        UVec3,

        /// <summary>
        ///
        /// </summary>
        UVec4,

        /// <summary>
        ///
        /// </summary>
        Float,

        /// <summary>
        ///
        /// </summary>
        Vec2,

        /// <summary>
        ///
        /// </summary>
        Vec3,

        /// <summary>
        ///
        /// </summary>
        Vec4,

        /// <summary>
        ///
        /// </summary>
        Double,

        /// <summary>
        ///
        /// </summary>
        DVec2,

        /// <summary>
        ///
        /// </summary>
        DVec3,

        /// <summary>
        ///
        /// </summary>
        DVec4,

        /// <summary>
        ///
        /// </summary>
        Mat2,

        /// <summary>
        ///
        /// </summary>
        Mat3,

        /// <summary>
        ///
        /// </summary>
        Mat4,
    }

    /// <summary>
    ///
    /// </summary>
    public static class VertexAttributeConfigHelper
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="config"></param>
        /// <param name="locationCount"></param>
        /// <param name="dataSize"></param>
        /// <param name="dataType"></param>
        /// <param name="stride"></param>
        /// <param name="startOffsetUnit"></param>
        public static void Parse(this VertexAttributeConfig config, out int locationCount, out int dataSize, out uint dataType, out int stride, out int startOffsetUnit)
        {
            locationCount = 1;
            //dataSize = 0;
            //dataType = 0;
            stride = 0;
            startOffsetUnit = 0;
            switch (config)
            {
                case VertexAttributeConfig.Byte:
                    dataSize = 1;
                    dataType = OpenGL.GL_BYTE;
                    break;

                case VertexAttributeConfig.BVec2:
                    dataSize = 2;
                    dataType = OpenGL.GL_BYTE;
                    break;

                case VertexAttributeConfig.BVec3:
                    dataSize = 3;
                    dataType = OpenGL.GL_BYTE;
                    break;

                case VertexAttributeConfig.BVec4:
                    dataSize = 4;
                    dataType = OpenGL.GL_BYTE;
                    break;

                case VertexAttributeConfig.Int:
                    dataSize = 1;
                    dataType = OpenGL.GL_INT;
                    break;

                case VertexAttributeConfig.IVec2:
                    dataSize = 2;
                    dataType = OpenGL.GL_INT;
                    break;

                case VertexAttributeConfig.IVec3:
                    dataSize = 3;
                    dataType = OpenGL.GL_INT;
                    break;

                case VertexAttributeConfig.IVec4:
                    dataSize = 4;
                    dataType = OpenGL.GL_INT;
                    break;

                case VertexAttributeConfig.UInt:
                    dataSize = 1;
                    dataType = OpenGL.GL_UNSIGNED_INT;
                    break;

                case VertexAttributeConfig.UVec2:
                    dataSize = 2;
                    dataType = OpenGL.GL_UNSIGNED_INT;
                    break;

                case VertexAttributeConfig.UVec3:
                    dataSize = 3;
                    dataType = OpenGL.GL_UNSIGNED_INT;
                    break;

                case VertexAttributeConfig.UVec4:
                    dataSize = 4;
                    dataType = OpenGL.GL_UNSIGNED_INT;
                    break;

                case VertexAttributeConfig.Float:
                    dataSize = 1;
                    dataType = OpenGL.GL_FLOAT;
                    break;

                case VertexAttributeConfig.Vec2:
                    dataSize = 2;
                    dataType = OpenGL.GL_FLOAT;
                    break;

                case VertexAttributeConfig.Vec3:
                    dataSize = 3;
                    dataType = OpenGL.GL_FLOAT;
                    break;

                case VertexAttributeConfig.Vec4:
                    dataSize = 4;
                    dataType = OpenGL.GL_FLOAT;
                    break;

                case VertexAttributeConfig.Double:
                    dataSize = 1;
                    dataType = OpenGL.GL_DOUBLE;
                    break;

                case VertexAttributeConfig.DVec2:
                    dataSize = 2;
                    dataType = OpenGL.GL_DOUBLE;
                    break;

                case VertexAttributeConfig.DVec3:
                    dataSize = 3;
                    dataType = OpenGL.GL_DOUBLE;
                    break;

                case VertexAttributeConfig.DVec4:
                    dataSize = 4;
                    dataType = OpenGL.GL_DOUBLE;
                    break;

                case VertexAttributeConfig.Mat2:
                    locationCount = 2;
                    dataSize = 2;
                    dataType = OpenGL.GL_FLOAT;
                    stride = Marshal.SizeOf(typeof(mat2));
                    startOffsetUnit = Marshal.SizeOf(typeof(vec2));
                    break;

                case VertexAttributeConfig.Mat3:
                    locationCount = 3;
                    dataSize = 3;
                    dataType = OpenGL.GL_FLOAT;
                    stride = Marshal.SizeOf(typeof(mat3));
                    startOffsetUnit = Marshal.SizeOf(typeof(vec3));
                    break;

                case VertexAttributeConfig.Mat4:
                    locationCount = 4;
                    dataSize = 4;
                    dataType = OpenGL.GL_FLOAT;
                    stride = Marshal.SizeOf(typeof(mat4));
                    startOffsetUnit = Marshal.SizeOf(typeof(vec4));
                    break;

                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}