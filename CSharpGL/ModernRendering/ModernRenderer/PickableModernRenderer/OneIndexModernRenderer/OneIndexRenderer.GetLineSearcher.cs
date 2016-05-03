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
                var triangle = new OneIndexLineInTriangleSearcher();
                var quad = new OneIndexLineInQuadSearcher();
                var polygon = new OneIndexLineInPolygonSearcher();
                var dict = new Dictionary<DrawMode, OneIndexLineSearcher>();
                dict.Add(DrawMode.Triangles, triangle);
                dict.Add(DrawMode.TrianglesAdjacency, triangle);
                dict.Add(DrawMode.TriangleStrip, triangle);
                dict.Add(DrawMode.TriangleStripAdjacency, triangle);
                dict.Add(DrawMode.TriangleFan, triangle);
                dict.Add(DrawMode.Quads, quad);
                dict.Add(DrawMode.QuadStrip, quad);
                dict.Add(DrawMode.Polygon, polygon);

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
