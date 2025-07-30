using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial struct vec4 {
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

        /// <summary>
        /// w = a = q
        /// </summary>
        [FieldOffset(sizeof(float) * 3)]
        public float w;


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

        public vec4 xxxx { get { return new vec4(x, x, x, x); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 xxxy { get { return new vec4(x, x, x, y); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 xxxz { get { return new vec4(x, x, x, z); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 xxxw { get { return new vec4(x, x, x, w); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 xxyx { get { return new vec4(x, x, y, x); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 xxyy { get { return new vec4(x, x, y, y); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 xxyz { get { return new vec4(x, x, y, z); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 xxyw { get { return new vec4(x, x, y, w); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 xxzx { get { return new vec4(x, x, z, x); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 xxzy { get { return new vec4(x, x, z, y); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 xxzz { get { return new vec4(x, x, z, z); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 xxzw { get { return new vec4(x, x, z, w); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 xxwx { get { return new vec4(x, x, w, x); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 xxwy { get { return new vec4(x, x, w, y); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 xxwz { get { return new vec4(x, x, w, z); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 xxww { get { return new vec4(x, x, w, w); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public vec4 xyxx { get { return new vec4(x, y, x, x); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 xyxy { get { return new vec4(x, y, x, y); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 xyxz { get { return new vec4(x, y, x, z); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 xyxw { get { return new vec4(x, y, x, w); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 xyyx { get { return new vec4(x, y, y, x); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 xyyy { get { return new vec4(x, y, y, y); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 xyyz { get { return new vec4(x, y, y, z); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 xyyw { get { return new vec4(x, y, y, w); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 xyzx { get { return new vec4(x, y, z, x); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 xyzy { get { return new vec4(x, y, z, y); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 xyzz { get { return new vec4(x, y, z, z); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 xyzw { get { return new vec4(x, y, z, w); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 xywx { get { return new vec4(x, y, w, x); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 xywy { get { return new vec4(x, y, w, y); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 xywz { get { return new vec4(x, y, w, z); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 xyww { get { return new vec4(x, y, w, w); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public vec4 xzxx { get { return new vec4(x, z, x, x); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 xzxy { get { return new vec4(x, z, x, y); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 xzxz { get { return new vec4(x, z, x, z); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 xzxw { get { return new vec4(x, z, x, w); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 xzyx { get { return new vec4(x, z, y, x); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 xzyy { get { return new vec4(x, z, y, y); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 xzyz { get { return new vec4(x, z, y, z); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 xzyw { get { return new vec4(x, z, y, w); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 xzzx { get { return new vec4(x, z, z, x); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 xzzy { get { return new vec4(x, z, z, y); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 xzzz { get { return new vec4(x, z, z, z); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 xzzw { get { return new vec4(x, z, z, w); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 xzwx { get { return new vec4(x, z, w, x); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 xzwy { get { return new vec4(x, z, w, y); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 xzwz { get { return new vec4(x, z, w, z); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 xzww { get { return new vec4(x, z, w, w); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public vec4 xwxx { get { return new vec4(x, w, x, x); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 xwxy { get { return new vec4(x, w, x, y); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 xwxz { get { return new vec4(x, w, x, z); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 xwxw { get { return new vec4(x, w, x, w); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 xwyx { get { return new vec4(x, w, y, x); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 xwyy { get { return new vec4(x, w, y, y); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 xwyz { get { return new vec4(x, w, y, z); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 xwyw { get { return new vec4(x, w, y, w); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 xwzx { get { return new vec4(x, w, z, x); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 xwzy { get { return new vec4(x, w, z, y); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 xwzz { get { return new vec4(x, w, z, z); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 xwzw { get { return new vec4(x, w, z, w); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 xwwx { get { return new vec4(x, w, w, x); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 xwwy { get { return new vec4(x, w, w, y); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 xwwz { get { return new vec4(x, w, w, z); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 xwww { get { return new vec4(x, w, w, w); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }
        public vec4 yxxx { get { return new vec4(y, x, x, x); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 yxxy { get { return new vec4(y, x, x, y); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 yxxz { get { return new vec4(y, x, x, z); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 yxxw { get { return new vec4(y, x, x, w); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 yxyx { get { return new vec4(y, x, y, x); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 yxyy { get { return new vec4(y, x, y, y); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 yxyz { get { return new vec4(y, x, y, z); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 yxyw { get { return new vec4(y, x, y, w); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 yxzx { get { return new vec4(y, x, z, x); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 yxzy { get { return new vec4(y, x, z, y); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 yxzz { get { return new vec4(y, x, z, z); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 yxzw { get { return new vec4(y, x, z, w); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 yxwx { get { return new vec4(y, x, w, x); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 yxwy { get { return new vec4(y, x, w, y); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 yxwz { get { return new vec4(y, x, w, z); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 yxww { get { return new vec4(y, x, w, w); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public vec4 yyxx { get { return new vec4(y, y, x, x); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 yyxy { get { return new vec4(y, y, x, y); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 yyxz { get { return new vec4(y, y, x, z); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 yyxw { get { return new vec4(y, y, x, w); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 yyyx { get { return new vec4(y, y, y, x); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 yyyy { get { return new vec4(y, y, y, y); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 yyyz { get { return new vec4(y, y, y, z); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 yyyw { get { return new vec4(y, y, y, w); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 yyzx { get { return new vec4(y, y, z, x); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 yyzy { get { return new vec4(y, y, z, y); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 yyzz { get { return new vec4(y, y, z, z); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 yyzw { get { return new vec4(y, y, z, w); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 yywx { get { return new vec4(y, y, w, x); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 yywy { get { return new vec4(y, y, w, y); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 yywz { get { return new vec4(y, y, w, z); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 yyww { get { return new vec4(y, y, w, w); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public vec4 yzxx { get { return new vec4(y, z, x, x); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 yzxy { get { return new vec4(y, z, x, y); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 yzxz { get { return new vec4(y, z, x, z); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 yzxw { get { return new vec4(y, z, x, w); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 yzyx { get { return new vec4(y, z, y, x); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 yzyy { get { return new vec4(y, z, y, y); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 yzyz { get { return new vec4(y, z, y, z); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 yzyw { get { return new vec4(y, z, y, w); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 yzzx { get { return new vec4(y, z, z, x); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 yzzy { get { return new vec4(y, z, z, y); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 yzzz { get { return new vec4(y, z, z, z); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 yzzw { get { return new vec4(y, z, z, w); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 yzwx { get { return new vec4(y, z, w, x); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 yzwy { get { return new vec4(y, z, w, y); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 yzwz { get { return new vec4(y, z, w, z); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 yzww { get { return new vec4(y, z, w, w); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public vec4 ywxx { get { return new vec4(y, w, x, x); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 ywxy { get { return new vec4(y, w, x, y); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 ywxz { get { return new vec4(y, w, x, z); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 ywxw { get { return new vec4(y, w, x, w); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 ywyx { get { return new vec4(y, w, y, x); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 ywyy { get { return new vec4(y, w, y, y); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 ywyz { get { return new vec4(y, w, y, z); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 ywyw { get { return new vec4(y, w, y, w); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 ywzx { get { return new vec4(y, w, z, x); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 ywzy { get { return new vec4(y, w, z, y); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 ywzz { get { return new vec4(y, w, z, z); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 ywzw { get { return new vec4(y, w, z, w); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 ywwx { get { return new vec4(y, w, w, x); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 ywwy { get { return new vec4(y, w, w, y); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 ywwz { get { return new vec4(y, w, w, z); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 ywww { get { return new vec4(y, w, w, w); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }
        public vec4 zxxx { get { return new vec4(z, x, x, x); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 zxxy { get { return new vec4(z, x, x, y); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 zxxz { get { return new vec4(z, x, x, z); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 zxxw { get { return new vec4(z, x, x, w); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 zxyx { get { return new vec4(z, x, y, x); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 zxyy { get { return new vec4(z, x, y, y); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 zxyz { get { return new vec4(z, x, y, z); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 zxyw { get { return new vec4(z, x, y, w); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 zxzx { get { return new vec4(z, x, z, x); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 zxzy { get { return new vec4(z, x, z, y); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 zxzz { get { return new vec4(z, x, z, z); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 zxzw { get { return new vec4(z, x, z, w); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 zxwx { get { return new vec4(z, x, w, x); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 zxwy { get { return new vec4(z, x, w, y); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 zxwz { get { return new vec4(z, x, w, z); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 zxww { get { return new vec4(z, x, w, w); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public vec4 zyxx { get { return new vec4(z, y, x, x); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 zyxy { get { return new vec4(z, y, x, y); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 zyxz { get { return new vec4(z, y, x, z); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 zyxw { get { return new vec4(z, y, x, w); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 zyyx { get { return new vec4(z, y, y, x); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 zyyy { get { return new vec4(z, y, y, y); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 zyyz { get { return new vec4(z, y, y, z); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 zyyw { get { return new vec4(z, y, y, w); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 zyzx { get { return new vec4(z, y, z, x); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 zyzy { get { return new vec4(z, y, z, y); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 zyzz { get { return new vec4(z, y, z, z); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 zyzw { get { return new vec4(z, y, z, w); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 zywx { get { return new vec4(z, y, w, x); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 zywy { get { return new vec4(z, y, w, y); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 zywz { get { return new vec4(z, y, w, z); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 zyww { get { return new vec4(z, y, w, w); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public vec4 zzxx { get { return new vec4(z, z, x, x); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 zzxy { get { return new vec4(z, z, x, y); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 zzxz { get { return new vec4(z, z, x, z); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 zzxw { get { return new vec4(z, z, x, w); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 zzyx { get { return new vec4(z, z, y, x); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 zzyy { get { return new vec4(z, z, y, y); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 zzyz { get { return new vec4(z, z, y, z); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 zzyw { get { return new vec4(z, z, y, w); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 zzzx { get { return new vec4(z, z, z, x); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 zzzy { get { return new vec4(z, z, z, y); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 zzzz { get { return new vec4(z, z, z, z); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 zzzw { get { return new vec4(z, z, z, w); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 zzwx { get { return new vec4(z, z, w, x); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 zzwy { get { return new vec4(z, z, w, y); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 zzwz { get { return new vec4(z, z, w, z); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 zzww { get { return new vec4(z, z, w, w); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public vec4 zwxx { get { return new vec4(z, w, x, x); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 zwxy { get { return new vec4(z, w, x, y); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 zwxz { get { return new vec4(z, w, x, z); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 zwxw { get { return new vec4(z, w, x, w); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 zwyx { get { return new vec4(z, w, y, x); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 zwyy { get { return new vec4(z, w, y, y); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 zwyz { get { return new vec4(z, w, y, z); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 zwyw { get { return new vec4(z, w, y, w); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 zwzx { get { return new vec4(z, w, z, x); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 zwzy { get { return new vec4(z, w, z, y); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 zwzz { get { return new vec4(z, w, z, z); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 zwzw { get { return new vec4(z, w, z, w); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 zwwx { get { return new vec4(z, w, w, x); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 zwwy { get { return new vec4(z, w, w, y); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 zwwz { get { return new vec4(z, w, w, z); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 zwww { get { return new vec4(z, w, w, w); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }
        public vec4 wxxx { get { return new vec4(w, x, x, x); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 wxxy { get { return new vec4(w, x, x, y); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 wxxz { get { return new vec4(w, x, x, z); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 wxxw { get { return new vec4(w, x, x, w); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 wxyx { get { return new vec4(w, x, y, x); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 wxyy { get { return new vec4(w, x, y, y); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 wxyz { get { return new vec4(w, x, y, z); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 wxyw { get { return new vec4(w, x, y, w); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 wxzx { get { return new vec4(w, x, z, x); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 wxzy { get { return new vec4(w, x, z, y); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 wxzz { get { return new vec4(w, x, z, z); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 wxzw { get { return new vec4(w, x, z, w); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 wxwx { get { return new vec4(w, x, w, x); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 wxwy { get { return new vec4(w, x, w, y); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 wxwz { get { return new vec4(w, x, w, z); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 wxww { get { return new vec4(w, x, w, w); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public vec4 wyxx { get { return new vec4(w, y, x, x); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 wyxy { get { return new vec4(w, y, x, y); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 wyxz { get { return new vec4(w, y, x, z); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 wyxw { get { return new vec4(w, y, x, w); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 wyyx { get { return new vec4(w, y, y, x); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 wyyy { get { return new vec4(w, y, y, y); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 wyyz { get { return new vec4(w, y, y, z); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 wyyw { get { return new vec4(w, y, y, w); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 wyzx { get { return new vec4(w, y, z, x); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 wyzy { get { return new vec4(w, y, z, y); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 wyzz { get { return new vec4(w, y, z, z); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 wyzw { get { return new vec4(w, y, z, w); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 wywx { get { return new vec4(w, y, w, x); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 wywy { get { return new vec4(w, y, w, y); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 wywz { get { return new vec4(w, y, w, z); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 wyww { get { return new vec4(w, y, w, w); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public vec4 wzxx { get { return new vec4(w, z, x, x); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 wzxy { get { return new vec4(w, z, x, y); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 wzxz { get { return new vec4(w, z, x, z); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 wzxw { get { return new vec4(w, z, x, w); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 wzyx { get { return new vec4(w, z, y, x); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 wzyy { get { return new vec4(w, z, y, y); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 wzyz { get { return new vec4(w, z, y, z); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 wzyw { get { return new vec4(w, z, y, w); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 wzzx { get { return new vec4(w, z, z, x); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 wzzy { get { return new vec4(w, z, z, y); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 wzzz { get { return new vec4(w, z, z, z); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 wzzw { get { return new vec4(w, z, z, w); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 wzwx { get { return new vec4(w, z, w, x); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 wzwy { get { return new vec4(w, z, w, y); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 wzwz { get { return new vec4(w, z, w, z); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 wzww { get { return new vec4(w, z, w, w); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public vec4 wwxx { get { return new vec4(w, w, x, x); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public vec4 wwxy { get { return new vec4(w, w, x, y); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public vec4 wwxz { get { return new vec4(w, w, x, z); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public vec4 wwxw { get { return new vec4(w, w, x, w); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public vec4 wwyx { get { return new vec4(w, w, y, x); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public vec4 wwyy { get { return new vec4(w, w, y, y); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public vec4 wwyz { get { return new vec4(w, w, y, z); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public vec4 wwyw { get { return new vec4(w, w, y, w); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public vec4 wwzx { get { return new vec4(w, w, z, x); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public vec4 wwzy { get { return new vec4(w, w, z, y); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public vec4 wwzz { get { return new vec4(w, w, z, z); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public vec4 wwzw { get { return new vec4(w, w, z, w); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public vec4 wwwx { get { return new vec4(w, w, w, x); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public vec4 wwwy { get { return new vec4(w, w, w, y); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public vec4 wwwz { get { return new vec4(w, w, w, z); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public vec4 wwww { get { return new vec4(w, w, w, w); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }

    }
}
