using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public static class DrawModeHelper
    {
        /// <summary>
        /// Convert <see cref="BeginMode"/> to <see cref="GeometryTypes"/>.
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static PrimitiveMode ToPrimitiveMode(this DrawMode mode)
        {
            PrimitiveMode result = PrimitiveMode.Points;
            switch (mode)
            {
                case DrawMode.Points:
                    result = PrimitiveMode.Points;
                    break;
                case DrawMode.LineStrip:
                    result = PrimitiveMode.LineStrip;
                    break;
                case DrawMode.LineLoop:
                    result = PrimitiveMode.LineLoop;
                    break;
                case DrawMode.Lines:
                    result = PrimitiveMode.Lines;
                    break;
                case DrawMode.LineStripAdjacency:
                    result = PrimitiveMode.LineStrip;
                    break;
                case DrawMode.LinesAdjacency:
                    result = PrimitiveMode.Lines;
                    break;
                case DrawMode.TriangleStrip:
                    result = PrimitiveMode.TriangleStrip;
                    break;
                case DrawMode.TriangleFan:
                    result = PrimitiveMode.TriangleFan;
                    break;
                case DrawMode.Triangles:
                    result = PrimitiveMode.Triangles;
                    break;
                case DrawMode.TriangleStripAdjacency:
                    result = PrimitiveMode.TriangleStrip;
                    break;
                case DrawMode.TrianglesAdjacency:
                    result = PrimitiveMode.Triangles;
                    break;
                case DrawMode.Patches:
                    result = PrimitiveMode.Points;//TODO: no idea what to do yet
                    break;
                case DrawMode.QuadStrip:
                    result = PrimitiveMode.QuadStrip;
                    break;
                case DrawMode.Quads:
                    result = PrimitiveMode.Quads;
                    break;
                case DrawMode.Polygon:
                    result = PrimitiveMode.Polygon;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
