using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial struct dvec3 {
        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(double) * 0)]
        public double x;

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(double) * 1)]
        public double y;

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(double) * 2)]
        public double z;


        public dvec2 xx { get { return new dvec2(x, x); } set { this.x = value.x; this.x = value.y; } }
        public dvec2 xy { get { return new dvec2(x, y); } set { this.x = value.x; this.y = value.y; } }
        public dvec2 yx { get { return new dvec2(y, x); } set { this.y = value.x; this.x = value.y; } }
        public dvec2 yy { get { return new dvec2(y, y); } set { this.y = value.x; this.y = value.y; } }

        public dvec3 xxx { get { return new dvec3(x, x, x); } set { this.x = value.x; this.x = value.y; this.x = value.z; } }
        public dvec3 xxy { get { return new dvec3(x, x, y); } set { this.x = value.x; this.x = value.y; this.y = value.z; } }
        public dvec3 xxz { get { return new dvec3(x, x, z); } set { this.x = value.x; this.x = value.y; this.z = value.z; } }
        public dvec3 xyx { get { return new dvec3(x, y, x); } set { this.x = value.x; this.y = value.y; this.x = value.z; } }
        public dvec3 xyy { get { return new dvec3(x, y, y); } set { this.x = value.x; this.y = value.y; this.y = value.z; } }
        public dvec3 xyz { get { return new dvec3(x, y, z); } set { this.x = value.x; this.y = value.y; this.z = value.z; } }
        public dvec3 xzx { get { return new dvec3(x, z, x); } set { this.x = value.x; this.z = value.y; this.x = value.z; } }
        public dvec3 xzy { get { return new dvec3(x, z, y); } set { this.x = value.x; this.z = value.y; this.y = value.z; } }
        public dvec3 xzz { get { return new dvec3(x, z, z); } set { this.x = value.x; this.z = value.y; this.z = value.z; } }
        public dvec3 yxx { get { return new dvec3(y, x, x); } set { this.y = value.x; this.x = value.y; this.x = value.z; } }
        public dvec3 yxy { get { return new dvec3(y, x, y); } set { this.y = value.x; this.x = value.y; this.y = value.z; } }
        public dvec3 yxz { get { return new dvec3(y, x, z); } set { this.y = value.x; this.x = value.y; this.z = value.z; } }
        public dvec3 yyx { get { return new dvec3(y, y, x); } set { this.y = value.x; this.y = value.y; this.x = value.z; } }
        public dvec3 yyy { get { return new dvec3(y, y, y); } set { this.y = value.x; this.y = value.y; this.y = value.z; } }
        public dvec3 yyz { get { return new dvec3(y, y, z); } set { this.y = value.x; this.y = value.y; this.z = value.z; } }
        public dvec3 yzx { get { return new dvec3(y, z, x); } set { this.y = value.x; this.z = value.y; this.x = value.z; } }
        public dvec3 yzy { get { return new dvec3(y, z, y); } set { this.y = value.x; this.z = value.y; this.y = value.z; } }
        public dvec3 yzz { get { return new dvec3(y, z, z); } set { this.y = value.x; this.z = value.y; this.z = value.z; } }
        public dvec3 zxx { get { return new dvec3(z, x, x); } set { this.z = value.x; this.x = value.y; this.x = value.z; } }
        public dvec3 zxy { get { return new dvec3(z, x, y); } set { this.z = value.x; this.x = value.y; this.y = value.z; } }
        public dvec3 zxz { get { return new dvec3(z, x, z); } set { this.z = value.x; this.x = value.y; this.z = value.z; } }
        public dvec3 zyx { get { return new dvec3(z, y, x); } set { this.z = value.x; this.y = value.y; this.x = value.z; } }
        public dvec3 zyy { get { return new dvec3(z, y, y); } set { this.z = value.x; this.y = value.y; this.y = value.z; } }
        public dvec3 zyz { get { return new dvec3(z, y, z); } set { this.z = value.x; this.y = value.y; this.z = value.z; } }
        public dvec3 zzx { get { return new dvec3(z, z, x); } set { this.z = value.x; this.z = value.y; this.x = value.z; } }
        public dvec3 zzy { get { return new dvec3(z, z, y); } set { this.z = value.x; this.z = value.y; this.y = value.z; } }
        public dvec3 zzz { get { return new dvec3(z, z, z); } set { this.z = value.x; this.z = value.y; this.z = value.z; } }

    }
}
