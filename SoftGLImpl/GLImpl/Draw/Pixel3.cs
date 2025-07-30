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
    public unsafe struct Pixel3 {
        public readonly int x;
        public readonly int y;
        public readonly float depth;
        public Pixel3(int x, int y, float depth) {
            this.x = x;
            this.y = y;
            this.depth = depth;
        }

        public override string ToString() {
            return $"{x}, {y}, {depth}";
        }
    }
}
