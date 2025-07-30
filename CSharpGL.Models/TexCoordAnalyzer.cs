using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public unsafe class TexCoordAnalyzer {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="texCoords">texture coordinates.</param>
        /// <param name="indices">indices of triangles.</param>
        /// <param name="length">length of returned bitmap file.</param>
        /// <returns></returns>
        public static Bitmap DumpLines(vec2[] texCoords, uint[] indices, int length) {
            if (length < 1) { throw new ArgumentOutOfRangeException(); }

            var bmp = new Bitmap(length, length);
            var pens = new Pen[] { new Pen(Color.Red), new Pen(Color.Green), new Pen(Color.Blue) };
            int penIndex = 0;
            using (var graphics = Graphics.FromImage(bmp)) {
                for (int i = 0; i < indices.Length; i += 3) {
                    var uv1 = texCoords[indices[i + 0]];
                    var uv2 = texCoords[indices[i + 1]];
                    var uv3 = texCoords[indices[i + 2]];
                    var p1 = new Point((int)(uv1.x * length), (int)(uv1.y * length));
                    var p2 = new Point((int)(uv2.x * length), (int)(uv2.y * length));
                    var p3 = new Point((int)(uv3.x * length), (int)(uv3.y * length));
                    graphics.DrawLine(pens[penIndex], p1, p2);
                    graphics.DrawLine(pens[penIndex], p2, p3);
                    graphics.DrawLine(pens[penIndex], p3, p1);
                    penIndex = (penIndex + 1 == pens.Length) ? 0 : penIndex + 1;
                }
            }

            return bmp;
        }
    }
}
