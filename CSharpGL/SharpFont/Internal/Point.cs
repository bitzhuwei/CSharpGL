using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SharpFont
{
    struct Point
    {
        public FUnit X;
        public FUnit Y;
        public PointType Type;

        public Point(FUnit x, FUnit y)
        {
            X = x;
            Y = y;
            Type = PointType.OnCurve;
        }

        //public static PointF operator *(Point lhs, float rhs) => new PointF(new Vector2(lhs.X * rhs, lhs.Y * rhs), lhs.Type);
        public static PointF operator *(Point lhs, float rhs)
        {
            return new PointF(new Vector2(lhs.X * rhs, lhs.Y * rhs), lhs.Type);
        }

        //public static explicit operator Vector2 (Point p) => new Vector2((int)p.X, (int)p.Y);
        public static explicit operator Vector2(Point p)
        {
            return new Vector2((int)p.X, (int)p.Y);
        }
    }
}
