using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    static class PrimitiveModesHelper
    {
        /// <summary>
        /// Convert <see cref="BeginMode"/> to <see cref="GeometryTypes"/>.
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static GeometryTypes ToGeometryType(this PrimitiveMode mode)
        {
            GeometryTypes result = GeometryTypes.Point;
            switch (mode)
            {
                case PrimitiveMode.Points:
                    result = GeometryTypes.Point;
                    break;
                case PrimitiveMode.Lines:
                    result = GeometryTypes.Line;
                    break;
                case PrimitiveMode.LineLoop:
                    result = GeometryTypes.Line;
                    break;
                case PrimitiveMode.LineStrip:
                    result = GeometryTypes.Line;
                    break;
                case PrimitiveMode.Triangles:
                    result = GeometryTypes.Triangle;
                    break;
                case PrimitiveMode.TriangleStrip:
                    result = GeometryTypes.Triangle;
                    break;
                case PrimitiveMode.TriangleFan:
                    result = GeometryTypes.Triangle;
                    break;
                case PrimitiveMode.Quads:
                    result = GeometryTypes.Quad;
                    break;
                case PrimitiveMode.QuadStrip:
                    result = GeometryTypes.Quad;
                    break;
                case PrimitiveMode.Polygon:
                    result = GeometryTypes.Polygon;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }
    }
}
