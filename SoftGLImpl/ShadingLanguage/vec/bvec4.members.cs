using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial struct bvec4 {
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

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(bool) * 3)]
        public bool w;


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

        public bvec4 xxxx { get { return new bvec4(x, x, x, x); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 xxxy { get { return new bvec4(x, x, x, y); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 xxxz { get { return new bvec4(x, x, x, z); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 xxxw { get { return new bvec4(x, x, x, w); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 xxyx { get { return new bvec4(x, x, y, x); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 xxyy { get { return new bvec4(x, x, y, y); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 xxyz { get { return new bvec4(x, x, y, z); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 xxyw { get { return new bvec4(x, x, y, w); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 xxzx { get { return new bvec4(x, x, z, x); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 xxzy { get { return new bvec4(x, x, z, y); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 xxzz { get { return new bvec4(x, x, z, z); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 xxzw { get { return new bvec4(x, x, z, w); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 xxwx { get { return new bvec4(x, x, w, x); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 xxwy { get { return new bvec4(x, x, w, y); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 xxwz { get { return new bvec4(x, x, w, z); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 xxww { get { return new bvec4(x, x, w, w); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public bvec4 xyxx { get { return new bvec4(x, y, x, x); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 xyxy { get { return new bvec4(x, y, x, y); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 xyxz { get { return new bvec4(x, y, x, z); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 xyxw { get { return new bvec4(x, y, x, w); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 xyyx { get { return new bvec4(x, y, y, x); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 xyyy { get { return new bvec4(x, y, y, y); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 xyyz { get { return new bvec4(x, y, y, z); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 xyyw { get { return new bvec4(x, y, y, w); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 xyzx { get { return new bvec4(x, y, z, x); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 xyzy { get { return new bvec4(x, y, z, y); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 xyzz { get { return new bvec4(x, y, z, z); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 xyzw { get { return new bvec4(x, y, z, w); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 xywx { get { return new bvec4(x, y, w, x); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 xywy { get { return new bvec4(x, y, w, y); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 xywz { get { return new bvec4(x, y, w, z); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 xyww { get { return new bvec4(x, y, w, w); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public bvec4 xzxx { get { return new bvec4(x, z, x, x); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 xzxy { get { return new bvec4(x, z, x, y); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 xzxz { get { return new bvec4(x, z, x, z); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 xzxw { get { return new bvec4(x, z, x, w); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 xzyx { get { return new bvec4(x, z, y, x); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 xzyy { get { return new bvec4(x, z, y, y); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 xzyz { get { return new bvec4(x, z, y, z); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 xzyw { get { return new bvec4(x, z, y, w); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 xzzx { get { return new bvec4(x, z, z, x); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 xzzy { get { return new bvec4(x, z, z, y); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 xzzz { get { return new bvec4(x, z, z, z); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 xzzw { get { return new bvec4(x, z, z, w); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 xzwx { get { return new bvec4(x, z, w, x); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 xzwy { get { return new bvec4(x, z, w, y); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 xzwz { get { return new bvec4(x, z, w, z); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 xzww { get { return new bvec4(x, z, w, w); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public bvec4 xwxx { get { return new bvec4(x, w, x, x); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 xwxy { get { return new bvec4(x, w, x, y); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 xwxz { get { return new bvec4(x, w, x, z); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 xwxw { get { return new bvec4(x, w, x, w); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 xwyx { get { return new bvec4(x, w, y, x); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 xwyy { get { return new bvec4(x, w, y, y); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 xwyz { get { return new bvec4(x, w, y, z); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 xwyw { get { return new bvec4(x, w, y, w); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 xwzx { get { return new bvec4(x, w, z, x); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 xwzy { get { return new bvec4(x, w, z, y); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 xwzz { get { return new bvec4(x, w, z, z); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 xwzw { get { return new bvec4(x, w, z, w); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 xwwx { get { return new bvec4(x, w, w, x); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 xwwy { get { return new bvec4(x, w, w, y); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 xwwz { get { return new bvec4(x, w, w, z); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 xwww { get { return new bvec4(x, w, w, w); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }
        public bvec4 yxxx { get { return new bvec4(y, x, x, x); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 yxxy { get { return new bvec4(y, x, x, y); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 yxxz { get { return new bvec4(y, x, x, z); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 yxxw { get { return new bvec4(y, x, x, w); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 yxyx { get { return new bvec4(y, x, y, x); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 yxyy { get { return new bvec4(y, x, y, y); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 yxyz { get { return new bvec4(y, x, y, z); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 yxyw { get { return new bvec4(y, x, y, w); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 yxzx { get { return new bvec4(y, x, z, x); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 yxzy { get { return new bvec4(y, x, z, y); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 yxzz { get { return new bvec4(y, x, z, z); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 yxzw { get { return new bvec4(y, x, z, w); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 yxwx { get { return new bvec4(y, x, w, x); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 yxwy { get { return new bvec4(y, x, w, y); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 yxwz { get { return new bvec4(y, x, w, z); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 yxww { get { return new bvec4(y, x, w, w); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public bvec4 yyxx { get { return new bvec4(y, y, x, x); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 yyxy { get { return new bvec4(y, y, x, y); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 yyxz { get { return new bvec4(y, y, x, z); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 yyxw { get { return new bvec4(y, y, x, w); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 yyyx { get { return new bvec4(y, y, y, x); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 yyyy { get { return new bvec4(y, y, y, y); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 yyyz { get { return new bvec4(y, y, y, z); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 yyyw { get { return new bvec4(y, y, y, w); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 yyzx { get { return new bvec4(y, y, z, x); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 yyzy { get { return new bvec4(y, y, z, y); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 yyzz { get { return new bvec4(y, y, z, z); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 yyzw { get { return new bvec4(y, y, z, w); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 yywx { get { return new bvec4(y, y, w, x); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 yywy { get { return new bvec4(y, y, w, y); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 yywz { get { return new bvec4(y, y, w, z); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 yyww { get { return new bvec4(y, y, w, w); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public bvec4 yzxx { get { return new bvec4(y, z, x, x); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 yzxy { get { return new bvec4(y, z, x, y); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 yzxz { get { return new bvec4(y, z, x, z); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 yzxw { get { return new bvec4(y, z, x, w); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 yzyx { get { return new bvec4(y, z, y, x); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 yzyy { get { return new bvec4(y, z, y, y); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 yzyz { get { return new bvec4(y, z, y, z); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 yzyw { get { return new bvec4(y, z, y, w); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 yzzx { get { return new bvec4(y, z, z, x); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 yzzy { get { return new bvec4(y, z, z, y); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 yzzz { get { return new bvec4(y, z, z, z); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 yzzw { get { return new bvec4(y, z, z, w); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 yzwx { get { return new bvec4(y, z, w, x); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 yzwy { get { return new bvec4(y, z, w, y); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 yzwz { get { return new bvec4(y, z, w, z); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 yzww { get { return new bvec4(y, z, w, w); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public bvec4 ywxx { get { return new bvec4(y, w, x, x); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 ywxy { get { return new bvec4(y, w, x, y); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 ywxz { get { return new bvec4(y, w, x, z); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 ywxw { get { return new bvec4(y, w, x, w); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 ywyx { get { return new bvec4(y, w, y, x); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 ywyy { get { return new bvec4(y, w, y, y); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 ywyz { get { return new bvec4(y, w, y, z); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 ywyw { get { return new bvec4(y, w, y, w); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 ywzx { get { return new bvec4(y, w, z, x); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 ywzy { get { return new bvec4(y, w, z, y); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 ywzz { get { return new bvec4(y, w, z, z); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 ywzw { get { return new bvec4(y, w, z, w); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 ywwx { get { return new bvec4(y, w, w, x); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 ywwy { get { return new bvec4(y, w, w, y); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 ywwz { get { return new bvec4(y, w, w, z); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 ywww { get { return new bvec4(y, w, w, w); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }
        public bvec4 zxxx { get { return new bvec4(z, x, x, x); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 zxxy { get { return new bvec4(z, x, x, y); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 zxxz { get { return new bvec4(z, x, x, z); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 zxxw { get { return new bvec4(z, x, x, w); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 zxyx { get { return new bvec4(z, x, y, x); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 zxyy { get { return new bvec4(z, x, y, y); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 zxyz { get { return new bvec4(z, x, y, z); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 zxyw { get { return new bvec4(z, x, y, w); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 zxzx { get { return new bvec4(z, x, z, x); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 zxzy { get { return new bvec4(z, x, z, y); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 zxzz { get { return new bvec4(z, x, z, z); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 zxzw { get { return new bvec4(z, x, z, w); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 zxwx { get { return new bvec4(z, x, w, x); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 zxwy { get { return new bvec4(z, x, w, y); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 zxwz { get { return new bvec4(z, x, w, z); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 zxww { get { return new bvec4(z, x, w, w); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public bvec4 zyxx { get { return new bvec4(z, y, x, x); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 zyxy { get { return new bvec4(z, y, x, y); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 zyxz { get { return new bvec4(z, y, x, z); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 zyxw { get { return new bvec4(z, y, x, w); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 zyyx { get { return new bvec4(z, y, y, x); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 zyyy { get { return new bvec4(z, y, y, y); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 zyyz { get { return new bvec4(z, y, y, z); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 zyyw { get { return new bvec4(z, y, y, w); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 zyzx { get { return new bvec4(z, y, z, x); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 zyzy { get { return new bvec4(z, y, z, y); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 zyzz { get { return new bvec4(z, y, z, z); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 zyzw { get { return new bvec4(z, y, z, w); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 zywx { get { return new bvec4(z, y, w, x); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 zywy { get { return new bvec4(z, y, w, y); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 zywz { get { return new bvec4(z, y, w, z); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 zyww { get { return new bvec4(z, y, w, w); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public bvec4 zzxx { get { return new bvec4(z, z, x, x); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 zzxy { get { return new bvec4(z, z, x, y); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 zzxz { get { return new bvec4(z, z, x, z); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 zzxw { get { return new bvec4(z, z, x, w); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 zzyx { get { return new bvec4(z, z, y, x); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 zzyy { get { return new bvec4(z, z, y, y); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 zzyz { get { return new bvec4(z, z, y, z); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 zzyw { get { return new bvec4(z, z, y, w); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 zzzx { get { return new bvec4(z, z, z, x); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 zzzy { get { return new bvec4(z, z, z, y); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 zzzz { get { return new bvec4(z, z, z, z); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 zzzw { get { return new bvec4(z, z, z, w); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 zzwx { get { return new bvec4(z, z, w, x); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 zzwy { get { return new bvec4(z, z, w, y); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 zzwz { get { return new bvec4(z, z, w, z); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 zzww { get { return new bvec4(z, z, w, w); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public bvec4 zwxx { get { return new bvec4(z, w, x, x); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 zwxy { get { return new bvec4(z, w, x, y); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 zwxz { get { return new bvec4(z, w, x, z); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 zwxw { get { return new bvec4(z, w, x, w); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 zwyx { get { return new bvec4(z, w, y, x); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 zwyy { get { return new bvec4(z, w, y, y); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 zwyz { get { return new bvec4(z, w, y, z); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 zwyw { get { return new bvec4(z, w, y, w); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 zwzx { get { return new bvec4(z, w, z, x); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 zwzy { get { return new bvec4(z, w, z, y); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 zwzz { get { return new bvec4(z, w, z, z); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 zwzw { get { return new bvec4(z, w, z, w); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 zwwx { get { return new bvec4(z, w, w, x); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 zwwy { get { return new bvec4(z, w, w, y); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 zwwz { get { return new bvec4(z, w, w, z); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 zwww { get { return new bvec4(z, w, w, w); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }
        public bvec4 wxxx { get { return new bvec4(w, x, x, x); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 wxxy { get { return new bvec4(w, x, x, y); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 wxxz { get { return new bvec4(w, x, x, z); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 wxxw { get { return new bvec4(w, x, x, w); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 wxyx { get { return new bvec4(w, x, y, x); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 wxyy { get { return new bvec4(w, x, y, y); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 wxyz { get { return new bvec4(w, x, y, z); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 wxyw { get { return new bvec4(w, x, y, w); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 wxzx { get { return new bvec4(w, x, z, x); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 wxzy { get { return new bvec4(w, x, z, y); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 wxzz { get { return new bvec4(w, x, z, z); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 wxzw { get { return new bvec4(w, x, z, w); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 wxwx { get { return new bvec4(w, x, w, x); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 wxwy { get { return new bvec4(w, x, w, y); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 wxwz { get { return new bvec4(w, x, w, z); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 wxww { get { return new bvec4(w, x, w, w); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public bvec4 wyxx { get { return new bvec4(w, y, x, x); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 wyxy { get { return new bvec4(w, y, x, y); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 wyxz { get { return new bvec4(w, y, x, z); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 wyxw { get { return new bvec4(w, y, x, w); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 wyyx { get { return new bvec4(w, y, y, x); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 wyyy { get { return new bvec4(w, y, y, y); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 wyyz { get { return new bvec4(w, y, y, z); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 wyyw { get { return new bvec4(w, y, y, w); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 wyzx { get { return new bvec4(w, y, z, x); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 wyzy { get { return new bvec4(w, y, z, y); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 wyzz { get { return new bvec4(w, y, z, z); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 wyzw { get { return new bvec4(w, y, z, w); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 wywx { get { return new bvec4(w, y, w, x); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 wywy { get { return new bvec4(w, y, w, y); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 wywz { get { return new bvec4(w, y, w, z); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 wyww { get { return new bvec4(w, y, w, w); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public bvec4 wzxx { get { return new bvec4(w, z, x, x); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 wzxy { get { return new bvec4(w, z, x, y); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 wzxz { get { return new bvec4(w, z, x, z); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 wzxw { get { return new bvec4(w, z, x, w); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 wzyx { get { return new bvec4(w, z, y, x); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 wzyy { get { return new bvec4(w, z, y, y); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 wzyz { get { return new bvec4(w, z, y, z); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 wzyw { get { return new bvec4(w, z, y, w); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 wzzx { get { return new bvec4(w, z, z, x); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 wzzy { get { return new bvec4(w, z, z, y); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 wzzz { get { return new bvec4(w, z, z, z); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 wzzw { get { return new bvec4(w, z, z, w); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 wzwx { get { return new bvec4(w, z, w, x); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 wzwy { get { return new bvec4(w, z, w, y); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 wzwz { get { return new bvec4(w, z, w, z); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 wzww { get { return new bvec4(w, z, w, w); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public bvec4 wwxx { get { return new bvec4(w, w, x, x); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public bvec4 wwxy { get { return new bvec4(w, w, x, y); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public bvec4 wwxz { get { return new bvec4(w, w, x, z); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public bvec4 wwxw { get { return new bvec4(w, w, x, w); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public bvec4 wwyx { get { return new bvec4(w, w, y, x); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public bvec4 wwyy { get { return new bvec4(w, w, y, y); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public bvec4 wwyz { get { return new bvec4(w, w, y, z); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public bvec4 wwyw { get { return new bvec4(w, w, y, w); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public bvec4 wwzx { get { return new bvec4(w, w, z, x); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public bvec4 wwzy { get { return new bvec4(w, w, z, y); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public bvec4 wwzz { get { return new bvec4(w, w, z, z); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public bvec4 wwzw { get { return new bvec4(w, w, z, w); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public bvec4 wwwx { get { return new bvec4(w, w, w, x); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public bvec4 wwwy { get { return new bvec4(w, w, w, y); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public bvec4 wwwz { get { return new bvec4(w, w, w, z); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public bvec4 wwww { get { return new bvec4(w, w, w, w); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }

    }
}
