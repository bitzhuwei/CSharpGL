using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial struct dvec4 {
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

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(double) * 3)]
        public double w;


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

        public dvec4 xxxx { get { return new dvec4(x, x, x, x); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 xxxy { get { return new dvec4(x, x, x, y); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 xxxz { get { return new dvec4(x, x, x, z); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 xxxw { get { return new dvec4(x, x, x, w); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 xxyx { get { return new dvec4(x, x, y, x); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 xxyy { get { return new dvec4(x, x, y, y); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 xxyz { get { return new dvec4(x, x, y, z); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 xxyw { get { return new dvec4(x, x, y, w); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 xxzx { get { return new dvec4(x, x, z, x); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 xxzy { get { return new dvec4(x, x, z, y); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 xxzz { get { return new dvec4(x, x, z, z); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 xxzw { get { return new dvec4(x, x, z, w); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 xxwx { get { return new dvec4(x, x, w, x); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 xxwy { get { return new dvec4(x, x, w, y); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 xxwz { get { return new dvec4(x, x, w, z); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 xxww { get { return new dvec4(x, x, w, w); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public dvec4 xyxx { get { return new dvec4(x, y, x, x); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 xyxy { get { return new dvec4(x, y, x, y); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 xyxz { get { return new dvec4(x, y, x, z); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 xyxw { get { return new dvec4(x, y, x, w); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 xyyx { get { return new dvec4(x, y, y, x); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 xyyy { get { return new dvec4(x, y, y, y); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 xyyz { get { return new dvec4(x, y, y, z); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 xyyw { get { return new dvec4(x, y, y, w); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 xyzx { get { return new dvec4(x, y, z, x); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 xyzy { get { return new dvec4(x, y, z, y); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 xyzz { get { return new dvec4(x, y, z, z); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 xyzw { get { return new dvec4(x, y, z, w); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 xywx { get { return new dvec4(x, y, w, x); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 xywy { get { return new dvec4(x, y, w, y); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 xywz { get { return new dvec4(x, y, w, z); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 xyww { get { return new dvec4(x, y, w, w); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public dvec4 xzxx { get { return new dvec4(x, z, x, x); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 xzxy { get { return new dvec4(x, z, x, y); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 xzxz { get { return new dvec4(x, z, x, z); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 xzxw { get { return new dvec4(x, z, x, w); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 xzyx { get { return new dvec4(x, z, y, x); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 xzyy { get { return new dvec4(x, z, y, y); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 xzyz { get { return new dvec4(x, z, y, z); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 xzyw { get { return new dvec4(x, z, y, w); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 xzzx { get { return new dvec4(x, z, z, x); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 xzzy { get { return new dvec4(x, z, z, y); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 xzzz { get { return new dvec4(x, z, z, z); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 xzzw { get { return new dvec4(x, z, z, w); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 xzwx { get { return new dvec4(x, z, w, x); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 xzwy { get { return new dvec4(x, z, w, y); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 xzwz { get { return new dvec4(x, z, w, z); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 xzww { get { return new dvec4(x, z, w, w); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public dvec4 xwxx { get { return new dvec4(x, w, x, x); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 xwxy { get { return new dvec4(x, w, x, y); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 xwxz { get { return new dvec4(x, w, x, z); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 xwxw { get { return new dvec4(x, w, x, w); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 xwyx { get { return new dvec4(x, w, y, x); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 xwyy { get { return new dvec4(x, w, y, y); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 xwyz { get { return new dvec4(x, w, y, z); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 xwyw { get { return new dvec4(x, w, y, w); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 xwzx { get { return new dvec4(x, w, z, x); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 xwzy { get { return new dvec4(x, w, z, y); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 xwzz { get { return new dvec4(x, w, z, z); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 xwzw { get { return new dvec4(x, w, z, w); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 xwwx { get { return new dvec4(x, w, w, x); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 xwwy { get { return new dvec4(x, w, w, y); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 xwwz { get { return new dvec4(x, w, w, z); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 xwww { get { return new dvec4(x, w, w, w); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }
        public dvec4 yxxx { get { return new dvec4(y, x, x, x); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 yxxy { get { return new dvec4(y, x, x, y); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 yxxz { get { return new dvec4(y, x, x, z); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 yxxw { get { return new dvec4(y, x, x, w); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 yxyx { get { return new dvec4(y, x, y, x); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 yxyy { get { return new dvec4(y, x, y, y); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 yxyz { get { return new dvec4(y, x, y, z); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 yxyw { get { return new dvec4(y, x, y, w); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 yxzx { get { return new dvec4(y, x, z, x); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 yxzy { get { return new dvec4(y, x, z, y); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 yxzz { get { return new dvec4(y, x, z, z); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 yxzw { get { return new dvec4(y, x, z, w); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 yxwx { get { return new dvec4(y, x, w, x); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 yxwy { get { return new dvec4(y, x, w, y); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 yxwz { get { return new dvec4(y, x, w, z); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 yxww { get { return new dvec4(y, x, w, w); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public dvec4 yyxx { get { return new dvec4(y, y, x, x); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 yyxy { get { return new dvec4(y, y, x, y); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 yyxz { get { return new dvec4(y, y, x, z); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 yyxw { get { return new dvec4(y, y, x, w); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 yyyx { get { return new dvec4(y, y, y, x); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 yyyy { get { return new dvec4(y, y, y, y); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 yyyz { get { return new dvec4(y, y, y, z); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 yyyw { get { return new dvec4(y, y, y, w); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 yyzx { get { return new dvec4(y, y, z, x); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 yyzy { get { return new dvec4(y, y, z, y); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 yyzz { get { return new dvec4(y, y, z, z); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 yyzw { get { return new dvec4(y, y, z, w); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 yywx { get { return new dvec4(y, y, w, x); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 yywy { get { return new dvec4(y, y, w, y); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 yywz { get { return new dvec4(y, y, w, z); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 yyww { get { return new dvec4(y, y, w, w); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public dvec4 yzxx { get { return new dvec4(y, z, x, x); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 yzxy { get { return new dvec4(y, z, x, y); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 yzxz { get { return new dvec4(y, z, x, z); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 yzxw { get { return new dvec4(y, z, x, w); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 yzyx { get { return new dvec4(y, z, y, x); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 yzyy { get { return new dvec4(y, z, y, y); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 yzyz { get { return new dvec4(y, z, y, z); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 yzyw { get { return new dvec4(y, z, y, w); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 yzzx { get { return new dvec4(y, z, z, x); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 yzzy { get { return new dvec4(y, z, z, y); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 yzzz { get { return new dvec4(y, z, z, z); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 yzzw { get { return new dvec4(y, z, z, w); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 yzwx { get { return new dvec4(y, z, w, x); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 yzwy { get { return new dvec4(y, z, w, y); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 yzwz { get { return new dvec4(y, z, w, z); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 yzww { get { return new dvec4(y, z, w, w); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public dvec4 ywxx { get { return new dvec4(y, w, x, x); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 ywxy { get { return new dvec4(y, w, x, y); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 ywxz { get { return new dvec4(y, w, x, z); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 ywxw { get { return new dvec4(y, w, x, w); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 ywyx { get { return new dvec4(y, w, y, x); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 ywyy { get { return new dvec4(y, w, y, y); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 ywyz { get { return new dvec4(y, w, y, z); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 ywyw { get { return new dvec4(y, w, y, w); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 ywzx { get { return new dvec4(y, w, z, x); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 ywzy { get { return new dvec4(y, w, z, y); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 ywzz { get { return new dvec4(y, w, z, z); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 ywzw { get { return new dvec4(y, w, z, w); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 ywwx { get { return new dvec4(y, w, w, x); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 ywwy { get { return new dvec4(y, w, w, y); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 ywwz { get { return new dvec4(y, w, w, z); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 ywww { get { return new dvec4(y, w, w, w); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }
        public dvec4 zxxx { get { return new dvec4(z, x, x, x); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 zxxy { get { return new dvec4(z, x, x, y); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 zxxz { get { return new dvec4(z, x, x, z); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 zxxw { get { return new dvec4(z, x, x, w); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 zxyx { get { return new dvec4(z, x, y, x); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 zxyy { get { return new dvec4(z, x, y, y); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 zxyz { get { return new dvec4(z, x, y, z); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 zxyw { get { return new dvec4(z, x, y, w); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 zxzx { get { return new dvec4(z, x, z, x); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 zxzy { get { return new dvec4(z, x, z, y); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 zxzz { get { return new dvec4(z, x, z, z); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 zxzw { get { return new dvec4(z, x, z, w); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 zxwx { get { return new dvec4(z, x, w, x); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 zxwy { get { return new dvec4(z, x, w, y); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 zxwz { get { return new dvec4(z, x, w, z); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 zxww { get { return new dvec4(z, x, w, w); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public dvec4 zyxx { get { return new dvec4(z, y, x, x); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 zyxy { get { return new dvec4(z, y, x, y); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 zyxz { get { return new dvec4(z, y, x, z); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 zyxw { get { return new dvec4(z, y, x, w); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 zyyx { get { return new dvec4(z, y, y, x); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 zyyy { get { return new dvec4(z, y, y, y); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 zyyz { get { return new dvec4(z, y, y, z); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 zyyw { get { return new dvec4(z, y, y, w); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 zyzx { get { return new dvec4(z, y, z, x); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 zyzy { get { return new dvec4(z, y, z, y); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 zyzz { get { return new dvec4(z, y, z, z); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 zyzw { get { return new dvec4(z, y, z, w); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 zywx { get { return new dvec4(z, y, w, x); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 zywy { get { return new dvec4(z, y, w, y); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 zywz { get { return new dvec4(z, y, w, z); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 zyww { get { return new dvec4(z, y, w, w); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public dvec4 zzxx { get { return new dvec4(z, z, x, x); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 zzxy { get { return new dvec4(z, z, x, y); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 zzxz { get { return new dvec4(z, z, x, z); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 zzxw { get { return new dvec4(z, z, x, w); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 zzyx { get { return new dvec4(z, z, y, x); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 zzyy { get { return new dvec4(z, z, y, y); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 zzyz { get { return new dvec4(z, z, y, z); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 zzyw { get { return new dvec4(z, z, y, w); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 zzzx { get { return new dvec4(z, z, z, x); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 zzzy { get { return new dvec4(z, z, z, y); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 zzzz { get { return new dvec4(z, z, z, z); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 zzzw { get { return new dvec4(z, z, z, w); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 zzwx { get { return new dvec4(z, z, w, x); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 zzwy { get { return new dvec4(z, z, w, y); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 zzwz { get { return new dvec4(z, z, w, z); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 zzww { get { return new dvec4(z, z, w, w); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public dvec4 zwxx { get { return new dvec4(z, w, x, x); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 zwxy { get { return new dvec4(z, w, x, y); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 zwxz { get { return new dvec4(z, w, x, z); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 zwxw { get { return new dvec4(z, w, x, w); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 zwyx { get { return new dvec4(z, w, y, x); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 zwyy { get { return new dvec4(z, w, y, y); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 zwyz { get { return new dvec4(z, w, y, z); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 zwyw { get { return new dvec4(z, w, y, w); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 zwzx { get { return new dvec4(z, w, z, x); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 zwzy { get { return new dvec4(z, w, z, y); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 zwzz { get { return new dvec4(z, w, z, z); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 zwzw { get { return new dvec4(z, w, z, w); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 zwwx { get { return new dvec4(z, w, w, x); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 zwwy { get { return new dvec4(z, w, w, y); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 zwwz { get { return new dvec4(z, w, w, z); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 zwww { get { return new dvec4(z, w, w, w); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }
        public dvec4 wxxx { get { return new dvec4(w, x, x, x); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 wxxy { get { return new dvec4(w, x, x, y); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 wxxz { get { return new dvec4(w, x, x, z); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 wxxw { get { return new dvec4(w, x, x, w); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 wxyx { get { return new dvec4(w, x, y, x); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 wxyy { get { return new dvec4(w, x, y, y); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 wxyz { get { return new dvec4(w, x, y, z); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 wxyw { get { return new dvec4(w, x, y, w); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 wxzx { get { return new dvec4(w, x, z, x); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 wxzy { get { return new dvec4(w, x, z, y); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 wxzz { get { return new dvec4(w, x, z, z); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 wxzw { get { return new dvec4(w, x, z, w); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 wxwx { get { return new dvec4(w, x, w, x); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 wxwy { get { return new dvec4(w, x, w, y); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 wxwz { get { return new dvec4(w, x, w, z); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 wxww { get { return new dvec4(w, x, w, w); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public dvec4 wyxx { get { return new dvec4(w, y, x, x); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 wyxy { get { return new dvec4(w, y, x, y); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 wyxz { get { return new dvec4(w, y, x, z); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 wyxw { get { return new dvec4(w, y, x, w); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 wyyx { get { return new dvec4(w, y, y, x); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 wyyy { get { return new dvec4(w, y, y, y); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 wyyz { get { return new dvec4(w, y, y, z); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 wyyw { get { return new dvec4(w, y, y, w); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 wyzx { get { return new dvec4(w, y, z, x); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 wyzy { get { return new dvec4(w, y, z, y); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 wyzz { get { return new dvec4(w, y, z, z); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 wyzw { get { return new dvec4(w, y, z, w); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 wywx { get { return new dvec4(w, y, w, x); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 wywy { get { return new dvec4(w, y, w, y); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 wywz { get { return new dvec4(w, y, w, z); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 wyww { get { return new dvec4(w, y, w, w); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public dvec4 wzxx { get { return new dvec4(w, z, x, x); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 wzxy { get { return new dvec4(w, z, x, y); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 wzxz { get { return new dvec4(w, z, x, z); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 wzxw { get { return new dvec4(w, z, x, w); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 wzyx { get { return new dvec4(w, z, y, x); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 wzyy { get { return new dvec4(w, z, y, y); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 wzyz { get { return new dvec4(w, z, y, z); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 wzyw { get { return new dvec4(w, z, y, w); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 wzzx { get { return new dvec4(w, z, z, x); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 wzzy { get { return new dvec4(w, z, z, y); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 wzzz { get { return new dvec4(w, z, z, z); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 wzzw { get { return new dvec4(w, z, z, w); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 wzwx { get { return new dvec4(w, z, w, x); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 wzwy { get { return new dvec4(w, z, w, y); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 wzwz { get { return new dvec4(w, z, w, z); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 wzww { get { return new dvec4(w, z, w, w); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public dvec4 wwxx { get { return new dvec4(w, w, x, x); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public dvec4 wwxy { get { return new dvec4(w, w, x, y); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public dvec4 wwxz { get { return new dvec4(w, w, x, z); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public dvec4 wwxw { get { return new dvec4(w, w, x, w); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public dvec4 wwyx { get { return new dvec4(w, w, y, x); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public dvec4 wwyy { get { return new dvec4(w, w, y, y); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public dvec4 wwyz { get { return new dvec4(w, w, y, z); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public dvec4 wwyw { get { return new dvec4(w, w, y, w); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public dvec4 wwzx { get { return new dvec4(w, w, z, x); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public dvec4 wwzy { get { return new dvec4(w, w, z, y); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public dvec4 wwzz { get { return new dvec4(w, w, z, z); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public dvec4 wwzw { get { return new dvec4(w, w, z, w); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public dvec4 wwwx { get { return new dvec4(w, w, w, x); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public dvec4 wwwy { get { return new dvec4(w, w, w, y); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public dvec4 wwwz { get { return new dvec4(w, w, w, z); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public dvec4 wwww { get { return new dvec4(w, w, w, w); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }

    }
}
