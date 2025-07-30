using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial struct vec3 {
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

        /// <summary>
        /// z = b = p
        /// </summary>
        [FieldOffset(sizeof(float) * 2)]
        public float z;


        public vec2 xx { get { return new vec2(x, x); } set { this.x = value.x; this.x = value.y; } }
        public vec2 xy { get { return new vec2(x, y); } set { this.x = value.x; this.y = value.y; } }
        public vec2 yx { get { return new vec2(y, x); } set { this.y = value.x; this.x = value.y; } }
        public vec2 yy { get { return new vec2(y, y); } set { this.y = value.x; this.y = value.y; } }

        public vec3 xxx { get { return new vec3(x, x, x); } set { this.x = value.x; this.x = value.y; this.x = value.z; } }
        public vec3 xxy { get { return new vec3(x, x, y); } set { this.x = value.x; this.x = value.y; this.y = value.z; } }
        public vec3 xxz { get { return new vec3(x, x, z); } set { this.x = value.x; this.x = value.y; this.z = value.z; } }
        public vec3 xyx { get { return new vec3(x, y, x); } set { this.x = value.x; this.y = value.y; this.x = value.z; } }
        public vec3 xyy { get { return new vec3(x, y, y); } set { this.x = value.x; this.y = value.y; this.y = value.z; } }
        public vec3 xyz { get { return new vec3(x, y, z); } set { this.x = value.x; this.y = value.y; this.z = value.z; } }
        public vec3 xzx { get { return new vec3(x, z, x); } set { this.x = value.x; this.z = value.y; this.x = value.z; } }
        public vec3 xzy { get { return new vec3(x, z, y); } set { this.x = value.x; this.z = value.y; this.y = value.z; } }
        public vec3 xzz { get { return new vec3(x, z, z); } set { this.x = value.x; this.z = value.y; this.z = value.z; } }
        public vec3 yxx { get { return new vec3(y, x, x); } set { this.y = value.x; this.x = value.y; this.x = value.z; } }
        public vec3 yxy { get { return new vec3(y, x, y); } set { this.y = value.x; this.x = value.y; this.y = value.z; } }
        public vec3 yxz { get { return new vec3(y, x, z); } set { this.y = value.x; this.x = value.y; this.z = value.z; } }
        public vec3 yyx { get { return new vec3(y, y, x); } set { this.y = value.x; this.y = value.y; this.x = value.z; } }
        public vec3 yyy { get { return new vec3(y, y, y); } set { this.y = value.x; this.y = value.y; this.y = value.z; } }
        public vec3 yyz { get { return new vec3(y, y, z); } set { this.y = value.x; this.y = value.y; this.z = value.z; } }
        public vec3 yzx { get { return new vec3(y, z, x); } set { this.y = value.x; this.z = value.y; this.x = value.z; } }
        public vec3 yzy { get { return new vec3(y, z, y); } set { this.y = value.x; this.z = value.y; this.y = value.z; } }
        public vec3 yzz { get { return new vec3(y, z, z); } set { this.y = value.x; this.z = value.y; this.z = value.z; } }
        public vec3 zxx { get { return new vec3(z, x, x); } set { this.z = value.x; this.x = value.y; this.x = value.z; } }
        public vec3 zxy { get { return new vec3(z, x, y); } set { this.z = value.x; this.x = value.y; this.y = value.z; } }
        public vec3 zxz { get { return new vec3(z, x, z); } set { this.z = value.x; this.x = value.y; this.z = value.z; } }
        public vec3 zyx { get { return new vec3(z, y, x); } set { this.z = value.x; this.y = value.y; this.x = value.z; } }
        public vec3 zyy { get { return new vec3(z, y, y); } set { this.z = value.x; this.y = value.y; this.y = value.z; } }
        public vec3 zyz { get { return new vec3(z, y, z); } set { this.z = value.x; this.y = value.y; this.z = value.z; } }
        public vec3 zzx { get { return new vec3(z, z, x); } set { this.z = value.x; this.z = value.y; this.x = value.z; } }
        public vec3 zzy { get { return new vec3(z, z, y); } set { this.z = value.x; this.z = value.y; this.y = value.z; } }
        public vec3 zzz { get { return new vec3(z, z, z); } set { this.z = value.x; this.z = value.y; this.z = value.z; } }

    }
}
