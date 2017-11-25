using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    internal static partial class VBOConfigHelper
    {
        /// <summary>
        /// Gets parameter values for glVertexAttribPointer() and glEnable/DisableVertexAttribArray().
        /// <para>second parameter in glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);</para>
        /// <para>How many primitive data type(float/int/uint etc) are there in a data unit?</para>
        /// </summary>
        /// <param name="config"></param>
        internal static int GetDataSize(this VBOConfig config)
        {
            int dataSize = 0;
            switch (config)
            {
                case VBOConfig.Byte:
                    dataSize = 1;
                    break;

                case VBOConfig.BVec2:
                    dataSize = 2;
                    break;

                case VBOConfig.BVec3:
                    dataSize = 3;
                    break;

                case VBOConfig.BVec4:
                    dataSize = 4;
                    break;

                case VBOConfig.Int:
                    dataSize = 1;
                    break;

                case VBOConfig.IVec2:
                    dataSize = 2;
                    break;

                case VBOConfig.IVec3:
                    dataSize = 3;
                    break;

                case VBOConfig.IVec4:
                    dataSize = 4;
                    break;

                case VBOConfig.UInt:
                    dataSize = 1;
                    break;

                case VBOConfig.UVec2:
                    dataSize = 2;
                    break;

                case VBOConfig.UVec3:
                    dataSize = 3;
                    break;

                case VBOConfig.UVec4:
                    dataSize = 4;
                    break;

                case VBOConfig.Float:
                    dataSize = 1;
                    break;

                case VBOConfig.Vec2:
                    dataSize = 2;
                    break;

                case VBOConfig.Vec3:
                    dataSize = 3;
                    break;

                case VBOConfig.Vec4:
                    dataSize = 4;
                    break;

                case VBOConfig.Double:
                    dataSize = 1;
                    break;

                case VBOConfig.DVec2:
                    dataSize = 2;
                    break;

                case VBOConfig.DVec3:
                    dataSize = 3;
                    break;

                case VBOConfig.DVec4:
                    dataSize = 4;
                    break;

                case VBOConfig.Mat2:
                    dataSize = 2;
                    break;

                case VBOConfig.Mat3:
                    dataSize = 3;
                    break;

                case VBOConfig.Mat4:
                    dataSize = 4;
                    break;

                default:
                    throw new NotDealWithNewEnumItemException(typeof(VBOConfig));
            }

            return dataSize;
        }
    }
}