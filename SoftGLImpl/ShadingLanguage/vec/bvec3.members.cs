using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial struct bvec3 {
        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(bool) * 0)]
        public bool x;

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(bool) * 1)]
        public bool y;

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(bool) * 2)]
        public bool z;


        public bvec2 xx { get { return new bvec2(x, x); } set { this.x = value.x; this.x = value.y; } }
        public bvec2 xy { get { return new bvec2(x, y); } set { this.x = value.x; this.y = value.y; } }
        public bvec2 yx { get { return new bvec2(y, x); } set { this.y = value.x; this.x = value.y; } }
        public bvec2 yy { get { return new bvec2(y, y); } set { this.y = value.x; this.y = value.y; } }

        public bvec3 xxx { get { return new bvec3(x, x, x); } set { this.x = value.x; this.x = value.y; this.x = value.z; } }
        public bvec3 xxy { get { return new bvec3(x, x, y); } set { this.x = value.x; this.x = value.y; this.y = value.z; } }
        public bvec3 xxz { get { return new bvec3(x, x, z); } set { this.x = value.x; this.x = value.y; this.z = value.z; } }
        public bvec3 xyx { get { return new bvec3(x, y, x); } set { this.x = value.x; this.y = value.y; this.x = value.z; } }
        public bvec3 xyy { get { return new bvec3(x, y, y); } set { this.x = value.x; this.y = value.y; this.y = value.z; } }
        public bvec3 xyz { get { return new bvec3(x, y, z); } set { this.x = value.x; this.y = value.y; this.z = value.z; } }
        public bvec3 xzx { get { return new bvec3(x, z, x); } set { this.x = value.x; this.z = value.y; this.x = value.z; } }
        public bvec3 xzy { get { return new bvec3(x, z, y); } set { this.x = value.x; this.z = value.y; this.y = value.z; } }
        public bvec3 xzz { get { return new bvec3(x, z, z); } set { this.x = value.x; this.z = value.y; this.z = value.z; } }
        public bvec3 yxx { get { return new bvec3(y, x, x); } set { this.y = value.x; this.x = value.y; this.x = value.z; } }
        public bvec3 yxy { get { return new bvec3(y, x, y); } set { this.y = value.x; this.x = value.y; this.y = value.z; } }
        public bvec3 yxz { get { return new bvec3(y, x, z); } set { this.y = value.x; this.x = value.y; this.z = value.z; } }
        public bvec3 yyx { get { return new bvec3(y, y, x); } set { this.y = value.x; this.y = value.y; this.x = value.z; } }
        public bvec3 yyy { get { return new bvec3(y, y, y); } set { this.y = value.x; this.y = value.y; this.y = value.z; } }
        public bvec3 yyz { get { return new bvec3(y, y, z); } set { this.y = value.x; this.y = value.y; this.z = value.z; } }
        public bvec3 yzx { get { return new bvec3(y, z, x); } set { this.y = value.x; this.z = value.y; this.x = value.z; } }
        public bvec3 yzy { get { return new bvec3(y, z, y); } set { this.y = value.x; this.z = value.y; this.y = value.z; } }
        public bvec3 yzz { get { return new bvec3(y, z, z); } set { this.y = value.x; this.z = value.y; this.z = value.z; } }
        public bvec3 zxx { get { return new bvec3(z, x, x); } set { this.z = value.x; this.x = value.y; this.x = value.z; } }
        public bvec3 zxy { get { return new bvec3(z, x, y); } set { this.z = value.x; this.x = value.y; this.y = value.z; } }
        public bvec3 zxz { get { return new bvec3(z, x, z); } set { this.z = value.x; this.x = value.y; this.z = value.z; } }
        public bvec3 zyx { get { return new bvec3(z, y, x); } set { this.z = value.x; this.y = value.y; this.x = value.z; } }
        public bvec3 zyy { get { return new bvec3(z, y, y); } set { this.z = value.x; this.y = value.y; this.y = value.z; } }
        public bvec3 zyz { get { return new bvec3(z, y, z); } set { this.z = value.x; this.y = value.y; this.z = value.z; } }
        public bvec3 zzx { get { return new bvec3(z, z, x); } set { this.z = value.x; this.z = value.y; this.x = value.z; } }
        public bvec3 zzy { get { return new bvec3(z, z, y); } set { this.z = value.x; this.z = value.y; this.y = value.z; } }
        public bvec3 zzz { get { return new bvec3(z, z, z); } set { this.z = value.x; this.z = value.y; this.z = value.z; } }

    }
}
