using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    internal static partial class VBOConfigHelper
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
        internal static void Parse(this VBOConfig config, out int locationCount, out int dataSize, out uint dataType, out int stride, out int startOffsetUnit)
        {
            locationCount = 1;
            //dataSize = 0;
            //dataType = 0;
            stride = 0;
            startOffsetUnit = 0;
            switch (config)
            {
                case VBOConfig.Byte:
                    dataSize = 1;
                    dataType = OpenGL.GL_BYTE;
                    break;

                case VBOConfig.BVec2:
                    dataSize = 2;
                    dataType = OpenGL.GL_BYTE;
                    break;

                case VBOConfig.BVec3:
                    dataSize = 3;
                    dataType = OpenGL.GL_BYTE;
                    break;

                case VBOConfig.BVec4:
                    dataSize = 4;
                    dataType = OpenGL.GL_BYTE;
                    break;

                case VBOConfig.Int:
                    dataSize = 1;
                    dataType = OpenGL.GL_INT;
                    break;

                case VBOConfig.IVec2:
                    dataSize = 2;
                    dataType = OpenGL.GL_INT;
                    break;

                case VBOConfig.IVec3:
                    dataSize = 3;
                    dataType = OpenGL.GL_INT;
                    break;

                case VBOConfig.IVec4:
                    dataSize = 4;
                    dataType = OpenGL.GL_INT;
                    break;

                case VBOConfig.UInt:
                    dataSize = 1;
                    dataType = OpenGL.GL_UNSIGNED_INT;
                    break;

                case VBOConfig.UVec2:
                    dataSize = 2;
                    dataType = OpenGL.GL_UNSIGNED_INT;
                    break;

                case VBOConfig.UVec3:
                    dataSize = 3;
                    dataType = OpenGL.GL_UNSIGNED_INT;
                    break;

                case VBOConfig.UVec4:
                    dataSize = 4;
                    dataType = OpenGL.GL_UNSIGNED_INT;
                    break;

                case VBOConfig.Float:
                    dataSize = 1;
                    dataType = OpenGL.GL_FLOAT;
                    break;

                case VBOConfig.Vec2:
                    dataSize = 2;
                    dataType = OpenGL.GL_FLOAT;
                    break;

                case VBOConfig.Vec3:
                    dataSize = 3;
                    dataType = OpenGL.GL_FLOAT;
                    break;

                case VBOConfig.Vec4:
                    dataSize = 4;
                    dataType = OpenGL.GL_FLOAT;
                    break;

                case VBOConfig.Double:
                    dataSize = 1;
                    dataType = OpenGL.GL_DOUBLE;
                    break;

                case VBOConfig.DVec2:
                    dataSize = 2;
                    dataType = OpenGL.GL_DOUBLE;
                    break;

                case VBOConfig.DVec3:
                    dataSize = 3;
                    dataType = OpenGL.GL_DOUBLE;
                    break;

                case VBOConfig.DVec4:
                    dataSize = 4;
                    dataType = OpenGL.GL_DOUBLE;
                    break;

                case VBOConfig.Mat2:
                    locationCount = 2;
                    dataSize = 2;
                    dataType = OpenGL.GL_FLOAT;
                    stride = Marshal.SizeOf(typeof(mat2));
                    startOffsetUnit = Marshal.SizeOf(typeof(vec2));
                    break;

                case VBOConfig.Mat3:
                    locationCount = 3;
                    dataSize = 3;
                    dataType = OpenGL.GL_FLOAT;
                    stride = Marshal.SizeOf(typeof(mat3));
                    startOffsetUnit = Marshal.SizeOf(typeof(vec3));
                    break;

                case VBOConfig.Mat4:
                    locationCount = 4;
                    dataSize = 4;
                    dataType = OpenGL.GL_FLOAT;
                    stride = Marshal.SizeOf(typeof(mat4));
                    startOffsetUnit = Marshal.SizeOf(typeof(vec4));
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}