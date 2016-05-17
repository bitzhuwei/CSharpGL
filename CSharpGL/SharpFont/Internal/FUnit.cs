using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFont
{
    struct FUnit
    {
        int value;

        //public static explicit operator int (FUnit v) => v.value;
        public static explicit operator int(FUnit v)
        {
            return v.value;
        }
        //public static explicit operator FUnit (int v) => new FUnit { value = v };
        public static explicit operator FUnit(int v)
        {
            return new FUnit { value = v };
        }

        //public static FUnit operator -(FUnit lhs, FUnit rhs) => (FUnit)(lhs.value - rhs.value);
        public static FUnit operator -(FUnit lhs, FUnit rhs)
        {
            return (FUnit)(lhs.value - rhs.value);
        }
        //public static FUnit operator +(FUnit lhs, FUnit rhs) => (FUnit)(lhs.value + rhs.value);
        public static FUnit operator +(FUnit lhs, FUnit rhs)
        {
            return (FUnit)(lhs.value + rhs.value);
        }
        //public static float operator *(FUnit lhs, float rhs) => lhs.value * rhs;
        public static float operator *(FUnit lhs, float rhs)
        {
            return lhs.value * rhs;
        }

        //public static FUnit Max (FUnit a, FUnit b) => (FUnit)Math.Max(a.value, b.value);
        public static FUnit Max(FUnit a, FUnit b)
        {
            return (FUnit)Math.Max(a.value, b.value);
        }
        //public static FUnit Min (FUnit a, FUnit b) => (FUnit)Math.Min(a.value, b.value);
        public static FUnit Min(FUnit a, FUnit b)
        {
            return (FUnit)Math.Min(a.value, b.value);
        }
    }
}
