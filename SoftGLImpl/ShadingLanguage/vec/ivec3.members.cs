using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial struct ivec3 {
        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(int) * 0)]
        public int x;

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(int) * 1)]
        public int y;

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(int) * 2)]
        public int z;


        public ivec2 xx { get { return new ivec2(x, x); } set { this.x = value.x; this.x = value.y; } }
        public ivec2 xy { get { return new ivec2(x, y); } set { this.x = value.x; this.y = value.y; } }
        public ivec2 yx { get { return new ivec2(y, x); } set { this.y = value.x; this.x = value.y; } }
        public ivec2 yy { get { return new ivec2(y, y); } set { this.y = value.x; this.y = value.y; } }

        public ivec3 xxx { get { return new ivec3(x, x, x); } set { this.x = value.x; this.x = value.y; this.x = value.z; } }
        public ivec3 xxy { get { return new ivec3(x, x, y); } set { this.x = value.x; this.x = value.y; this.y = value.z; } }
        public ivec3 xxz { get { return new ivec3(x, x, z); } set { this.x = value.x; this.x = value.y; this.z = value.z; } }
        public ivec3 xyx { get { return new ivec3(x, y, x); } set { this.x = value.x; this.y = value.y; this.x = value.z; } }
        public ivec3 xyy { get { return new ivec3(x, y, y); } set { this.x = value.x; this.y = value.y; this.y = value.z; } }
        public ivec3 xyz { get { return new ivec3(x, y, z); } set { this.x = value.x; this.y = value.y; this.z = value.z; } }
        public ivec3 xzx { get { return new ivec3(x, z, x); } set { this.x = value.x; this.z = value.y; this.x = value.z; } }
        public ivec3 xzy { get { return new ivec3(x, z, y); } set { this.x = value.x; this.z = value.y; this.y = value.z; } }
        public ivec3 xzz { get { return new ivec3(x, z, z); } set { this.x = value.x; this.z = value.y; this.z = value.z; } }
        public ivec3 yxx { get { return new ivec3(y, x, x); } set { this.y = value.x; this.x = value.y; this.x = value.z; } }
        public ivec3 yxy { get { return new ivec3(y, x, y); } set { this.y = value.x; this.x = value.y; this.y = value.z; } }
        public ivec3 yxz { get { return new ivec3(y, x, z); } set { this.y = value.x; this.x = value.y; this.z = value.z; } }
        public ivec3 yyx { get { return new ivec3(y, y, x); } set { this.y = value.x; this.y = value.y; this.x = value.z; } }
        public ivec3 yyy { get { return new ivec3(y, y, y); } set { this.y = value.x; this.y = value.y; this.y = value.z; } }
        public ivec3 yyz { get { return new ivec3(y, y, z); } set { this.y = value.x; this.y = value.y; this.z = value.z; } }
        public ivec3 yzx { get { return new ivec3(y, z, x); } set { this.y = value.x; this.z = value.y; this.x = value.z; } }
        public ivec3 yzy { get { return new ivec3(y, z, y); } set { this.y = value.x; this.z = value.y; this.y = value.z; } }
        public ivec3 yzz { get { return new ivec3(y, z, z); } set { this.y = value.x; this.z = value.y; this.z = value.z; } }
        public ivec3 zxx { get { return new ivec3(z, x, x); } set { this.z = value.x; this.x = value.y; this.x = value.z; } }
        public ivec3 zxy { get { return new ivec3(z, x, y); } set { this.z = value.x; this.x = value.y; this.y = value.z; } }
        public ivec3 zxz { get { return new ivec3(z, x, z); } set { this.z = value.x; this.x = value.y; this.z = value.z; } }
        public ivec3 zyx { get { return new ivec3(z, y, x); } set { this.z = value.x; this.y = value.y; this.x = value.z; } }
        public ivec3 zyy { get { return new ivec3(z, y, y); } set { this.z = value.x; this.y = value.y; this.y = value.z; } }
        public ivec3 zyz { get { return new ivec3(z, y, z); } set { this.z = value.x; this.y = value.y; this.z = value.z; } }
        public ivec3 zzx { get { return new ivec3(z, z, x); } set { this.z = value.x; this.z = value.y; this.x = value.z; } }
        public ivec3 zzy { get { return new ivec3(z, z, y); } set { this.z = value.x; this.z = value.y; this.y = value.z; } }
        public ivec3 zzz { get { return new ivec3(z, z, z); } set { this.z = value.x; this.z = value.y; this.z = value.z; } }

    }
}
