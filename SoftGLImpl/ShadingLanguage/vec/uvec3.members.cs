using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial struct uvec3 {
        /// <summary>
        /// Don't change the order of x, y, z, w appears!
        /// </summary>
        [FieldOffset(sizeof(uint) * 0)]
        public uint x;

        /// <summary>
        /// Don't change the order of x, y, z, w appears!
        /// </summary>
        [FieldOffset(sizeof(uint) * 1)]
        public uint y;

        /// <summary>
        /// Don't change the order of x, y, z, w appears!
        /// </summary>
        [FieldOffset(sizeof(uint) * 2)]
        public uint z;


        public uvec2 xx { get { return new uvec2(x, x); } set { this.x = value.x; this.x = value.y; } }
        public uvec2 xy { get { return new uvec2(x, y); } set { this.x = value.x; this.y = value.y; } }
        public uvec2 yx { get { return new uvec2(y, x); } set { this.y = value.x; this.x = value.y; } }
        public uvec2 yy { get { return new uvec2(y, y); } set { this.y = value.x; this.y = value.y; } }

        public uvec3 xxx { get { return new uvec3(x, x, x); } set { this.x = value.x; this.x = value.y; this.x = value.z; } }
        public uvec3 xxy { get { return new uvec3(x, x, y); } set { this.x = value.x; this.x = value.y; this.y = value.z; } }
        public uvec3 xxz { get { return new uvec3(x, x, z); } set { this.x = value.x; this.x = value.y; this.z = value.z; } }
        public uvec3 xyx { get { return new uvec3(x, y, x); } set { this.x = value.x; this.y = value.y; this.x = value.z; } }
        public uvec3 xyy { get { return new uvec3(x, y, y); } set { this.x = value.x; this.y = value.y; this.y = value.z; } }
        public uvec3 xyz { get { return new uvec3(x, y, z); } set { this.x = value.x; this.y = value.y; this.z = value.z; } }
        public uvec3 xzx { get { return new uvec3(x, z, x); } set { this.x = value.x; this.z = value.y; this.x = value.z; } }
        public uvec3 xzy { get { return new uvec3(x, z, y); } set { this.x = value.x; this.z = value.y; this.y = value.z; } }
        public uvec3 xzz { get { return new uvec3(x, z, z); } set { this.x = value.x; this.z = value.y; this.z = value.z; } }
        public uvec3 yxx { get { return new uvec3(y, x, x); } set { this.y = value.x; this.x = value.y; this.x = value.z; } }
        public uvec3 yxy { get { return new uvec3(y, x, y); } set { this.y = value.x; this.x = value.y; this.y = value.z; } }
        public uvec3 yxz { get { return new uvec3(y, x, z); } set { this.y = value.x; this.x = value.y; this.z = value.z; } }
        public uvec3 yyx { get { return new uvec3(y, y, x); } set { this.y = value.x; this.y = value.y; this.x = value.z; } }
        public uvec3 yyy { get { return new uvec3(y, y, y); } set { this.y = value.x; this.y = value.y; this.y = value.z; } }
        public uvec3 yyz { get { return new uvec3(y, y, z); } set { this.y = value.x; this.y = value.y; this.z = value.z; } }
        public uvec3 yzx { get { return new uvec3(y, z, x); } set { this.y = value.x; this.z = value.y; this.x = value.z; } }
        public uvec3 yzy { get { return new uvec3(y, z, y); } set { this.y = value.x; this.z = value.y; this.y = value.z; } }
        public uvec3 yzz { get { return new uvec3(y, z, z); } set { this.y = value.x; this.z = value.y; this.z = value.z; } }
        public uvec3 zxx { get { return new uvec3(z, x, x); } set { this.z = value.x; this.x = value.y; this.x = value.z; } }
        public uvec3 zxy { get { return new uvec3(z, x, y); } set { this.z = value.x; this.x = value.y; this.y = value.z; } }
        public uvec3 zxz { get { return new uvec3(z, x, z); } set { this.z = value.x; this.x = value.y; this.z = value.z; } }
        public uvec3 zyx { get { return new uvec3(z, y, x); } set { this.z = value.x; this.y = value.y; this.x = value.z; } }
        public uvec3 zyy { get { return new uvec3(z, y, y); } set { this.z = value.x; this.y = value.y; this.y = value.z; } }
        public uvec3 zyz { get { return new uvec3(z, y, z); } set { this.z = value.x; this.y = value.y; this.z = value.z; } }
        public uvec3 zzx { get { return new uvec3(z, z, x); } set { this.z = value.x; this.z = value.y; this.x = value.z; } }
        public uvec3 zzy { get { return new uvec3(z, z, y); } set { this.z = value.x; this.z = value.y; this.y = value.z; } }
        public uvec3 zzz { get { return new uvec3(z, z, z); } set { this.z = value.x; this.z = value.y; this.z = value.z; } }

    }
}
