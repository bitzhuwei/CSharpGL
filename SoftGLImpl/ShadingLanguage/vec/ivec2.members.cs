using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial struct ivec2 {
        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(int) * 0)]
        public int x;

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(int) * 1)]
        public int y;


        public ivec2 xx { get { return new ivec2(x, x); } set { this.x = value.x; this.x = value.y; } }
        public ivec2 xy { get { return new ivec2(x, y); } set { this.x = value.x; this.y = value.y; } }
        public ivec2 yx { get { return new ivec2(y, x); } set { this.y = value.x; this.x = value.y; } }
        public ivec2 yy { get { return new ivec2(y, y); } set { this.y = value.x; this.y = value.y; } }

    }
}
