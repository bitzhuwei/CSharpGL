using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    internal static partial class VertexAttributeConfigHelper
    {
        internal static int GetDataTypeByteLength(this VertexAttributeConfig config)
        {
            int result = 0;

            switch (config)
            {
                case VertexAttributeConfig.Byte:
                    result = sizeof(byte);
                    break;

                case VertexAttributeConfig.BVec2:
                    result = sizeof(byte);
                    break;

                case VertexAttributeConfig.BVec3:
                    result = sizeof(byte);
                    break;

                case VertexAttributeConfig.BVec4:
                    result = sizeof(byte);
                    break;

                case VertexAttributeConfig.Int:
                    result = sizeof(int);
                    break;

                case VertexAttributeConfig.IVec2:
                    result = sizeof(int);
                    break;

                case VertexAttributeConfig.IVec3:
                    result = sizeof(int);
                    break;

                case VertexAttributeConfig.IVec4:
                    result = sizeof(int);
                    break;

                case VertexAttributeConfig.UInt:
                    result = sizeof(uint);
                    break;

                case VertexAttributeConfig.UVec2:
                    result = sizeof(uint);
                    break;

                case VertexAttributeConfig.UVec3:
                    result = sizeof(uint);
                    break;

                case VertexAttributeConfig.UVec4:
                    result = sizeof(uint);
                    break;

                case VertexAttributeConfig.Float:
                    result = sizeof(float);
                    break;

                case VertexAttributeConfig.Vec2:
                    result = sizeof(float);
                    break;

                case VertexAttributeConfig.Vec3:
                    result = sizeof(float);
                    break;

                case VertexAttributeConfig.Vec4:
                    result = sizeof(float);
                    break;

                case VertexAttributeConfig.Double:
                    result = sizeof(double);
                    break;

                case VertexAttributeConfig.DVec2:
                    result = sizeof(double);
                    break;

                case VertexAttributeConfig.DVec3:
                    result = sizeof(double);
                    break;

                case VertexAttributeConfig.DVec4:
                    result = sizeof(double);
                    break;

                case VertexAttributeConfig.Mat2:
                    result = sizeof(float);
                    break;

                case VertexAttributeConfig.Mat3:
                    result = sizeof(float);
                    break;

                case VertexAttributeConfig.Mat4:
                    result = sizeof(float);
                    break;

                default:
                    throw new System.NotImplementedException();
            }

            return result;
        }
    }
}