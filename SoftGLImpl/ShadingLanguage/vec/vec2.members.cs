using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial struct vec2 {
        /// <summary>
        /// x = r = s
        /// </summary>
        [FieldOffset(sizeof(float) * 0)]
        public float x;

        /// <summary>
        /// y = g = t
        /// </summary>
        [FieldOffset(sizeof(float) * 1)]
        public float y;

        public vec2 xx { get { return new vec2(x, x); } set { this.x = value.x; this.x = value.y; } }
        public vec2 xy { get { return new vec2(x, y); } set { this.x = value.x; this.y = value.y; } }
        public vec2 yx { get { return new vec2(y, x); } set { this.y = value.x; this.x = value.y; } }
        public vec2 yy { get { return new vec2(y, y); } set { this.y = value.x; this.y = value.y; } }

    }
}
