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
        internal static VBOConfigDetail Parse(this VBOConfig config)
        {
            var result = new VBOConfigDetail();

            switch (config)
            {
                case VBOConfig.Byte:
                    result.dataSize = 1;
                    result.dataType = OpenGL.GL_BYTE;
                    break;

                case VBOConfig.BVec2:
                    result.dataSize = 2;
                    result.dataType = OpenGL.GL_BYTE;
                    break;

                case VBOConfig.BVec3:
                    result.dataSize = 3;
                    result.dataType = OpenGL.GL_BYTE;
                    break;

                case VBOConfig.BVec4:
                    result.dataSize = 4;
                    result.dataType = OpenGL.GL_BYTE;
                    break;

                case VBOConfig.Int:
                    result.dataSize = 1;
                    result.dataType = OpenGL.GL_INT;
                    break;

                case VBOConfig.IVec2:
                    result.dataSize = 2;
                    result.dataType = OpenGL.GL_INT;
                    break;

                case VBOConfig.IVec3:
                    result.dataSize = 3;
                    result.dataType = OpenGL.GL_INT;
                    break;

                case VBOConfig.IVec4:
                    result.dataSize = 4;
                    result.dataType = OpenGL.GL_INT;
                    break;

                case VBOConfig.UInt:
                    result.dataSize = 1;
                    result.dataType = OpenGL.GL_UNSIGNED_INT;
                    break;

                case VBOConfig.UVec2:
                    result.dataSize = 2;
                    result.dataType = OpenGL.GL_UNSIGNED_INT;
                    break;

                case VBOConfig.UVec3:
                    result.dataSize = 3;
                    result.dataType = OpenGL.GL_UNSIGNED_INT;
                    break;

                case VBOConfig.UVec4:
                    result.dataSize = 4;
                    result.dataType = OpenGL.GL_UNSIGNED_INT;
                    break;

                case VBOConfig.Float:
                    result.dataSize = 1;
                    result.dataType = OpenGL.GL_FLOAT;
                    break;

                case VBOConfig.Vec2:
                    result.dataSize = 2;
                    result.dataType = OpenGL.GL_FLOAT;
                    break;

                case VBOConfig.Vec3:
                    result.dataSize = 3;
                    result.dataType = OpenGL.GL_FLOAT;
                    break;

                case VBOConfig.Vec4:
                    result.dataSize = 4;
                    result.dataType = OpenGL.GL_FLOAT;
                    break;

                case VBOConfig.Double:
                    result.dataSize = 1;
                    result.dataType = OpenGL.GL_DOUBLE;
                    break;

                case VBOConfig.DVec2:
                    result.dataSize = 2;
                    result.dataType = OpenGL.GL_DOUBLE;
                    break;

                case VBOConfig.DVec3:
                    result.dataSize = 3;
                    result.dataType = OpenGL.GL_DOUBLE;
                    break;

                case VBOConfig.DVec4:
                    result.dataSize = 4;
                    result.dataType = OpenGL.GL_DOUBLE;
                    break;

                case VBOConfig.Mat2:
                    result.locationCount = 2;
                    result.dataSize = 2;
                    result.dataType = OpenGL.GL_FLOAT;
                    result.stride = Marshal.SizeOf(typeof(mat2));
                    result.startOffsetUnit = Marshal.SizeOf(typeof(vec2));
                    break;

                case VBOConfig.Mat3:
                    result.locationCount = 3;
                    result.dataSize = 3;
                    result.dataType = OpenGL.GL_FLOAT;
                    result.stride = Marshal.SizeOf(typeof(mat3));
                    result.startOffsetUnit = Marshal.SizeOf(typeof(vec3));
                    break;

                case VBOConfig.Mat4:
                    result.locationCount = 4;
                    result.dataSize = 4;
                    result.dataType = OpenGL.GL_FLOAT;
                    result.stride = Marshal.SizeOf(typeof(mat4));
                    result.startOffsetUnit = Marshal.SizeOf(typeof(vec4));
                    break;

                default:
                    throw new NotImplementedException();
            }

            return result;
        }
    }

    internal class VBOConfigDetail
    {
        public int locationCount = 1;
        public int dataSize;
        public uint dataType;
        public int stride;
        public int startOffsetUnit;
    }
}