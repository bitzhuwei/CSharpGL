using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace TestBresenham {
    partial class Bresenham {
        /// <summary>
        /// Find fragments in the specified triangle.
        /// </summary>
        /// <param name="fragCoord0"></param>
        /// <param name="fragCoord1"></param>
        /// <param name="fragCoord2"></param>
        /// <param name="endpoints0"></param>
        /// <param name="endpoints1"></param>
        /// <param name="endpoints2"></param>
        /// <param name="result"></param>
        public static void FindFragmentsInTriangle(
           PointF fragCoord0, PointF fragCoord1, PointF fragCoord2,
           ConcurrentBag<Point> result) {
            int left = (int)fragCoord0.X, right = left;
            if (left > (int)fragCoord1.X) { left = (int)fragCoord1.X; }
            if (left > (int)fragCoord2.X) { left = (int)fragCoord2.X; }
            if (right < (int)fragCoord1.X) { right = (int)fragCoord1.X; }
            if (right < (int)fragCoord2.X) { right = (int)fragCoord2.X; }
            //int bottom = left, top = left;
            //if (bottom > (int)fragCoord1.Y) { bottom = (int)fragCoord1.Y; }
            //if (bottom > (int)fragCoord2.Y) { bottom = (int)fragCoord2.Y; }
            //if (top < (int)fragCoord1.Y) { top = (int)fragCoord1.Y; }
            //if (top < (int)fragCoord2.Y) { top = (int)fragCoord2.Y; }

            var scanlines = new Scanline[right - left + 1];// we'll find the vertial scanlines
            LocateScanlines(fragCoord0, fragCoord1, left, scanlines);
            LocateScanlines(fragCoord1, fragCoord2, left, scanlines);
            LocateScanlines(fragCoord2, fragCoord0, left, scanlines);
            // way #1
            for (int i = 0; i < scanlines.Length; i++) {
                var scanline = scanlines[i];
                var min = scanline.start; var max = scanline.end;
                for (int y = min.Y; y <= max.Y; y++) {
                    var fragment = new Point(min.X, y);
                    result.Add(fragment);
                }
            }
            // way #3
            //ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);
            //var countdown = new CountdownEvent(scanlines.Length);
            //for (int i = 0; i < scanlines.Length; i++) {
            //    var state = new InitParamScaneline(scanlines[i], inverseMat, endpoints0, endpoints1, endpoints2, result, countdown);
            //    ThreadPool.QueueUserWorkItem(fillScanline, state, true);
            //}
            //countdown.Wait(1000);//wait for 1 second at most
        }

        class InitParamScaneline {
            public Scanline scanline;
            public ConcurrentBag<Point> result;
            public CountdownEvent countdown;

            public InitParamScaneline(Scanline scanline, ConcurrentBag<Point> result, CountdownEvent countdown) {
                this.scanline = scanline;
                this.result = result;
                this.countdown = countdown;
            }
        }
        private static readonly Action<InitParamScaneline> fillScanline = (state) => {
            var min = state.scanline.start; var max = state.scanline.end;
            for (int y = min.Y; y <= max.Y; y++) {
                var fragment = new Point(min.X, y);
                state.result.Add(fragment);
            }
            state.countdown.Signal();
        };
        private static void LocateScanlines(PointF start, PointF end,
            int left, Scanline[] scanlines) {
            if (start.X < end.X) { DoLocateScanlines(start, end, left, scanlines); }
            else { DoLocateScanlines(end, start, left, scanlines); }
        }

        private static void DoLocateScanlines(PointF start, PointF end, int left, Scanline[] scanlines) {
            // now start.X <= end.X
            if (start.Y < end.Y) { LocateScanlines1(start, end, left, scanlines); }
            else { LocateScanlines2(start, end, left, scanlines); }
        }


        /// <summary>
        /// from (0, height - 1)(start) to (width - 1, 0)(end)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="pixels"></param>
        private static void LocateScanlines2(PointF start, PointF end, int left, Scanline[] scanlines) {
            var x0 = (int)start.X; var y0 = (int)start.Y;
            var x1 = (int)end.X; var y1 = (int)end.Y;
            //float dx = end.X - start.X, dy = start.Y - end.Y;
            float dx = x1 - x0, dy = y0 - y1;
            if (dx >= dy) {
                float p = dy + dy - dx;
                for (; x0 <= x1; x0++) {
                    var a = (x0 + 0.5f - start.X) / (end.X - start.X);
                    //Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (x0 == x1) { y0 = y1; }
                    {
                        var index = x0 - left;
                        scanlines[index].TryExtend(x0, y0);
                    }
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
                    var a = (y0 + 0.5f - end.Y) / (start.Y - end.Y);
                    //Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (y0 == y1) { x0 = x1; }
                    {
                        var index = x0 - left;
                        scanlines[index].TryExtend(x0, y0);
                    }
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
        private static void LocateScanlines1(PointF start, PointF end, int left, Scanline[] scanlines) {
            var x0 = (int)start.X; var y0 = (int)start.Y;
            var x1 = (int)end.X; var y1 = (int)end.Y;
            //float dx = end.X - start.X, dy = end.Y - start.Y;
            float dx = x1 - x0, dy = y1 - y0;
            if (dx >= dy) {
                float p = dy + dy - dx;
                for (; x0 <= x1; x0++) {
                    var a = (x0 + 0.5f - start.X) / (end.X - start.X);
                    //Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (x0 == x1) { y0 = y1; }
                    {
                        var index = x0 - left;
                        scanlines[index].TryExtend(x0, y0);
                    }
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
                    var a = (y0 + 0.5f - start.Y) / (end.Y - start.Y);
                    //Debug.Assert(x0 > -10000 && x0 < 10000 && y0 > -10000 && y0 < 10000);
                    if (y0 == y1) { x0 = x1; }// the last pixel
                    {
                        var index = x0 - left;
                        scanlines[index].TryExtend(x0, y0);
                    }
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
