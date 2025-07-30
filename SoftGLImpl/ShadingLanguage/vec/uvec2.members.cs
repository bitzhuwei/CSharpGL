using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial struct uvec2 {
        /// <summary>
        /// Don't change the order of x, y appears!
        /// </summary>
        [FieldOffset(sizeof(uint) * 0)]
        public uint x;

        /// <summary>
        /// Don't change the order of x, y appears!
        /// </summary>
        [FieldOffset(sizeof(uint) * 1)]
        public uint y;

        public uvec2 xx { get { return new uvec2(x, x); } set { this.x = value.x; this.x = value.y; } }
        public uvec2 xy { get { return new uvec2(x, y); } set { this.x = value.x; this.y = value.y; } }
        public uvec2 yx { get { return new uvec2(y, x); } set { this.y = value.x; this.x = value.y; } }
        public uvec2 yy { get { return new uvec2(y, y); } set { this.y = value.x; this.y = value.y; } }

    }
}
