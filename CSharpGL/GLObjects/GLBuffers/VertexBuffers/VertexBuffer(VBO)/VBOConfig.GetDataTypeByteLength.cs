using System;
namespace CSharpGL
{
    internal static partial class VBOConfigHelper
    {
        internal static int GetDataTypeByteLength(this VBOConfig config)
        {
            int result = 0;

            switch (config)
            {
                case VBOConfig.Byte:
                    result = sizeof(byte);
                    break;

                case VBOConfig.BVec2:
                    result = sizeof(byte);
                    break;

                case VBOConfig.BVec3:
                    result = sizeof(byte);
                    break;

                case VBOConfig.BVec4:
                    result = sizeof(byte);
                    break;

                case VBOConfig.Int:
                    result = sizeof(int);
                    break;

                case VBOConfig.IVec2:
                    result = sizeof(int);
                    break;

                case VBOConfig.IVec3:
                    result = sizeof(int);
                    break;

                case VBOConfig.IVec4:
                    result = sizeof(int);
                    break;

                case VBOConfig.UInt:
                    result = sizeof(uint);
                    break;

                case VBOConfig.UVec2:
                    result = sizeof(uint);
                    break;

                case VBOConfig.UVec3:
                    result = sizeof(uint);
                    break;

                case VBOConfig.UVec4:
                    result = sizeof(uint);
                    break;

                case VBOConfig.Float:
                    result = sizeof(float);
                    break;

                case VBOConfig.Vec2:
                    result = sizeof(float);
                    break;

                case VBOConfig.Vec3:
                    result = sizeof(float);
                    break;

                case VBOConfig.Vec4:
                    result = sizeof(float);
                    break;

                case VBOConfig.Double:
                    result = sizeof(double);
                    break;

                case VBOConfig.DVec2:
                    result = sizeof(double);
                    break;

                case VBOConfig.DVec3:
                    result = sizeof(double);
                    break;

                case VBOConfig.DVec4:
                    result = sizeof(double);
                    break;

                case VBOConfig.Mat2:
                    result = sizeof(float);
                    break;

                case VBOConfig.Mat3:
                    result = sizeof(float);
                    break;

                case VBOConfig.Mat4:
                    result = sizeof(float);
                    break;

                default:
                    throw new NotDealWithNewEnumItemException(typeof(VBOConfig));
            }

            return result;
        }
    }
}