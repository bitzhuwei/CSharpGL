namespace CSharpGL.CSSL
{
    /// <summary>
    /// 专用于CSSL。不可用于数学计算。
    /// <para>Specially designed for CSSL. Not for glm.</para>
    /// </summary>
    public class bvec2
    {
        //internal double a0;
        //internal double a1;

        #region compositions

        public bool x { get { return false; } set { } }
        public bool y { get { return false; } set { } }

        public bvec2 xx { get { return null; } set { } }
        public bvec2 xy { get { return null; } set { } }
        public bvec2 yx { get { return null; } set { } }
        public bvec2 yy { get { return null; } set { } }

        public bool r { get { return false; } set { } }
        public bool g { get { return false; } set { } }

        public bvec2 rr { get { return null; } set { } }
        public bvec2 rg { get { return null; } set { } }
        public bvec2 gr { get { return null; } set { } }
        public bvec2 gg { get { return null; } set { } }

        public bool s { get { return false; } set { } }
        public bool t { get { return false; } set { } }

        public bvec2 ss { get { return null; } set { } }
        public bvec2 st { get { return null; } set { } }
        public bvec2 ts { get { return null; } set { } }
        public bvec2 tt { get { return null; } set { } }

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

        private bvec2()
        {
        }

        public static bvec2 operator -(bvec2 lhs)
        {
            return null;
        }

        public static bvec2 operator +(bvec2 lhs, bvec2 rhs)
        {
            return null;
        }

        public static bvec2 operator +(bvec2 lhs, double rhs)
        {
            return null;
        }

        public static bvec2 operator -(bvec2 lhs, bvec2 rhs)
        {
            return null;
        }

        public static bvec2 operator -(bvec2 lhs, double rhs)
        {
            return null;
        }

        public static bvec2 operator *(bvec2 self, double s)
        {
            return null;
        }

        public static bvec2 operator *(double lhs, bvec2 rhs)
        {
            return null;
        }

        public static bvec2 operator *(bvec2 lhs, bvec2 rhs)
        {
            return null;
        }

        public static bvec2 operator /(bvec2 lhs, double rhs)
        {
            return null;
        }

        public override string ToString()
        {
            return string.Format("CSSL's bvec2 type.");
        }
    }
}