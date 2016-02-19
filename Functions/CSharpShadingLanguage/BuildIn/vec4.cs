using System;
using System.Runtime.InteropServices;

namespace CSharpShadingLanguage
{
    /// <summary>
    /// Represents a four dimensional vector.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 4 * 4)]
    public class vec4
    {
        internal float a0;
        internal float a1;
        internal float a2;
        internal float a3;

        #region compositions

        public float x { get { return a0; } set { a0 = x; } }
        public float y { get { return a1; } set { a1 = y; } }
        public float z { get { return a2; } set { a2 = z; } }
        public float w { get { return a3; } set { a3 = w; } }

        public vec2 xx { get { return new vec2(x, x); } set { this.x = value.a0; this.x = value.a1; } }
        public vec2 xy { get { return new vec2(x, y); } set { this.x = value.a0; this.y = value.a1; } }
        public vec2 xz { get { return new vec2(x, z); } set { this.x = value.a0; this.z = value.a1; } }
        public vec2 xw { get { return new vec2(x, w); } set { this.x = value.a0; this.w = value.a1; } }
        public vec2 yx { get { return new vec2(y, x); } set { this.y = value.a0; this.x = value.a1; } }
        public vec2 yy { get { return new vec2(y, y); } set { this.y = value.a0; this.y = value.a1; } }
        public vec2 yz { get { return new vec2(y, z); } set { this.y = value.a0; this.z = value.a1; } }
        public vec2 yw { get { return new vec2(y, w); } set { this.y = value.a0; this.w = value.a1; } }
        public vec2 zx { get { return new vec2(z, x); } set { this.z = value.a0; this.x = value.a1; } }
        public vec2 zy { get { return new vec2(z, y); } set { this.z = value.a0; this.y = value.a1; } }
        public vec2 zz { get { return new vec2(z, z); } set { this.z = value.a0; this.z = value.a1; } }
        public vec2 zw { get { return new vec2(z, w); } set { this.z = value.a0; this.w = value.a1; } }
        public vec2 wx { get { return new vec2(w, x); } set { this.w = value.a0; this.x = value.a1; } }
        public vec2 wy { get { return new vec2(w, y); } set { this.w = value.a0; this.y = value.a1; } }
        public vec2 wz { get { return new vec2(w, z); } set { this.w = value.a0; this.z = value.a1; } }
        public vec2 ww { get { return new vec2(w, w); } set { this.w = value.a0; this.w = value.a1; } }

        public vec3 xxx { get { return new vec3(x, x, x); } set { this.x = value.a0; this.x = value.a1; this.x = value.a2; } }
        public vec3 xxy { get { return new vec3(x, x, y); } set { this.x = value.a0; this.x = value.a1; this.y = value.a2; } }
        public vec3 xxz { get { return new vec3(x, x, z); } set { this.x = value.a0; this.x = value.a1; this.z = value.a2; } }
        public vec3 xxw { get { return new vec3(x, x, w); } set { this.x = value.a0; this.x = value.a1; this.w = value.a2; } }
        public vec3 xyx { get { return new vec3(x, y, x); } set { this.x = value.a0; this.y = value.a1; this.x = value.a2; } }
        public vec3 xyy { get { return new vec3(x, y, y); } set { this.x = value.a0; this.y = value.a1; this.y = value.a2; } }
        public vec3 xyz { get { return new vec3(x, y, z); } set { this.x = value.a0; this.y = value.a1; this.z = value.a2; } }
        public vec3 xyw { get { return new vec3(x, y, w); } set { this.x = value.a0; this.y = value.a1; this.w = value.a2; } }
        public vec3 xzx { get { return new vec3(x, z, x); } set { this.x = value.a0; this.z = value.a1; this.x = value.a2; } }
        public vec3 xzy { get { return new vec3(x, z, y); } set { this.x = value.a0; this.z = value.a1; this.y = value.a2; } }
        public vec3 xzz { get { return new vec3(x, z, z); } set { this.x = value.a0; this.z = value.a1; this.z = value.a2; } }
        public vec3 xzw { get { return new vec3(x, z, w); } set { this.x = value.a0; this.z = value.a1; this.w = value.a2; } }
        public vec3 xwx { get { return new vec3(x, w, x); } set { this.x = value.a0; this.w = value.a1; this.x = value.a2; } }
        public vec3 xwy { get { return new vec3(x, w, y); } set { this.x = value.a0; this.w = value.a1; this.y = value.a2; } }
        public vec3 xwz { get { return new vec3(x, w, z); } set { this.x = value.a0; this.w = value.a1; this.z = value.a2; } }
        public vec3 xww { get { return new vec3(x, w, w); } set { this.x = value.a0; this.w = value.a1; this.w = value.a2; } }
        public vec3 yxx { get { return new vec3(y, x, x); } set { this.y = value.a0; this.x = value.a1; this.x = value.a2; } }
        public vec3 yxy { get { return new vec3(y, x, y); } set { this.y = value.a0; this.x = value.a1; this.y = value.a2; } }
        public vec3 yxz { get { return new vec3(y, x, z); } set { this.y = value.a0; this.x = value.a1; this.z = value.a2; } }
        public vec3 yxw { get { return new vec3(y, x, w); } set { this.y = value.a0; this.x = value.a1; this.w = value.a2; } }
        public vec3 yyx { get { return new vec3(y, y, x); } set { this.y = value.a0; this.y = value.a1; this.x = value.a2; } }
        public vec3 yyy { get { return new vec3(y, y, y); } set { this.y = value.a0; this.y = value.a1; this.y = value.a2; } }
        public vec3 yyz { get { return new vec3(y, y, z); } set { this.y = value.a0; this.y = value.a1; this.z = value.a2; } }
        public vec3 yyw { get { return new vec3(y, y, w); } set { this.y = value.a0; this.y = value.a1; this.w = value.a2; } }
        public vec3 yzx { get { return new vec3(y, z, x); } set { this.y = value.a0; this.z = value.a1; this.x = value.a2; } }
        public vec3 yzy { get { return new vec3(y, z, y); } set { this.y = value.a0; this.z = value.a1; this.y = value.a2; } }
        public vec3 yzz { get { return new vec3(y, z, z); } set { this.y = value.a0; this.z = value.a1; this.z = value.a2; } }
        public vec3 yzw { get { return new vec3(y, z, w); } set { this.y = value.a0; this.z = value.a1; this.w = value.a2; } }
        public vec3 ywx { get { return new vec3(y, w, x); } set { this.y = value.a0; this.w = value.a1; this.x = value.a2; } }
        public vec3 ywy { get { return new vec3(y, w, y); } set { this.y = value.a0; this.w = value.a1; this.y = value.a2; } }
        public vec3 ywz { get { return new vec3(y, w, z); } set { this.y = value.a0; this.w = value.a1; this.z = value.a2; } }
        public vec3 yww { get { return new vec3(y, w, w); } set { this.y = value.a0; this.w = value.a1; this.w = value.a2; } }
        public vec3 zxx { get { return new vec3(z, x, x); } set { this.z = value.a0; this.x = value.a1; this.x = value.a2; } }
        public vec3 zxy { get { return new vec3(z, x, y); } set { this.z = value.a0; this.x = value.a1; this.y = value.a2; } }
        public vec3 zxz { get { return new vec3(z, x, z); } set { this.z = value.a0; this.x = value.a1; this.z = value.a2; } }
        public vec3 zxw { get { return new vec3(z, x, w); } set { this.z = value.a0; this.x = value.a1; this.w = value.a2; } }
        public vec3 zyx { get { return new vec3(z, y, x); } set { this.z = value.a0; this.y = value.a1; this.x = value.a2; } }
        public vec3 zyy { get { return new vec3(z, y, y); } set { this.z = value.a0; this.y = value.a1; this.y = value.a2; } }
        public vec3 zyz { get { return new vec3(z, y, z); } set { this.z = value.a0; this.y = value.a1; this.z = value.a2; } }
        public vec3 zyw { get { return new vec3(z, y, w); } set { this.z = value.a0; this.y = value.a1; this.w = value.a2; } }
        public vec3 zzx { get { return new vec3(z, z, x); } set { this.z = value.a0; this.z = value.a1; this.x = value.a2; } }
        public vec3 zzy { get { return new vec3(z, z, y); } set { this.z = value.a0; this.z = value.a1; this.y = value.a2; } }
        public vec3 zzz { get { return new vec3(z, z, z); } set { this.z = value.a0; this.z = value.a1; this.z = value.a2; } }
        public vec3 zzw { get { return new vec3(z, z, w); } set { this.z = value.a0; this.z = value.a1; this.w = value.a2; } }
        public vec3 zwx { get { return new vec3(z, w, x); } set { this.z = value.a0; this.w = value.a1; this.x = value.a2; } }
        public vec3 zwy { get { return new vec3(z, w, y); } set { this.z = value.a0; this.w = value.a1; this.y = value.a2; } }
        public vec3 zwz { get { return new vec3(z, w, z); } set { this.z = value.a0; this.w = value.a1; this.z = value.a2; } }
        public vec3 zww { get { return new vec3(z, w, w); } set { this.z = value.a0; this.w = value.a1; this.w = value.a2; } }
        public vec3 wxx { get { return new vec3(w, x, x); } set { this.w = value.a0; this.x = value.a1; this.x = value.a2; } }
        public vec3 wxy { get { return new vec3(w, x, y); } set { this.w = value.a0; this.x = value.a1; this.y = value.a2; } }
        public vec3 wxz { get { return new vec3(w, x, z); } set { this.w = value.a0; this.x = value.a1; this.z = value.a2; } }
        public vec3 wxw { get { return new vec3(w, x, w); } set { this.w = value.a0; this.x = value.a1; this.w = value.a2; } }
        public vec3 wyx { get { return new vec3(w, y, x); } set { this.w = value.a0; this.y = value.a1; this.x = value.a2; } }
        public vec3 wyy { get { return new vec3(w, y, y); } set { this.w = value.a0; this.y = value.a1; this.y = value.a2; } }
        public vec3 wyz { get { return new vec3(w, y, z); } set { this.w = value.a0; this.y = value.a1; this.z = value.a2; } }
        public vec3 wyw { get { return new vec3(w, y, w); } set { this.w = value.a0; this.y = value.a1; this.w = value.a2; } }
        public vec3 wzx { get { return new vec3(w, z, x); } set { this.w = value.a0; this.z = value.a1; this.x = value.a2; } }
        public vec3 wzy { get { return new vec3(w, z, y); } set { this.w = value.a0; this.z = value.a1; this.y = value.a2; } }
        public vec3 wzz { get { return new vec3(w, z, z); } set { this.w = value.a0; this.z = value.a1; this.z = value.a2; } }
        public vec3 wzw { get { return new vec3(w, z, w); } set { this.w = value.a0; this.z = value.a1; this.w = value.a2; } }
        public vec3 wwx { get { return new vec3(w, w, x); } set { this.w = value.a0; this.w = value.a1; this.x = value.a2; } }
        public vec3 wwy { get { return new vec3(w, w, y); } set { this.w = value.a0; this.w = value.a1; this.y = value.a2; } }
        public vec3 wwz { get { return new vec3(w, w, z); } set { this.w = value.a0; this.w = value.a1; this.z = value.a2; } }
        public vec3 www { get { return new vec3(w, w, w); } set { this.w = value.a0; this.w = value.a1; this.w = value.a2; } }

        public vec4 xxxx { get { return new vec4(x, x, x, x); } set { this.x = value.a0; this.x = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 xxxy { get { return new vec4(x, x, x, y); } set { this.x = value.a0; this.x = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 xxxz { get { return new vec4(x, x, x, z); } set { this.x = value.a0; this.x = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 xxxw { get { return new vec4(x, x, x, w); } set { this.x = value.a0; this.x = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 xxyx { get { return new vec4(x, x, y, x); } set { this.x = value.a0; this.x = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 xxyy { get { return new vec4(x, x, y, y); } set { this.x = value.a0; this.x = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 xxyz { get { return new vec4(x, x, y, z); } set { this.x = value.a0; this.x = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 xxyw { get { return new vec4(x, x, y, w); } set { this.x = value.a0; this.x = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 xxzx { get { return new vec4(x, x, z, x); } set { this.x = value.a0; this.x = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 xxzy { get { return new vec4(x, x, z, y); } set { this.x = value.a0; this.x = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 xxzz { get { return new vec4(x, x, z, z); } set { this.x = value.a0; this.x = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 xxzw { get { return new vec4(x, x, z, w); } set { this.x = value.a0; this.x = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 xxwx { get { return new vec4(x, x, w, x); } set { this.x = value.a0; this.x = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 xxwy { get { return new vec4(x, x, w, y); } set { this.x = value.a0; this.x = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 xxwz { get { return new vec4(x, x, w, z); } set { this.x = value.a0; this.x = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 xxww { get { return new vec4(x, x, w, w); } set { this.x = value.a0; this.x = value.a1; this.w = value.a2; this.w = value.a3; } }
        public vec4 xyxx { get { return new vec4(x, y, x, x); } set { this.x = value.a0; this.y = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 xyxy { get { return new vec4(x, y, x, y); } set { this.x = value.a0; this.y = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 xyxz { get { return new vec4(x, y, x, z); } set { this.x = value.a0; this.y = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 xyxw { get { return new vec4(x, y, x, w); } set { this.x = value.a0; this.y = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 xyyx { get { return new vec4(x, y, y, x); } set { this.x = value.a0; this.y = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 xyyy { get { return new vec4(x, y, y, y); } set { this.x = value.a0; this.y = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 xyyz { get { return new vec4(x, y, y, z); } set { this.x = value.a0; this.y = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 xyyw { get { return new vec4(x, y, y, w); } set { this.x = value.a0; this.y = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 xyzx { get { return new vec4(x, y, z, x); } set { this.x = value.a0; this.y = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 xyzy { get { return new vec4(x, y, z, y); } set { this.x = value.a0; this.y = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 xyzz { get { return new vec4(x, y, z, z); } set { this.x = value.a0; this.y = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 xyzw { get { return new vec4(x, y, z, w); } set { this.x = value.a0; this.y = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 xywx { get { return new vec4(x, y, w, x); } set { this.x = value.a0; this.y = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 xywy { get { return new vec4(x, y, w, y); } set { this.x = value.a0; this.y = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 xywz { get { return new vec4(x, y, w, z); } set { this.x = value.a0; this.y = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 xyww { get { return new vec4(x, y, w, w); } set { this.x = value.a0; this.y = value.a1; this.w = value.a2; this.w = value.a3; } }
        public vec4 xzxx { get { return new vec4(x, z, x, x); } set { this.x = value.a0; this.z = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 xzxy { get { return new vec4(x, z, x, y); } set { this.x = value.a0; this.z = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 xzxz { get { return new vec4(x, z, x, z); } set { this.x = value.a0; this.z = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 xzxw { get { return new vec4(x, z, x, w); } set { this.x = value.a0; this.z = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 xzyx { get { return new vec4(x, z, y, x); } set { this.x = value.a0; this.z = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 xzyy { get { return new vec4(x, z, y, y); } set { this.x = value.a0; this.z = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 xzyz { get { return new vec4(x, z, y, z); } set { this.x = value.a0; this.z = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 xzyw { get { return new vec4(x, z, y, w); } set { this.x = value.a0; this.z = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 xzzx { get { return new vec4(x, z, z, x); } set { this.x = value.a0; this.z = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 xzzy { get { return new vec4(x, z, z, y); } set { this.x = value.a0; this.z = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 xzzz { get { return new vec4(x, z, z, z); } set { this.x = value.a0; this.z = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 xzzw { get { return new vec4(x, z, z, w); } set { this.x = value.a0; this.z = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 xzwx { get { return new vec4(x, z, w, x); } set { this.x = value.a0; this.z = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 xzwy { get { return new vec4(x, z, w, y); } set { this.x = value.a0; this.z = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 xzwz { get { return new vec4(x, z, w, z); } set { this.x = value.a0; this.z = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 xzww { get { return new vec4(x, z, w, w); } set { this.x = value.a0; this.z = value.a1; this.w = value.a2; this.w = value.a3; } }
        public vec4 xwxx { get { return new vec4(x, w, x, x); } set { this.x = value.a0; this.w = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 xwxy { get { return new vec4(x, w, x, y); } set { this.x = value.a0; this.w = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 xwxz { get { return new vec4(x, w, x, z); } set { this.x = value.a0; this.w = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 xwxw { get { return new vec4(x, w, x, w); } set { this.x = value.a0; this.w = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 xwyx { get { return new vec4(x, w, y, x); } set { this.x = value.a0; this.w = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 xwyy { get { return new vec4(x, w, y, y); } set { this.x = value.a0; this.w = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 xwyz { get { return new vec4(x, w, y, z); } set { this.x = value.a0; this.w = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 xwyw { get { return new vec4(x, w, y, w); } set { this.x = value.a0; this.w = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 xwzx { get { return new vec4(x, w, z, x); } set { this.x = value.a0; this.w = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 xwzy { get { return new vec4(x, w, z, y); } set { this.x = value.a0; this.w = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 xwzz { get { return new vec4(x, w, z, z); } set { this.x = value.a0; this.w = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 xwzw { get { return new vec4(x, w, z, w); } set { this.x = value.a0; this.w = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 xwwx { get { return new vec4(x, w, w, x); } set { this.x = value.a0; this.w = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 xwwy { get { return new vec4(x, w, w, y); } set { this.x = value.a0; this.w = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 xwwz { get { return new vec4(x, w, w, z); } set { this.x = value.a0; this.w = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 xwww { get { return new vec4(x, w, w, w); } set { this.x = value.a0; this.w = value.a1; this.w = value.a2; this.w = value.a3; } }
        public vec4 yxxx { get { return new vec4(y, x, x, x); } set { this.y = value.a0; this.x = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 yxxy { get { return new vec4(y, x, x, y); } set { this.y = value.a0; this.x = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 yxxz { get { return new vec4(y, x, x, z); } set { this.y = value.a0; this.x = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 yxxw { get { return new vec4(y, x, x, w); } set { this.y = value.a0; this.x = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 yxyx { get { return new vec4(y, x, y, x); } set { this.y = value.a0; this.x = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 yxyy { get { return new vec4(y, x, y, y); } set { this.y = value.a0; this.x = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 yxyz { get { return new vec4(y, x, y, z); } set { this.y = value.a0; this.x = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 yxyw { get { return new vec4(y, x, y, w); } set { this.y = value.a0; this.x = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 yxzx { get { return new vec4(y, x, z, x); } set { this.y = value.a0; this.x = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 yxzy { get { return new vec4(y, x, z, y); } set { this.y = value.a0; this.x = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 yxzz { get { return new vec4(y, x, z, z); } set { this.y = value.a0; this.x = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 yxzw { get { return new vec4(y, x, z, w); } set { this.y = value.a0; this.x = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 yxwx { get { return new vec4(y, x, w, x); } set { this.y = value.a0; this.x = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 yxwy { get { return new vec4(y, x, w, y); } set { this.y = value.a0; this.x = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 yxwz { get { return new vec4(y, x, w, z); } set { this.y = value.a0; this.x = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 yxww { get { return new vec4(y, x, w, w); } set { this.y = value.a0; this.x = value.a1; this.w = value.a2; this.w = value.a3; } }
        public vec4 yyxx { get { return new vec4(y, y, x, x); } set { this.y = value.a0; this.y = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 yyxy { get { return new vec4(y, y, x, y); } set { this.y = value.a0; this.y = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 yyxz { get { return new vec4(y, y, x, z); } set { this.y = value.a0; this.y = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 yyxw { get { return new vec4(y, y, x, w); } set { this.y = value.a0; this.y = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 yyyx { get { return new vec4(y, y, y, x); } set { this.y = value.a0; this.y = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 yyyy { get { return new vec4(y, y, y, y); } set { this.y = value.a0; this.y = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 yyyz { get { return new vec4(y, y, y, z); } set { this.y = value.a0; this.y = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 yyyw { get { return new vec4(y, y, y, w); } set { this.y = value.a0; this.y = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 yyzx { get { return new vec4(y, y, z, x); } set { this.y = value.a0; this.y = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 yyzy { get { return new vec4(y, y, z, y); } set { this.y = value.a0; this.y = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 yyzz { get { return new vec4(y, y, z, z); } set { this.y = value.a0; this.y = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 yyzw { get { return new vec4(y, y, z, w); } set { this.y = value.a0; this.y = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 yywx { get { return new vec4(y, y, w, x); } set { this.y = value.a0; this.y = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 yywy { get { return new vec4(y, y, w, y); } set { this.y = value.a0; this.y = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 yywz { get { return new vec4(y, y, w, z); } set { this.y = value.a0; this.y = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 yyww { get { return new vec4(y, y, w, w); } set { this.y = value.a0; this.y = value.a1; this.w = value.a2; this.w = value.a3; } }
        public vec4 yzxx { get { return new vec4(y, z, x, x); } set { this.y = value.a0; this.z = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 yzxy { get { return new vec4(y, z, x, y); } set { this.y = value.a0; this.z = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 yzxz { get { return new vec4(y, z, x, z); } set { this.y = value.a0; this.z = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 yzxw { get { return new vec4(y, z, x, w); } set { this.y = value.a0; this.z = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 yzyx { get { return new vec4(y, z, y, x); } set { this.y = value.a0; this.z = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 yzyy { get { return new vec4(y, z, y, y); } set { this.y = value.a0; this.z = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 yzyz { get { return new vec4(y, z, y, z); } set { this.y = value.a0; this.z = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 yzyw { get { return new vec4(y, z, y, w); } set { this.y = value.a0; this.z = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 yzzx { get { return new vec4(y, z, z, x); } set { this.y = value.a0; this.z = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 yzzy { get { return new vec4(y, z, z, y); } set { this.y = value.a0; this.z = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 yzzz { get { return new vec4(y, z, z, z); } set { this.y = value.a0; this.z = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 yzzw { get { return new vec4(y, z, z, w); } set { this.y = value.a0; this.z = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 yzwx { get { return new vec4(y, z, w, x); } set { this.y = value.a0; this.z = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 yzwy { get { return new vec4(y, z, w, y); } set { this.y = value.a0; this.z = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 yzwz { get { return new vec4(y, z, w, z); } set { this.y = value.a0; this.z = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 yzww { get { return new vec4(y, z, w, w); } set { this.y = value.a0; this.z = value.a1; this.w = value.a2; this.w = value.a3; } }
        public vec4 ywxx { get { return new vec4(y, w, x, x); } set { this.y = value.a0; this.w = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 ywxy { get { return new vec4(y, w, x, y); } set { this.y = value.a0; this.w = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 ywxz { get { return new vec4(y, w, x, z); } set { this.y = value.a0; this.w = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 ywxw { get { return new vec4(y, w, x, w); } set { this.y = value.a0; this.w = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 ywyx { get { return new vec4(y, w, y, x); } set { this.y = value.a0; this.w = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 ywyy { get { return new vec4(y, w, y, y); } set { this.y = value.a0; this.w = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 ywyz { get { return new vec4(y, w, y, z); } set { this.y = value.a0; this.w = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 ywyw { get { return new vec4(y, w, y, w); } set { this.y = value.a0; this.w = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 ywzx { get { return new vec4(y, w, z, x); } set { this.y = value.a0; this.w = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 ywzy { get { return new vec4(y, w, z, y); } set { this.y = value.a0; this.w = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 ywzz { get { return new vec4(y, w, z, z); } set { this.y = value.a0; this.w = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 ywzw { get { return new vec4(y, w, z, w); } set { this.y = value.a0; this.w = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 ywwx { get { return new vec4(y, w, w, x); } set { this.y = value.a0; this.w = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 ywwy { get { return new vec4(y, w, w, y); } set { this.y = value.a0; this.w = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 ywwz { get { return new vec4(y, w, w, z); } set { this.y = value.a0; this.w = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 ywww { get { return new vec4(y, w, w, w); } set { this.y = value.a0; this.w = value.a1; this.w = value.a2; this.w = value.a3; } }
        public vec4 zxxx { get { return new vec4(z, x, x, x); } set { this.z = value.a0; this.x = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 zxxy { get { return new vec4(z, x, x, y); } set { this.z = value.a0; this.x = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 zxxz { get { return new vec4(z, x, x, z); } set { this.z = value.a0; this.x = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 zxxw { get { return new vec4(z, x, x, w); } set { this.z = value.a0; this.x = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 zxyx { get { return new vec4(z, x, y, x); } set { this.z = value.a0; this.x = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 zxyy { get { return new vec4(z, x, y, y); } set { this.z = value.a0; this.x = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 zxyz { get { return new vec4(z, x, y, z); } set { this.z = value.a0; this.x = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 zxyw { get { return new vec4(z, x, y, w); } set { this.z = value.a0; this.x = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 zxzx { get { return new vec4(z, x, z, x); } set { this.z = value.a0; this.x = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 zxzy { get { return new vec4(z, x, z, y); } set { this.z = value.a0; this.x = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 zxzz { get { return new vec4(z, x, z, z); } set { this.z = value.a0; this.x = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 zxzw { get { return new vec4(z, x, z, w); } set { this.z = value.a0; this.x = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 zxwx { get { return new vec4(z, x, w, x); } set { this.z = value.a0; this.x = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 zxwy { get { return new vec4(z, x, w, y); } set { this.z = value.a0; this.x = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 zxwz { get { return new vec4(z, x, w, z); } set { this.z = value.a0; this.x = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 zxww { get { return new vec4(z, x, w, w); } set { this.z = value.a0; this.x = value.a1; this.w = value.a2; this.w = value.a3; } }
        public vec4 zyxx { get { return new vec4(z, y, x, x); } set { this.z = value.a0; this.y = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 zyxy { get { return new vec4(z, y, x, y); } set { this.z = value.a0; this.y = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 zyxz { get { return new vec4(z, y, x, z); } set { this.z = value.a0; this.y = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 zyxw { get { return new vec4(z, y, x, w); } set { this.z = value.a0; this.y = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 zyyx { get { return new vec4(z, y, y, x); } set { this.z = value.a0; this.y = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 zyyy { get { return new vec4(z, y, y, y); } set { this.z = value.a0; this.y = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 zyyz { get { return new vec4(z, y, y, z); } set { this.z = value.a0; this.y = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 zyyw { get { return new vec4(z, y, y, w); } set { this.z = value.a0; this.y = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 zyzx { get { return new vec4(z, y, z, x); } set { this.z = value.a0; this.y = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 zyzy { get { return new vec4(z, y, z, y); } set { this.z = value.a0; this.y = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 zyzz { get { return new vec4(z, y, z, z); } set { this.z = value.a0; this.y = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 zyzw { get { return new vec4(z, y, z, w); } set { this.z = value.a0; this.y = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 zywx { get { return new vec4(z, y, w, x); } set { this.z = value.a0; this.y = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 zywy { get { return new vec4(z, y, w, y); } set { this.z = value.a0; this.y = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 zywz { get { return new vec4(z, y, w, z); } set { this.z = value.a0; this.y = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 zyww { get { return new vec4(z, y, w, w); } set { this.z = value.a0; this.y = value.a1; this.w = value.a2; this.w = value.a3; } }
        public vec4 zzxx { get { return new vec4(z, z, x, x); } set { this.z = value.a0; this.z = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 zzxy { get { return new vec4(z, z, x, y); } set { this.z = value.a0; this.z = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 zzxz { get { return new vec4(z, z, x, z); } set { this.z = value.a0; this.z = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 zzxw { get { return new vec4(z, z, x, w); } set { this.z = value.a0; this.z = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 zzyx { get { return new vec4(z, z, y, x); } set { this.z = value.a0; this.z = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 zzyy { get { return new vec4(z, z, y, y); } set { this.z = value.a0; this.z = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 zzyz { get { return new vec4(z, z, y, z); } set { this.z = value.a0; this.z = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 zzyw { get { return new vec4(z, z, y, w); } set { this.z = value.a0; this.z = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 zzzx { get { return new vec4(z, z, z, x); } set { this.z = value.a0; this.z = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 zzzy { get { return new vec4(z, z, z, y); } set { this.z = value.a0; this.z = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 zzzz { get { return new vec4(z, z, z, z); } set { this.z = value.a0; this.z = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 zzzw { get { return new vec4(z, z, z, w); } set { this.z = value.a0; this.z = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 zzwx { get { return new vec4(z, z, w, x); } set { this.z = value.a0; this.z = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 zzwy { get { return new vec4(z, z, w, y); } set { this.z = value.a0; this.z = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 zzwz { get { return new vec4(z, z, w, z); } set { this.z = value.a0; this.z = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 zzww { get { return new vec4(z, z, w, w); } set { this.z = value.a0; this.z = value.a1; this.w = value.a2; this.w = value.a3; } }
        public vec4 zwxx { get { return new vec4(z, w, x, x); } set { this.z = value.a0; this.w = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 zwxy { get { return new vec4(z, w, x, y); } set { this.z = value.a0; this.w = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 zwxz { get { return new vec4(z, w, x, z); } set { this.z = value.a0; this.w = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 zwxw { get { return new vec4(z, w, x, w); } set { this.z = value.a0; this.w = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 zwyx { get { return new vec4(z, w, y, x); } set { this.z = value.a0; this.w = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 zwyy { get { return new vec4(z, w, y, y); } set { this.z = value.a0; this.w = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 zwyz { get { return new vec4(z, w, y, z); } set { this.z = value.a0; this.w = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 zwyw { get { return new vec4(z, w, y, w); } set { this.z = value.a0; this.w = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 zwzx { get { return new vec4(z, w, z, x); } set { this.z = value.a0; this.w = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 zwzy { get { return new vec4(z, w, z, y); } set { this.z = value.a0; this.w = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 zwzz { get { return new vec4(z, w, z, z); } set { this.z = value.a0; this.w = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 zwzw { get { return new vec4(z, w, z, w); } set { this.z = value.a0; this.w = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 zwwx { get { return new vec4(z, w, w, x); } set { this.z = value.a0; this.w = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 zwwy { get { return new vec4(z, w, w, y); } set { this.z = value.a0; this.w = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 zwwz { get { return new vec4(z, w, w, z); } set { this.z = value.a0; this.w = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 zwww { get { return new vec4(z, w, w, w); } set { this.z = value.a0; this.w = value.a1; this.w = value.a2; this.w = value.a3; } }
        public vec4 wxxx { get { return new vec4(w, x, x, x); } set { this.w = value.a0; this.x = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 wxxy { get { return new vec4(w, x, x, y); } set { this.w = value.a0; this.x = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 wxxz { get { return new vec4(w, x, x, z); } set { this.w = value.a0; this.x = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 wxxw { get { return new vec4(w, x, x, w); } set { this.w = value.a0; this.x = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 wxyx { get { return new vec4(w, x, y, x); } set { this.w = value.a0; this.x = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 wxyy { get { return new vec4(w, x, y, y); } set { this.w = value.a0; this.x = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 wxyz { get { return new vec4(w, x, y, z); } set { this.w = value.a0; this.x = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 wxyw { get { return new vec4(w, x, y, w); } set { this.w = value.a0; this.x = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 wxzx { get { return new vec4(w, x, z, x); } set { this.w = value.a0; this.x = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 wxzy { get { return new vec4(w, x, z, y); } set { this.w = value.a0; this.x = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 wxzz { get { return new vec4(w, x, z, z); } set { this.w = value.a0; this.x = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 wxzw { get { return new vec4(w, x, z, w); } set { this.w = value.a0; this.x = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 wxwx { get { return new vec4(w, x, w, x); } set { this.w = value.a0; this.x = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 wxwy { get { return new vec4(w, x, w, y); } set { this.w = value.a0; this.x = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 wxwz { get { return new vec4(w, x, w, z); } set { this.w = value.a0; this.x = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 wxww { get { return new vec4(w, x, w, w); } set { this.w = value.a0; this.x = value.a1; this.w = value.a2; this.w = value.a3; } }
        public vec4 wyxx { get { return new vec4(w, y, x, x); } set { this.w = value.a0; this.y = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 wyxy { get { return new vec4(w, y, x, y); } set { this.w = value.a0; this.y = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 wyxz { get { return new vec4(w, y, x, z); } set { this.w = value.a0; this.y = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 wyxw { get { return new vec4(w, y, x, w); } set { this.w = value.a0; this.y = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 wyyx { get { return new vec4(w, y, y, x); } set { this.w = value.a0; this.y = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 wyyy { get { return new vec4(w, y, y, y); } set { this.w = value.a0; this.y = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 wyyz { get { return new vec4(w, y, y, z); } set { this.w = value.a0; this.y = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 wyyw { get { return new vec4(w, y, y, w); } set { this.w = value.a0; this.y = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 wyzx { get { return new vec4(w, y, z, x); } set { this.w = value.a0; this.y = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 wyzy { get { return new vec4(w, y, z, y); } set { this.w = value.a0; this.y = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 wyzz { get { return new vec4(w, y, z, z); } set { this.w = value.a0; this.y = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 wyzw { get { return new vec4(w, y, z, w); } set { this.w = value.a0; this.y = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 wywx { get { return new vec4(w, y, w, x); } set { this.w = value.a0; this.y = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 wywy { get { return new vec4(w, y, w, y); } set { this.w = value.a0; this.y = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 wywz { get { return new vec4(w, y, w, z); } set { this.w = value.a0; this.y = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 wyww { get { return new vec4(w, y, w, w); } set { this.w = value.a0; this.y = value.a1; this.w = value.a2; this.w = value.a3; } }
        public vec4 wzxx { get { return new vec4(w, z, x, x); } set { this.w = value.a0; this.z = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 wzxy { get { return new vec4(w, z, x, y); } set { this.w = value.a0; this.z = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 wzxz { get { return new vec4(w, z, x, z); } set { this.w = value.a0; this.z = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 wzxw { get { return new vec4(w, z, x, w); } set { this.w = value.a0; this.z = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 wzyx { get { return new vec4(w, z, y, x); } set { this.w = value.a0; this.z = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 wzyy { get { return new vec4(w, z, y, y); } set { this.w = value.a0; this.z = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 wzyz { get { return new vec4(w, z, y, z); } set { this.w = value.a0; this.z = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 wzyw { get { return new vec4(w, z, y, w); } set { this.w = value.a0; this.z = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 wzzx { get { return new vec4(w, z, z, x); } set { this.w = value.a0; this.z = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 wzzy { get { return new vec4(w, z, z, y); } set { this.w = value.a0; this.z = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 wzzz { get { return new vec4(w, z, z, z); } set { this.w = value.a0; this.z = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 wzzw { get { return new vec4(w, z, z, w); } set { this.w = value.a0; this.z = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 wzwx { get { return new vec4(w, z, w, x); } set { this.w = value.a0; this.z = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 wzwy { get { return new vec4(w, z, w, y); } set { this.w = value.a0; this.z = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 wzwz { get { return new vec4(w, z, w, z); } set { this.w = value.a0; this.z = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 wzww { get { return new vec4(w, z, w, w); } set { this.w = value.a0; this.z = value.a1; this.w = value.a2; this.w = value.a3; } }
        public vec4 wwxx { get { return new vec4(w, w, x, x); } set { this.w = value.a0; this.w = value.a1; this.x = value.a2; this.x = value.a3; } }
        public vec4 wwxy { get { return new vec4(w, w, x, y); } set { this.w = value.a0; this.w = value.a1; this.x = value.a2; this.y = value.a3; } }
        public vec4 wwxz { get { return new vec4(w, w, x, z); } set { this.w = value.a0; this.w = value.a1; this.x = value.a2; this.z = value.a3; } }
        public vec4 wwxw { get { return new vec4(w, w, x, w); } set { this.w = value.a0; this.w = value.a1; this.x = value.a2; this.w = value.a3; } }
        public vec4 wwyx { get { return new vec4(w, w, y, x); } set { this.w = value.a0; this.w = value.a1; this.y = value.a2; this.x = value.a3; } }
        public vec4 wwyy { get { return new vec4(w, w, y, y); } set { this.w = value.a0; this.w = value.a1; this.y = value.a2; this.y = value.a3; } }
        public vec4 wwyz { get { return new vec4(w, w, y, z); } set { this.w = value.a0; this.w = value.a1; this.y = value.a2; this.z = value.a3; } }
        public vec4 wwyw { get { return new vec4(w, w, y, w); } set { this.w = value.a0; this.w = value.a1; this.y = value.a2; this.w = value.a3; } }
        public vec4 wwzx { get { return new vec4(w, w, z, x); } set { this.w = value.a0; this.w = value.a1; this.z = value.a2; this.x = value.a3; } }
        public vec4 wwzy { get { return new vec4(w, w, z, y); } set { this.w = value.a0; this.w = value.a1; this.z = value.a2; this.y = value.a3; } }
        public vec4 wwzz { get { return new vec4(w, w, z, z); } set { this.w = value.a0; this.w = value.a1; this.z = value.a2; this.z = value.a3; } }
        public vec4 wwzw { get { return new vec4(w, w, z, w); } set { this.w = value.a0; this.w = value.a1; this.z = value.a2; this.w = value.a3; } }
        public vec4 wwwx { get { return new vec4(w, w, w, x); } set { this.w = value.a0; this.w = value.a1; this.w = value.a2; this.x = value.a3; } }
        public vec4 wwwy { get { return new vec4(w, w, w, y); } set { this.w = value.a0; this.w = value.a1; this.w = value.a2; this.y = value.a3; } }
        public vec4 wwwz { get { return new vec4(w, w, w, z); } set { this.w = value.a0; this.w = value.a1; this.w = value.a2; this.z = value.a3; } }
        public vec4 wwww { get { return new vec4(w, w, w, w); } set { this.w = value.a0; this.w = value.a1; this.w = value.a2; this.w = value.a3; } }
        public float r { get { return a0; } set { a0 = r; } }
        public float g { get { return a1; } set { a1 = g; } }
        public float b { get { return a2; } set { a2 = b; } }
        public float a { get { return a3; } set { a3 = a; } }

        public vec2 rr { get { return new vec2(r, r); } set { this.r = value.a0; this.r = value.a1; } }
        public vec2 rg { get { return new vec2(r, g); } set { this.r = value.a0; this.g = value.a1; } }
        public vec2 rb { get { return new vec2(r, b); } set { this.r = value.a0; this.b = value.a1; } }
        public vec2 ra { get { return new vec2(r, a); } set { this.r = value.a0; this.a = value.a1; } }
        public vec2 gr { get { return new vec2(g, r); } set { this.g = value.a0; this.r = value.a1; } }
        public vec2 gg { get { return new vec2(g, g); } set { this.g = value.a0; this.g = value.a1; } }
        public vec2 gb { get { return new vec2(g, b); } set { this.g = value.a0; this.b = value.a1; } }
        public vec2 ga { get { return new vec2(g, a); } set { this.g = value.a0; this.a = value.a1; } }
        public vec2 br { get { return new vec2(b, r); } set { this.b = value.a0; this.r = value.a1; } }
        public vec2 bg { get { return new vec2(b, g); } set { this.b = value.a0; this.g = value.a1; } }
        public vec2 bb { get { return new vec2(b, b); } set { this.b = value.a0; this.b = value.a1; } }
        public vec2 ba { get { return new vec2(b, a); } set { this.b = value.a0; this.a = value.a1; } }
        public vec2 ar { get { return new vec2(a, r); } set { this.a = value.a0; this.r = value.a1; } }
        public vec2 ag { get { return new vec2(a, g); } set { this.a = value.a0; this.g = value.a1; } }
        public vec2 ab { get { return new vec2(a, b); } set { this.a = value.a0; this.b = value.a1; } }
        public vec2 aa { get { return new vec2(a, a); } set { this.a = value.a0; this.a = value.a1; } }

        public vec3 rrr { get { return new vec3(r, r, r); } set { this.r = value.a0; this.r = value.a1; this.r = value.a2; } }
        public vec3 rrg { get { return new vec3(r, r, g); } set { this.r = value.a0; this.r = value.a1; this.g = value.a2; } }
        public vec3 rrb { get { return new vec3(r, r, b); } set { this.r = value.a0; this.r = value.a1; this.b = value.a2; } }
        public vec3 rra { get { return new vec3(r, r, a); } set { this.r = value.a0; this.r = value.a1; this.a = value.a2; } }
        public vec3 rgr { get { return new vec3(r, g, r); } set { this.r = value.a0; this.g = value.a1; this.r = value.a2; } }
        public vec3 rgg { get { return new vec3(r, g, g); } set { this.r = value.a0; this.g = value.a1; this.g = value.a2; } }
        public vec3 rgb { get { return new vec3(r, g, b); } set { this.r = value.a0; this.g = value.a1; this.b = value.a2; } }
        public vec3 rga { get { return new vec3(r, g, a); } set { this.r = value.a0; this.g = value.a1; this.a = value.a2; } }
        public vec3 rbr { get { return new vec3(r, b, r); } set { this.r = value.a0; this.b = value.a1; this.r = value.a2; } }
        public vec3 rbg { get { return new vec3(r, b, g); } set { this.r = value.a0; this.b = value.a1; this.g = value.a2; } }
        public vec3 rbb { get { return new vec3(r, b, b); } set { this.r = value.a0; this.b = value.a1; this.b = value.a2; } }
        public vec3 rba { get { return new vec3(r, b, a); } set { this.r = value.a0; this.b = value.a1; this.a = value.a2; } }
        public vec3 rar { get { return new vec3(r, a, r); } set { this.r = value.a0; this.a = value.a1; this.r = value.a2; } }
        public vec3 rag { get { return new vec3(r, a, g); } set { this.r = value.a0; this.a = value.a1; this.g = value.a2; } }
        public vec3 rab { get { return new vec3(r, a, b); } set { this.r = value.a0; this.a = value.a1; this.b = value.a2; } }
        public vec3 raa { get { return new vec3(r, a, a); } set { this.r = value.a0; this.a = value.a1; this.a = value.a2; } }
        public vec3 grr { get { return new vec3(g, r, r); } set { this.g = value.a0; this.r = value.a1; this.r = value.a2; } }
        public vec3 grg { get { return new vec3(g, r, g); } set { this.g = value.a0; this.r = value.a1; this.g = value.a2; } }
        public vec3 grb { get { return new vec3(g, r, b); } set { this.g = value.a0; this.r = value.a1; this.b = value.a2; } }
        public vec3 gra { get { return new vec3(g, r, a); } set { this.g = value.a0; this.r = value.a1; this.a = value.a2; } }
        public vec3 ggr { get { return new vec3(g, g, r); } set { this.g = value.a0; this.g = value.a1; this.r = value.a2; } }
        public vec3 ggg { get { return new vec3(g, g, g); } set { this.g = value.a0; this.g = value.a1; this.g = value.a2; } }
        public vec3 ggb { get { return new vec3(g, g, b); } set { this.g = value.a0; this.g = value.a1; this.b = value.a2; } }
        public vec3 gga { get { return new vec3(g, g, a); } set { this.g = value.a0; this.g = value.a1; this.a = value.a2; } }
        public vec3 gbr { get { return new vec3(g, b, r); } set { this.g = value.a0; this.b = value.a1; this.r = value.a2; } }
        public vec3 gbg { get { return new vec3(g, b, g); } set { this.g = value.a0; this.b = value.a1; this.g = value.a2; } }
        public vec3 gbb { get { return new vec3(g, b, b); } set { this.g = value.a0; this.b = value.a1; this.b = value.a2; } }
        public vec3 gba { get { return new vec3(g, b, a); } set { this.g = value.a0; this.b = value.a1; this.a = value.a2; } }
        public vec3 gar { get { return new vec3(g, a, r); } set { this.g = value.a0; this.a = value.a1; this.r = value.a2; } }
        public vec3 gag { get { return new vec3(g, a, g); } set { this.g = value.a0; this.a = value.a1; this.g = value.a2; } }
        public vec3 gab { get { return new vec3(g, a, b); } set { this.g = value.a0; this.a = value.a1; this.b = value.a2; } }
        public vec3 gaa { get { return new vec3(g, a, a); } set { this.g = value.a0; this.a = value.a1; this.a = value.a2; } }
        public vec3 brr { get { return new vec3(b, r, r); } set { this.b = value.a0; this.r = value.a1; this.r = value.a2; } }
        public vec3 brg { get { return new vec3(b, r, g); } set { this.b = value.a0; this.r = value.a1; this.g = value.a2; } }
        public vec3 brb { get { return new vec3(b, r, b); } set { this.b = value.a0; this.r = value.a1; this.b = value.a2; } }
        public vec3 bra { get { return new vec3(b, r, a); } set { this.b = value.a0; this.r = value.a1; this.a = value.a2; } }
        public vec3 bgr { get { return new vec3(b, g, r); } set { this.b = value.a0; this.g = value.a1; this.r = value.a2; } }
        public vec3 bgg { get { return new vec3(b, g, g); } set { this.b = value.a0; this.g = value.a1; this.g = value.a2; } }
        public vec3 bgb { get { return new vec3(b, g, b); } set { this.b = value.a0; this.g = value.a1; this.b = value.a2; } }
        public vec3 bga { get { return new vec3(b, g, a); } set { this.b = value.a0; this.g = value.a1; this.a = value.a2; } }
        public vec3 bbr { get { return new vec3(b, b, r); } set { this.b = value.a0; this.b = value.a1; this.r = value.a2; } }
        public vec3 bbg { get { return new vec3(b, b, g); } set { this.b = value.a0; this.b = value.a1; this.g = value.a2; } }
        public vec3 bbb { get { return new vec3(b, b, b); } set { this.b = value.a0; this.b = value.a1; this.b = value.a2; } }
        public vec3 bba { get { return new vec3(b, b, a); } set { this.b = value.a0; this.b = value.a1; this.a = value.a2; } }
        public vec3 bar { get { return new vec3(b, a, r); } set { this.b = value.a0; this.a = value.a1; this.r = value.a2; } }
        public vec3 bag { get { return new vec3(b, a, g); } set { this.b = value.a0; this.a = value.a1; this.g = value.a2; } }
        public vec3 bab { get { return new vec3(b, a, b); } set { this.b = value.a0; this.a = value.a1; this.b = value.a2; } }
        public vec3 baa { get { return new vec3(b, a, a); } set { this.b = value.a0; this.a = value.a1; this.a = value.a2; } }
        public vec3 arr { get { return new vec3(a, r, r); } set { this.a = value.a0; this.r = value.a1; this.r = value.a2; } }
        public vec3 arg { get { return new vec3(a, r, g); } set { this.a = value.a0; this.r = value.a1; this.g = value.a2; } }
        public vec3 arb { get { return new vec3(a, r, b); } set { this.a = value.a0; this.r = value.a1; this.b = value.a2; } }
        public vec3 ara { get { return new vec3(a, r, a); } set { this.a = value.a0; this.r = value.a1; this.a = value.a2; } }
        public vec3 agr { get { return new vec3(a, g, r); } set { this.a = value.a0; this.g = value.a1; this.r = value.a2; } }
        public vec3 agg { get { return new vec3(a, g, g); } set { this.a = value.a0; this.g = value.a1; this.g = value.a2; } }
        public vec3 agb { get { return new vec3(a, g, b); } set { this.a = value.a0; this.g = value.a1; this.b = value.a2; } }
        public vec3 aga { get { return new vec3(a, g, a); } set { this.a = value.a0; this.g = value.a1; this.a = value.a2; } }
        public vec3 abr { get { return new vec3(a, b, r); } set { this.a = value.a0; this.b = value.a1; this.r = value.a2; } }
        public vec3 abg { get { return new vec3(a, b, g); } set { this.a = value.a0; this.b = value.a1; this.g = value.a2; } }
        public vec3 abb { get { return new vec3(a, b, b); } set { this.a = value.a0; this.b = value.a1; this.b = value.a2; } }
        public vec3 aba { get { return new vec3(a, b, a); } set { this.a = value.a0; this.b = value.a1; this.a = value.a2; } }
        public vec3 aar { get { return new vec3(a, a, r); } set { this.a = value.a0; this.a = value.a1; this.r = value.a2; } }
        public vec3 aag { get { return new vec3(a, a, g); } set { this.a = value.a0; this.a = value.a1; this.g = value.a2; } }
        public vec3 aab { get { return new vec3(a, a, b); } set { this.a = value.a0; this.a = value.a1; this.b = value.a2; } }
        public vec3 aaa { get { return new vec3(a, a, a); } set { this.a = value.a0; this.a = value.a1; this.a = value.a2; } }

        public vec4 rrrr { get { return new vec4(r, r, r, r); } set { this.r = value.a0; this.r = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 rrrg { get { return new vec4(r, r, r, g); } set { this.r = value.a0; this.r = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 rrrb { get { return new vec4(r, r, r, b); } set { this.r = value.a0; this.r = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 rrra { get { return new vec4(r, r, r, a); } set { this.r = value.a0; this.r = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 rrgr { get { return new vec4(r, r, g, r); } set { this.r = value.a0; this.r = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 rrgg { get { return new vec4(r, r, g, g); } set { this.r = value.a0; this.r = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 rrgb { get { return new vec4(r, r, g, b); } set { this.r = value.a0; this.r = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 rrga { get { return new vec4(r, r, g, a); } set { this.r = value.a0; this.r = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 rrbr { get { return new vec4(r, r, b, r); } set { this.r = value.a0; this.r = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 rrbg { get { return new vec4(r, r, b, g); } set { this.r = value.a0; this.r = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 rrbb { get { return new vec4(r, r, b, b); } set { this.r = value.a0; this.r = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 rrba { get { return new vec4(r, r, b, a); } set { this.r = value.a0; this.r = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 rrar { get { return new vec4(r, r, a, r); } set { this.r = value.a0; this.r = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 rrag { get { return new vec4(r, r, a, g); } set { this.r = value.a0; this.r = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 rrab { get { return new vec4(r, r, a, b); } set { this.r = value.a0; this.r = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 rraa { get { return new vec4(r, r, a, a); } set { this.r = value.a0; this.r = value.a1; this.a = value.a2; this.a = value.a3; } }
        public vec4 rgrr { get { return new vec4(r, g, r, r); } set { this.r = value.a0; this.g = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 rgrg { get { return new vec4(r, g, r, g); } set { this.r = value.a0; this.g = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 rgrb { get { return new vec4(r, g, r, b); } set { this.r = value.a0; this.g = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 rgra { get { return new vec4(r, g, r, a); } set { this.r = value.a0; this.g = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 rggr { get { return new vec4(r, g, g, r); } set { this.r = value.a0; this.g = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 rggg { get { return new vec4(r, g, g, g); } set { this.r = value.a0; this.g = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 rggb { get { return new vec4(r, g, g, b); } set { this.r = value.a0; this.g = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 rgga { get { return new vec4(r, g, g, a); } set { this.r = value.a0; this.g = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 rgbr { get { return new vec4(r, g, b, r); } set { this.r = value.a0; this.g = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 rgbg { get { return new vec4(r, g, b, g); } set { this.r = value.a0; this.g = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 rgbb { get { return new vec4(r, g, b, b); } set { this.r = value.a0; this.g = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 rgba { get { return new vec4(r, g, b, a); } set { this.r = value.a0; this.g = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 rgar { get { return new vec4(r, g, a, r); } set { this.r = value.a0; this.g = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 rgag { get { return new vec4(r, g, a, g); } set { this.r = value.a0; this.g = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 rgab { get { return new vec4(r, g, a, b); } set { this.r = value.a0; this.g = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 rgaa { get { return new vec4(r, g, a, a); } set { this.r = value.a0; this.g = value.a1; this.a = value.a2; this.a = value.a3; } }
        public vec4 rbrr { get { return new vec4(r, b, r, r); } set { this.r = value.a0; this.b = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 rbrg { get { return new vec4(r, b, r, g); } set { this.r = value.a0; this.b = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 rbrb { get { return new vec4(r, b, r, b); } set { this.r = value.a0; this.b = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 rbra { get { return new vec4(r, b, r, a); } set { this.r = value.a0; this.b = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 rbgr { get { return new vec4(r, b, g, r); } set { this.r = value.a0; this.b = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 rbgg { get { return new vec4(r, b, g, g); } set { this.r = value.a0; this.b = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 rbgb { get { return new vec4(r, b, g, b); } set { this.r = value.a0; this.b = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 rbga { get { return new vec4(r, b, g, a); } set { this.r = value.a0; this.b = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 rbbr { get { return new vec4(r, b, b, r); } set { this.r = value.a0; this.b = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 rbbg { get { return new vec4(r, b, b, g); } set { this.r = value.a0; this.b = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 rbbb { get { return new vec4(r, b, b, b); } set { this.r = value.a0; this.b = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 rbba { get { return new vec4(r, b, b, a); } set { this.r = value.a0; this.b = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 rbar { get { return new vec4(r, b, a, r); } set { this.r = value.a0; this.b = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 rbag { get { return new vec4(r, b, a, g); } set { this.r = value.a0; this.b = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 rbab { get { return new vec4(r, b, a, b); } set { this.r = value.a0; this.b = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 rbaa { get { return new vec4(r, b, a, a); } set { this.r = value.a0; this.b = value.a1; this.a = value.a2; this.a = value.a3; } }
        public vec4 rarr { get { return new vec4(r, a, r, r); } set { this.r = value.a0; this.a = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 rarg { get { return new vec4(r, a, r, g); } set { this.r = value.a0; this.a = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 rarb { get { return new vec4(r, a, r, b); } set { this.r = value.a0; this.a = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 rara { get { return new vec4(r, a, r, a); } set { this.r = value.a0; this.a = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 ragr { get { return new vec4(r, a, g, r); } set { this.r = value.a0; this.a = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 ragg { get { return new vec4(r, a, g, g); } set { this.r = value.a0; this.a = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 ragb { get { return new vec4(r, a, g, b); } set { this.r = value.a0; this.a = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 raga { get { return new vec4(r, a, g, a); } set { this.r = value.a0; this.a = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 rabr { get { return new vec4(r, a, b, r); } set { this.r = value.a0; this.a = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 rabg { get { return new vec4(r, a, b, g); } set { this.r = value.a0; this.a = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 rabb { get { return new vec4(r, a, b, b); } set { this.r = value.a0; this.a = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 raba { get { return new vec4(r, a, b, a); } set { this.r = value.a0; this.a = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 raar { get { return new vec4(r, a, a, r); } set { this.r = value.a0; this.a = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 raag { get { return new vec4(r, a, a, g); } set { this.r = value.a0; this.a = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 raab { get { return new vec4(r, a, a, b); } set { this.r = value.a0; this.a = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 raaa { get { return new vec4(r, a, a, a); } set { this.r = value.a0; this.a = value.a1; this.a = value.a2; this.a = value.a3; } }
        public vec4 grrr { get { return new vec4(g, r, r, r); } set { this.g = value.a0; this.r = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 grrg { get { return new vec4(g, r, r, g); } set { this.g = value.a0; this.r = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 grrb { get { return new vec4(g, r, r, b); } set { this.g = value.a0; this.r = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 grra { get { return new vec4(g, r, r, a); } set { this.g = value.a0; this.r = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 grgr { get { return new vec4(g, r, g, r); } set { this.g = value.a0; this.r = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 grgg { get { return new vec4(g, r, g, g); } set { this.g = value.a0; this.r = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 grgb { get { return new vec4(g, r, g, b); } set { this.g = value.a0; this.r = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 grga { get { return new vec4(g, r, g, a); } set { this.g = value.a0; this.r = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 grbr { get { return new vec4(g, r, b, r); } set { this.g = value.a0; this.r = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 grbg { get { return new vec4(g, r, b, g); } set { this.g = value.a0; this.r = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 grbb { get { return new vec4(g, r, b, b); } set { this.g = value.a0; this.r = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 grba { get { return new vec4(g, r, b, a); } set { this.g = value.a0; this.r = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 grar { get { return new vec4(g, r, a, r); } set { this.g = value.a0; this.r = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 grag { get { return new vec4(g, r, a, g); } set { this.g = value.a0; this.r = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 grab { get { return new vec4(g, r, a, b); } set { this.g = value.a0; this.r = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 graa { get { return new vec4(g, r, a, a); } set { this.g = value.a0; this.r = value.a1; this.a = value.a2; this.a = value.a3; } }
        public vec4 ggrr { get { return new vec4(g, g, r, r); } set { this.g = value.a0; this.g = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 ggrg { get { return new vec4(g, g, r, g); } set { this.g = value.a0; this.g = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 ggrb { get { return new vec4(g, g, r, b); } set { this.g = value.a0; this.g = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 ggra { get { return new vec4(g, g, r, a); } set { this.g = value.a0; this.g = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 gggr { get { return new vec4(g, g, g, r); } set { this.g = value.a0; this.g = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 gggg { get { return new vec4(g, g, g, g); } set { this.g = value.a0; this.g = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 gggb { get { return new vec4(g, g, g, b); } set { this.g = value.a0; this.g = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 ggga { get { return new vec4(g, g, g, a); } set { this.g = value.a0; this.g = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 ggbr { get { return new vec4(g, g, b, r); } set { this.g = value.a0; this.g = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 ggbg { get { return new vec4(g, g, b, g); } set { this.g = value.a0; this.g = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 ggbb { get { return new vec4(g, g, b, b); } set { this.g = value.a0; this.g = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 ggba { get { return new vec4(g, g, b, a); } set { this.g = value.a0; this.g = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 ggar { get { return new vec4(g, g, a, r); } set { this.g = value.a0; this.g = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 ggag { get { return new vec4(g, g, a, g); } set { this.g = value.a0; this.g = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 ggab { get { return new vec4(g, g, a, b); } set { this.g = value.a0; this.g = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 ggaa { get { return new vec4(g, g, a, a); } set { this.g = value.a0; this.g = value.a1; this.a = value.a2; this.a = value.a3; } }
        public vec4 gbrr { get { return new vec4(g, b, r, r); } set { this.g = value.a0; this.b = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 gbrg { get { return new vec4(g, b, r, g); } set { this.g = value.a0; this.b = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 gbrb { get { return new vec4(g, b, r, b); } set { this.g = value.a0; this.b = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 gbra { get { return new vec4(g, b, r, a); } set { this.g = value.a0; this.b = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 gbgr { get { return new vec4(g, b, g, r); } set { this.g = value.a0; this.b = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 gbgg { get { return new vec4(g, b, g, g); } set { this.g = value.a0; this.b = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 gbgb { get { return new vec4(g, b, g, b); } set { this.g = value.a0; this.b = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 gbga { get { return new vec4(g, b, g, a); } set { this.g = value.a0; this.b = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 gbbr { get { return new vec4(g, b, b, r); } set { this.g = value.a0; this.b = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 gbbg { get { return new vec4(g, b, b, g); } set { this.g = value.a0; this.b = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 gbbb { get { return new vec4(g, b, b, b); } set { this.g = value.a0; this.b = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 gbba { get { return new vec4(g, b, b, a); } set { this.g = value.a0; this.b = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 gbar { get { return new vec4(g, b, a, r); } set { this.g = value.a0; this.b = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 gbag { get { return new vec4(g, b, a, g); } set { this.g = value.a0; this.b = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 gbab { get { return new vec4(g, b, a, b); } set { this.g = value.a0; this.b = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 gbaa { get { return new vec4(g, b, a, a); } set { this.g = value.a0; this.b = value.a1; this.a = value.a2; this.a = value.a3; } }
        public vec4 garr { get { return new vec4(g, a, r, r); } set { this.g = value.a0; this.a = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 garg { get { return new vec4(g, a, r, g); } set { this.g = value.a0; this.a = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 garb { get { return new vec4(g, a, r, b); } set { this.g = value.a0; this.a = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 gara { get { return new vec4(g, a, r, a); } set { this.g = value.a0; this.a = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 gagr { get { return new vec4(g, a, g, r); } set { this.g = value.a0; this.a = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 gagg { get { return new vec4(g, a, g, g); } set { this.g = value.a0; this.a = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 gagb { get { return new vec4(g, a, g, b); } set { this.g = value.a0; this.a = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 gaga { get { return new vec4(g, a, g, a); } set { this.g = value.a0; this.a = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 gabr { get { return new vec4(g, a, b, r); } set { this.g = value.a0; this.a = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 gabg { get { return new vec4(g, a, b, g); } set { this.g = value.a0; this.a = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 gabb { get { return new vec4(g, a, b, b); } set { this.g = value.a0; this.a = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 gaba { get { return new vec4(g, a, b, a); } set { this.g = value.a0; this.a = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 gaar { get { return new vec4(g, a, a, r); } set { this.g = value.a0; this.a = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 gaag { get { return new vec4(g, a, a, g); } set { this.g = value.a0; this.a = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 gaab { get { return new vec4(g, a, a, b); } set { this.g = value.a0; this.a = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 gaaa { get { return new vec4(g, a, a, a); } set { this.g = value.a0; this.a = value.a1; this.a = value.a2; this.a = value.a3; } }
        public vec4 brrr { get { return new vec4(b, r, r, r); } set { this.b = value.a0; this.r = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 brrg { get { return new vec4(b, r, r, g); } set { this.b = value.a0; this.r = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 brrb { get { return new vec4(b, r, r, b); } set { this.b = value.a0; this.r = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 brra { get { return new vec4(b, r, r, a); } set { this.b = value.a0; this.r = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 brgr { get { return new vec4(b, r, g, r); } set { this.b = value.a0; this.r = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 brgg { get { return new vec4(b, r, g, g); } set { this.b = value.a0; this.r = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 brgb { get { return new vec4(b, r, g, b); } set { this.b = value.a0; this.r = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 brga { get { return new vec4(b, r, g, a); } set { this.b = value.a0; this.r = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 brbr { get { return new vec4(b, r, b, r); } set { this.b = value.a0; this.r = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 brbg { get { return new vec4(b, r, b, g); } set { this.b = value.a0; this.r = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 brbb { get { return new vec4(b, r, b, b); } set { this.b = value.a0; this.r = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 brba { get { return new vec4(b, r, b, a); } set { this.b = value.a0; this.r = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 brar { get { return new vec4(b, r, a, r); } set { this.b = value.a0; this.r = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 brag { get { return new vec4(b, r, a, g); } set { this.b = value.a0; this.r = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 brab { get { return new vec4(b, r, a, b); } set { this.b = value.a0; this.r = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 braa { get { return new vec4(b, r, a, a); } set { this.b = value.a0; this.r = value.a1; this.a = value.a2; this.a = value.a3; } }
        public vec4 bgrr { get { return new vec4(b, g, r, r); } set { this.b = value.a0; this.g = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 bgrg { get { return new vec4(b, g, r, g); } set { this.b = value.a0; this.g = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 bgrb { get { return new vec4(b, g, r, b); } set { this.b = value.a0; this.g = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 bgra { get { return new vec4(b, g, r, a); } set { this.b = value.a0; this.g = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 bggr { get { return new vec4(b, g, g, r); } set { this.b = value.a0; this.g = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 bggg { get { return new vec4(b, g, g, g); } set { this.b = value.a0; this.g = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 bggb { get { return new vec4(b, g, g, b); } set { this.b = value.a0; this.g = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 bgga { get { return new vec4(b, g, g, a); } set { this.b = value.a0; this.g = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 bgbr { get { return new vec4(b, g, b, r); } set { this.b = value.a0; this.g = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 bgbg { get { return new vec4(b, g, b, g); } set { this.b = value.a0; this.g = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 bgbb { get { return new vec4(b, g, b, b); } set { this.b = value.a0; this.g = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 bgba { get { return new vec4(b, g, b, a); } set { this.b = value.a0; this.g = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 bgar { get { return new vec4(b, g, a, r); } set { this.b = value.a0; this.g = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 bgag { get { return new vec4(b, g, a, g); } set { this.b = value.a0; this.g = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 bgab { get { return new vec4(b, g, a, b); } set { this.b = value.a0; this.g = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 bgaa { get { return new vec4(b, g, a, a); } set { this.b = value.a0; this.g = value.a1; this.a = value.a2; this.a = value.a3; } }
        public vec4 bbrr { get { return new vec4(b, b, r, r); } set { this.b = value.a0; this.b = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 bbrg { get { return new vec4(b, b, r, g); } set { this.b = value.a0; this.b = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 bbrb { get { return new vec4(b, b, r, b); } set { this.b = value.a0; this.b = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 bbra { get { return new vec4(b, b, r, a); } set { this.b = value.a0; this.b = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 bbgr { get { return new vec4(b, b, g, r); } set { this.b = value.a0; this.b = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 bbgg { get { return new vec4(b, b, g, g); } set { this.b = value.a0; this.b = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 bbgb { get { return new vec4(b, b, g, b); } set { this.b = value.a0; this.b = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 bbga { get { return new vec4(b, b, g, a); } set { this.b = value.a0; this.b = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 bbbr { get { return new vec4(b, b, b, r); } set { this.b = value.a0; this.b = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 bbbg { get { return new vec4(b, b, b, g); } set { this.b = value.a0; this.b = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 bbbb { get { return new vec4(b, b, b, b); } set { this.b = value.a0; this.b = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 bbba { get { return new vec4(b, b, b, a); } set { this.b = value.a0; this.b = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 bbar { get { return new vec4(b, b, a, r); } set { this.b = value.a0; this.b = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 bbag { get { return new vec4(b, b, a, g); } set { this.b = value.a0; this.b = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 bbab { get { return new vec4(b, b, a, b); } set { this.b = value.a0; this.b = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 bbaa { get { return new vec4(b, b, a, a); } set { this.b = value.a0; this.b = value.a1; this.a = value.a2; this.a = value.a3; } }
        public vec4 barr { get { return new vec4(b, a, r, r); } set { this.b = value.a0; this.a = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 barg { get { return new vec4(b, a, r, g); } set { this.b = value.a0; this.a = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 barb { get { return new vec4(b, a, r, b); } set { this.b = value.a0; this.a = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 bara { get { return new vec4(b, a, r, a); } set { this.b = value.a0; this.a = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 bagr { get { return new vec4(b, a, g, r); } set { this.b = value.a0; this.a = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 bagg { get { return new vec4(b, a, g, g); } set { this.b = value.a0; this.a = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 bagb { get { return new vec4(b, a, g, b); } set { this.b = value.a0; this.a = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 baga { get { return new vec4(b, a, g, a); } set { this.b = value.a0; this.a = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 babr { get { return new vec4(b, a, b, r); } set { this.b = value.a0; this.a = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 babg { get { return new vec4(b, a, b, g); } set { this.b = value.a0; this.a = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 babb { get { return new vec4(b, a, b, b); } set { this.b = value.a0; this.a = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 baba { get { return new vec4(b, a, b, a); } set { this.b = value.a0; this.a = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 baar { get { return new vec4(b, a, a, r); } set { this.b = value.a0; this.a = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 baag { get { return new vec4(b, a, a, g); } set { this.b = value.a0; this.a = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 baab { get { return new vec4(b, a, a, b); } set { this.b = value.a0; this.a = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 baaa { get { return new vec4(b, a, a, a); } set { this.b = value.a0; this.a = value.a1; this.a = value.a2; this.a = value.a3; } }
        public vec4 arrr { get { return new vec4(a, r, r, r); } set { this.a = value.a0; this.r = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 arrg { get { return new vec4(a, r, r, g); } set { this.a = value.a0; this.r = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 arrb { get { return new vec4(a, r, r, b); } set { this.a = value.a0; this.r = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 arra { get { return new vec4(a, r, r, a); } set { this.a = value.a0; this.r = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 argr { get { return new vec4(a, r, g, r); } set { this.a = value.a0; this.r = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 argg { get { return new vec4(a, r, g, g); } set { this.a = value.a0; this.r = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 argb { get { return new vec4(a, r, g, b); } set { this.a = value.a0; this.r = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 arga { get { return new vec4(a, r, g, a); } set { this.a = value.a0; this.r = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 arbr { get { return new vec4(a, r, b, r); } set { this.a = value.a0; this.r = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 arbg { get { return new vec4(a, r, b, g); } set { this.a = value.a0; this.r = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 arbb { get { return new vec4(a, r, b, b); } set { this.a = value.a0; this.r = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 arba { get { return new vec4(a, r, b, a); } set { this.a = value.a0; this.r = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 arar { get { return new vec4(a, r, a, r); } set { this.a = value.a0; this.r = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 arag { get { return new vec4(a, r, a, g); } set { this.a = value.a0; this.r = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 arab { get { return new vec4(a, r, a, b); } set { this.a = value.a0; this.r = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 araa { get { return new vec4(a, r, a, a); } set { this.a = value.a0; this.r = value.a1; this.a = value.a2; this.a = value.a3; } }
        public vec4 agrr { get { return new vec4(a, g, r, r); } set { this.a = value.a0; this.g = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 agrg { get { return new vec4(a, g, r, g); } set { this.a = value.a0; this.g = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 agrb { get { return new vec4(a, g, r, b); } set { this.a = value.a0; this.g = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 agra { get { return new vec4(a, g, r, a); } set { this.a = value.a0; this.g = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 aggr { get { return new vec4(a, g, g, r); } set { this.a = value.a0; this.g = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 aggg { get { return new vec4(a, g, g, g); } set { this.a = value.a0; this.g = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 aggb { get { return new vec4(a, g, g, b); } set { this.a = value.a0; this.g = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 agga { get { return new vec4(a, g, g, a); } set { this.a = value.a0; this.g = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 agbr { get { return new vec4(a, g, b, r); } set { this.a = value.a0; this.g = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 agbg { get { return new vec4(a, g, b, g); } set { this.a = value.a0; this.g = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 agbb { get { return new vec4(a, g, b, b); } set { this.a = value.a0; this.g = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 agba { get { return new vec4(a, g, b, a); } set { this.a = value.a0; this.g = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 agar { get { return new vec4(a, g, a, r); } set { this.a = value.a0; this.g = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 agag { get { return new vec4(a, g, a, g); } set { this.a = value.a0; this.g = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 agab { get { return new vec4(a, g, a, b); } set { this.a = value.a0; this.g = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 agaa { get { return new vec4(a, g, a, a); } set { this.a = value.a0; this.g = value.a1; this.a = value.a2; this.a = value.a3; } }
        public vec4 abrr { get { return new vec4(a, b, r, r); } set { this.a = value.a0; this.b = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 abrg { get { return new vec4(a, b, r, g); } set { this.a = value.a0; this.b = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 abrb { get { return new vec4(a, b, r, b); } set { this.a = value.a0; this.b = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 abra { get { return new vec4(a, b, r, a); } set { this.a = value.a0; this.b = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 abgr { get { return new vec4(a, b, g, r); } set { this.a = value.a0; this.b = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 abgg { get { return new vec4(a, b, g, g); } set { this.a = value.a0; this.b = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 abgb { get { return new vec4(a, b, g, b); } set { this.a = value.a0; this.b = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 abga { get { return new vec4(a, b, g, a); } set { this.a = value.a0; this.b = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 abbr { get { return new vec4(a, b, b, r); } set { this.a = value.a0; this.b = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 abbg { get { return new vec4(a, b, b, g); } set { this.a = value.a0; this.b = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 abbb { get { return new vec4(a, b, b, b); } set { this.a = value.a0; this.b = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 abba { get { return new vec4(a, b, b, a); } set { this.a = value.a0; this.b = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 abar { get { return new vec4(a, b, a, r); } set { this.a = value.a0; this.b = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 abag { get { return new vec4(a, b, a, g); } set { this.a = value.a0; this.b = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 abab { get { return new vec4(a, b, a, b); } set { this.a = value.a0; this.b = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 abaa { get { return new vec4(a, b, a, a); } set { this.a = value.a0; this.b = value.a1; this.a = value.a2; this.a = value.a3; } }
        public vec4 aarr { get { return new vec4(a, a, r, r); } set { this.a = value.a0; this.a = value.a1; this.r = value.a2; this.r = value.a3; } }
        public vec4 aarg { get { return new vec4(a, a, r, g); } set { this.a = value.a0; this.a = value.a1; this.r = value.a2; this.g = value.a3; } }
        public vec4 aarb { get { return new vec4(a, a, r, b); } set { this.a = value.a0; this.a = value.a1; this.r = value.a2; this.b = value.a3; } }
        public vec4 aara { get { return new vec4(a, a, r, a); } set { this.a = value.a0; this.a = value.a1; this.r = value.a2; this.a = value.a3; } }
        public vec4 aagr { get { return new vec4(a, a, g, r); } set { this.a = value.a0; this.a = value.a1; this.g = value.a2; this.r = value.a3; } }
        public vec4 aagg { get { return new vec4(a, a, g, g); } set { this.a = value.a0; this.a = value.a1; this.g = value.a2; this.g = value.a3; } }
        public vec4 aagb { get { return new vec4(a, a, g, b); } set { this.a = value.a0; this.a = value.a1; this.g = value.a2; this.b = value.a3; } }
        public vec4 aaga { get { return new vec4(a, a, g, a); } set { this.a = value.a0; this.a = value.a1; this.g = value.a2; this.a = value.a3; } }
        public vec4 aabr { get { return new vec4(a, a, b, r); } set { this.a = value.a0; this.a = value.a1; this.b = value.a2; this.r = value.a3; } }
        public vec4 aabg { get { return new vec4(a, a, b, g); } set { this.a = value.a0; this.a = value.a1; this.b = value.a2; this.g = value.a3; } }
        public vec4 aabb { get { return new vec4(a, a, b, b); } set { this.a = value.a0; this.a = value.a1; this.b = value.a2; this.b = value.a3; } }
        public vec4 aaba { get { return new vec4(a, a, b, a); } set { this.a = value.a0; this.a = value.a1; this.b = value.a2; this.a = value.a3; } }
        public vec4 aaar { get { return new vec4(a, a, a, r); } set { this.a = value.a0; this.a = value.a1; this.a = value.a2; this.r = value.a3; } }
        public vec4 aaag { get { return new vec4(a, a, a, g); } set { this.a = value.a0; this.a = value.a1; this.a = value.a2; this.g = value.a3; } }
        public vec4 aaab { get { return new vec4(a, a, a, b); } set { this.a = value.a0; this.a = value.a1; this.a = value.a2; this.b = value.a3; } }
        public vec4 aaaa { get { return new vec4(a, a, a, a); } set { this.a = value.a0; this.a = value.a1; this.a = value.a2; this.a = value.a3; } }
        public float s { get { return a0; } set { a0 = s; } }
        public float t { get { return a1; } set { a1 = t; } }
        public float p { get { return a2; } set { a2 = p; } }
        public float q { get { return a3; } set { a3 = q; } }

        public vec2 ss { get { return new vec2(s, s); } set { this.s = value.a0; this.s = value.a1; } }
        public vec2 st { get { return new vec2(s, t); } set { this.s = value.a0; this.t = value.a1; } }
        public vec2 sp { get { return new vec2(s, p); } set { this.s = value.a0; this.p = value.a1; } }
        public vec2 sq { get { return new vec2(s, q); } set { this.s = value.a0; this.q = value.a1; } }
        public vec2 ts { get { return new vec2(t, s); } set { this.t = value.a0; this.s = value.a1; } }
        public vec2 tt { get { return new vec2(t, t); } set { this.t = value.a0; this.t = value.a1; } }
        public vec2 tp { get { return new vec2(t, p); } set { this.t = value.a0; this.p = value.a1; } }
        public vec2 tq { get { return new vec2(t, q); } set { this.t = value.a0; this.q = value.a1; } }
        public vec2 ps { get { return new vec2(p, s); } set { this.p = value.a0; this.s = value.a1; } }
        public vec2 pt { get { return new vec2(p, t); } set { this.p = value.a0; this.t = value.a1; } }
        public vec2 pp { get { return new vec2(p, p); } set { this.p = value.a0; this.p = value.a1; } }
        public vec2 pq { get { return new vec2(p, q); } set { this.p = value.a0; this.q = value.a1; } }
        public vec2 qs { get { return new vec2(q, s); } set { this.q = value.a0; this.s = value.a1; } }
        public vec2 qt { get { return new vec2(q, t); } set { this.q = value.a0; this.t = value.a1; } }
        public vec2 qp { get { return new vec2(q, p); } set { this.q = value.a0; this.p = value.a1; } }
        public vec2 qq { get { return new vec2(q, q); } set { this.q = value.a0; this.q = value.a1; } }

        public vec3 sss { get { return new vec3(s, s, s); } set { this.s = value.a0; this.s = value.a1; this.s = value.a2; } }
        public vec3 sst { get { return new vec3(s, s, t); } set { this.s = value.a0; this.s = value.a1; this.t = value.a2; } }
        public vec3 ssp { get { return new vec3(s, s, p); } set { this.s = value.a0; this.s = value.a1; this.p = value.a2; } }
        public vec3 ssq { get { return new vec3(s, s, q); } set { this.s = value.a0; this.s = value.a1; this.q = value.a2; } }
        public vec3 sts { get { return new vec3(s, t, s); } set { this.s = value.a0; this.t = value.a1; this.s = value.a2; } }
        public vec3 stt { get { return new vec3(s, t, t); } set { this.s = value.a0; this.t = value.a1; this.t = value.a2; } }
        public vec3 stp { get { return new vec3(s, t, p); } set { this.s = value.a0; this.t = value.a1; this.p = value.a2; } }
        public vec3 stq { get { return new vec3(s, t, q); } set { this.s = value.a0; this.t = value.a1; this.q = value.a2; } }
        public vec3 sps { get { return new vec3(s, p, s); } set { this.s = value.a0; this.p = value.a1; this.s = value.a2; } }
        public vec3 spt { get { return new vec3(s, p, t); } set { this.s = value.a0; this.p = value.a1; this.t = value.a2; } }
        public vec3 spp { get { return new vec3(s, p, p); } set { this.s = value.a0; this.p = value.a1; this.p = value.a2; } }
        public vec3 spq { get { return new vec3(s, p, q); } set { this.s = value.a0; this.p = value.a1; this.q = value.a2; } }
        public vec3 sqs { get { return new vec3(s, q, s); } set { this.s = value.a0; this.q = value.a1; this.s = value.a2; } }
        public vec3 sqt { get { return new vec3(s, q, t); } set { this.s = value.a0; this.q = value.a1; this.t = value.a2; } }
        public vec3 sqp { get { return new vec3(s, q, p); } set { this.s = value.a0; this.q = value.a1; this.p = value.a2; } }
        public vec3 sqq { get { return new vec3(s, q, q); } set { this.s = value.a0; this.q = value.a1; this.q = value.a2; } }
        public vec3 tss { get { return new vec3(t, s, s); } set { this.t = value.a0; this.s = value.a1; this.s = value.a2; } }
        public vec3 tst { get { return new vec3(t, s, t); } set { this.t = value.a0; this.s = value.a1; this.t = value.a2; } }
        public vec3 tsp { get { return new vec3(t, s, p); } set { this.t = value.a0; this.s = value.a1; this.p = value.a2; } }
        public vec3 tsq { get { return new vec3(t, s, q); } set { this.t = value.a0; this.s = value.a1; this.q = value.a2; } }
        public vec3 tts { get { return new vec3(t, t, s); } set { this.t = value.a0; this.t = value.a1; this.s = value.a2; } }
        public vec3 ttt { get { return new vec3(t, t, t); } set { this.t = value.a0; this.t = value.a1; this.t = value.a2; } }
        public vec3 ttp { get { return new vec3(t, t, p); } set { this.t = value.a0; this.t = value.a1; this.p = value.a2; } }
        public vec3 ttq { get { return new vec3(t, t, q); } set { this.t = value.a0; this.t = value.a1; this.q = value.a2; } }
        public vec3 tps { get { return new vec3(t, p, s); } set { this.t = value.a0; this.p = value.a1; this.s = value.a2; } }
        public vec3 tpt { get { return new vec3(t, p, t); } set { this.t = value.a0; this.p = value.a1; this.t = value.a2; } }
        public vec3 tpp { get { return new vec3(t, p, p); } set { this.t = value.a0; this.p = value.a1; this.p = value.a2; } }
        public vec3 tpq { get { return new vec3(t, p, q); } set { this.t = value.a0; this.p = value.a1; this.q = value.a2; } }
        public vec3 tqs { get { return new vec3(t, q, s); } set { this.t = value.a0; this.q = value.a1; this.s = value.a2; } }
        public vec3 tqt { get { return new vec3(t, q, t); } set { this.t = value.a0; this.q = value.a1; this.t = value.a2; } }
        public vec3 tqp { get { return new vec3(t, q, p); } set { this.t = value.a0; this.q = value.a1; this.p = value.a2; } }
        public vec3 tqq { get { return new vec3(t, q, q); } set { this.t = value.a0; this.q = value.a1; this.q = value.a2; } }
        public vec3 pss { get { return new vec3(p, s, s); } set { this.p = value.a0; this.s = value.a1; this.s = value.a2; } }
        public vec3 pst { get { return new vec3(p, s, t); } set { this.p = value.a0; this.s = value.a1; this.t = value.a2; } }
        public vec3 psp { get { return new vec3(p, s, p); } set { this.p = value.a0; this.s = value.a1; this.p = value.a2; } }
        public vec3 psq { get { return new vec3(p, s, q); } set { this.p = value.a0; this.s = value.a1; this.q = value.a2; } }
        public vec3 pts { get { return new vec3(p, t, s); } set { this.p = value.a0; this.t = value.a1; this.s = value.a2; } }
        public vec3 ptt { get { return new vec3(p, t, t); } set { this.p = value.a0; this.t = value.a1; this.t = value.a2; } }
        public vec3 ptp { get { return new vec3(p, t, p); } set { this.p = value.a0; this.t = value.a1; this.p = value.a2; } }
        public vec3 ptq { get { return new vec3(p, t, q); } set { this.p = value.a0; this.t = value.a1; this.q = value.a2; } }
        public vec3 pps { get { return new vec3(p, p, s); } set { this.p = value.a0; this.p = value.a1; this.s = value.a2; } }
        public vec3 ppt { get { return new vec3(p, p, t); } set { this.p = value.a0; this.p = value.a1; this.t = value.a2; } }
        public vec3 ppp { get { return new vec3(p, p, p); } set { this.p = value.a0; this.p = value.a1; this.p = value.a2; } }
        public vec3 ppq { get { return new vec3(p, p, q); } set { this.p = value.a0; this.p = value.a1; this.q = value.a2; } }
        public vec3 pqs { get { return new vec3(p, q, s); } set { this.p = value.a0; this.q = value.a1; this.s = value.a2; } }
        public vec3 pqt { get { return new vec3(p, q, t); } set { this.p = value.a0; this.q = value.a1; this.t = value.a2; } }
        public vec3 pqp { get { return new vec3(p, q, p); } set { this.p = value.a0; this.q = value.a1; this.p = value.a2; } }
        public vec3 pqq { get { return new vec3(p, q, q); } set { this.p = value.a0; this.q = value.a1; this.q = value.a2; } }
        public vec3 qss { get { return new vec3(q, s, s); } set { this.q = value.a0; this.s = value.a1; this.s = value.a2; } }
        public vec3 qst { get { return new vec3(q, s, t); } set { this.q = value.a0; this.s = value.a1; this.t = value.a2; } }
        public vec3 qsp { get { return new vec3(q, s, p); } set { this.q = value.a0; this.s = value.a1; this.p = value.a2; } }
        public vec3 qsq { get { return new vec3(q, s, q); } set { this.q = value.a0; this.s = value.a1; this.q = value.a2; } }
        public vec3 qts { get { return new vec3(q, t, s); } set { this.q = value.a0; this.t = value.a1; this.s = value.a2; } }
        public vec3 qtt { get { return new vec3(q, t, t); } set { this.q = value.a0; this.t = value.a1; this.t = value.a2; } }
        public vec3 qtp { get { return new vec3(q, t, p); } set { this.q = value.a0; this.t = value.a1; this.p = value.a2; } }
        public vec3 qtq { get { return new vec3(q, t, q); } set { this.q = value.a0; this.t = value.a1; this.q = value.a2; } }
        public vec3 qps { get { return new vec3(q, p, s); } set { this.q = value.a0; this.p = value.a1; this.s = value.a2; } }
        public vec3 qpt { get { return new vec3(q, p, t); } set { this.q = value.a0; this.p = value.a1; this.t = value.a2; } }
        public vec3 qpp { get { return new vec3(q, p, p); } set { this.q = value.a0; this.p = value.a1; this.p = value.a2; } }
        public vec3 qpq { get { return new vec3(q, p, q); } set { this.q = value.a0; this.p = value.a1; this.q = value.a2; } }
        public vec3 qqs { get { return new vec3(q, q, s); } set { this.q = value.a0; this.q = value.a1; this.s = value.a2; } }
        public vec3 qqt { get { return new vec3(q, q, t); } set { this.q = value.a0; this.q = value.a1; this.t = value.a2; } }
        public vec3 qqp { get { return new vec3(q, q, p); } set { this.q = value.a0; this.q = value.a1; this.p = value.a2; } }
        public vec3 qqq { get { return new vec3(q, q, q); } set { this.q = value.a0; this.q = value.a1; this.q = value.a2; } }

        public vec4 ssss { get { return new vec4(s, s, s, s); } set { this.s = value.a0; this.s = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 ssst { get { return new vec4(s, s, s, t); } set { this.s = value.a0; this.s = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 sssp { get { return new vec4(s, s, s, p); } set { this.s = value.a0; this.s = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 sssq { get { return new vec4(s, s, s, q); } set { this.s = value.a0; this.s = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 ssts { get { return new vec4(s, s, t, s); } set { this.s = value.a0; this.s = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 sstt { get { return new vec4(s, s, t, t); } set { this.s = value.a0; this.s = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 sstp { get { return new vec4(s, s, t, p); } set { this.s = value.a0; this.s = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 sstq { get { return new vec4(s, s, t, q); } set { this.s = value.a0; this.s = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 ssps { get { return new vec4(s, s, p, s); } set { this.s = value.a0; this.s = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 sspt { get { return new vec4(s, s, p, t); } set { this.s = value.a0; this.s = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 sspp { get { return new vec4(s, s, p, p); } set { this.s = value.a0; this.s = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 sspq { get { return new vec4(s, s, p, q); } set { this.s = value.a0; this.s = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 ssqs { get { return new vec4(s, s, q, s); } set { this.s = value.a0; this.s = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 ssqt { get { return new vec4(s, s, q, t); } set { this.s = value.a0; this.s = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 ssqp { get { return new vec4(s, s, q, p); } set { this.s = value.a0; this.s = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 ssqq { get { return new vec4(s, s, q, q); } set { this.s = value.a0; this.s = value.a1; this.q = value.a2; this.q = value.a3; } }
        public vec4 stss { get { return new vec4(s, t, s, s); } set { this.s = value.a0; this.t = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 stst { get { return new vec4(s, t, s, t); } set { this.s = value.a0; this.t = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 stsp { get { return new vec4(s, t, s, p); } set { this.s = value.a0; this.t = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 stsq { get { return new vec4(s, t, s, q); } set { this.s = value.a0; this.t = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 stts { get { return new vec4(s, t, t, s); } set { this.s = value.a0; this.t = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 sttt { get { return new vec4(s, t, t, t); } set { this.s = value.a0; this.t = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 sttp { get { return new vec4(s, t, t, p); } set { this.s = value.a0; this.t = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 sttq { get { return new vec4(s, t, t, q); } set { this.s = value.a0; this.t = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 stps { get { return new vec4(s, t, p, s); } set { this.s = value.a0; this.t = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 stpt { get { return new vec4(s, t, p, t); } set { this.s = value.a0; this.t = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 stpp { get { return new vec4(s, t, p, p); } set { this.s = value.a0; this.t = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 stpq { get { return new vec4(s, t, p, q); } set { this.s = value.a0; this.t = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 stqs { get { return new vec4(s, t, q, s); } set { this.s = value.a0; this.t = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 stqt { get { return new vec4(s, t, q, t); } set { this.s = value.a0; this.t = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 stqp { get { return new vec4(s, t, q, p); } set { this.s = value.a0; this.t = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 stqq { get { return new vec4(s, t, q, q); } set { this.s = value.a0; this.t = value.a1; this.q = value.a2; this.q = value.a3; } }
        public vec4 spss { get { return new vec4(s, p, s, s); } set { this.s = value.a0; this.p = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 spst { get { return new vec4(s, p, s, t); } set { this.s = value.a0; this.p = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 spsp { get { return new vec4(s, p, s, p); } set { this.s = value.a0; this.p = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 spsq { get { return new vec4(s, p, s, q); } set { this.s = value.a0; this.p = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 spts { get { return new vec4(s, p, t, s); } set { this.s = value.a0; this.p = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 sptt { get { return new vec4(s, p, t, t); } set { this.s = value.a0; this.p = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 sptp { get { return new vec4(s, p, t, p); } set { this.s = value.a0; this.p = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 sptq { get { return new vec4(s, p, t, q); } set { this.s = value.a0; this.p = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 spps { get { return new vec4(s, p, p, s); } set { this.s = value.a0; this.p = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 sppt { get { return new vec4(s, p, p, t); } set { this.s = value.a0; this.p = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 sppp { get { return new vec4(s, p, p, p); } set { this.s = value.a0; this.p = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 sppq { get { return new vec4(s, p, p, q); } set { this.s = value.a0; this.p = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 spqs { get { return new vec4(s, p, q, s); } set { this.s = value.a0; this.p = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 spqt { get { return new vec4(s, p, q, t); } set { this.s = value.a0; this.p = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 spqp { get { return new vec4(s, p, q, p); } set { this.s = value.a0; this.p = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 spqq { get { return new vec4(s, p, q, q); } set { this.s = value.a0; this.p = value.a1; this.q = value.a2; this.q = value.a3; } }
        public vec4 sqss { get { return new vec4(s, q, s, s); } set { this.s = value.a0; this.q = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 sqst { get { return new vec4(s, q, s, t); } set { this.s = value.a0; this.q = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 sqsp { get { return new vec4(s, q, s, p); } set { this.s = value.a0; this.q = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 sqsq { get { return new vec4(s, q, s, q); } set { this.s = value.a0; this.q = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 sqts { get { return new vec4(s, q, t, s); } set { this.s = value.a0; this.q = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 sqtt { get { return new vec4(s, q, t, t); } set { this.s = value.a0; this.q = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 sqtp { get { return new vec4(s, q, t, p); } set { this.s = value.a0; this.q = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 sqtq { get { return new vec4(s, q, t, q); } set { this.s = value.a0; this.q = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 sqps { get { return new vec4(s, q, p, s); } set { this.s = value.a0; this.q = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 sqpt { get { return new vec4(s, q, p, t); } set { this.s = value.a0; this.q = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 sqpp { get { return new vec4(s, q, p, p); } set { this.s = value.a0; this.q = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 sqpq { get { return new vec4(s, q, p, q); } set { this.s = value.a0; this.q = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 sqqs { get { return new vec4(s, q, q, s); } set { this.s = value.a0; this.q = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 sqqt { get { return new vec4(s, q, q, t); } set { this.s = value.a0; this.q = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 sqqp { get { return new vec4(s, q, q, p); } set { this.s = value.a0; this.q = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 sqqq { get { return new vec4(s, q, q, q); } set { this.s = value.a0; this.q = value.a1; this.q = value.a2; this.q = value.a3; } }
        public vec4 tsss { get { return new vec4(t, s, s, s); } set { this.t = value.a0; this.s = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 tsst { get { return new vec4(t, s, s, t); } set { this.t = value.a0; this.s = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 tssp { get { return new vec4(t, s, s, p); } set { this.t = value.a0; this.s = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 tssq { get { return new vec4(t, s, s, q); } set { this.t = value.a0; this.s = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 tsts { get { return new vec4(t, s, t, s); } set { this.t = value.a0; this.s = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 tstt { get { return new vec4(t, s, t, t); } set { this.t = value.a0; this.s = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 tstp { get { return new vec4(t, s, t, p); } set { this.t = value.a0; this.s = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 tstq { get { return new vec4(t, s, t, q); } set { this.t = value.a0; this.s = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 tsps { get { return new vec4(t, s, p, s); } set { this.t = value.a0; this.s = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 tspt { get { return new vec4(t, s, p, t); } set { this.t = value.a0; this.s = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 tspp { get { return new vec4(t, s, p, p); } set { this.t = value.a0; this.s = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 tspq { get { return new vec4(t, s, p, q); } set { this.t = value.a0; this.s = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 tsqs { get { return new vec4(t, s, q, s); } set { this.t = value.a0; this.s = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 tsqt { get { return new vec4(t, s, q, t); } set { this.t = value.a0; this.s = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 tsqp { get { return new vec4(t, s, q, p); } set { this.t = value.a0; this.s = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 tsqq { get { return new vec4(t, s, q, q); } set { this.t = value.a0; this.s = value.a1; this.q = value.a2; this.q = value.a3; } }
        public vec4 ttss { get { return new vec4(t, t, s, s); } set { this.t = value.a0; this.t = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 ttst { get { return new vec4(t, t, s, t); } set { this.t = value.a0; this.t = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 ttsp { get { return new vec4(t, t, s, p); } set { this.t = value.a0; this.t = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 ttsq { get { return new vec4(t, t, s, q); } set { this.t = value.a0; this.t = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 ttts { get { return new vec4(t, t, t, s); } set { this.t = value.a0; this.t = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 tttt { get { return new vec4(t, t, t, t); } set { this.t = value.a0; this.t = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 tttp { get { return new vec4(t, t, t, p); } set { this.t = value.a0; this.t = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 tttq { get { return new vec4(t, t, t, q); } set { this.t = value.a0; this.t = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 ttps { get { return new vec4(t, t, p, s); } set { this.t = value.a0; this.t = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 ttpt { get { return new vec4(t, t, p, t); } set { this.t = value.a0; this.t = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 ttpp { get { return new vec4(t, t, p, p); } set { this.t = value.a0; this.t = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 ttpq { get { return new vec4(t, t, p, q); } set { this.t = value.a0; this.t = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 ttqs { get { return new vec4(t, t, q, s); } set { this.t = value.a0; this.t = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 ttqt { get { return new vec4(t, t, q, t); } set { this.t = value.a0; this.t = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 ttqp { get { return new vec4(t, t, q, p); } set { this.t = value.a0; this.t = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 ttqq { get { return new vec4(t, t, q, q); } set { this.t = value.a0; this.t = value.a1; this.q = value.a2; this.q = value.a3; } }
        public vec4 tpss { get { return new vec4(t, p, s, s); } set { this.t = value.a0; this.p = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 tpst { get { return new vec4(t, p, s, t); } set { this.t = value.a0; this.p = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 tpsp { get { return new vec4(t, p, s, p); } set { this.t = value.a0; this.p = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 tpsq { get { return new vec4(t, p, s, q); } set { this.t = value.a0; this.p = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 tpts { get { return new vec4(t, p, t, s); } set { this.t = value.a0; this.p = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 tptt { get { return new vec4(t, p, t, t); } set { this.t = value.a0; this.p = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 tptp { get { return new vec4(t, p, t, p); } set { this.t = value.a0; this.p = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 tptq { get { return new vec4(t, p, t, q); } set { this.t = value.a0; this.p = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 tpps { get { return new vec4(t, p, p, s); } set { this.t = value.a0; this.p = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 tppt { get { return new vec4(t, p, p, t); } set { this.t = value.a0; this.p = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 tppp { get { return new vec4(t, p, p, p); } set { this.t = value.a0; this.p = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 tppq { get { return new vec4(t, p, p, q); } set { this.t = value.a0; this.p = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 tpqs { get { return new vec4(t, p, q, s); } set { this.t = value.a0; this.p = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 tpqt { get { return new vec4(t, p, q, t); } set { this.t = value.a0; this.p = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 tpqp { get { return new vec4(t, p, q, p); } set { this.t = value.a0; this.p = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 tpqq { get { return new vec4(t, p, q, q); } set { this.t = value.a0; this.p = value.a1; this.q = value.a2; this.q = value.a3; } }
        public vec4 tqss { get { return new vec4(t, q, s, s); } set { this.t = value.a0; this.q = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 tqst { get { return new vec4(t, q, s, t); } set { this.t = value.a0; this.q = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 tqsp { get { return new vec4(t, q, s, p); } set { this.t = value.a0; this.q = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 tqsq { get { return new vec4(t, q, s, q); } set { this.t = value.a0; this.q = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 tqts { get { return new vec4(t, q, t, s); } set { this.t = value.a0; this.q = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 tqtt { get { return new vec4(t, q, t, t); } set { this.t = value.a0; this.q = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 tqtp { get { return new vec4(t, q, t, p); } set { this.t = value.a0; this.q = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 tqtq { get { return new vec4(t, q, t, q); } set { this.t = value.a0; this.q = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 tqps { get { return new vec4(t, q, p, s); } set { this.t = value.a0; this.q = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 tqpt { get { return new vec4(t, q, p, t); } set { this.t = value.a0; this.q = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 tqpp { get { return new vec4(t, q, p, p); } set { this.t = value.a0; this.q = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 tqpq { get { return new vec4(t, q, p, q); } set { this.t = value.a0; this.q = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 tqqs { get { return new vec4(t, q, q, s); } set { this.t = value.a0; this.q = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 tqqt { get { return new vec4(t, q, q, t); } set { this.t = value.a0; this.q = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 tqqp { get { return new vec4(t, q, q, p); } set { this.t = value.a0; this.q = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 tqqq { get { return new vec4(t, q, q, q); } set { this.t = value.a0; this.q = value.a1; this.q = value.a2; this.q = value.a3; } }
        public vec4 psss { get { return new vec4(p, s, s, s); } set { this.p = value.a0; this.s = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 psst { get { return new vec4(p, s, s, t); } set { this.p = value.a0; this.s = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 pssp { get { return new vec4(p, s, s, p); } set { this.p = value.a0; this.s = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 pssq { get { return new vec4(p, s, s, q); } set { this.p = value.a0; this.s = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 psts { get { return new vec4(p, s, t, s); } set { this.p = value.a0; this.s = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 pstt { get { return new vec4(p, s, t, t); } set { this.p = value.a0; this.s = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 pstp { get { return new vec4(p, s, t, p); } set { this.p = value.a0; this.s = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 pstq { get { return new vec4(p, s, t, q); } set { this.p = value.a0; this.s = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 psps { get { return new vec4(p, s, p, s); } set { this.p = value.a0; this.s = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 pspt { get { return new vec4(p, s, p, t); } set { this.p = value.a0; this.s = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 pspp { get { return new vec4(p, s, p, p); } set { this.p = value.a0; this.s = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 pspq { get { return new vec4(p, s, p, q); } set { this.p = value.a0; this.s = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 psqs { get { return new vec4(p, s, q, s); } set { this.p = value.a0; this.s = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 psqt { get { return new vec4(p, s, q, t); } set { this.p = value.a0; this.s = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 psqp { get { return new vec4(p, s, q, p); } set { this.p = value.a0; this.s = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 psqq { get { return new vec4(p, s, q, q); } set { this.p = value.a0; this.s = value.a1; this.q = value.a2; this.q = value.a3; } }
        public vec4 ptss { get { return new vec4(p, t, s, s); } set { this.p = value.a0; this.t = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 ptst { get { return new vec4(p, t, s, t); } set { this.p = value.a0; this.t = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 ptsp { get { return new vec4(p, t, s, p); } set { this.p = value.a0; this.t = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 ptsq { get { return new vec4(p, t, s, q); } set { this.p = value.a0; this.t = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 ptts { get { return new vec4(p, t, t, s); } set { this.p = value.a0; this.t = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 pttt { get { return new vec4(p, t, t, t); } set { this.p = value.a0; this.t = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 pttp { get { return new vec4(p, t, t, p); } set { this.p = value.a0; this.t = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 pttq { get { return new vec4(p, t, t, q); } set { this.p = value.a0; this.t = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 ptps { get { return new vec4(p, t, p, s); } set { this.p = value.a0; this.t = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 ptpt { get { return new vec4(p, t, p, t); } set { this.p = value.a0; this.t = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 ptpp { get { return new vec4(p, t, p, p); } set { this.p = value.a0; this.t = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 ptpq { get { return new vec4(p, t, p, q); } set { this.p = value.a0; this.t = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 ptqs { get { return new vec4(p, t, q, s); } set { this.p = value.a0; this.t = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 ptqt { get { return new vec4(p, t, q, t); } set { this.p = value.a0; this.t = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 ptqp { get { return new vec4(p, t, q, p); } set { this.p = value.a0; this.t = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 ptqq { get { return new vec4(p, t, q, q); } set { this.p = value.a0; this.t = value.a1; this.q = value.a2; this.q = value.a3; } }
        public vec4 ppss { get { return new vec4(p, p, s, s); } set { this.p = value.a0; this.p = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 ppst { get { return new vec4(p, p, s, t); } set { this.p = value.a0; this.p = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 ppsp { get { return new vec4(p, p, s, p); } set { this.p = value.a0; this.p = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 ppsq { get { return new vec4(p, p, s, q); } set { this.p = value.a0; this.p = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 ppts { get { return new vec4(p, p, t, s); } set { this.p = value.a0; this.p = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 pptt { get { return new vec4(p, p, t, t); } set { this.p = value.a0; this.p = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 pptp { get { return new vec4(p, p, t, p); } set { this.p = value.a0; this.p = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 pptq { get { return new vec4(p, p, t, q); } set { this.p = value.a0; this.p = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 ppps { get { return new vec4(p, p, p, s); } set { this.p = value.a0; this.p = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 pppt { get { return new vec4(p, p, p, t); } set { this.p = value.a0; this.p = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 pppp { get { return new vec4(p, p, p, p); } set { this.p = value.a0; this.p = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 pppq { get { return new vec4(p, p, p, q); } set { this.p = value.a0; this.p = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 ppqs { get { return new vec4(p, p, q, s); } set { this.p = value.a0; this.p = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 ppqt { get { return new vec4(p, p, q, t); } set { this.p = value.a0; this.p = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 ppqp { get { return new vec4(p, p, q, p); } set { this.p = value.a0; this.p = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 ppqq { get { return new vec4(p, p, q, q); } set { this.p = value.a0; this.p = value.a1; this.q = value.a2; this.q = value.a3; } }
        public vec4 pqss { get { return new vec4(p, q, s, s); } set { this.p = value.a0; this.q = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 pqst { get { return new vec4(p, q, s, t); } set { this.p = value.a0; this.q = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 pqsp { get { return new vec4(p, q, s, p); } set { this.p = value.a0; this.q = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 pqsq { get { return new vec4(p, q, s, q); } set { this.p = value.a0; this.q = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 pqts { get { return new vec4(p, q, t, s); } set { this.p = value.a0; this.q = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 pqtt { get { return new vec4(p, q, t, t); } set { this.p = value.a0; this.q = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 pqtp { get { return new vec4(p, q, t, p); } set { this.p = value.a0; this.q = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 pqtq { get { return new vec4(p, q, t, q); } set { this.p = value.a0; this.q = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 pqps { get { return new vec4(p, q, p, s); } set { this.p = value.a0; this.q = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 pqpt { get { return new vec4(p, q, p, t); } set { this.p = value.a0; this.q = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 pqpp { get { return new vec4(p, q, p, p); } set { this.p = value.a0; this.q = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 pqpq { get { return new vec4(p, q, p, q); } set { this.p = value.a0; this.q = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 pqqs { get { return new vec4(p, q, q, s); } set { this.p = value.a0; this.q = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 pqqt { get { return new vec4(p, q, q, t); } set { this.p = value.a0; this.q = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 pqqp { get { return new vec4(p, q, q, p); } set { this.p = value.a0; this.q = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 pqqq { get { return new vec4(p, q, q, q); } set { this.p = value.a0; this.q = value.a1; this.q = value.a2; this.q = value.a3; } }
        public vec4 qsss { get { return new vec4(q, s, s, s); } set { this.q = value.a0; this.s = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 qsst { get { return new vec4(q, s, s, t); } set { this.q = value.a0; this.s = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 qssp { get { return new vec4(q, s, s, p); } set { this.q = value.a0; this.s = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 qssq { get { return new vec4(q, s, s, q); } set { this.q = value.a0; this.s = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 qsts { get { return new vec4(q, s, t, s); } set { this.q = value.a0; this.s = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 qstt { get { return new vec4(q, s, t, t); } set { this.q = value.a0; this.s = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 qstp { get { return new vec4(q, s, t, p); } set { this.q = value.a0; this.s = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 qstq { get { return new vec4(q, s, t, q); } set { this.q = value.a0; this.s = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 qsps { get { return new vec4(q, s, p, s); } set { this.q = value.a0; this.s = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 qspt { get { return new vec4(q, s, p, t); } set { this.q = value.a0; this.s = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 qspp { get { return new vec4(q, s, p, p); } set { this.q = value.a0; this.s = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 qspq { get { return new vec4(q, s, p, q); } set { this.q = value.a0; this.s = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 qsqs { get { return new vec4(q, s, q, s); } set { this.q = value.a0; this.s = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 qsqt { get { return new vec4(q, s, q, t); } set { this.q = value.a0; this.s = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 qsqp { get { return new vec4(q, s, q, p); } set { this.q = value.a0; this.s = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 qsqq { get { return new vec4(q, s, q, q); } set { this.q = value.a0; this.s = value.a1; this.q = value.a2; this.q = value.a3; } }
        public vec4 qtss { get { return new vec4(q, t, s, s); } set { this.q = value.a0; this.t = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 qtst { get { return new vec4(q, t, s, t); } set { this.q = value.a0; this.t = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 qtsp { get { return new vec4(q, t, s, p); } set { this.q = value.a0; this.t = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 qtsq { get { return new vec4(q, t, s, q); } set { this.q = value.a0; this.t = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 qtts { get { return new vec4(q, t, t, s); } set { this.q = value.a0; this.t = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 qttt { get { return new vec4(q, t, t, t); } set { this.q = value.a0; this.t = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 qttp { get { return new vec4(q, t, t, p); } set { this.q = value.a0; this.t = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 qttq { get { return new vec4(q, t, t, q); } set { this.q = value.a0; this.t = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 qtps { get { return new vec4(q, t, p, s); } set { this.q = value.a0; this.t = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 qtpt { get { return new vec4(q, t, p, t); } set { this.q = value.a0; this.t = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 qtpp { get { return new vec4(q, t, p, p); } set { this.q = value.a0; this.t = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 qtpq { get { return new vec4(q, t, p, q); } set { this.q = value.a0; this.t = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 qtqs { get { return new vec4(q, t, q, s); } set { this.q = value.a0; this.t = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 qtqt { get { return new vec4(q, t, q, t); } set { this.q = value.a0; this.t = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 qtqp { get { return new vec4(q, t, q, p); } set { this.q = value.a0; this.t = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 qtqq { get { return new vec4(q, t, q, q); } set { this.q = value.a0; this.t = value.a1; this.q = value.a2; this.q = value.a3; } }
        public vec4 qpss { get { return new vec4(q, p, s, s); } set { this.q = value.a0; this.p = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 qpst { get { return new vec4(q, p, s, t); } set { this.q = value.a0; this.p = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 qpsp { get { return new vec4(q, p, s, p); } set { this.q = value.a0; this.p = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 qpsq { get { return new vec4(q, p, s, q); } set { this.q = value.a0; this.p = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 qpts { get { return new vec4(q, p, t, s); } set { this.q = value.a0; this.p = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 qptt { get { return new vec4(q, p, t, t); } set { this.q = value.a0; this.p = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 qptp { get { return new vec4(q, p, t, p); } set { this.q = value.a0; this.p = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 qptq { get { return new vec4(q, p, t, q); } set { this.q = value.a0; this.p = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 qpps { get { return new vec4(q, p, p, s); } set { this.q = value.a0; this.p = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 qppt { get { return new vec4(q, p, p, t); } set { this.q = value.a0; this.p = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 qppp { get { return new vec4(q, p, p, p); } set { this.q = value.a0; this.p = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 qppq { get { return new vec4(q, p, p, q); } set { this.q = value.a0; this.p = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 qpqs { get { return new vec4(q, p, q, s); } set { this.q = value.a0; this.p = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 qpqt { get { return new vec4(q, p, q, t); } set { this.q = value.a0; this.p = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 qpqp { get { return new vec4(q, p, q, p); } set { this.q = value.a0; this.p = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 qpqq { get { return new vec4(q, p, q, q); } set { this.q = value.a0; this.p = value.a1; this.q = value.a2; this.q = value.a3; } }
        public vec4 qqss { get { return new vec4(q, q, s, s); } set { this.q = value.a0; this.q = value.a1; this.s = value.a2; this.s = value.a3; } }
        public vec4 qqst { get { return new vec4(q, q, s, t); } set { this.q = value.a0; this.q = value.a1; this.s = value.a2; this.t = value.a3; } }
        public vec4 qqsp { get { return new vec4(q, q, s, p); } set { this.q = value.a0; this.q = value.a1; this.s = value.a2; this.p = value.a3; } }
        public vec4 qqsq { get { return new vec4(q, q, s, q); } set { this.q = value.a0; this.q = value.a1; this.s = value.a2; this.q = value.a3; } }
        public vec4 qqts { get { return new vec4(q, q, t, s); } set { this.q = value.a0; this.q = value.a1; this.t = value.a2; this.s = value.a3; } }
        public vec4 qqtt { get { return new vec4(q, q, t, t); } set { this.q = value.a0; this.q = value.a1; this.t = value.a2; this.t = value.a3; } }
        public vec4 qqtp { get { return new vec4(q, q, t, p); } set { this.q = value.a0; this.q = value.a1; this.t = value.a2; this.p = value.a3; } }
        public vec4 qqtq { get { return new vec4(q, q, t, q); } set { this.q = value.a0; this.q = value.a1; this.t = value.a2; this.q = value.a3; } }
        public vec4 qqps { get { return new vec4(q, q, p, s); } set { this.q = value.a0; this.q = value.a1; this.p = value.a2; this.s = value.a3; } }
        public vec4 qqpt { get { return new vec4(q, q, p, t); } set { this.q = value.a0; this.q = value.a1; this.p = value.a2; this.t = value.a3; } }
        public vec4 qqpp { get { return new vec4(q, q, p, p); } set { this.q = value.a0; this.q = value.a1; this.p = value.a2; this.p = value.a3; } }
        public vec4 qqpq { get { return new vec4(q, q, p, q); } set { this.q = value.a0; this.q = value.a1; this.p = value.a2; this.q = value.a3; } }
        public vec4 qqqs { get { return new vec4(q, q, q, s); } set { this.q = value.a0; this.q = value.a1; this.q = value.a2; this.s = value.a3; } }
        public vec4 qqqt { get { return new vec4(q, q, q, t); } set { this.q = value.a0; this.q = value.a1; this.q = value.a2; this.t = value.a3; } }
        public vec4 qqqp { get { return new vec4(q, q, q, p); } set { this.q = value.a0; this.q = value.a1; this.q = value.a2; this.p = value.a3; } }
        public vec4 qqqq { get { return new vec4(q, q, q, q); } set { this.q = value.a0; this.q = value.a1; this.q = value.a2; this.q = value.a3; } }
   
        #endregion compositions

 
        public float this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else if (index == 2) return z;
                else if (index == 3) return w;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0)      x = value;
                else if (index == 1) y = value;
                else if (index == 2) z = value;
                else if (index == 3) w = value;
                else throw new Exception("Out of range.");
            }
        }

        internal vec4() { }

        internal vec4(float s)
        {
            x = y = z = w = s;
        }

        internal vec4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        internal vec4(vec4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        internal vec4(vec3 xyz, float w)
        {
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;
            this.w = w;
        }

        public static vec4 operator -(vec4 lhs)
        {
            return new vec4(-lhs.x, -lhs.y, -lhs.z, -lhs.w);
        }

        public static vec4 operator +(vec4 lhs, vec4 rhs)
        {
            return new vec4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }

        //public static vec4 operator +(vec4 lhs, float rhs)
        //{
        //    return new vec4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs);
        //}

        //public static vec4 operator -(vec4 lhs, float rhs)
        //{
        //    return new vec4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
        //}

        public static vec4 operator -(vec4 lhs, vec4 rhs)
        {
            return new vec4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }

        public static vec4 operator *(vec4 self, float s)
        {
            return new vec4(self.x * s, self.y * s, self.z * s, self.w * s);
        }

        public static vec4 operator *(float lhs, vec4 rhs)
        {
            return new vec4(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs, rhs.w * lhs);
        }

        public static vec4 operator *(vec4 lhs, vec4 rhs)
        {
            return new vec4(rhs.x * lhs.x, rhs.y * lhs.y, rhs.z * lhs.z, rhs.w * lhs.w);
        }

        public static vec4 operator /(vec4 lhs, float rhs)
        {
            return new vec4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        }

        internal float dot(vec4 rhs)
        {
            var result = this.x * rhs.x + this.y * rhs.y + this.z * rhs.z + this.w * rhs.w;
            return result;
        }

        internal float Magnitude()
        {
            double result = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);

            return (float)result;
        }

        internal float[] to_array()
        {
            return new[] { x, y, z, w };
        }

        /// <summary>
        /// 归一化向量
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        internal vec4 normalize()
        {
            var frt = (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);

            return new vec4(x / frt, y / frt, z / frt, w / frt);
        }

        public override string ToString()
        {
            return string.Format("{0:0.00},{1:0.00},{2:0.00},{3:0.00}", x, y, z, w);
        }
    }
}