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
        static Dictionary<DrawMode, OneIndexLineSearcher> lineSearcherDict;
        static Dictionary<DrawMode, OneIndexPointSearcher> pointSearcherDict;

        static OneIndexLineSearcher GetLineSearcher(DrawMode mode)
        {
            if (lineSearcherDict == null)
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

                lineSearcherDict = dict;
            }

            OneIndexLineSearcher result = null;
            if (lineSearcherDict.TryGetValue(mode, out result))
            { return result; }
            else
            { return null; }
        }

        static OneIndexPointSearcher GetPointSearcher(DrawMode mode)
        {
            if (pointSearcherDict == null)
            {
                var triangle = new OneIndexPointInTriangleSearcher();
                var quad = new OneIndexPointInQuadSearcher();
                var polygon = new OneIndexPointInPolygonSearcher();
                var dict = new Dictionary<DrawMode, OneIndexPointSearcher>();
                dict.Add(DrawMode.Triangles, triangle);
                dict.Add(DrawMode.TrianglesAdjacency, triangle);
                dict.Add(DrawMode.TriangleStrip, triangle);
                dict.Add(DrawMode.TriangleStripAdjacency, triangle);
                dict.Add(DrawMode.TriangleFan, triangle);
                dict.Add(DrawMode.Quads, quad);
                dict.Add(DrawMode.QuadStrip, quad);
                dict.Add(DrawMode.Polygon, polygon);

                pointSearcherDict = dict;
            }

            OneIndexPointSearcher result = null;
            if (pointSearcherDict.TryGetValue(mode, out result))
            { return result; }
            else
            { return null; }
        }
    }
}
