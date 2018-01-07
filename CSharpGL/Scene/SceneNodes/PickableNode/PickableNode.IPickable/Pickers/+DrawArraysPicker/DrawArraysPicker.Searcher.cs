using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    partial class DrawArraysPicker
    {
        private static readonly DrawArraysLineSearcher lineInTriangles = new DrawArraysLineInTriangleSearcher();
        private static readonly DrawArraysLineSearcher lineInTrianglesAdjacency = new DrawArraysLineInTrianglesAdjacencySearcher();
        private static readonly DrawArraysLineSearcher lineInTriangleStrip = new DrawArraysLineInTriangleStripSearcher();
        private static readonly DrawArraysLineSearcher lineInTriangleStripAdjacency = new DrawArraysLineInTriangleStripAdjacencySearcher();
        private static readonly DrawArraysLineSearcher lineInTriangleFan = new DrawArraysLineInTriangleFanSearcher();
        private static readonly DrawArraysLineSearcher lineInQuads = new DrawArraysLineInQuadSearcher();
        private static readonly DrawArraysLineSearcher lineInQuadStrip = new DrawArraysLineInQuadStripSearcher();
        private static readonly DrawArraysLineSearcher lineInPolygon = new DrawArraysLineInPolygonSearcher();

        private static DrawArraysLineSearcher GetLineSearcher(DrawMode mode)
        {
            DrawArraysLineSearcher result = null;
            switch (mode)
            {
                case DrawMode.Points:
                    result = null;
                    break;
                case DrawMode.Lines:
                    result = null;
                    break;
                case DrawMode.LineLoop:
                    result = null;
                    break;
                case DrawMode.LineStrip:
                    result = null;
                    break;
                case DrawMode.Triangles:
                    result = lineInTriangles;
                    break;
                case DrawMode.TriangleStrip:
                    result = lineInTriangleStrip;
                    break;
                case DrawMode.TriangleFan:
                    result = lineInTriangleFan;
                    break;
                case DrawMode.Quads:
                    result = lineInQuads;
                    break;
                case DrawMode.QuadStrip:
                    result = lineInQuadStrip;
                    break;
                case DrawMode.Polygon:
                    result = lineInPolygon;
                    break;
                case DrawMode.LinesAdjacency:
                    result = null;
                    break;
                case DrawMode.LineStripAdjacency:
                    result = null;
                    break;
                case DrawMode.TrianglesAdjacency:
                    result = lineInTrianglesAdjacency;
                    break;
                case DrawMode.TriangleStripAdjacency:
                    result = lineInTriangleStripAdjacency;
                    break;
                case DrawMode.Patches:
                    result = null;
                    break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(DrawMode));
            }

            return result;
        }

        private static readonly DrawArraysPointSearcher pointInTriangles = new DrawArraysPointInTriangleSearcher();
        private static readonly DrawArraysPointSearcher pointInTrianglesAdjacency = new DrawArraysPointInTrianglesAdjacencySearcher();
        private static readonly DrawArraysPointSearcher pointInTriangleStrip = new DrawArraysPointInTriangleStripSearcher();
        private static readonly DrawArraysPointSearcher pointInTriangleStripAdjacency = new DrawArraysPointInTriangleStripAdjacencySearcher();
        private static readonly DrawArraysPointSearcher pointInTriangleFan = new DrawArraysPointInTriangleFanSearcher();
        private static readonly DrawArraysPointSearcher pointInQuads = new DrawArraysPointInQuadSearcher();
        private static readonly DrawArraysPointSearcher pointInQuadStrip = new DrawArraysPointInQuadStripSearcher();
        private static readonly DrawArraysPointSearcher pointInPolygon = new DrawArraysPointInPolygonSearcher();

        private static DrawArraysPointSearcher GetPointSearcher(DrawMode mode)
        {
            DrawArraysPointSearcher result = null;
            switch (mode)
            {
                case DrawMode.Points:
                    result = null;
                    break;
                case DrawMode.Lines:
                    result = null;
                    break;
                case DrawMode.LineLoop:
                    result = null;
                    break;
                case DrawMode.LineStrip:
                    result = null;
                    break;
                case DrawMode.Triangles:
                    result = pointInTriangles;
                    break;
                case DrawMode.TriangleStrip:
                    result = pointInTriangleStrip;
                    break;
                case DrawMode.TriangleFan:
                    result = pointInTriangleFan;
                    break;
                case DrawMode.Quads:
                    result = pointInQuads;
                    break;
                case DrawMode.QuadStrip:
                    result = pointInQuadStrip;
                    break;
                case DrawMode.Polygon:
                    result = pointInPolygon;
                    break;
                case DrawMode.LinesAdjacency:
                    result = null;
                    break;
                case DrawMode.LineStripAdjacency:
                    result = null;
                    break;
                case DrawMode.TrianglesAdjacency:
                    result = pointInTrianglesAdjacency;
                    break;
                case DrawMode.TriangleStripAdjacency:
                    result = pointInTriangleStripAdjacency;
                    break;
                case DrawMode.Patches:
                    result = null;
                    break;
                default:
                    throw new NotDealWithNewEnumItemException(typeof(DrawMode));
            }

            return result;
        }
    }
}
