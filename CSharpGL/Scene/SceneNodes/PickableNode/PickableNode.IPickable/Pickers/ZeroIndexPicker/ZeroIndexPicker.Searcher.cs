using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    partial class ZeroIndexPicker
    {
        private static readonly ZeroIndexLineSearcher lineInTriangles = new ZeroIndexLineInTriangleSearcher();
        private static readonly ZeroIndexLineSearcher lineInTrianglesAdjacency = new ZeroIndexLineInTrianglesAdjacencySearcher();
        private static readonly ZeroIndexLineSearcher lineInTriangleStrip = new ZeroIndexLineInTriangleStripSearcher();
        private static readonly ZeroIndexLineSearcher lineInTriangleStripAdjacency = new ZeroIndexLineInTriangleStripAdjacencySearcher();
        private static readonly ZeroIndexLineSearcher lineInTriangleFan = new ZeroIndexLineInTriangleFanSearcher();
        private static readonly ZeroIndexLineSearcher lineInQuads = new ZeroIndexLineInQuadSearcher();
        private static readonly ZeroIndexLineSearcher lineInQuadStrip = new ZeroIndexLineInQuadStripSearcher();
        private static readonly ZeroIndexLineSearcher lineInPolygon = new ZeroIndexLineInPolygonSearcher();

        private static ZeroIndexLineSearcher GetLineSearcher(DrawMode mode)
        {
            ZeroIndexLineSearcher result = null;
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

        private static readonly ZeroIndexPointSearcher pointInTriangles = new ZeroIndexPointInTriangleSearcher();
        private static readonly ZeroIndexPointSearcher pointInTrianglesAdjacency = new ZeroIndexPointInTrianglesAdjacencySearcher();
        private static readonly ZeroIndexPointSearcher pointInTriangleStrip = new ZeroIndexPointInTriangleStripSearcher();
        private static readonly ZeroIndexPointSearcher pointInTriangleStripAdjacency = new ZeroIndexPointInTriangleStripAdjacencySearcher();
        private static readonly ZeroIndexPointSearcher pointInTriangleFan = new ZeroIndexPointInTriangleFanSearcher();
        private static readonly ZeroIndexPointSearcher pointInQuads = new ZeroIndexPointInQuadSearcher();
        private static readonly ZeroIndexPointSearcher pointInQuadStrip = new ZeroIndexPointInQuadStripSearcher();
        private static readonly ZeroIndexPointSearcher pointInPolygon = new ZeroIndexPointInPolygonSearcher();

        private static ZeroIndexPointSearcher GetPointSearcher(DrawMode mode)
        {
            ZeroIndexPointSearcher result = null;
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
