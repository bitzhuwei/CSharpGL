using System;

namespace CSharpGL
{
    internal static partial class VertexAttributeConfigHelper
    {
        internal static VertexAttribPointerType GetVertexAttribPointerType(this VertexAttributeConfig config)
        {
            var result = VertexAttribPointerType.Default;

            switch (config)
            {
                case VertexAttributeConfig.Byte:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VertexAttributeConfig.BVec2:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VertexAttributeConfig.BVec3:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VertexAttributeConfig.BVec4:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VertexAttributeConfig.Int:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VertexAttributeConfig.IVec2:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VertexAttributeConfig.IVec3:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VertexAttributeConfig.IVec4:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VertexAttributeConfig.UInt:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VertexAttributeConfig.UVec2:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VertexAttributeConfig.UVec3:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VertexAttributeConfig.UVec4:
                    result = VertexAttribPointerType.Integer;
                    break;

                case VertexAttributeConfig.Float:
                    break;

                case VertexAttributeConfig.Vec2:
                    break;

                case VertexAttributeConfig.Vec3:
                    break;

                case VertexAttributeConfig.Vec4:
                    break;

                case VertexAttributeConfig.Double:
                    result = VertexAttribPointerType.Long;
                    break;

                case VertexAttributeConfig.DVec2:
                    result = VertexAttribPointerType.Long;
                    break;

                case VertexAttributeConfig.DVec3:
                    result = VertexAttribPointerType.Long;
                    break;

                case VertexAttributeConfig.DVec4:
                    result = VertexAttribPointerType.Long;
                    break;

                case VertexAttributeConfig.Mat2:
                    break;

                case VertexAttributeConfig.Mat3:
                    break;

                case VertexAttributeConfig.Mat4:
                    break;

                default:
                    throw new NotImplementedException();
            }

            return result;
        }
    }
}