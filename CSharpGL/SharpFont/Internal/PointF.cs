using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SharpFont
{
    struct PointF
    {
        public Vector2 P;
        public PointType Type;

        public PointF(Vector2 position, PointType type)
        {
            P = position;
            Type = type;
        }

        //public PointF Offset (Vector2 offset) => new PointF(P + offset, Type);
        public PointF Offset(Vector2 offset)
        {
            return new PointF(P + offset, Type);
        }

        //public override string ToString () => $"{P} ({Type})";
        public override string ToString()
        {
            return string.Format("{0} ({1})", this.P, this.Type);
        }

        //public static implicit operator Vector2 (PointF p) => p.P;
        public static implicit operator Vector2(PointF p)
        {
            return p.P;
        }
    }
}
