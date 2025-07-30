using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    partial struct ivec4 {
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

        /// <summary>
        /// </summary>
        [FieldOffset(sizeof(int) * 3)]
        public int w;


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

        public ivec4 xxxx { get { return new ivec4(x, x, x, x); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 xxxy { get { return new ivec4(x, x, x, y); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 xxxz { get { return new ivec4(x, x, x, z); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 xxxw { get { return new ivec4(x, x, x, w); } set { this.x = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 xxyx { get { return new ivec4(x, x, y, x); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 xxyy { get { return new ivec4(x, x, y, y); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 xxyz { get { return new ivec4(x, x, y, z); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 xxyw { get { return new ivec4(x, x, y, w); } set { this.x = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 xxzx { get { return new ivec4(x, x, z, x); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 xxzy { get { return new ivec4(x, x, z, y); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 xxzz { get { return new ivec4(x, x, z, z); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 xxzw { get { return new ivec4(x, x, z, w); } set { this.x = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 xxwx { get { return new ivec4(x, x, w, x); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 xxwy { get { return new ivec4(x, x, w, y); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 xxwz { get { return new ivec4(x, x, w, z); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 xxww { get { return new ivec4(x, x, w, w); } set { this.x = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public ivec4 xyxx { get { return new ivec4(x, y, x, x); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 xyxy { get { return new ivec4(x, y, x, y); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 xyxz { get { return new ivec4(x, y, x, z); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 xyxw { get { return new ivec4(x, y, x, w); } set { this.x = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 xyyx { get { return new ivec4(x, y, y, x); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 xyyy { get { return new ivec4(x, y, y, y); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 xyyz { get { return new ivec4(x, y, y, z); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 xyyw { get { return new ivec4(x, y, y, w); } set { this.x = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 xyzx { get { return new ivec4(x, y, z, x); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 xyzy { get { return new ivec4(x, y, z, y); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 xyzz { get { return new ivec4(x, y, z, z); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 xyzw { get { return new ivec4(x, y, z, w); } set { this.x = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 xywx { get { return new ivec4(x, y, w, x); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 xywy { get { return new ivec4(x, y, w, y); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 xywz { get { return new ivec4(x, y, w, z); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 xyww { get { return new ivec4(x, y, w, w); } set { this.x = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public ivec4 xzxx { get { return new ivec4(x, z, x, x); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 xzxy { get { return new ivec4(x, z, x, y); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 xzxz { get { return new ivec4(x, z, x, z); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 xzxw { get { return new ivec4(x, z, x, w); } set { this.x = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 xzyx { get { return new ivec4(x, z, y, x); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 xzyy { get { return new ivec4(x, z, y, y); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 xzyz { get { return new ivec4(x, z, y, z); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 xzyw { get { return new ivec4(x, z, y, w); } set { this.x = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 xzzx { get { return new ivec4(x, z, z, x); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 xzzy { get { return new ivec4(x, z, z, y); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 xzzz { get { return new ivec4(x, z, z, z); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 xzzw { get { return new ivec4(x, z, z, w); } set { this.x = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 xzwx { get { return new ivec4(x, z, w, x); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 xzwy { get { return new ivec4(x, z, w, y); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 xzwz { get { return new ivec4(x, z, w, z); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 xzww { get { return new ivec4(x, z, w, w); } set { this.x = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public ivec4 xwxx { get { return new ivec4(x, w, x, x); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 xwxy { get { return new ivec4(x, w, x, y); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 xwxz { get { return new ivec4(x, w, x, z); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 xwxw { get { return new ivec4(x, w, x, w); } set { this.x = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 xwyx { get { return new ivec4(x, w, y, x); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 xwyy { get { return new ivec4(x, w, y, y); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 xwyz { get { return new ivec4(x, w, y, z); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 xwyw { get { return new ivec4(x, w, y, w); } set { this.x = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 xwzx { get { return new ivec4(x, w, z, x); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 xwzy { get { return new ivec4(x, w, z, y); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 xwzz { get { return new ivec4(x, w, z, z); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 xwzw { get { return new ivec4(x, w, z, w); } set { this.x = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 xwwx { get { return new ivec4(x, w, w, x); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 xwwy { get { return new ivec4(x, w, w, y); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 xwwz { get { return new ivec4(x, w, w, z); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 xwww { get { return new ivec4(x, w, w, w); } set { this.x = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }
        public ivec4 yxxx { get { return new ivec4(y, x, x, x); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 yxxy { get { return new ivec4(y, x, x, y); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 yxxz { get { return new ivec4(y, x, x, z); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 yxxw { get { return new ivec4(y, x, x, w); } set { this.y = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 yxyx { get { return new ivec4(y, x, y, x); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 yxyy { get { return new ivec4(y, x, y, y); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 yxyz { get { return new ivec4(y, x, y, z); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 yxyw { get { return new ivec4(y, x, y, w); } set { this.y = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 yxzx { get { return new ivec4(y, x, z, x); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 yxzy { get { return new ivec4(y, x, z, y); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 yxzz { get { return new ivec4(y, x, z, z); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 yxzw { get { return new ivec4(y, x, z, w); } set { this.y = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 yxwx { get { return new ivec4(y, x, w, x); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 yxwy { get { return new ivec4(y, x, w, y); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 yxwz { get { return new ivec4(y, x, w, z); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 yxww { get { return new ivec4(y, x, w, w); } set { this.y = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public ivec4 yyxx { get { return new ivec4(y, y, x, x); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 yyxy { get { return new ivec4(y, y, x, y); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 yyxz { get { return new ivec4(y, y, x, z); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 yyxw { get { return new ivec4(y, y, x, w); } set { this.y = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 yyyx { get { return new ivec4(y, y, y, x); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 yyyy { get { return new ivec4(y, y, y, y); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 yyyz { get { return new ivec4(y, y, y, z); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 yyyw { get { return new ivec4(y, y, y, w); } set { this.y = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 yyzx { get { return new ivec4(y, y, z, x); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 yyzy { get { return new ivec4(y, y, z, y); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 yyzz { get { return new ivec4(y, y, z, z); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 yyzw { get { return new ivec4(y, y, z, w); } set { this.y = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 yywx { get { return new ivec4(y, y, w, x); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 yywy { get { return new ivec4(y, y, w, y); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 yywz { get { return new ivec4(y, y, w, z); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 yyww { get { return new ivec4(y, y, w, w); } set { this.y = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public ivec4 yzxx { get { return new ivec4(y, z, x, x); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 yzxy { get { return new ivec4(y, z, x, y); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 yzxz { get { return new ivec4(y, z, x, z); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 yzxw { get { return new ivec4(y, z, x, w); } set { this.y = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 yzyx { get { return new ivec4(y, z, y, x); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 yzyy { get { return new ivec4(y, z, y, y); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 yzyz { get { return new ivec4(y, z, y, z); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 yzyw { get { return new ivec4(y, z, y, w); } set { this.y = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 yzzx { get { return new ivec4(y, z, z, x); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 yzzy { get { return new ivec4(y, z, z, y); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 yzzz { get { return new ivec4(y, z, z, z); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 yzzw { get { return new ivec4(y, z, z, w); } set { this.y = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 yzwx { get { return new ivec4(y, z, w, x); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 yzwy { get { return new ivec4(y, z, w, y); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 yzwz { get { return new ivec4(y, z, w, z); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 yzww { get { return new ivec4(y, z, w, w); } set { this.y = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public ivec4 ywxx { get { return new ivec4(y, w, x, x); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 ywxy { get { return new ivec4(y, w, x, y); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 ywxz { get { return new ivec4(y, w, x, z); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 ywxw { get { return new ivec4(y, w, x, w); } set { this.y = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 ywyx { get { return new ivec4(y, w, y, x); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 ywyy { get { return new ivec4(y, w, y, y); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 ywyz { get { return new ivec4(y, w, y, z); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 ywyw { get { return new ivec4(y, w, y, w); } set { this.y = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 ywzx { get { return new ivec4(y, w, z, x); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 ywzy { get { return new ivec4(y, w, z, y); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 ywzz { get { return new ivec4(y, w, z, z); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 ywzw { get { return new ivec4(y, w, z, w); } set { this.y = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 ywwx { get { return new ivec4(y, w, w, x); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 ywwy { get { return new ivec4(y, w, w, y); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 ywwz { get { return new ivec4(y, w, w, z); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 ywww { get { return new ivec4(y, w, w, w); } set { this.y = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }
        public ivec4 zxxx { get { return new ivec4(z, x, x, x); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 zxxy { get { return new ivec4(z, x, x, y); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 zxxz { get { return new ivec4(z, x, x, z); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 zxxw { get { return new ivec4(z, x, x, w); } set { this.z = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 zxyx { get { return new ivec4(z, x, y, x); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 zxyy { get { return new ivec4(z, x, y, y); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 zxyz { get { return new ivec4(z, x, y, z); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 zxyw { get { return new ivec4(z, x, y, w); } set { this.z = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 zxzx { get { return new ivec4(z, x, z, x); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 zxzy { get { return new ivec4(z, x, z, y); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 zxzz { get { return new ivec4(z, x, z, z); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 zxzw { get { return new ivec4(z, x, z, w); } set { this.z = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 zxwx { get { return new ivec4(z, x, w, x); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 zxwy { get { return new ivec4(z, x, w, y); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 zxwz { get { return new ivec4(z, x, w, z); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 zxww { get { return new ivec4(z, x, w, w); } set { this.z = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public ivec4 zyxx { get { return new ivec4(z, y, x, x); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 zyxy { get { return new ivec4(z, y, x, y); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 zyxz { get { return new ivec4(z, y, x, z); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 zyxw { get { return new ivec4(z, y, x, w); } set { this.z = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 zyyx { get { return new ivec4(z, y, y, x); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 zyyy { get { return new ivec4(z, y, y, y); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 zyyz { get { return new ivec4(z, y, y, z); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 zyyw { get { return new ivec4(z, y, y, w); } set { this.z = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 zyzx { get { return new ivec4(z, y, z, x); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 zyzy { get { return new ivec4(z, y, z, y); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 zyzz { get { return new ivec4(z, y, z, z); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 zyzw { get { return new ivec4(z, y, z, w); } set { this.z = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 zywx { get { return new ivec4(z, y, w, x); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 zywy { get { return new ivec4(z, y, w, y); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 zywz { get { return new ivec4(z, y, w, z); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 zyww { get { return new ivec4(z, y, w, w); } set { this.z = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public ivec4 zzxx { get { return new ivec4(z, z, x, x); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 zzxy { get { return new ivec4(z, z, x, y); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 zzxz { get { return new ivec4(z, z, x, z); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 zzxw { get { return new ivec4(z, z, x, w); } set { this.z = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 zzyx { get { return new ivec4(z, z, y, x); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 zzyy { get { return new ivec4(z, z, y, y); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 zzyz { get { return new ivec4(z, z, y, z); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 zzyw { get { return new ivec4(z, z, y, w); } set { this.z = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 zzzx { get { return new ivec4(z, z, z, x); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 zzzy { get { return new ivec4(z, z, z, y); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 zzzz { get { return new ivec4(z, z, z, z); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 zzzw { get { return new ivec4(z, z, z, w); } set { this.z = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 zzwx { get { return new ivec4(z, z, w, x); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 zzwy { get { return new ivec4(z, z, w, y); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 zzwz { get { return new ivec4(z, z, w, z); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 zzww { get { return new ivec4(z, z, w, w); } set { this.z = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public ivec4 zwxx { get { return new ivec4(z, w, x, x); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 zwxy { get { return new ivec4(z, w, x, y); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 zwxz { get { return new ivec4(z, w, x, z); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 zwxw { get { return new ivec4(z, w, x, w); } set { this.z = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 zwyx { get { return new ivec4(z, w, y, x); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 zwyy { get { return new ivec4(z, w, y, y); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 zwyz { get { return new ivec4(z, w, y, z); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 zwyw { get { return new ivec4(z, w, y, w); } set { this.z = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 zwzx { get { return new ivec4(z, w, z, x); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 zwzy { get { return new ivec4(z, w, z, y); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 zwzz { get { return new ivec4(z, w, z, z); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 zwzw { get { return new ivec4(z, w, z, w); } set { this.z = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 zwwx { get { return new ivec4(z, w, w, x); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 zwwy { get { return new ivec4(z, w, w, y); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 zwwz { get { return new ivec4(z, w, w, z); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 zwww { get { return new ivec4(z, w, w, w); } set { this.z = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }
        public ivec4 wxxx { get { return new ivec4(w, x, x, x); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 wxxy { get { return new ivec4(w, x, x, y); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 wxxz { get { return new ivec4(w, x, x, z); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 wxxw { get { return new ivec4(w, x, x, w); } set { this.w = value.x; this.x = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 wxyx { get { return new ivec4(w, x, y, x); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 wxyy { get { return new ivec4(w, x, y, y); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 wxyz { get { return new ivec4(w, x, y, z); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 wxyw { get { return new ivec4(w, x, y, w); } set { this.w = value.x; this.x = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 wxzx { get { return new ivec4(w, x, z, x); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 wxzy { get { return new ivec4(w, x, z, y); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 wxzz { get { return new ivec4(w, x, z, z); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 wxzw { get { return new ivec4(w, x, z, w); } set { this.w = value.x; this.x = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 wxwx { get { return new ivec4(w, x, w, x); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 wxwy { get { return new ivec4(w, x, w, y); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 wxwz { get { return new ivec4(w, x, w, z); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 wxww { get { return new ivec4(w, x, w, w); } set { this.w = value.x; this.x = value.y; this.w = value.z; this.w = value.w; } }
        public ivec4 wyxx { get { return new ivec4(w, y, x, x); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 wyxy { get { return new ivec4(w, y, x, y); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 wyxz { get { return new ivec4(w, y, x, z); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 wyxw { get { return new ivec4(w, y, x, w); } set { this.w = value.x; this.y = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 wyyx { get { return new ivec4(w, y, y, x); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 wyyy { get { return new ivec4(w, y, y, y); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 wyyz { get { return new ivec4(w, y, y, z); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 wyyw { get { return new ivec4(w, y, y, w); } set { this.w = value.x; this.y = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 wyzx { get { return new ivec4(w, y, z, x); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 wyzy { get { return new ivec4(w, y, z, y); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 wyzz { get { return new ivec4(w, y, z, z); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 wyzw { get { return new ivec4(w, y, z, w); } set { this.w = value.x; this.y = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 wywx { get { return new ivec4(w, y, w, x); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 wywy { get { return new ivec4(w, y, w, y); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 wywz { get { return new ivec4(w, y, w, z); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 wyww { get { return new ivec4(w, y, w, w); } set { this.w = value.x; this.y = value.y; this.w = value.z; this.w = value.w; } }
        public ivec4 wzxx { get { return new ivec4(w, z, x, x); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 wzxy { get { return new ivec4(w, z, x, y); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 wzxz { get { return new ivec4(w, z, x, z); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 wzxw { get { return new ivec4(w, z, x, w); } set { this.w = value.x; this.z = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 wzyx { get { return new ivec4(w, z, y, x); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 wzyy { get { return new ivec4(w, z, y, y); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 wzyz { get { return new ivec4(w, z, y, z); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 wzyw { get { return new ivec4(w, z, y, w); } set { this.w = value.x; this.z = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 wzzx { get { return new ivec4(w, z, z, x); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 wzzy { get { return new ivec4(w, z, z, y); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 wzzz { get { return new ivec4(w, z, z, z); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 wzzw { get { return new ivec4(w, z, z, w); } set { this.w = value.x; this.z = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 wzwx { get { return new ivec4(w, z, w, x); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 wzwy { get { return new ivec4(w, z, w, y); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 wzwz { get { return new ivec4(w, z, w, z); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 wzww { get { return new ivec4(w, z, w, w); } set { this.w = value.x; this.z = value.y; this.w = value.z; this.w = value.w; } }
        public ivec4 wwxx { get { return new ivec4(w, w, x, x); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.x = value.w; } }
        public ivec4 wwxy { get { return new ivec4(w, w, x, y); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.y = value.w; } }
        public ivec4 wwxz { get { return new ivec4(w, w, x, z); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.z = value.w; } }
        public ivec4 wwxw { get { return new ivec4(w, w, x, w); } set { this.w = value.x; this.w = value.y; this.x = value.z; this.w = value.w; } }
        public ivec4 wwyx { get { return new ivec4(w, w, y, x); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.x = value.w; } }
        public ivec4 wwyy { get { return new ivec4(w, w, y, y); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.y = value.w; } }
        public ivec4 wwyz { get { return new ivec4(w, w, y, z); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.z = value.w; } }
        public ivec4 wwyw { get { return new ivec4(w, w, y, w); } set { this.w = value.x; this.w = value.y; this.y = value.z; this.w = value.w; } }
        public ivec4 wwzx { get { return new ivec4(w, w, z, x); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.x = value.w; } }
        public ivec4 wwzy { get { return new ivec4(w, w, z, y); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.y = value.w; } }
        public ivec4 wwzz { get { return new ivec4(w, w, z, z); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.z = value.w; } }
        public ivec4 wwzw { get { return new ivec4(w, w, z, w); } set { this.w = value.x; this.w = value.y; this.z = value.z; this.w = value.w; } }
        public ivec4 wwwx { get { return new ivec4(w, w, w, x); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.x = value.w; } }
        public ivec4 wwwy { get { return new ivec4(w, w, w, y); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.y = value.w; } }
        public ivec4 wwwz { get { return new ivec4(w, w, w, z); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.z = value.w; } }
        public ivec4 wwww { get { return new ivec4(w, w, w, w); } set { this.w = value.x; this.w = value.y; this.w = value.z; this.w = value.w; } }

    }
}
