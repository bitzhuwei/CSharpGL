using System;

namespace CSharpGL
{
    internal static partial class VBOConfigHelper
    {
        internal static VertexAttribPointerType GetVertexAttribPointerType(this VBOConfig config)
        {
            var result = VertexAttribPointerType.Default;

            switch (config)
            {
                case VBOConfig.Byte:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.BVec2:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.BVec3:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.BVec4:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.Int:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.IVec2:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.IVec3:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.IVec4:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.UInt:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.UVec2:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.UVec3:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.UVec4:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VBOConfig.Float:
                    break;

                case VBOConfig.Vec2:
                    break;

                case VBOConfig.Vec3:
                    break;

                case VBOConfig.Vec4:
                    break;

                case VBOConfig.Double:
                    result = VertexAttribPointerType.Long;
                    break;

                case VBOConfig.DVec2:
                    result = VertexAttribPointerType.Long;
                    break;

                case VBOConfig.DVec3:
                    result = VertexAttribPointerType.Long;
                    break;

                case VBOConfig.DVec4:
                    result = VertexAttribPointerType.Long;
                    break;

                case VBOConfig.Mat2:
                    break;

                case VBOConfig.Mat3:
                    break;

                case VBOConfig.Mat4:
                    break;

                default:
                    throw new NotImplementedException();
            }

            return result;
        }
    }
}