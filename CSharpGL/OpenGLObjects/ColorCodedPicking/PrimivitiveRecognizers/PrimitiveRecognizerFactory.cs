using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    static class PrimitiveRecognizerFactory
    {
        public static PrimitiveRecognizer Create(DrawMode mode)
        {
            PrimitiveRecognizer recognizer = null;

            switch (mode)
            {
                case DrawMode.Points:
                    recognizer = new PointsRecognizer();
                    break;
                case DrawMode.LineStrip:
                    recognizer = new LineStripRecognizer();
                    break;
                case DrawMode.LineLoop:
                    recognizer = new LineLoopRecognizer();
                    break;
                case DrawMode.Lines:
                    recognizer = new LinesRecognizer();
                    break;
                case DrawMode.LineStripAdjacency:
                    break;
                case DrawMode.LinesAdjacency:
                    break;
                case DrawMode.TriangleStrip:
                    recognizer = new TriangleStripRecognizer();
                    break;
                case DrawMode.TriangleFan:
                    break;
                case DrawMode.Triangles:
                    recognizer = new TrianglesRecognizer();
                    break;
                case DrawMode.TriangleStripAdjacency:
                    break;
                case DrawMode.TrianglesAdjacency:
                    break;
                case DrawMode.Patches:
                    break;
                case DrawMode.QuadStrip:
                    recognizer = new QuadStripRecognizer();
                    break;
                case DrawMode.Quads:
                    recognizer = new QuadsRecognizer();
                    break;
                case DrawMode.Polygon:
                    break;
                default:
                    break;
            }

            if (recognizer == null)
            { throw new NotImplementedException(); }

            return recognizer;
        }
    }
}
