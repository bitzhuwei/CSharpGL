using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    partial class ZeroIndexRenderer
    {
        static Dictionary<DrawMode, ZeroIndexLineSearcher> lineSearcherDict;
        static Dictionary<DrawMode, ZeroIndexPointSearcher> pointSearcherDict;

        static ZeroIndexLineSearcher GetLineSearcher(DrawMode mode)
        {
            if (lineSearcherDict == null)
            {
                var dict = new Dictionary<DrawMode, ZeroIndexLineSearcher>();
                dict.Add(DrawMode.Triangles, new ZeroIndexLineInTriangleSearcher());
                dict.Add(DrawMode.TrianglesAdjacency, new ZeroIndexLineInTrianglesAdjacencySearcher());
                dict.Add(DrawMode.TriangleStrip, new ZeroIndexLineInTriangleStripSearcher());
                dict.Add(DrawMode.TriangleStripAdjacency, new ZeroIndexLineInTriangleStripAdjacencySearcher());
                dict.Add(DrawMode.TriangleFan, new ZeroIndexLineInTriangleFanSearcher());
                dict.Add(DrawMode.Quads, new ZeroIndexLineInQuadSearcher());
                dict.Add(DrawMode.QuadStrip, new ZeroIndexLineInQuadStripSearcher());
                dict.Add(DrawMode.Polygon, new ZeroIndexLineInPolygonSearcher());

                lineSearcherDict = dict;
            }

            ZeroIndexLineSearcher result = null;
            if (lineSearcherDict.TryGetValue(mode, out result))
            { return result; }
            else
            { return null; }
        }

        static ZeroIndexPointSearcher GetPointSearcher(DrawMode mode)
        {
            if (pointSearcherDict == null)
            {
                var dict = new Dictionary<DrawMode, ZeroIndexPointSearcher>();
                dict.Add(DrawMode.Triangles, new ZeroIndexPointInTriangleSearcher());
                dict.Add(DrawMode.TrianglesAdjacency, new ZeroIndexPointInTrianglesAdjacencySearcher());
                dict.Add(DrawMode.TriangleStrip, new ZeroIndexPointInTriangleStripSearcher());
                dict.Add(DrawMode.TriangleStripAdjacency, new ZeroIndexPointInTriangleStripAdjacencySearcher());
                dict.Add(DrawMode.TriangleFan, new ZeroIndexPointInTriangleFanSearcher());
                dict.Add(DrawMode.Quads, new ZeroIndexPointInQuadSearcher());
                dict.Add(DrawMode.QuadStrip, new ZeroIndexPointInQuadStripSearcher());
                dict.Add(DrawMode.Polygon, new ZeroIndexPointInPolygonSearcher());

                pointSearcherDict = dict;
            }

            ZeroIndexPointSearcher result = null;
            if (pointSearcherDict.TryGetValue(mode, out result))
            { return result; }
            else
            { return null; }
        }
    }
}
