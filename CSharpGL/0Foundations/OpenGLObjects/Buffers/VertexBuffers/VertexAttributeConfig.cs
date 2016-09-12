using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Decides parameter values for glVertexAttribPointer() and glEnable/DisableVertexAttribArray().
    /// </summary>
    public enum VertexAttributeConfig : uint
    {
        /// <summary>
        /// byte.
        /// </summary>
        Byte,

        /// <summary>
        /// <see cref="bvec2"/>.
        /// </summary>
        BVec2,

        /// <summary>
        /// <see cref="bvec3"/>.
        /// </summary>
        BVec3,

        /// <summary>
        /// <see cref="bvec4"/>.
        /// </summary>
        BVec4,

        /// <summary>
        /// int.
        /// </summary>
        Int,

        /// <summary>
        /// <see cref="ivec2"/>.
        /// </summary>
        IVec2,

        /// <summary>
        /// <see cref="ivec3"/>.
        /// </summary>
        IVec3,

        /// <summary>
        /// <see cref="ivec4"/>.
        /// </summary>
        IVec4,

        /// <summary>
        /// uint.
        /// </summary>
        UInt,

        /// <summary>
        /// <see cref="uvec2"/>.
        /// </summary>
        UVec2,

        /// <summary>
        /// <see cref="uvec3"/>.
        /// </summary>
        UVec3,

        /// <summary>
        /// <see cref="uvec4"/>.
        /// </summary>
        UVec4,

        /// <summary>
        /// float.
        /// </summary>
        Float,

        /// <summary>
        /// <see cref="vec2"/>.
        /// </summary>
        Vec2,

        /// <summary>
        /// <see cref="vec3"/>.
        /// </summary>
        Vec3,

        /// <summary>
        /// <see cref="vec4"/>.
        /// </summary>
        Vec4,

        /// <summary>
        /// double.
        /// </summary>
        Double,

        /// <summary>
        /// d<see cref="vec2"/>.
        /// </summary>
        DVec2,

        /// <summary>
        /// <see cref="dvec3"/>.
        /// </summary>
        DVec3,

        /// <summary>
        /// <see cref="dvec4"/>.
        /// </summary>
        DVec4,

        /// <summary>
        /// <see cref="mat2"/>.
        /// </summary>
        Mat2,

        /// <summary>
        /// <see cref="mat3"/>.
        /// </summary>
        Mat3,

        /// <summary>
        /// <see cref="mat4"/>.
        /// </summary>
        Mat4,
    }

    /// <summary>
    ///
    /// </summary>
    public static class VertexAttributeConfigHelper
    {
        /// <summary>
        /// Gets parameter values for glVertexAttribPointer() and glEnable/DisableVertexAttribArray().
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