using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBresenham {
    internal partial class Bresenham {
        internal static void FindPixelsAtLine(PointF start, PointF end, List<Point> pixels) {
            if (start.X < end.X) { DoFindPixelsAtLine(start, end, pixels); }
            else { DoFindPixelsAtLine(end, start, pixels); }
        }

        /// <summary>
        /// from left(start) to right(end)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="pixels"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void DoFindPixelsAtLine(PointF start, PointF end, List<Point> pixels) {
            // now start.X <= end.X
            if (start.Y < end.Y) { FindPixelsAtLine1(start, end, pixels); }
            else { FindPixelsAtLine2(start, end, pixels); }
        }

        /// <summary>
        /// from (0, height - 1)(start) to (width - 1, 0)(end)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="pixels"></param>
        private static void FindPixelsAtLine2(PointF start, PointF end, List<Point> pixels) {
            var x0 = (int)start.X; var y0 = (int)start.Y;
            var x1 = (int)end.X; var y1 = (int)end.Y;
            //float dx = end.X - start.X, dy = start.Y - end.Y;
            float dx = x1 - x0, dy = y0 - y1;
            if (dx >= dy) {
                float p = dy + dy - dx;
                for (; x0 <= x1; x0++) {
                    Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (x0 == x1) { y0 = y1; }
                    pixels.Add(new Point(x0, y0));
                    if (p > 0) {
                        y0 -= 1;
                        p = p + dy + dy - dx - dx;
                    }
                    else {
                        p = p + dy + dy;
                    }
                }
            }
            else {
                float p = dx + dx - dy;
                for (; y0 >= y1; y0--) {
                    Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (y0 == y1) { x0 = x1; }
                    pixels.Add(new Point(x0, y0));
                    if (p >= 0) {
                        x0 += 1;
                        p = p + dx + dx - dy - dy;
                    }
                    else {
                        p = p + dx + dx;
                    }
                }
            }
        }

        /// <summary>
        /// from (0, 0)(start) to (width - 1, height - 1)(end)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="pixels"></param>
        private static void FindPixelsAtLine1(PointF start, PointF end, List<Point> pixels) {
            var x0 = (int)start.X; var y0 = (int)start.Y;
            var x1 = (int)end.X; var y1 = (int)end.Y;
            //float dx = end.X - start.X, dy = end.Y - start.Y;
            float dx = x1 - x0, dy = y1 - y0;
            if (dx >= dy) {
                float p = dy + dy - dx;
                for (; x0 <= x1; x0++) {
                    Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (x0 == x1) { y0 = y1; }
                    pixels.Add(new Point(x0, y0));
                    if (p >= 0) {
                        y0 += 1;
                        p = p + dy + dy - dx - dx;
                    }
                    else {
                        p = p + dy + dy;
                    }
                }
            }
            else {
                float p = dx + dx - dy;
                for (; y0 <= y1; y0++) {
                    Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (y0 == y1) { x0 = x1; }// the last pixel
                    pixels.Add(new Point(x0, y0));
                    if (p >= 0) {
                        x0 += 1;
                        p = p + dx + dx - dy - dy;
                    }
                    else {
                        p = p + dx + dx;
                    }
                }
            }
        }
    }
}
