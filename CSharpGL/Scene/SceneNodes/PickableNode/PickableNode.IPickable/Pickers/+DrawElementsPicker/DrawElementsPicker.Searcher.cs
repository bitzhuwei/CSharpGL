using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    partial class DrawElementsPicker
    {
        private static readonly DrawElementsLineSearcher lineInTriangle = new DrawElementsLineInTriangleSearcher();
        private static readonly DrawElementsLineSearcher lineInQuad = new DrawElementsLineInQuadSearcher();
        private static readonly DrawElementsLineSearcher lineInPolygon = new DrawElementsLineInPolygonSearcher();

        private static DrawElementsLineSearcher GetLineSearcher(DrawMode mode)
        {
            DrawElementsLineSearcher result = null;
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
                    throw new NotDealWithNewEnumItemException(typeof(DrawMode));
            }

            return result;
        }

        private static readonly DrawElementsPointSearcher pointInLine = new DrawElementsPointInLineSearcher();
        private static readonly DrawElementsPointSearcher pointInTriangle = new DrawElementsPointInTriangleSearcher();
        private static readonly DrawElementsPointSearcher pointInQuad = new DrawElementsPointInQuadSearcher();
        private static readonly DrawElementsPointSearcher pointInPolygon = new DrawElementsPointInPolygonSearcher();

        private static DrawElementsPointSearcher GetPointSearcher(DrawMode mode)
        {
            DrawElementsPointSearcher result = null;
            switch (mode)
            {
                case DrawMode.Points:
                    break;
                case DrawMode.Lines:
                    result = pointInLine;
                    break;
                case DrawMode.LineLoop:
                    result = pointInLine;
                    break;
                case DrawMode.LineStrip:
                    result = pointInLine;
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
                    result = pointInLine;
                    break;
                case DrawMode.LineStripAdjacency:
                    result = pointInLine;
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
                    throw new NotDealWithNewEnumItemException(typeof(DrawMode));
            }

            return result;
        }
    }
}
