using System;
using System.Runtime.InteropServices;

namespace CSharpGL.CSSL
{
    /// <summary>
    /// 专用于CSSL。不可用于数学计算。
    /// <para>Specially designed for CSSL. Not for glm.</para>
    /// </summary>
    public class uvec2
    {
        //internal double a0;
        //internal double a1;

        #region compositions

        public uint x { get { return 0; } set { } }
        public uint y { get { return 0; } set { } }

        public uvec2 xx { get { return null; } set { } }
        public uvec2 xy { get { return null; } set { } }
        public uvec2 yx { get { return null; } set { } }
        public uvec2 yy { get { return null; } set { } }

        public uint r { get { return 0; } set { } }
        public uint g { get { return 0; } set { } }

        public uvec2 rr { get { return null; } set { } }
        public uvec2 rg { get { return null; } set { } }
        public uvec2 gr { get { return null; } set { } }
        public uvec2 gg { get { return null; } set { } }

        public uint s { get { return 0; } set { } }
        public uint t { get { return 0; } set { } }

        public uvec2 ss { get { return null; } set { } }
        public uvec2 st { get { return null; } set { } }
        public uvec2 ts { get { return null; } set { } }
        public uvec2 tt { get { return null; } set { } }

        #endregion compositions

        public uint this[int index]
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        private uvec2() { }

        public static uvec2 operator -(uvec2 lhs)
        {
            return null;
        }

        public static uvec2 operator +(uvec2 lhs, uvec2 rhs)
        {
            return null;
        }

        public static uvec2 operator +(uvec2 lhs, double rhs)
        {
            return null;
        }

        public static uvec2 operator -(uvec2 lhs, uvec2 rhs)
        {
            return null;
        }

        public static uvec2 operator -(uvec2 lhs, double rhs)
        {
            return null;
        }

        public static uvec2 operator *(uvec2 self, double s)
        {
            return null;
        }

        public static uvec2 operator *(double lhs, uvec2 rhs)
        {
            return null;
        }

        public static uvec2 operator *(uvec2 lhs, uvec2 rhs)
        {
            return null;
        }

        public static uvec2 operator /(uvec2 lhs, double rhs)
        {
            return null;
        }

        public override string ToString()
        {
            return string.Format("CSSL's uvec2 type.");
        }
    }
}