using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial struct uvec4 {
        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(uint) * 0)]
        public uint x;

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(uint) * 1)]
        public uint y;

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(uint) * 2)]
        public uint z;

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(uint) * 3)]
        public uint w;


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

        public uvec4 xxxx { get { return new uvec4(x, x, x, x); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 xxxy { get { return new uvec4(x, x, x, y); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 xxxz { get { return new uvec4(x, x, x, z); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 xxxw { get { return new uvec4(x, x, x, w); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 xxyx { get { return new uvec4(x, x, y, x); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 xxyy { get { return new uvec4(x, x, y, y); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 xxyz { get { return new uvec4(x, x, y, z); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 xxyw { get { return new uvec4(x, x, y, w); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 xxzx { get { return new uvec4(x, x, z, x); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 xxzy { get { return new uvec4(x, x, z, y); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 xxzz { get { return new uvec4(x, x, z, z); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 xxzw { get { return new uvec4(x, x, z, w); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 xxwx { get { return new uvec4(x, x, w, x); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 xxwy { get { return new uvec4(x, x, w, y); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 xxwz { get { return new uvec4(x, x, w, z); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 xxww { get { return new uvec4(x, x, w, w); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public uvec4 xyxx { get { return new uvec4(x, y, x, x); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 xyxy { get { return new uvec4(x, y, x, y); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 xyxz { get { return new uvec4(x, y, x, z); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 xyxw { get { return new uvec4(x, y, x, w); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 xyyx { get { return new uvec4(x, y, y, x); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 xyyy { get { return new uvec4(x, y, y, y); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 xyyz { get { return new uvec4(x, y, y, z); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 xyyw { get { return new uvec4(x, y, y, w); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 xyzx { get { return new uvec4(x, y, z, x); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 xyzy { get { return new uvec4(x, y, z, y); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 xyzz { get { return new uvec4(x, y, z, z); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 xyzw { get { return new uvec4(x, y, z, w); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 xywx { get { return new uvec4(x, y, w, x); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 xywy { get { return new uvec4(x, y, w, y); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 xywz { get { return new uvec4(x, y, w, z); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 xyww { get { return new uvec4(x, y, w, w); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public uvec4 xzxx { get { return new uvec4(x, z, x, x); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 xzxy { get { return new uvec4(x, z, x, y); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 xzxz { get { return new uvec4(x, z, x, z); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 xzxw { get { return new uvec4(x, z, x, w); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 xzyx { get { return new uvec4(x, z, y, x); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 xzyy { get { return new uvec4(x, z, y, y); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 xzyz { get { return new uvec4(x, z, y, z); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 xzyw { get { return new uvec4(x, z, y, w); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 xzzx { get { return new uvec4(x, z, z, x); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 xzzy { get { return new uvec4(x, z, z, y); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 xzzz { get { return new uvec4(x, z, z, z); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 xzzw { get { return new uvec4(x, z, z, w); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 xzwx { get { return new uvec4(x, z, w, x); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 xzwy { get { return new uvec4(x, z, w, y); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 xzwz { get { return new uvec4(x, z, w, z); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 xzww { get { return new uvec4(x, z, w, w); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public uvec4 xwxx { get { return new uvec4(x, w, x, x); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 xwxy { get { return new uvec4(x, w, x, y); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 xwxz { get { return new uvec4(x, w, x, z); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 xwxw { get { return new uvec4(x, w, x, w); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 xwyx { get { return new uvec4(x, w, y, x); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 xwyy { get { return new uvec4(x, w, y, y); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 xwyz { get { return new uvec4(x, w, y, z); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 xwyw { get { return new uvec4(x, w, y, w); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 xwzx { get { return new uvec4(x, w, z, x); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 xwzy { get { return new uvec4(x, w, z, y); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 xwzz { get { return new uvec4(x, w, z, z); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 xwzw { get { return new uvec4(x, w, z, w); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 xwwx { get { return new uvec4(x, w, w, x); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 xwwy { get { return new uvec4(x, w, w, y); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 xwwz { get { return new uvec4(x, w, w, z); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 xwww { get { return new uvec4(x, w, w, w); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }
        public uvec4 yxxx { get { return new uvec4(y, x, x, x); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 yxxy { get { return new uvec4(y, x, x, y); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 yxxz { get { return new uvec4(y, x, x, z); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 yxxw { get { return new uvec4(y, x, x, w); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 yxyx { get { return new uvec4(y, x, y, x); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 yxyy { get { return new uvec4(y, x, y, y); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 yxyz { get { return new uvec4(y, x, y, z); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 yxyw { get { return new uvec4(y, x, y, w); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 yxzx { get { return new uvec4(y, x, z, x); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 yxzy { get { return new uvec4(y, x, z, y); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 yxzz { get { return new uvec4(y, x, z, z); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 yxzw { get { return new uvec4(y, x, z, w); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 yxwx { get { return new uvec4(y, x, w, x); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 yxwy { get { return new uvec4(y, x, w, y); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 yxwz { get { return new uvec4(y, x, w, z); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 yxww { get { return new uvec4(y, x, w, w); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public uvec4 yyxx { get { return new uvec4(y, y, x, x); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 yyxy { get { return new uvec4(y, y, x, y); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 yyxz { get { return new uvec4(y, y, x, z); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 yyxw { get { return new uvec4(y, y, x, w); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 yyyx { get { return new uvec4(y, y, y, x); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 yyyy { get { return new uvec4(y, y, y, y); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 yyyz { get { return new uvec4(y, y, y, z); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 yyyw { get { return new uvec4(y, y, y, w); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 yyzx { get { return new uvec4(y, y, z, x); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 yyzy { get { return new uvec4(y, y, z, y); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 yyzz { get { return new uvec4(y, y, z, z); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 yyzw { get { return new uvec4(y, y, z, w); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 yywx { get { return new uvec4(y, y, w, x); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 yywy { get { return new uvec4(y, y, w, y); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 yywz { get { return new uvec4(y, y, w, z); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 yyww { get { return new uvec4(y, y, w, w); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public uvec4 yzxx { get { return new uvec4(y, z, x, x); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 yzxy { get { return new uvec4(y, z, x, y); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 yzxz { get { return new uvec4(y, z, x, z); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 yzxw { get { return new uvec4(y, z, x, w); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 yzyx { get { return new uvec4(y, z, y, x); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 yzyy { get { return new uvec4(y, z, y, y); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 yzyz { get { return new uvec4(y, z, y, z); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 yzyw { get { return new uvec4(y, z, y, w); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 yzzx { get { return new uvec4(y, z, z, x); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 yzzy { get { return new uvec4(y, z, z, y); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 yzzz { get { return new uvec4(y, z, z, z); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 yzzw { get { return new uvec4(y, z, z, w); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 yzwx { get { return new uvec4(y, z, w, x); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 yzwy { get { return new uvec4(y, z, w, y); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 yzwz { get { return new uvec4(y, z, w, z); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 yzww { get { return new uvec4(y, z, w, w); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public uvec4 ywxx { get { return new uvec4(y, w, x, x); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 ywxy { get { return new uvec4(y, w, x, y); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 ywxz { get { return new uvec4(y, w, x, z); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 ywxw { get { return new uvec4(y, w, x, w); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 ywyx { get { return new uvec4(y, w, y, x); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 ywyy { get { return new uvec4(y, w, y, y); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 ywyz { get { return new uvec4(y, w, y, z); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 ywyw { get { return new uvec4(y, w, y, w); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 ywzx { get { return new uvec4(y, w, z, x); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 ywzy { get { return new uvec4(y, w, z, y); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 ywzz { get { return new uvec4(y, w, z, z); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 ywzw { get { return new uvec4(y, w, z, w); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 ywwx { get { return new uvec4(y, w, w, x); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 ywwy { get { return new uvec4(y, w, w, y); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 ywwz { get { return new uvec4(y, w, w, z); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 ywww { get { return new uvec4(y, w, w, w); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }
        public uvec4 zxxx { get { return new uvec4(z, x, x, x); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 zxxy { get { return new uvec4(z, x, x, y); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 zxxz { get { return new uvec4(z, x, x, z); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 zxxw { get { return new uvec4(z, x, x, w); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 zxyx { get { return new uvec4(z, x, y, x); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 zxyy { get { return new uvec4(z, x, y, y); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 zxyz { get { return new uvec4(z, x, y, z); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 zxyw { get { return new uvec4(z, x, y, w); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 zxzx { get { return new uvec4(z, x, z, x); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 zxzy { get { return new uvec4(z, x, z, y); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 zxzz { get { return new uvec4(z, x, z, z); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 zxzw { get { return new uvec4(z, x, z, w); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 zxwx { get { return new uvec4(z, x, w, x); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 zxwy { get { return new uvec4(z, x, w, y); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 zxwz { get { return new uvec4(z, x, w, z); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 zxww { get { return new uvec4(z, x, w, w); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public uvec4 zyxx { get { return new uvec4(z, y, x, x); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 zyxy { get { return new uvec4(z, y, x, y); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 zyxz { get { return new uvec4(z, y, x, z); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 zyxw { get { return new uvec4(z, y, x, w); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 zyyx { get { return new uvec4(z, y, y, x); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 zyyy { get { return new uvec4(z, y, y, y); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 zyyz { get { return new uvec4(z, y, y, z); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 zyyw { get { return new uvec4(z, y, y, w); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 zyzx { get { return new uvec4(z, y, z, x); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 zyzy { get { return new uvec4(z, y, z, y); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 zyzz { get { return new uvec4(z, y, z, z); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 zyzw { get { return new uvec4(z, y, z, w); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 zywx { get { return new uvec4(z, y, w, x); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 zywy { get { return new uvec4(z, y, w, y); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 zywz { get { return new uvec4(z, y, w, z); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 zyww { get { return new uvec4(z, y, w, w); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public uvec4 zzxx { get { return new uvec4(z, z, x, x); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 zzxy { get { return new uvec4(z, z, x, y); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 zzxz { get { return new uvec4(z, z, x, z); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 zzxw { get { return new uvec4(z, z, x, w); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 zzyx { get { return new uvec4(z, z, y, x); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 zzyy { get { return new uvec4(z, z, y, y); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 zzyz { get { return new uvec4(z, z, y, z); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 zzyw { get { return new uvec4(z, z, y, w); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 zzzx { get { return new uvec4(z, z, z, x); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 zzzy { get { return new uvec4(z, z, z, y); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 zzzz { get { return new uvec4(z, z, z, z); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 zzzw { get { return new uvec4(z, z, z, w); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 zzwx { get { return new uvec4(z, z, w, x); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 zzwy { get { return new uvec4(z, z, w, y); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 zzwz { get { return new uvec4(z, z, w, z); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 zzww { get { return new uvec4(z, z, w, w); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public uvec4 zwxx { get { return new uvec4(z, w, x, x); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 zwxy { get { return new uvec4(z, w, x, y); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 zwxz { get { return new uvec4(z, w, x, z); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 zwxw { get { return new uvec4(z, w, x, w); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 zwyx { get { return new uvec4(z, w, y, x); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 zwyy { get { return new uvec4(z, w, y, y); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 zwyz { get { return new uvec4(z, w, y, z); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 zwyw { get { return new uvec4(z, w, y, w); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 zwzx { get { return new uvec4(z, w, z, x); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 zwzy { get { return new uvec4(z, w, z, y); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 zwzz { get { return new uvec4(z, w, z, z); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 zwzw { get { return new uvec4(z, w, z, w); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 zwwx { get { return new uvec4(z, w, w, x); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 zwwy { get { return new uvec4(z, w, w, y); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 zwwz { get { return new uvec4(z, w, w, z); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 zwww { get { return new uvec4(z, w, w, w); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }
        public uvec4 wxxx { get { return new uvec4(w, x, x, x); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 wxxy { get { return new uvec4(w, x, x, y); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 wxxz { get { return new uvec4(w, x, x, z); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 wxxw { get { return new uvec4(w, x, x, w); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 wxyx { get { return new uvec4(w, x, y, x); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 wxyy { get { return new uvec4(w, x, y, y); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 wxyz { get { return new uvec4(w, x, y, z); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 wxyw { get { return new uvec4(w, x, y, w); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 wxzx { get { return new uvec4(w, x, z, x); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 wxzy { get { return new uvec4(w, x, z, y); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 wxzz { get { return new uvec4(w, x, z, z); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 wxzw { get { return new uvec4(w, x, z, w); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 wxwx { get { return new uvec4(w, x, w, x); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 wxwy { get { return new uvec4(w, x, w, y); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 wxwz { get { return new uvec4(w, x, w, z); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 wxww { get { return new uvec4(w, x, w, w); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public uvec4 wyxx { get { return new uvec4(w, y, x, x); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 wyxy { get { return new uvec4(w, y, x, y); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 wyxz { get { return new uvec4(w, y, x, z); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 wyxw { get { return new uvec4(w, y, x, w); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 wyyx { get { return new uvec4(w, y, y, x); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 wyyy { get { return new uvec4(w, y, y, y); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 wyyz { get { return new uvec4(w, y, y, z); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 wyyw { get { return new uvec4(w, y, y, w); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 wyzx { get { return new uvec4(w, y, z, x); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 wyzy { get { return new uvec4(w, y, z, y); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 wyzz { get { return new uvec4(w, y, z, z); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 wyzw { get { return new uvec4(w, y, z, w); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 wywx { get { return new uvec4(w, y, w, x); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 wywy { get { return new uvec4(w, y, w, y); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 wywz { get { return new uvec4(w, y, w, z); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 wyww { get { return new uvec4(w, y, w, w); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public uvec4 wzxx { get { return new uvec4(w, z, x, x); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 wzxy { get { return new uvec4(w, z, x, y); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 wzxz { get { return new uvec4(w, z, x, z); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 wzxw { get { return new uvec4(w, z, x, w); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 wzyx { get { return new uvec4(w, z, y, x); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 wzyy { get { return new uvec4(w, z, y, y); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 wzyz { get { return new uvec4(w, z, y, z); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 wzyw { get { return new uvec4(w, z, y, w); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 wzzx { get { return new uvec4(w, z, z, x); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 wzzy { get { return new uvec4(w, z, z, y); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 wzzz { get { return new uvec4(w, z, z, z); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 wzzw { get { return new uvec4(w, z, z, w); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 wzwx { get { return new uvec4(w, z, w, x); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 wzwy { get { return new uvec4(w, z, w, y); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 wzwz { get { return new uvec4(w, z, w, z); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 wzww { get { return new uvec4(w, z, w, w); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public uvec4 wwxx { get { return new uvec4(w, w, x, x); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public uvec4 wwxy { get { return new uvec4(w, w, x, y); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public uvec4 wwxz { get { return new uvec4(w, w, x, z); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public uvec4 wwxw { get { return new uvec4(w, w, x, w); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public uvec4 wwyx { get { return new uvec4(w, w, y, x); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public uvec4 wwyy { get { return new uvec4(w, w, y, y); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public uvec4 wwyz { get { return new uvec4(w, w, y, z); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public uvec4 wwyw { get { return new uvec4(w, w, y, w); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public uvec4 wwzx { get { return new uvec4(w, w, z, x); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public uvec4 wwzy { get { return new uvec4(w, w, z, y); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public uvec4 wwzz { get { return new uvec4(w, w, z, z); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public uvec4 wwzw { get { return new uvec4(w, w, z, w); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public uvec4 wwwx { get { return new uvec4(w, w, w, x); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public uvec4 wwwy { get { return new uvec4(w, w, w, y); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public uvec4 wwwz { get { return new uvec4(w, w, w, z); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public uvec4 wwww { get { return new uvec4(w, w, w, w); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }

    }
}
