namespace CSharpGL.CSSL
{
    /// <summary>
    /// 专用于CSSL。不可用于数学计算。
    /// <para>Specially designed for CSSL. Not for glm.</para>
    /// </summary>
    public class ivec2
    {
        //internal double a0;
        //internal double a1;

        #region compositions

        public int x { get { return 0; } set { } }
        public int y { get { return 0; } set { } }

        public ivec2 xx { get { return null; } set { } }
        public ivec2 xy { get { return null; } set { } }
        public ivec2 yx { get { return null; } set { } }
        public ivec2 yy { get { return null; } set { } }

        public int r { get { return 0; } set { } }
        public int g { get { return 0; } set { } }

        public ivec2 rr { get { return null; } set { } }
        public ivec2 rg { get { return null; } set { } }
        public ivec2 gr { get { return null; } set { } }
        public ivec2 gg { get { return null; } set { } }

        public int s { get { return 0; } set { } }
        public int t { get { return 0; } set { } }

        public ivec2 ss { get { return null; } set { } }
        public ivec2 st { get { return null; } set { } }
        public ivec2 ts { get { return null; } set { } }
        public ivec2 tt { get { return null; } set { } }

        #endregion compositions

        public int this[int index]
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        private ivec2()
        {
        }

        public static ivec2 operator -(ivec2 lhs)
        {
            return null;
        }

        public static ivec2 operator +(ivec2 lhs, ivec2 rhs)
        {
            return null;
        }

        public static ivec2 operator +(ivec2 lhs, double rhs)
        {
            return null;
        }

        public static ivec2 operator -(ivec2 lhs, ivec2 rhs)
        {
            return null;
        }

        public static ivec2 operator -(ivec2 lhs, double rhs)
        {
            return null;
        }

        public static ivec2 operator *(ivec2 self, double s)
        {
            return null;
        }

        public static ivec2 operator *(double lhs, ivec2 rhs)
        {
            return null;
        }

        public static ivec2 operator *(ivec2 lhs, ivec2 rhs)
        {
            return null;
        }

        public static ivec2 operator /(ivec2 lhs, double rhs)
        {
            return null;
        }

        public override string ToString()
        {
            return string.Format("CSSL's ivec2 type.");
        }
    }
}