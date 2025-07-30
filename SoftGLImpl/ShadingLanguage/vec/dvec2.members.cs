using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial struct dvec2 {
        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(double) * 0)]
        public double x;

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(double) * 1)]
        public double y;


        public dvec2 xx { get { return new dvec2(x, x); } set { this.x = value.x; this.x = value.y; } }
        public dvec2 xy { get { return new dvec2(x, y); } set { this.x = value.x; this.y = value.y; } }
        public dvec2 yx { get { return new dvec2(y, x); } set { this.y = value.x; this.x = value.y; } }
        public dvec2 yy { get { return new dvec2(y, y); } set { this.y = value.x; this.y = value.y; } }

    }
}
