using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.ColorCodedPicking
{
    static class PrimitiveModesHelper
    {
        /// <summary>
        /// Convert <see cref="BeginMode"/> to <see cref="GeometryTypes"/>.
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static GeometryTypes ToGeometryType(this PrimitiveModes mode)
        {
            GeometryTypes result = GeometryTypes.Point;
            switch (mode)
            {
                case PrimitiveModes.Points:
                    result = GeometryTypes.Point;
                    break;
                case PrimitiveModes.Lines:
                    result = GeometryTypes.Line;
                    break;
                case PrimitiveModes.LineLoop:
                    result = GeometryTypes.Line;
                    break;
                case PrimitiveModes.LineStrip:
                    result = GeometryTypes.Line;
                    break;
                case PrimitiveModes.Triangles:
                    result = GeometryTypes.Triangle;
                    break;
                case PrimitiveModes.TriangleStrip:
                    result = GeometryTypes.Triangle;
                    break;
                case PrimitiveModes.TriangleFan:
                    result = GeometryTypes.Triangle;
                    break;
                case PrimitiveModes.Quads:
                    result = GeometryTypes.Quad;
                    break;
                case PrimitiveModes.QuadStrip:
                    result = GeometryTypes.Quad;
                    break;
                case PrimitiveModes.Polygon:
                    result = GeometryTypes.Polygon;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }
    }
}
