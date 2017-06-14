using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    partial class OneIndexPicker
    {
        private static readonly OneIndexLineSearcher lineInTriangle = new OneIndexLineInTriangleSearcher();
        private static readonly OneIndexLineSearcher lineInQuad = new OneIndexLineInQuadSearcher();
        private static readonly OneIndexLineSearcher lineInPolygon = new OneIndexLineInPolygonSearcher();

        private static OneIndexLineSearcher GetLineSearcher(DrawMode mode)
        {
            OneIndexLineSearcher result = null;
            switch (mode)
            {
                case DrawMode.Points:
                    break;
                case DrawMode.Lines:
                    break;
                case DrawMode.LineLoop:
                    break;
                case DrawMode.LineStrip:
                    break;
                case DrawMode.Triangles:
                    result = lineInTriangle;
                    break;
                case DrawMode.TriangleStrip:
                    result = lineInTriangle;
                    break;
                case DrawMode.TriangleFan:
                    result = lineInTriangle;
                    break;
                case DrawMode.Quads:
                    result = lineInQuad;
                    break;
                case DrawMode.QuadStrip:
                    result = lineInQuad;
                    break;
                case DrawMode.Polygon:
                    result = lineInPolygon;
                    break;
                case DrawMode.LinesAdjacency:
                    break;
                case DrawMode.LineStripAdjacency:
                    break;
                case DrawMode.TrianglesAdjacency:
                    result = lineInTriangle;
                    break;
                case DrawMode.TriangleStripAdjacency:
                    result = lineInTriangle;
                    break;
                case DrawMode.Patches:
                    break;
                default:
                    break;
            }

            return result;
        }

        private static readonly OneIndexPointSearcher pointInTriangle = new OneIndexPointInTriangleSearcher();
        private static readonly OneIndexPointSearcher pointInQuad = new OneIndexPointInQuadSearcher();
        private static readonly OneIndexPointSearcher pointInPolygon = new OneIndexPointInPolygonSearcher();

        private static OneIndexPointSearcher GetPointSearcher(DrawMode mode)
        {
            OneIndexPointSearcher result = null;
            switch (mode)
            {
                case DrawMode.Points:
                    break;
                case DrawMode.Lines:
                    break;
                case DrawMode.LineLoop:
                    break;
                case DrawMode.LineStrip:
                    break;
                case DrawMode.Triangles:
                    result = pointInTriangle;
                    break;
                case DrawMode.TriangleStrip:
                    result = pointInTriangle;
                    break;
                case DrawMode.TriangleFan:
                    result = pointInTriangle;
                    break;
                case DrawMode.Quads:
                    result = pointInQuad;
                    break;
                case DrawMode.QuadStrip:
                    result = pointInQuad;
                    break;
                case DrawMode.Polygon:
                    result = pointInPolygon;
                    break;
                case DrawMode.LinesAdjacency:
                    break;
                case DrawMode.LineStripAdjacency:
                    break;
                case DrawMode.TrianglesAdjacency:
                    result = pointInTriangle;
                    break;
                case DrawMode.TriangleStripAdjacency:
                    result = pointInTriangle;
                    break;
                case DrawMode.Patches:
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
