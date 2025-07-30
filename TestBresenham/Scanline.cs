using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TestBresenham {
    /// <summary>
    /// used in FindFragments()
    /// </summary>
    public struct Scanline {
        public Point end;
        public Point start;
        //public Scanline() {
        //    this.end = new Pixel3(-1, -1, 0);
        //    this.start = new Pixel3(-1, -1, 0);
        //}
        //public Scanline(Pixel3 start, Pixel3 end) {
        //    this.end = end;
        //    this.start = start;
        //}

        public override string ToString() {
            return $"Scanline: {start} -> {end}";
        }

        public void TryExtend(int x, int y) {
            if (start.X == 0 && start.Y == 0
             && end.X == 0 && end.Y == 0) {// init this scanline
                end = new Point(x, y);
                start = new Point(x, y);
            }
            else {// try to extend this scanline
                Debug.Assert(start.X == x);
                if (end.Y < y) { end = new Point(x, y); }
                if (start.Y > y) { start = new Point(x, y); }
            }
        }
    }
}
