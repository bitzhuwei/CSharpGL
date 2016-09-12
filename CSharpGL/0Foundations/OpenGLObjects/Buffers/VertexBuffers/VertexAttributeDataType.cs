using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public enum VertexAttributeDataType : uint
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
    public static class VertexAttributeDataTypeHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="locationCount"></param>
        /// <param name="dataSize"></param>
        /// <param name="dataType"></param>
        /// <param name="stride"></param>
        /// <param name="startOffsetUnit"></param>
        public static void Parse(this VertexAttributeDataType type, out int locationCount, out int dataSize, out uint dataType, out int stride, out int startOffsetUnit)
        {
            locationCount = 1;
            //dataSize = 0;
            //dataType = 0;
            stride = 0;
            startOffsetUnit = 0;
            switch (type)
            {
                case VertexAttributeDataType.Byte:
                    dataSize = 1;
                    dataType = OpenGL.GL_BYTE;
                    break;
                case VertexAttributeDataType.BVec2:
                    dataSize = 2;
                    dataType = OpenGL.GL_BYTE;
                    break;
                case VertexAttributeDataType.BVec3:
                    dataSize = 3;
                    dataType = OpenGL.GL_BYTE;
                    break;
                case VertexAttributeDataType.BVec4:
                    dataSize = 4;
                    dataType = OpenGL.GL_BYTE;
                    break;
                case VertexAttributeDataType.Int:
                    dataSize = 1;
                    dataType = OpenGL.GL_INT;
                    break;
                case VertexAttributeDataType.IVec2:
                    dataSize = 2;
                    dataType = OpenGL.GL_INT;
                    break;
                case VertexAttributeDataType.IVec3:
                    dataSize = 3;
                    dataType = OpenGL.GL_INT;
                    break;
                case VertexAttributeDataType.IVec4:
                    dataSize = 4;
                    dataType = OpenGL.GL_INT;
                    break;
                case VertexAttributeDataType.UInt:
                    dataSize = 1;
                    dataType = OpenGL.GL_UNSIGNED_INT;
                    break;
                case VertexAttributeDataType.UVec2:
                    dataSize = 2;
                    dataType = OpenGL.GL_UNSIGNED_INT;
                    break;
                case VertexAttributeDataType.UVec3:
                    dataSize = 3;
                    dataType = OpenGL.GL_UNSIGNED_INT;
                    break;
                case VertexAttributeDataType.UVec4:
                    dataSize = 4;
                    dataType = OpenGL.GL_UNSIGNED_INT;
                    break;
                case VertexAttributeDataType.Float:
                    dataSize = 1;
                    dataType = OpenGL.GL_FLOAT;
                    break;
                case VertexAttributeDataType.Vec2:
                    dataSize = 2;
                    dataType = OpenGL.GL_FLOAT;
                    break;
                case VertexAttributeDataType.Vec3:
                    dataSize = 3;
                    dataType = OpenGL.GL_FLOAT;
                    break;
                case VertexAttributeDataType.Vec4:
                    dataSize = 4;
                    dataType = OpenGL.GL_FLOAT;
                    break;
                case VertexAttributeDataType.Double:
                    dataSize = 1;
                    dataType = OpenGL.GL_DOUBLE;
                    break;
                case VertexAttributeDataType.DVec2:
                    dataSize = 2;
                    dataType = OpenGL.GL_DOUBLE;
                    break;
                case VertexAttributeDataType.DVec3:
                    dataSize = 3;
                    dataType = OpenGL.GL_DOUBLE;
                    break;
                case VertexAttributeDataType.DVec4:
                    dataSize = 4;
                    dataType = OpenGL.GL_DOUBLE;
                    break;
                case VertexAttributeDataType.Mat2:
                    locationCount = 2;
                    dataSize = 2;
                    dataType = OpenGL.GL_FLOAT;
                    stride = Marshal.SizeOf(typeof(mat2));
                    startOffsetUnit = Marshal.SizeOf(typeof(vec2));
                    break;
                case VertexAttributeDataType.Mat3:
                    locationCount = 3;
                    dataSize = 3;
                    dataType = OpenGL.GL_FLOAT;
                    stride = Marshal.SizeOf(typeof(mat3));
                    startOffsetUnit = Marshal.SizeOf(typeof(vec3));
                    break;
                case VertexAttributeDataType.Mat4:
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