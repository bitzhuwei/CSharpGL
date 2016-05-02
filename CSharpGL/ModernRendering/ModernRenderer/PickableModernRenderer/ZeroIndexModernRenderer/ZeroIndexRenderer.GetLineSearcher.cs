using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class ZeroIndexRenderer
    {
        static Dictionary<DrawMode, ZeroIndexLineSearcher> lineSearchDict;

        static ZeroIndexLineSearcher GetLineSearcher(DrawMode mode)
        {
            if (lineSearchDict == null)
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

                lineSearchDict = dict;
            }

            ZeroIndexLineSearcher result = null;
            if (lineSearchDict.TryGetValue(mode, out result))
            { return result; }
            else
            { return null; }
        }
    }
}
