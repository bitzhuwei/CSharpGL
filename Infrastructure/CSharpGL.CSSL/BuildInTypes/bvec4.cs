using System;
using System.Runtime.InteropServices;

namespace CSharpGL.CSSL
{
    /// <summary>
    /// 专用于CSSL。不可用于数学计算。
    /// <para>Specially designed for CSSL. Not for glm.</para>
    /// </summary>
    public class bvec4
    {
        internal double a0;
        internal double a1;
        internal double a2;
        internal double a3;

        #region compositions

        public bool x { get { return false; } set { } }
        public bool y { get { return false; } set { } }
        public bool z { get { return false; } set { } }
        public bool w { get { return false; } set { } }

        public vec2 xx { get { return null; } set { } }
        public vec2 xy { get { return null; } set { } }
        public vec2 xz { get { return null; } set { } }
        public vec2 xw { get { return null; } set { } }
        public vec2 yx { get { return null; } set { } }
        public vec2 yy { get { return null; } set { } }
        public vec2 yz { get { return null; } set { } }
        public vec2 yw { get { return null; } set { } }
        public vec2 zx { get { return null; } set { } }
        public vec2 zy { get { return null; } set { } }
        public vec2 zz { get { return null; } set { } }
        public vec2 zw { get { return null; } set { } }
        public vec2 wx { get { return null; } set { } }
        public vec2 wy { get { return null; } set { } }
        public vec2 wz { get { return null; } set { } }
        public vec2 ww { get { return null; } set { } }

        public vec3 xxx { get { return null; } set { } }
        public vec3 xxy { get { return null; } set { } }
        public vec3 xxz { get { return null; } set { } }
        public vec3 xxw { get { return null; } set { } }
        public vec3 xyx { get { return null; } set { } }
        public vec3 xyy { get { return null; } set { } }
        public vec3 xyz { get { return null; } set { } }
        public vec3 xyw { get { return null; } set { } }
        public vec3 xzx { get { return null; } set { } }
        public vec3 xzy { get { return null; } set { } }
        public vec3 xzz { get { return null; } set { } }
        public vec3 xzw { get { return null; } set { } }
        public vec3 xwx { get { return null; } set { } }
        public vec3 xwy { get { return null; } set { } }
        public vec3 xwz { get { return null; } set { } }
        public vec3 xww { get { return null; } set { } }
        public vec3 yxx { get { return null; } set { } }
        public vec3 yxy { get { return null; } set { } }
        public vec3 yxz { get { return null; } set { } }
        public vec3 yxw { get { return null; } set { } }
        public vec3 yyx { get { return null; } set { } }
        public vec3 yyy { get { return null; } set { } }
        public vec3 yyz { get { return null; } set { } }
        public vec3 yyw { get { return null; } set { } }
        public vec3 yzx { get { return null; } set { } }
        public vec3 yzy { get { return null; } set { } }
        public vec3 yzz { get { return null; } set { } }
        public vec3 yzw { get { return null; } set { } }
        public vec3 ywx { get { return null; } set { } }
        public vec3 ywy { get { return null; } set { } }
        public vec3 ywz { get { return null; } set { } }
        public vec3 yww { get { return null; } set { } }
        public vec3 zxx { get { return null; } set { } }
        public vec3 zxy { get { return null; } set { } }
        public vec3 zxz { get { return null; } set { } }
        public vec3 zxw { get { return null; } set { } }
        public vec3 zyx { get { return null; } set { } }
        public vec3 zyy { get { return null; } set { } }
        public vec3 zyz { get { return null; } set { } }
        public vec3 zyw { get { return null; } set { } }
        public vec3 zzx { get { return null; } set { } }
        public vec3 zzy { get { return null; } set { } }
        public vec3 zzz { get { return null; } set { } }
        public vec3 zzw { get { return null; } set { } }
        public vec3 zwx { get { return null; } set { } }
        public vec3 zwy { get { return null; } set { } }
        public vec3 zwz { get { return null; } set { } }
        public vec3 zww { get { return null; } set { } }
        public vec3 wxx { get { return null; } set { } }
        public vec3 wxy { get { return null; } set { } }
        public vec3 wxz { get { return null; } set { } }
        public vec3 wxw { get { return null; } set { } }
        public vec3 wyx { get { return null; } set { } }
        public vec3 wyy { get { return null; } set { } }
        public vec3 wyz { get { return null; } set { } }
        public vec3 wyw { get { return null; } set { } }
        public vec3 wzx { get { return null; } set { } }
        public vec3 wzy { get { return null; } set { } }
        public vec3 wzz { get { return null; } set { } }
        public vec3 wzw { get { return null; } set { } }
        public vec3 wwx { get { return null; } set { } }
        public vec3 wwy { get { return null; } set { } }
        public vec3 wwz { get { return null; } set { } }
        public vec3 www { get { return null; } set { } }

        public bvec4 xxxx { get { return null; } set { } }
        public bvec4 xxxy { get { return null; } set { } }
        public bvec4 xxxz { get { return null; } set { } }
        public bvec4 xxxw { get { return null; } set { } }
        public bvec4 xxyx { get { return null; } set { } }
        public bvec4 xxyy { get { return null; } set { } }
        public bvec4 xxyz { get { return null; } set { } }
        public bvec4 xxyw { get { return null; } set { } }
        public bvec4 xxzx { get { return null; } set { } }
        public bvec4 xxzy { get { return null; } set { } }
        public bvec4 xxzz { get { return null; } set { } }
        public bvec4 xxzw { get { return null; } set { } }
        public bvec4 xxwx { get { return null; } set { } }
        public bvec4 xxwy { get { return null; } set { } }
        public bvec4 xxwz { get { return null; } set { } }
        public bvec4 xxww { get { return null; } set { } }
        public bvec4 xyxx { get { return null; } set { } }
        public bvec4 xyxy { get { return null; } set { } }
        public bvec4 xyxz { get { return null; } set { } }
        public bvec4 xyxw { get { return null; } set { } }
        public bvec4 xyyx { get { return null; } set { } }
        public bvec4 xyyy { get { return null; } set { } }
        public bvec4 xyyz { get { return null; } set { } }
        public bvec4 xyyw { get { return null; } set { } }
        public bvec4 xyzx { get { return null; } set { } }
        public bvec4 xyzy { get { return null; } set { } }
        public bvec4 xyzz { get { return null; } set { } }
        public bvec4 xyzw { get { return null; } set { } }
        public bvec4 xywx { get { return null; } set { } }
        public bvec4 xywy { get { return null; } set { } }
        public bvec4 xywz { get { return null; } set { } }
        public bvec4 xyww { get { return null; } set { } }
        public bvec4 xzxx { get { return null; } set { } }
        public bvec4 xzxy { get { return null; } set { } }
        public bvec4 xzxz { get { return null; } set { } }
        public bvec4 xzxw { get { return null; } set { } }
        public bvec4 xzyx { get { return null; } set { } }
        public bvec4 xzyy { get { return null; } set { } }
        public bvec4 xzyz { get { return null; } set { } }
        public bvec4 xzyw { get { return null; } set { } }
        public bvec4 xzzx { get { return null; } set { } }
        public bvec4 xzzy { get { return null; } set { } }
        public bvec4 xzzz { get { return null; } set { } }
        public bvec4 xzzw { get { return null; } set { } }
        public bvec4 xzwx { get { return null; } set { } }
        public bvec4 xzwy { get { return null; } set { } }
        public bvec4 xzwz { get { return null; } set { } }
        public bvec4 xzww { get { return null; } set { } }
        public bvec4 xwxx { get { return null; } set { } }
        public bvec4 xwxy { get { return null; } set { } }
        public bvec4 xwxz { get { return null; } set { } }
        public bvec4 xwxw { get { return null; } set { } }
        public bvec4 xwyx { get { return null; } set { } }
        public bvec4 xwyy { get { return null; } set { } }
        public bvec4 xwyz { get { return null; } set { } }
        public bvec4 xwyw { get { return null; } set { } }
        public bvec4 xwzx { get { return null; } set { } }
        public bvec4 xwzy { get { return null; } set { } }
        public bvec4 xwzz { get { return null; } set { } }
        public bvec4 xwzw { get { return null; } set { } }
        public bvec4 xwwx { get { return null; } set { } }
        public bvec4 xwwy { get { return null; } set { } }
        public bvec4 xwwz { get { return null; } set { } }
        public bvec4 xwww { get { return null; } set { } }
        public bvec4 yxxx { get { return null; } set { } }
        public bvec4 yxxy { get { return null; } set { } }
        public bvec4 yxxz { get { return null; } set { } }
        public bvec4 yxxw { get { return null; } set { } }
        public bvec4 yxyx { get { return null; } set { } }
        public bvec4 yxyy { get { return null; } set { } }
        public bvec4 yxyz { get { return null; } set { } }
        public bvec4 yxyw { get { return null; } set { } }
        public bvec4 yxzx { get { return null; } set { } }
        public bvec4 yxzy { get { return null; } set { } }
        public bvec4 yxzz { get { return null; } set { } }
        public bvec4 yxzw { get { return null; } set { } }
        public bvec4 yxwx { get { return null; } set { } }
        public bvec4 yxwy { get { return null; } set { } }
        public bvec4 yxwz { get { return null; } set { } }
        public bvec4 yxww { get { return null; } set { } }
        public bvec4 yyxx { get { return null; } set { } }
        public bvec4 yyxy { get { return null; } set { } }
        public bvec4 yyxz { get { return null; } set { } }
        public bvec4 yyxw { get { return null; } set { } }
        public bvec4 yyyx { get { return null; } set { } }
        public bvec4 yyyy { get { return null; } set { } }
        public bvec4 yyyz { get { return null; } set { } }
        public bvec4 yyyw { get { return null; } set { } }
        public bvec4 yyzx { get { return null; } set { } }
        public bvec4 yyzy { get { return null; } set { } }
        public bvec4 yyzz { get { return null; } set { } }
        public bvec4 yyzw { get { return null; } set { } }
        public bvec4 yywx { get { return null; } set { } }
        public bvec4 yywy { get { return null; } set { } }
        public bvec4 yywz { get { return null; } set { } }
        public bvec4 yyww { get { return null; } set { } }
        public bvec4 yzxx { get { return null; } set { } }
        public bvec4 yzxy { get { return null; } set { } }
        public bvec4 yzxz { get { return null; } set { } }
        public bvec4 yzxw { get { return null; } set { } }
        public bvec4 yzyx { get { return null; } set { } }
        public bvec4 yzyy { get { return null; } set { } }
        public bvec4 yzyz { get { return null; } set { } }
        public bvec4 yzyw { get { return null; } set { } }
        public bvec4 yzzx { get { return null; } set { } }
        public bvec4 yzzy { get { return null; } set { } }
        public bvec4 yzzz { get { return null; } set { } }
        public bvec4 yzzw { get { return null; } set { } }
        public bvec4 yzwx { get { return null; } set { } }
        public bvec4 yzwy { get { return null; } set { } }
        public bvec4 yzwz { get { return null; } set { } }
        public bvec4 yzww { get { return null; } set { } }
        public bvec4 ywxx { get { return null; } set { } }
        public bvec4 ywxy { get { return null; } set { } }
        public bvec4 ywxz { get { return null; } set { } }
        public bvec4 ywxw { get { return null; } set { } }
        public bvec4 ywyx { get { return null; } set { } }
        public bvec4 ywyy { get { return null; } set { } }
        public bvec4 ywyz { get { return null; } set { } }
        public bvec4 ywyw { get { return null; } set { } }
        public bvec4 ywzx { get { return null; } set { } }
        public bvec4 ywzy { get { return null; } set { } }
        public bvec4 ywzz { get { return null; } set { } }
        public bvec4 ywzw { get { return null; } set { } }
        public bvec4 ywwx { get { return null; } set { } }
        public bvec4 ywwy { get { return null; } set { } }
        public bvec4 ywwz { get { return null; } set { } }
        public bvec4 ywww { get { return null; } set { } }
        public bvec4 zxxx { get { return null; } set { } }
        public bvec4 zxxy { get { return null; } set { } }
        public bvec4 zxxz { get { return null; } set { } }
        public bvec4 zxxw { get { return null; } set { } }
        public bvec4 zxyx { get { return null; } set { } }
        public bvec4 zxyy { get { return null; } set { } }
        public bvec4 zxyz { get { return null; } set { } }
        public bvec4 zxyw { get { return null; } set { } }
        public bvec4 zxzx { get { return null; } set { } }
        public bvec4 zxzy { get { return null; } set { } }
        public bvec4 zxzz { get { return null; } set { } }
        public bvec4 zxzw { get { return null; } set { } }
        public bvec4 zxwx { get { return null; } set { } }
        public bvec4 zxwy { get { return null; } set { } }
        public bvec4 zxwz { get { return null; } set { } }
        public bvec4 zxww { get { return null; } set { } }
        public bvec4 zyxx { get { return null; } set { } }
        public bvec4 zyxy { get { return null; } set { } }
        public bvec4 zyxz { get { return null; } set { } }
        public bvec4 zyxw { get { return null; } set { } }
        public bvec4 zyyx { get { return null; } set { } }
        public bvec4 zyyy { get { return null; } set { } }
        public bvec4 zyyz { get { return null; } set { } }
        public bvec4 zyyw { get { return null; } set { } }
        public bvec4 zyzx { get { return null; } set { } }
        public bvec4 zyzy { get { return null; } set { } }
        public bvec4 zyzz { get { return null; } set { } }
        public bvec4 zyzw { get { return null; } set { } }
        public bvec4 zywx { get { return null; } set { } }
        public bvec4 zywy { get { return null; } set { } }
        public bvec4 zywz { get { return null; } set { } }
        public bvec4 zyww { get { return null; } set { } }
        public bvec4 zzxx { get { return null; } set { } }
        public bvec4 zzxy { get { return null; } set { } }
        public bvec4 zzxz { get { return null; } set { } }
        public bvec4 zzxw { get { return null; } set { } }
        public bvec4 zzyx { get { return null; } set { } }
        public bvec4 zzyy { get { return null; } set { } }
        public bvec4 zzyz { get { return null; } set { } }
        public bvec4 zzyw { get { return null; } set { } }
        public bvec4 zzzx { get { return null; } set { } }
        public bvec4 zzzy { get { return null; } set { } }
        public bvec4 zzzz { get { return null; } set { } }
        public bvec4 zzzw { get { return null; } set { } }
        public bvec4 zzwx { get { return null; } set { } }
        public bvec4 zzwy { get { return null; } set { } }
        public bvec4 zzwz { get { return null; } set { } }
        public bvec4 zzww { get { return null; } set { } }
        public bvec4 zwxx { get { return null; } set { } }
        public bvec4 zwxy { get { return null; } set { } }
        public bvec4 zwxz { get { return null; } set { } }
        public bvec4 zwxw { get { return null; } set { } }
        public bvec4 zwyx { get { return null; } set { } }
        public bvec4 zwyy { get { return null; } set { } }
        public bvec4 zwyz { get { return null; } set { } }
        public bvec4 zwyw { get { return null; } set { } }
        public bvec4 zwzx { get { return null; } set { } }
        public bvec4 zwzy { get { return null; } set { } }
        public bvec4 zwzz { get { return null; } set { } }
        public bvec4 zwzw { get { return null; } set { } }
        public bvec4 zwwx { get { return null; } set { } }
        public bvec4 zwwy { get { return null; } set { } }
        public bvec4 zwwz { get { return null; } set { } }
        public bvec4 zwww { get { return null; } set { } }
        public bvec4 wxxx { get { return null; } set { } }
        public bvec4 wxxy { get { return null; } set { } }
        public bvec4 wxxz { get { return null; } set { } }
        public bvec4 wxxw { get { return null; } set { } }
        public bvec4 wxyx { get { return null; } set { } }
        public bvec4 wxyy { get { return null; } set { } }
        public bvec4 wxyz { get { return null; } set { } }
        public bvec4 wxyw { get { return null; } set { } }
        public bvec4 wxzx { get { return null; } set { } }
        public bvec4 wxzy { get { return null; } set { } }
        public bvec4 wxzz { get { return null; } set { } }
        public bvec4 wxzw { get { return null; } set { } }
        public bvec4 wxwx { get { return null; } set { } }
        public bvec4 wxwy { get { return null; } set { } }
        public bvec4 wxwz { get { return null; } set { } }
        public bvec4 wxww { get { return null; } set { } }
        public bvec4 wyxx { get { return null; } set { } }
        public bvec4 wyxy { get { return null; } set { } }
        public bvec4 wyxz { get { return null; } set { } }
        public bvec4 wyxw { get { return null; } set { } }
        public bvec4 wyyx { get { return null; } set { } }
        public bvec4 wyyy { get { return null; } set { } }
        public bvec4 wyyz { get { return null; } set { } }
        public bvec4 wyyw { get { return null; } set { } }
        public bvec4 wyzx { get { return null; } set { } }
        public bvec4 wyzy { get { return null; } set { } }
        public bvec4 wyzz { get { return null; } set { } }
        public bvec4 wyzw { get { return null; } set { } }
        public bvec4 wywx { get { return null; } set { } }
        public bvec4 wywy { get { return null; } set { } }
        public bvec4 wywz { get { return null; } set { } }
        public bvec4 wyww { get { return null; } set { } }
        public bvec4 wzxx { get { return null; } set { } }
        public bvec4 wzxy { get { return null; } set { } }
        public bvec4 wzxz { get { return null; } set { } }
        public bvec4 wzxw { get { return null; } set { } }
        public bvec4 wzyx { get { return null; } set { } }
        public bvec4 wzyy { get { return null; } set { } }
        public bvec4 wzyz { get { return null; } set { } }
        public bvec4 wzyw { get { return null; } set { } }
        public bvec4 wzzx { get { return null; } set { } }
        public bvec4 wzzy { get { return null; } set { } }
        public bvec4 wzzz { get { return null; } set { } }
        public bvec4 wzzw { get { return null; } set { } }
        public bvec4 wzwx { get { return null; } set { } }
        public bvec4 wzwy { get { return null; } set { } }
        public bvec4 wzwz { get { return null; } set { } }
        public bvec4 wzww { get { return null; } set { } }
        public bvec4 wwxx { get { return null; } set { } }
        public bvec4 wwxy { get { return null; } set { } }
        public bvec4 wwxz { get { return null; } set { } }
        public bvec4 wwxw { get { return null; } set { } }
        public bvec4 wwyx { get { return null; } set { } }
        public bvec4 wwyy { get { return null; } set { } }
        public bvec4 wwyz { get { return null; } set { } }
        public bvec4 wwyw { get { return null; } set { } }
        public bvec4 wwzx { get { return null; } set { } }
        public bvec4 wwzy { get { return null; } set { } }
        public bvec4 wwzz { get { return null; } set { } }
        public bvec4 wwzw { get { return null; } set { } }
        public bvec4 wwwx { get { return null; } set { } }
        public bvec4 wwwy { get { return null; } set { } }
        public bvec4 wwwz { get { return null; } set { } }
        public bvec4 wwww { get { return null; } set { } }
        public bool r { get { return false; } set { } }
        public bool g { get { return false; } set { } }
        public bool b { get { return false; } set { } }
        public bool a { get { return false; } set { } }

        public vec2 rr { get { return null; } set { } }
        public vec2 rg { get { return null; } set { } }
        public vec2 rb { get { return null; } set { } }
        public vec2 ra { get { return null; } set { } }
        public vec2 gr { get { return null; } set { } }
        public vec2 gg { get { return null; } set { } }
        public vec2 gb { get { return null; } set { } }
        public vec2 ga { get { return null; } set { } }
        public vec2 br { get { return null; } set { } }
        public vec2 bg { get { return null; } set { } }
        public vec2 bb { get { return null; } set { } }
        public vec2 ba { get { return null; } set { } }
        public vec2 ar { get { return null; } set { } }
        public vec2 ag { get { return null; } set { } }
        public vec2 ab { get { return null; } set { } }
        public vec2 aa { get { return null; } set { } }

        public vec3 rrr{ get { return null; } set { } }
        public vec3 rrg{ get { return null; } set { } }
        public vec3 rrb{ get { return null; } set { } }
        public vec3 rra{ get { return null; } set { } }
        public vec3 rgr{ get { return null; } set { } }
        public vec3 rgg{ get { return null; } set { } }
        public vec3 rgb{ get { return null; } set { } }
        public vec3 rga{ get { return null; } set { } }
        public vec3 rbr{ get { return null; } set { } }
        public vec3 rbg{ get { return null; } set { } }
        public vec3 rbb{ get { return null; } set { } }
        public vec3 rba{ get { return null; } set { } }
        public vec3 rar{ get { return null; } set { } }
        public vec3 rag{ get { return null; } set { } }
        public vec3 rab{ get { return null; } set { } }
        public vec3 raa{ get { return null; } set { } }
        public vec3 grr{ get { return null; } set { } }
        public vec3 grg{ get { return null; } set { } }
        public vec3 grb{ get { return null; } set { } }
        public vec3 gra{ get { return null; } set { } }
        public vec3 ggr{ get { return null; } set { } }
        public vec3 ggg{ get { return null; } set { } }
        public vec3 ggb{ get { return null; } set { } }
        public vec3 gga{ get { return null; } set { } }
        public vec3 gbr{ get { return null; } set { } }
        public vec3 gbg{ get { return null; } set { } }
        public vec3 gbb{ get { return null; } set { } }
        public vec3 gba{ get { return null; } set { } }
        public vec3 gar{ get { return null; } set { } }
        public vec3 gag{ get { return null; } set { } }
        public vec3 gab{ get { return null; } set { } }
        public vec3 gaa{ get { return null; } set { } }
        public vec3 brr{ get { return null; } set { } }
        public vec3 brg{ get { return null; } set { } }
        public vec3 brb{ get { return null; } set { } }
        public vec3 bra{ get { return null; } set { } }
        public vec3 bgr{ get { return null; } set { } }
        public vec3 bgg{ get { return null; } set { } }
        public vec3 bgb{ get { return null; } set { } }
        public vec3 bga{ get { return null; } set { } }
        public vec3 bbr{ get { return null; } set { } }
        public vec3 bbg{ get { return null; } set { } }
        public vec3 bbb{ get { return null; } set { } }
        public vec3 bba{ get { return null; } set { } }
        public vec3 bar{ get { return null; } set { } }
        public vec3 bag{ get { return null; } set { } }
        public vec3 bab{ get { return null; } set { } }
        public vec3 baa{ get { return null; } set { } }
        public vec3 arr{ get { return null; } set { } }
        public vec3 arg{ get { return null; } set { } }
        public vec3 arb{ get { return null; } set { } }
        public vec3 ara{ get { return null; } set { } }
        public vec3 agr{ get { return null; } set { } }
        public vec3 agg{ get { return null; } set { } }
        public vec3 agb{ get { return null; } set { } }
        public vec3 aga{ get { return null; } set { } }
        public vec3 abr{ get { return null; } set { } }
        public vec3 abg{ get { return null; } set { } }
        public vec3 abb{ get { return null; } set { } }
        public vec3 aba{ get { return null; } set { } }
        public vec3 aar{ get { return null; } set { } }
        public vec3 aag{ get { return null; } set { } }
        public vec3 aab{ get { return null; } set { } }
        public vec3 aaa{ get { return null; } set { } }

        public bvec4 rrrr { get { return null; } set { } }
        public bvec4 rrrg { get { return null; } set { } }
        public bvec4 rrrb { get { return null; } set { } }
        public bvec4 rrra { get { return null; } set { } }
        public bvec4 rrgr { get { return null; } set { } }
        public bvec4 rrgg { get { return null; } set { } }
        public bvec4 rrgb { get { return null; } set { } }
        public bvec4 rrga { get { return null; } set { } }
        public bvec4 rrbr { get { return null; } set { } }
        public bvec4 rrbg { get { return null; } set { } }
        public bvec4 rrbb { get { return null; } set { } }
        public bvec4 rrba { get { return null; } set { } }
        public bvec4 rrar { get { return null; } set { } }
        public bvec4 rrag { get { return null; } set { } }
        public bvec4 rrab { get { return null; } set { } }
        public bvec4 rraa { get { return null; } set { } }
        public bvec4 rgrr { get { return null; } set { } }
        public bvec4 rgrg { get { return null; } set { } }
        public bvec4 rgrb { get { return null; } set { } }
        public bvec4 rgra { get { return null; } set { } }
        public bvec4 rggr { get { return null; } set { } }
        public bvec4 rggg { get { return null; } set { } }
        public bvec4 rggb { get { return null; } set { } }
        public bvec4 rgga { get { return null; } set { } }
        public bvec4 rgbr { get { return null; } set { } }
        public bvec4 rgbg { get { return null; } set { } }
        public bvec4 rgbb { get { return null; } set { } }
        public bvec4 rgba { get { return null; } set { } }
        public bvec4 rgar { get { return null; } set { } }
        public bvec4 rgag { get { return null; } set { } }
        public bvec4 rgab { get { return null; } set { } }
        public bvec4 rgaa { get { return null; } set { } }
        public bvec4 rbrr { get { return null; } set { } }
        public bvec4 rbrg { get { return null; } set { } }
        public bvec4 rbrb { get { return null; } set { } }
        public bvec4 rbra { get { return null; } set { } }
        public bvec4 rbgr { get { return null; } set { } }
        public bvec4 rbgg { get { return null; } set { } }
        public bvec4 rbgb { get { return null; } set { } }
        public bvec4 rbga { get { return null; } set { } }
        public bvec4 rbbr { get { return null; } set { } }
        public bvec4 rbbg { get { return null; } set { } }
        public bvec4 rbbb { get { return null; } set { } }
        public bvec4 rbba { get { return null; } set { } }
        public bvec4 rbar { get { return null; } set { } }
        public bvec4 rbag { get { return null; } set { } }
        public bvec4 rbab { get { return null; } set { } }
        public bvec4 rbaa { get { return null; } set { } }
        public bvec4 rarr { get { return null; } set { } }
        public bvec4 rarg { get { return null; } set { } }
        public bvec4 rarb { get { return null; } set { } }
        public bvec4 rara { get { return null; } set { } }
        public bvec4 ragr { get { return null; } set { } }
        public bvec4 ragg { get { return null; } set { } }
        public bvec4 ragb { get { return null; } set { } }
        public bvec4 raga { get { return null; } set { } }
        public bvec4 rabr { get { return null; } set { } }
        public bvec4 rabg { get { return null; } set { } }
        public bvec4 rabb { get { return null; } set { } }
        public bvec4 raba { get { return null; } set { } }
        public bvec4 raar { get { return null; } set { } }
        public bvec4 raag { get { return null; } set { } }
        public bvec4 raab { get { return null; } set { } }
        public bvec4 raaa { get { return null; } set { } }
        public bvec4 grrr { get { return null; } set { } }
        public bvec4 grrg { get { return null; } set { } }
        public bvec4 grrb { get { return null; } set { } }
        public bvec4 grra { get { return null; } set { } }
        public bvec4 grgr { get { return null; } set { } }
        public bvec4 grgg { get { return null; } set { } }
        public bvec4 grgb { get { return null; } set { } }
        public bvec4 grga { get { return null; } set { } }
        public bvec4 grbr { get { return null; } set { } }
        public bvec4 grbg { get { return null; } set { } }
        public bvec4 grbb { get { return null; } set { } }
        public bvec4 grba { get { return null; } set { } }
        public bvec4 grar { get { return null; } set { } }
        public bvec4 grag { get { return null; } set { } }
        public bvec4 grab { get { return null; } set { } }
        public bvec4 graa { get { return null; } set { } }
        public bvec4 ggrr { get { return null; } set { } }
        public bvec4 ggrg { get { return null; } set { } }
        public bvec4 ggrb { get { return null; } set { } }
        public bvec4 ggra { get { return null; } set { } }
        public bvec4 gggr { get { return null; } set { } }
        public bvec4 gggg { get { return null; } set { } }
        public bvec4 gggb { get { return null; } set { } }
        public bvec4 ggga { get { return null; } set { } }
        public bvec4 ggbr { get { return null; } set { } }
        public bvec4 ggbg { get { return null; } set { } }
        public bvec4 ggbb { get { return null; } set { } }
        public bvec4 ggba { get { return null; } set { } }
        public bvec4 ggar { get { return null; } set { } }
        public bvec4 ggag { get { return null; } set { } }
        public bvec4 ggab { get { return null; } set { } }
        public bvec4 ggaa { get { return null; } set { } }
        public bvec4 gbrr { get { return null; } set { } }
        public bvec4 gbrg { get { return null; } set { } }
        public bvec4 gbrb { get { return null; } set { } }
        public bvec4 gbra { get { return null; } set { } }
        public bvec4 gbgr { get { return null; } set { } }
        public bvec4 gbgg { get { return null; } set { } }
        public bvec4 gbgb { get { return null; } set { } }
        public bvec4 gbga { get { return null; } set { } }
        public bvec4 gbbr { get { return null; } set { } }
        public bvec4 gbbg { get { return null; } set { } }
        public bvec4 gbbb { get { return null; } set { } }
        public bvec4 gbba { get { return null; } set { } }
        public bvec4 gbar { get { return null; } set { } }
        public bvec4 gbag { get { return null; } set { } }
        public bvec4 gbab { get { return null; } set { } }
        public bvec4 gbaa { get { return null; } set { } }
        public bvec4 garr { get { return null; } set { } }
        public bvec4 garg { get { return null; } set { } }
        public bvec4 garb { get { return null; } set { } }
        public bvec4 gara { get { return null; } set { } }
        public bvec4 gagr { get { return null; } set { } }
        public bvec4 gagg { get { return null; } set { } }
        public bvec4 gagb { get { return null; } set { } }
        public bvec4 gaga { get { return null; } set { } }
        public bvec4 gabr { get { return null; } set { } }
        public bvec4 gabg { get { return null; } set { } }
        public bvec4 gabb { get { return null; } set { } }
        public bvec4 gaba { get { return null; } set { } }
        public bvec4 gaar { get { return null; } set { } }
        public bvec4 gaag { get { return null; } set { } }
        public bvec4 gaab { get { return null; } set { } }
        public bvec4 gaaa { get { return null; } set { } }
        public bvec4 brrr { get { return null; } set { } }
        public bvec4 brrg { get { return null; } set { } }
        public bvec4 brrb { get { return null; } set { } }
        public bvec4 brra { get { return null; } set { } }
        public bvec4 brgr { get { return null; } set { } }
        public bvec4 brgg { get { return null; } set { } }
        public bvec4 brgb { get { return null; } set { } }
        public bvec4 brga { get { return null; } set { } }
        public bvec4 brbr { get { return null; } set { } }
        public bvec4 brbg { get { return null; } set { } }
        public bvec4 brbb { get { return null; } set { } }
        public bvec4 brba { get { return null; } set { } }
        public bvec4 brar { get { return null; } set { } }
        public bvec4 brag { get { return null; } set { } }
        public bvec4 brab { get { return null; } set { } }
        public bvec4 braa { get { return null; } set { } }
        public bvec4 bgrr { get { return null; } set { } }
        public bvec4 bgrg { get { return null; } set { } }
        public bvec4 bgrb { get { return null; } set { } }
        public bvec4 bgra { get { return null; } set { } }
        public bvec4 bggr { get { return null; } set { } }
        public bvec4 bggg { get { return null; } set { } }
        public bvec4 bggb { get { return null; } set { } }
        public bvec4 bgga { get { return null; } set { } }
        public bvec4 bgbr { get { return null; } set { } }
        public bvec4 bgbg { get { return null; } set { } }
        public bvec4 bgbb { get { return null; } set { } }
        public bvec4 bgba { get { return null; } set { } }
        public bvec4 bgar { get { return null; } set { } }
        public bvec4 bgag { get { return null; } set { } }
        public bvec4 bgab { get { return null; } set { } }
        public bvec4 bgaa { get { return null; } set { } }
        public bvec4 bbrr { get { return null; } set { } }
        public bvec4 bbrg { get { return null; } set { } }
        public bvec4 bbrb { get { return null; } set { } }
        public bvec4 bbra { get { return null; } set { } }
        public bvec4 bbgr { get { return null; } set { } }
        public bvec4 bbgg { get { return null; } set { } }
        public bvec4 bbgb { get { return null; } set { } }
        public bvec4 bbga { get { return null; } set { } }
        public bvec4 bbbr { get { return null; } set { } }
        public bvec4 bbbg { get { return null; } set { } }
        public bvec4 bbbb { get { return null; } set { } }
        public bvec4 bbba { get { return null; } set { } }
        public bvec4 bbar { get { return null; } set { } }
        public bvec4 bbag { get { return null; } set { } }
        public bvec4 bbab { get { return null; } set { } }
        public bvec4 bbaa { get { return null; } set { } }
        public bvec4 barr { get { return null; } set { } }
        public bvec4 barg { get { return null; } set { } }
        public bvec4 barb { get { return null; } set { } }
        public bvec4 bara { get { return null; } set { } }
        public bvec4 bagr { get { return null; } set { } }
        public bvec4 bagg { get { return null; } set { } }
        public bvec4 bagb { get { return null; } set { } }
        public bvec4 baga { get { return null; } set { } }
        public bvec4 babr { get { return null; } set { } }
        public bvec4 babg { get { return null; } set { } }
        public bvec4 babb { get { return null; } set { } }
        public bvec4 baba { get { return null; } set { } }
        public bvec4 baar { get { return null; } set { } }
        public bvec4 baag { get { return null; } set { } }
        public bvec4 baab { get { return null; } set { } }
        public bvec4 baaa { get { return null; } set { } }
        public bvec4 arrr { get { return null; } set { } }
        public bvec4 arrg { get { return null; } set { } }
        public bvec4 arrb { get { return null; } set { } }
        public bvec4 arra { get { return null; } set { } }
        public bvec4 argr { get { return null; } set { } }
        public bvec4 argg { get { return null; } set { } }
        public bvec4 argb { get { return null; } set { } }
        public bvec4 arga { get { return null; } set { } }
        public bvec4 arbr { get { return null; } set { } }
        public bvec4 arbg { get { return null; } set { } }
        public bvec4 arbb { get { return null; } set { } }
        public bvec4 arba { get { return null; } set { } }
        public bvec4 arar { get { return null; } set { } }
        public bvec4 arag { get { return null; } set { } }
        public bvec4 arab { get { return null; } set { } }
        public bvec4 araa { get { return null; } set { } }
        public bvec4 agrr { get { return null; } set { } }
        public bvec4 agrg { get { return null; } set { } }
        public bvec4 agrb { get { return null; } set { } }
        public bvec4 agra { get { return null; } set { } }
        public bvec4 aggr { get { return null; } set { } }
        public bvec4 aggg { get { return null; } set { } }
        public bvec4 aggb { get { return null; } set { } }
        public bvec4 agga { get { return null; } set { } }
        public bvec4 agbr { get { return null; } set { } }
        public bvec4 agbg { get { return null; } set { } }
        public bvec4 agbb { get { return null; } set { } }
        public bvec4 agba { get { return null; } set { } }
        public bvec4 agar { get { return null; } set { } }
        public bvec4 agag { get { return null; } set { } }
        public bvec4 agab { get { return null; } set { } }
        public bvec4 agaa { get { return null; } set { } }
        public bvec4 abrr { get { return null; } set { } }
        public bvec4 abrg { get { return null; } set { } }
        public bvec4 abrb { get { return null; } set { } }
        public bvec4 abra { get { return null; } set { } }
        public bvec4 abgr { get { return null; } set { } }
        public bvec4 abgg { get { return null; } set { } }
        public bvec4 abgb { get { return null; } set { } }
        public bvec4 abga { get { return null; } set { } }
        public bvec4 abbr { get { return null; } set { } }
        public bvec4 abbg { get { return null; } set { } }
        public bvec4 abbb { get { return null; } set { } }
        public bvec4 abba { get { return null; } set { } }
        public bvec4 abar { get { return null; } set { } }
        public bvec4 abag { get { return null; } set { } }
        public bvec4 abab { get { return null; } set { } }
        public bvec4 abaa { get { return null; } set { } }
        public bvec4 aarr { get { return null; } set { } }
        public bvec4 aarg { get { return null; } set { } }
        public bvec4 aarb { get { return null; } set { } }
        public bvec4 aara { get { return null; } set { } }
        public bvec4 aagr { get { return null; } set { } }
        public bvec4 aagg { get { return null; } set { } }
        public bvec4 aagb { get { return null; } set { } }
        public bvec4 aaga { get { return null; } set { } }
        public bvec4 aabr { get { return null; } set { } }
        public bvec4 aabg { get { return null; } set { } }
        public bvec4 aabb { get { return null; } set { } }
        public bvec4 aaba { get { return null; } set { } }
        public bvec4 aaar { get { return null; } set { } }
        public bvec4 aaag { get { return null; } set { } }
        public bvec4 aaab { get { return null; } set { } }
        public bvec4 aaaa { get { return null; } set { } }

        public bool s { get { return false; } set { } }
        public bool t { get { return false; } set { } }
        public bool p { get { return false; } set { } }
        public bool q { get { return false; } set { } }

        public vec2 ss { get { return null; } set { } }
        public vec2 st { get { return null; } set { } }
        public vec2 sp { get { return null; } set { } }
        public vec2 sq { get { return null; } set { } }
        public vec2 ts { get { return null; } set { } }
        public vec2 tt { get { return null; } set { } }
        public vec2 tp { get { return null; } set { } }
        public vec2 tq { get { return null; } set { } }
        public vec2 ps { get { return null; } set { } }
        public vec2 pt { get { return null; } set { } }
        public vec2 pp { get { return null; } set { } }
        public vec2 pq { get { return null; } set { } }
        public vec2 qs { get { return null; } set { } }
        public vec2 qt { get { return null; } set { } }
        public vec2 qp { get { return null; } set { } }
        public vec2 qq { get { return null; } set { } }

        public vec3 sss { get { return null; } set { } }
        public vec3 sst { get { return null; } set { } }
        public vec3 ssp { get { return null; } set { } }
        public vec3 ssq { get { return null; } set { } }
        public vec3 sts { get { return null; } set { } }
        public vec3 stt { get { return null; } set { } }
        public vec3 stp { get { return null; } set { } }
        public vec3 stq { get { return null; } set { } }
        public vec3 sps { get { return null; } set { } }
        public vec3 spt { get { return null; } set { } }
        public vec3 spp { get { return null; } set { } }
        public vec3 spq { get { return null; } set { } }
        public vec3 sqs { get { return null; } set { } }
        public vec3 sqt { get { return null; } set { } }
        public vec3 sqp { get { return null; } set { } }
        public vec3 sqq { get { return null; } set { } }
        public vec3 tss { get { return null; } set { } }
        public vec3 tst { get { return null; } set { } }
        public vec3 tsp { get { return null; } set { } }
        public vec3 tsq { get { return null; } set { } }
        public vec3 tts { get { return null; } set { } }
        public vec3 ttt { get { return null; } set { } }
        public vec3 ttp { get { return null; } set { } }
        public vec3 ttq { get { return null; } set { } }
        public vec3 tps { get { return null; } set { } }
        public vec3 tpt { get { return null; } set { } }
        public vec3 tpp { get { return null; } set { } }
        public vec3 tpq { get { return null; } set { } }
        public vec3 tqs { get { return null; } set { } }
        public vec3 tqt { get { return null; } set { } }
        public vec3 tqp { get { return null; } set { } }
        public vec3 tqq { get { return null; } set { } }
        public vec3 pss { get { return null; } set { } }
        public vec3 pst { get { return null; } set { } }
        public vec3 psp { get { return null; } set { } }
        public vec3 psq { get { return null; } set { } }
        public vec3 pts { get { return null; } set { } }
        public vec3 ptt { get { return null; } set { } }
        public vec3 ptp { get { return null; } set { } }
        public vec3 ptq { get { return null; } set { } }
        public vec3 pps { get { return null; } set { } }
        public vec3 ppt { get { return null; } set { } }
        public vec3 ppp { get { return null; } set { } }
        public vec3 ppq { get { return null; } set { } }
        public vec3 pqs { get { return null; } set { } }
        public vec3 pqt { get { return null; } set { } }
        public vec3 pqp { get { return null; } set { } }
        public vec3 pqq { get { return null; } set { } }
        public vec3 qss { get { return null; } set { } }
        public vec3 qst { get { return null; } set { } }
        public vec3 qsp { get { return null; } set { } }
        public vec3 qsq { get { return null; } set { } }
        public vec3 qts { get { return null; } set { } }
        public vec3 qtt { get { return null; } set { } }
        public vec3 qtp { get { return null; } set { } }
        public vec3 qtq { get { return null; } set { } }
        public vec3 qps { get { return null; } set { } }
        public vec3 qpt { get { return null; } set { } }
        public vec3 qpp { get { return null; } set { } }
        public vec3 qpq { get { return null; } set { } }
        public vec3 qqs { get { return null; } set { } }
        public vec3 qqt { get { return null; } set { } }
        public vec3 qqp { get { return null; } set { } }
        public vec3 qqq { get { return null; } set { } }

        public bvec4 ssss { get { return null; } set { } }
        public bvec4 ssst { get { return null; } set { } }
        public bvec4 sssp { get { return null; } set { } }
        public bvec4 sssq { get { return null; } set { } }
        public bvec4 ssts { get { return null; } set { } }
        public bvec4 sstt { get { return null; } set { } }
        public bvec4 sstp { get { return null; } set { } }
        public bvec4 sstq { get { return null; } set { } }
        public bvec4 ssps { get { return null; } set { } }
        public bvec4 sspt { get { return null; } set { } }
        public bvec4 sspp { get { return null; } set { } }
        public bvec4 sspq { get { return null; } set { } }
        public bvec4 ssqs { get { return null; } set { } }
        public bvec4 ssqt { get { return null; } set { } }
        public bvec4 ssqp { get { return null; } set { } }
        public bvec4 ssqq { get { return null; } set { } }
        public bvec4 stss { get { return null; } set { } }
        public bvec4 stst { get { return null; } set { } }
        public bvec4 stsp { get { return null; } set { } }
        public bvec4 stsq { get { return null; } set { } }
        public bvec4 stts { get { return null; } set { } }
        public bvec4 sttt { get { return null; } set { } }
        public bvec4 sttp { get { return null; } set { } }
        public bvec4 sttq { get { return null; } set { } }
        public bvec4 stps { get { return null; } set { } }
        public bvec4 stpt { get { return null; } set { } }
        public bvec4 stpp { get { return null; } set { } }
        public bvec4 stpq { get { return null; } set { } }
        public bvec4 stqs { get { return null; } set { } }
        public bvec4 stqt { get { return null; } set { } }
        public bvec4 stqp { get { return null; } set { } }
        public bvec4 stqq { get { return null; } set { } }
        public bvec4 spss { get { return null; } set { } }
        public bvec4 spst { get { return null; } set { } }
        public bvec4 spsp { get { return null; } set { } }
        public bvec4 spsq { get { return null; } set { } }
        public bvec4 spts { get { return null; } set { } }
        public bvec4 sptt { get { return null; } set { } }
        public bvec4 sptp { get { return null; } set { } }
        public bvec4 sptq { get { return null; } set { } }
        public bvec4 spps { get { return null; } set { } }
        public bvec4 sppt { get { return null; } set { } }
        public bvec4 sppp { get { return null; } set { } }
        public bvec4 sppq { get { return null; } set { } }
        public bvec4 spqs { get { return null; } set { } }
        public bvec4 spqt { get { return null; } set { } }
        public bvec4 spqp { get { return null; } set { } }
        public bvec4 spqq { get { return null; } set { } }
        public bvec4 sqss { get { return null; } set { } }
        public bvec4 sqst { get { return null; } set { } }
        public bvec4 sqsp { get { return null; } set { } }
        public bvec4 sqsq { get { return null; } set { } }
        public bvec4 sqts { get { return null; } set { } }
        public bvec4 sqtt { get { return null; } set { } }
        public bvec4 sqtp { get { return null; } set { } }
        public bvec4 sqtq { get { return null; } set { } }
        public bvec4 sqps { get { return null; } set { } }
        public bvec4 sqpt { get { return null; } set { } }
        public bvec4 sqpp { get { return null; } set { } }
        public bvec4 sqpq { get { return null; } set { } }
        public bvec4 sqqs { get { return null; } set { } }
        public bvec4 sqqt { get { return null; } set { } }
        public bvec4 sqqp { get { return null; } set { } }
        public bvec4 sqqq { get { return null; } set { } }
        public bvec4 tsss { get { return null; } set { } }
        public bvec4 tsst { get { return null; } set { } }
        public bvec4 tssp { get { return null; } set { } }
        public bvec4 tssq { get { return null; } set { } }
        public bvec4 tsts { get { return null; } set { } }
        public bvec4 tstt { get { return null; } set { } }
        public bvec4 tstp { get { return null; } set { } }
        public bvec4 tstq { get { return null; } set { } }
        public bvec4 tsps { get { return null; } set { } }
        public bvec4 tspt { get { return null; } set { } }
        public bvec4 tspp { get { return null; } set { } }
        public bvec4 tspq { get { return null; } set { } }
        public bvec4 tsqs { get { return null; } set { } }
        public bvec4 tsqt { get { return null; } set { } }
        public bvec4 tsqp { get { return null; } set { } }
        public bvec4 tsqq { get { return null; } set { } }
        public bvec4 ttss { get { return null; } set { } }
        public bvec4 ttst { get { return null; } set { } }
        public bvec4 ttsp { get { return null; } set { } }
        public bvec4 ttsq { get { return null; } set { } }
        public bvec4 ttts { get { return null; } set { } }
        public bvec4 tttt { get { return null; } set { } }
        public bvec4 tttp { get { return null; } set { } }
        public bvec4 tttq { get { return null; } set { } }
        public bvec4 ttps { get { return null; } set { } }
        public bvec4 ttpt { get { return null; } set { } }
        public bvec4 ttpp { get { return null; } set { } }
        public bvec4 ttpq { get { return null; } set { } }
        public bvec4 ttqs { get { return null; } set { } }
        public bvec4 ttqt { get { return null; } set { } }
        public bvec4 ttqp { get { return null; } set { } }
        public bvec4 ttqq { get { return null; } set { } }
        public bvec4 tpss { get { return null; } set { } }
        public bvec4 tpst { get { return null; } set { } }
        public bvec4 tpsp { get { return null; } set { } }
        public bvec4 tpsq { get { return null; } set { } }
        public bvec4 tpts { get { return null; } set { } }
        public bvec4 tptt { get { return null; } set { } }
        public bvec4 tptp { get { return null; } set { } }
        public bvec4 tptq { get { return null; } set { } }
        public bvec4 tpps { get { return null; } set { } }
        public bvec4 tppt { get { return null; } set { } }
        public bvec4 tppp { get { return null; } set { } }
        public bvec4 tppq { get { return null; } set { } }
        public bvec4 tpqs { get { return null; } set { } }
        public bvec4 tpqt { get { return null; } set { } }
        public bvec4 tpqp { get { return null; } set { } }
        public bvec4 tpqq { get { return null; } set { } }
        public bvec4 tqss { get { return null; } set { } }
        public bvec4 tqst { get { return null; } set { } }
        public bvec4 tqsp { get { return null; } set { } }
        public bvec4 tqsq { get { return null; } set { } }
        public bvec4 tqts { get { return null; } set { } }
        public bvec4 tqtt { get { return null; } set { } }
        public bvec4 tqtp { get { return null; } set { } }
        public bvec4 tqtq { get { return null; } set { } }
        public bvec4 tqps { get { return null; } set { } }
        public bvec4 tqpt { get { return null; } set { } }
        public bvec4 tqpp { get { return null; } set { } }
        public bvec4 tqpq { get { return null; } set { } }
        public bvec4 tqqs { get { return null; } set { } }
        public bvec4 tqqt { get { return null; } set { } }
        public bvec4 tqqp { get { return null; } set { } }
        public bvec4 tqqq { get { return null; } set { } }
        public bvec4 psss { get { return null; } set { } }
        public bvec4 psst { get { return null; } set { } }
        public bvec4 pssp { get { return null; } set { } }
        public bvec4 pssq { get { return null; } set { } }
        public bvec4 psts { get { return null; } set { } }
        public bvec4 pstt { get { return null; } set { } }
        public bvec4 pstp { get { return null; } set { } }
        public bvec4 pstq { get { return null; } set { } }
        public bvec4 psps { get { return null; } set { } }
        public bvec4 pspt { get { return null; } set { } }
        public bvec4 pspp { get { return null; } set { } }
        public bvec4 pspq { get { return null; } set { } }
        public bvec4 psqs { get { return null; } set { } }
        public bvec4 psqt { get { return null; } set { } }
        public bvec4 psqp { get { return null; } set { } }
        public bvec4 psqq { get { return null; } set { } }
        public bvec4 ptss { get { return null; } set { } }
        public bvec4 ptst { get { return null; } set { } }
        public bvec4 ptsp { get { return null; } set { } }
        public bvec4 ptsq { get { return null; } set { } }
        public bvec4 ptts { get { return null; } set { } }
        public bvec4 pttt { get { return null; } set { } }
        public bvec4 pttp { get { return null; } set { } }
        public bvec4 pttq { get { return null; } set { } }
        public bvec4 ptps { get { return null; } set { } }
        public bvec4 ptpt { get { return null; } set { } }
        public bvec4 ptpp { get { return null; } set { } }
        public bvec4 ptpq { get { return null; } set { } }
        public bvec4 ptqs { get { return null; } set { } }
        public bvec4 ptqt { get { return null; } set { } }
        public bvec4 ptqp { get { return null; } set { } }
        public bvec4 ptqq { get { return null; } set { } }
        public bvec4 ppss { get { return null; } set { } }
        public bvec4 ppst { get { return null; } set { } }
        public bvec4 ppsp { get { return null; } set { } }
        public bvec4 ppsq { get { return null; } set { } }
        public bvec4 ppts { get { return null; } set { } }
        public bvec4 pptt { get { return null; } set { } }
        public bvec4 pptp { get { return null; } set { } }
        public bvec4 pptq { get { return null; } set { } }
        public bvec4 ppps { get { return null; } set { } }
        public bvec4 pppt { get { return null; } set { } }
        public bvec4 pppp { get { return null; } set { } }
        public bvec4 pppq { get { return null; } set { } }
        public bvec4 ppqs { get { return null; } set { } }
        public bvec4 ppqt { get { return null; } set { } }
        public bvec4 ppqp { get { return null; } set { } }
        public bvec4 ppqq { get { return null; } set { } }
        public bvec4 pqss { get { return null; } set { } }
        public bvec4 pqst { get { return null; } set { } }
        public bvec4 pqsp { get { return null; } set { } }
        public bvec4 pqsq { get { return null; } set { } }
        public bvec4 pqts { get { return null; } set { } }
        public bvec4 pqtt { get { return null; } set { } }
        public bvec4 pqtp { get { return null; } set { } }
        public bvec4 pqtq { get { return null; } set { } }
        public bvec4 pqps { get { return null; } set { } }
        public bvec4 pqpt { get { return null; } set { } }
        public bvec4 pqpp { get { return null; } set { } }
        public bvec4 pqpq { get { return null; } set { } }
        public bvec4 pqqs { get { return null; } set { } }
        public bvec4 pqqt { get { return null; } set { } }
        public bvec4 pqqp { get { return null; } set { } }
        public bvec4 pqqq { get { return null; } set { } }
        public bvec4 qsss { get { return null; } set { } }
        public bvec4 qsst { get { return null; } set { } }
        public bvec4 qssp { get { return null; } set { } }
        public bvec4 qssq { get { return null; } set { } }
        public bvec4 qsts { get { return null; } set { } }
        public bvec4 qstt { get { return null; } set { } }
        public bvec4 qstp { get { return null; } set { } }
        public bvec4 qstq { get { return null; } set { } }
        public bvec4 qsps { get { return null; } set { } }
        public bvec4 qspt { get { return null; } set { } }
        public bvec4 qspp { get { return null; } set { } }
        public bvec4 qspq { get { return null; } set { } }
        public bvec4 qsqs { get { return null; } set { } }
        public bvec4 qsqt { get { return null; } set { } }
        public bvec4 qsqp { get { return null; } set { } }
        public bvec4 qsqq { get { return null; } set { } }
        public bvec4 qtss { get { return null; } set { } }
        public bvec4 qtst { get { return null; } set { } }
        public bvec4 qtsp { get { return null; } set { } }
        public bvec4 qtsq { get { return null; } set { } }
        public bvec4 qtts { get { return null; } set { } }
        public bvec4 qttt { get { return null; } set { } }
        public bvec4 qttp { get { return null; } set { } }
        public bvec4 qttq { get { return null; } set { } }
        public bvec4 qtps { get { return null; } set { } }
        public bvec4 qtpt { get { return null; } set { } }
        public bvec4 qtpp { get { return null; } set { } }
        public bvec4 qtpq { get { return null; } set { } }
        public bvec4 qtqs { get { return null; } set { } }
        public bvec4 qtqt { get { return null; } set { } }
        public bvec4 qtqp { get { return null; } set { } }
        public bvec4 qtqq { get { return null; } set { } }
        public bvec4 qpss { get { return null; } set { } }
        public bvec4 qpst { get { return null; } set { } }
        public bvec4 qpsp { get { return null; } set { } }
        public bvec4 qpsq { get { return null; } set { } }
        public bvec4 qpts { get { return null; } set { } }
        public bvec4 qptt { get { return null; } set { } }
        public bvec4 qptp { get { return null; } set { } }
        public bvec4 qptq { get { return null; } set { } }
        public bvec4 qpps { get { return null; } set { } }
        public bvec4 qppt { get { return null; } set { } }
        public bvec4 qppp { get { return null; } set { } }
        public bvec4 qppq { get { return null; } set { } }
        public bvec4 qpqs { get { return null; } set { } }
        public bvec4 qpqt { get { return null; } set { } }
        public bvec4 qpqp { get { return null; } set { } }
        public bvec4 qpqq { get { return null; } set { } }
        public bvec4 qqss { get { return null; } set { } }
        public bvec4 qqst { get { return null; } set { } }
        public bvec4 qqsp { get { return null; } set { } }
        public bvec4 qqsq { get { return null; } set { } }
        public bvec4 qqts { get { return null; } set { } }
        public bvec4 qqtt { get { return null; } set { } }
        public bvec4 qqtp { get { return null; } set { } }
        public bvec4 qqtq { get { return null; } set { } }
        public bvec4 qqps { get { return null; } set { } }
        public bvec4 qqpt { get { return null; } set { } }
        public bvec4 qqpp { get { return null; } set { } }
        public bvec4 qqpq { get { return null; } set { } }
        public bvec4 qqqs { get { return null; } set { } }
        public bvec4 qqqt { get { return null; } set { } }
        public bvec4 qqqp { get { return null; } set { } }
        public bvec4 qqqq { get { return null; } set { } }

        #endregion compositions


        public bool this[int index]
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        private bvec4() { }

        public static bvec4 operator -(bvec4 lhs)
        {
            return null;
        }

        public static bvec4 operator +(bvec4 lhs, bvec4 rhs)
        {
            return null;
        }

        public static bvec4 operator +(bvec4 lhs, double rhs)
        {
            return null;
        }

        public static bvec4 operator -(bvec4 lhs, double rhs)
        {
            return null;
        }

        public static bvec4 operator -(bvec4 lhs, bvec4 rhs)
        {
            return null;
        }

        public static bvec4 operator *(bvec4 self, double s)
        {
            return null;
        }

        public static bvec4 operator *(double lhs, bvec4 rhs)
        {
            return null;
        }

        public static bvec4 operator *(bvec4 lhs, bvec4 rhs)
        {
            return null;
        }

        public static bvec4 operator /(bvec4 lhs, double rhs)
        {
            return null;
        }

        public override string ToString()
        {
            return string.Format("CSSL's bvec4 type.");
        }
    }
}