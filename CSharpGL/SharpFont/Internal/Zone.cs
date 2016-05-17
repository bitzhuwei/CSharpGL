using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SharpFont
{
    struct Zone
    {
        public PointF[] Current;
        public PointF[] Original;
        public TouchState[] TouchState;
        public bool IsTwilight;

        public Zone(PointF[] points, bool isTwilight)
        {
            IsTwilight = isTwilight;
            Current = points;
            Original = (PointF[])points.Clone();
            TouchState = new TouchState[points.Length];
        }

        //public Vector2 GetCurrent (int index) => Current[index].P;
        public Vector2 GetCurrent(int index)
        {
            return Current[index].P;
        }
        //public Vector2 GetOriginal (int index) => Original[index].P;
        public Vector2 GetOriginal(int index)
        {
            return Original[index].P;
        }
    }
}
