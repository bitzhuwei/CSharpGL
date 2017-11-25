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
                    result.dataType = GL.GL_BYTE;
                    result.pointerType = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.BVec2:
                    result.dataSize = 2;
                    result.dataType = GL.GL_BYTE;
                    result.pointerType = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.BVec3:
                    result.dataSize = 3;
                    result.dataType = GL.GL_BYTE;
                    result.pointerType = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.BVec4:
                    result.dataSize = 4;
                    result.dataType = GL.GL_BYTE;
                    result.pointerType = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.Int:
                    result.dataSize = 1;
                    result.dataType = GL.GL_INT;
                    result.pointerType = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.IVec2:
                    result.dataSize = 2;
                    result.dataType = GL.GL_INT;
                    result.pointerType = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.IVec3:
                    result.dataSize = 3;
                    result.dataType = GL.GL_INT;
                    result.pointerType = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.IVec4:
                    result.dataSize = 4;
                    result.dataType = GL.GL_INT;
                    result.pointerType = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.UInt:
                    result.dataSize = 1;
                    result.dataType = GL.GL_UNSIGNED_INT;
                    result.pointerType = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.UVec2:
                    result.dataSize = 2;
                    result.dataType = GL.GL_UNSIGNED_INT;
                    result.pointerType = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.UVec3:
                    result.dataSize = 3;
                    result.dataType = GL.GL_UNSIGNED_INT;
                    result.pointerType = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.UVec4:
                    result.dataSize = 4;
                    result.dataType = GL.GL_UNSIGNED_INT;
                    result.pointerType = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.Float:
                    result.dataSize = 1;
                    result.dataType = GL.GL_FLOAT;
                    result.pointerType = VertexAttribPointerType.Default;
                    break;

                case VBOConfig.Vec2:
                    result.dataSize = 2;
                    result.dataType = GL.GL_FLOAT;
                    result.pointerType = VertexAttribPointerType.Default;
                    break;

                case VBOConfig.Vec3:
                    result.dataSize = 3;
                    result.dataType = GL.GL_FLOAT;
                    result.pointerType = VertexAttribPointerType.Default;
                    break;

                case VBOConfig.Vec4:
                    result.dataSize = 4;
                    result.dataType = GL.GL_FLOAT;
                    result.pointerType = VertexAttribPointerType.Default;
                    break;

                case VBOConfig.Double:
                    result.dataSize = 1;
                    result.dataType = GL.GL_DOUBLE;
                    result.pointerType = VertexAttribPointerType.Long;
                    break;

                case VBOConfig.DVec2:
                    result.dataSize = 2;
                    result.dataType = GL.GL_DOUBLE;
                    result.pointerType = VertexAttribPointerType.Long;
                    break;

                case VBOConfig.DVec3:
                    result.dataSize = 3;
                    result.dataType = GL.GL_DOUBLE;
                    result.pointerType = VertexAttribPointerType.Long;
                    break;

                case VBOConfig.DVec4:
                    result.dataSize = 4;
                    result.dataType = GL.GL_DOUBLE;
                    result.pointerType = VertexAttribPointerType.Long;
                    break;

                case VBOConfig.Mat2:
                    result.locationCount = 2;
                    result.dataSize = 2;
                    result.dataType = GL.GL_FLOAT;
                    result.stride = Marshal.SizeOf(typeof(mat2));
                    result.startOffsetUnit = Marshal.SizeOf(typeof(vec2));
                    result.pointerType = VertexAttribPointerType.Default;
                    break;

                case VBOConfig.Mat3:
                    result.locationCount = 3;
                    result.dataSize = 3;
                    result.dataType = GL.GL_FLOAT;
                    result.stride = Marshal.SizeOf(typeof(mat3));
                    result.startOffsetUnit = Marshal.SizeOf(typeof(vec3));
                    result.pointerType = VertexAttribPointerType.Default;
                    break;

                case VBOConfig.Mat4:
                    result.locationCount = 4;
                    result.dataSize = 4;
                    result.dataType = GL.GL_FLOAT;
                    result.stride = Marshal.SizeOf(typeof(mat4));
                    result.startOffsetUnit = Marshal.SizeOf(typeof(vec4));
                    result.pointerType = VertexAttribPointerType.Default;
                    break;

                default:
                    throw new NotDealWithNewEnumItemException(typeof(VBOConfig));
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
        public VertexAttribPointerType pointerType;
    }
}