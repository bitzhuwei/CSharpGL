using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftGLImpl {
    /// <summary>
    /// used in FindFragments()
    /// </summary>
    public unsafe struct Scanline {
        public Pixel3 end;
        public Pixel3 start;
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

        public void TryExtend(int x, int y, float depth) {
            if (start.x == 0 && start.y == 0 && start.depth == 0
             && end.x == 0 && end.y == 0 && end.depth == 0) {// init this scanline
                end = new Pixel3(x, y, depth);
                start = new Pixel3(x, y, depth);
            }
            else {// try to extend this scanline
                Debug.Assert(start.x == x);
                if (end.y < y) { end = new Pixel3(x, y, depth); }
                if (start.y > y) { start = new Pixel3(x, y, depth); }
            }
        }
    }
}
