using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial struct bvec2 {
        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(bool) * 0)]
        public bool x;

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(bool) * 1)]
        public bool y;


        public bvec2 xx { get { return new bvec2(x, x); } set { this.x = value.x; this.x = value.y; } }
        public bvec2 xy { get { return new bvec2(x, y); } set { this.x = value.x; this.y = value.y; } }
        public bvec2 yx { get { return new bvec2(y, x); } set { this.y = value.x; this.x = value.y; } }
        public bvec2 yy { get { return new bvec2(y, y); } set { this.y = value.x; this.y = value.y; } }

    }
}
