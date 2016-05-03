using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class OneIndexRenderer
    {
        static Dictionary<DrawMode, OneIndexLineSearcher> lineSearchDict;

        static OneIndexLineSearcher GetLineSearcher(DrawMode mode)
        {
            if (lineSearchDict == null)
            {
                var dict = new Dictionary<DrawMode, OneIndexLineSearcher>();
                dict.Add(DrawMode.Triangles, new OneIndexLineInTrianglesSearcher());
                //dict.Add(DrawMode.TrianglesAdjacency, new ZeroIndexLineInTrianglesAdjacencySearcher());
                //dict.Add(DrawMode.TriangleStrip, new ZeroIndexLineInTriangleStripSearcher());
                //dict.Add(DrawMode.TriangleStripAdjacency, new ZeroIndexLineInTriangleStripAdjacencySearcher());
                //dict.Add(DrawMode.TriangleFan, new ZeroIndexLineInTriangleFanSearcher());
                //dict.Add(DrawMode.Quads, new ZeroIndexLineInQuadSearcher());
                //dict.Add(DrawMode.QuadStrip, new ZeroIndexLineInQuadStripSearcher());
                //dict.Add(DrawMode.Polygon, new ZeroIndexLineInPolygonSearcher());

                lineSearchDict = dict;
            }

            OneIndexLineSearcher result = null;
            if (lineSearchDict.TryGetValue(mode, out result))
            { return result; }
            else
            { return null; }
        }
    }
}
