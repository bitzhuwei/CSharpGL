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
                    break;
                case DrawMode.LineStrip:
                    break;
                case DrawMode.LineLoop:
                    break;
                case DrawMode.Lines:
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
                    break;
                case DrawMode.Quads:
                    break;
                case DrawMode.Polygon:
                    break;
                default:
                    break;
            }

            return recognizer;
        }
    }
}
