using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public class PointSizeSwitch : GLSwitch
    {
        static float min;
        static float max;

        static PointSizeSwitch()
        {
            float[] pointSizeWidthRange = new float[2];
            GL.GetFloat(GetTarget.PointSizeRange, pointSizeWidthRange);
            min = pointSizeWidthRange[0];
            max = pointSizeWidthRange[1];
            GL.GetFloat(GetTarget.PointSizeGranularity, pointSizeWidthRange);//TODO: what does PointSizeGranularity mean?
        }

        public float MinPointSize { get; private set; }
        public float MaxPointSize { get; private set; }

        public float PointSize { get; set; }

        public PointSizeSwitch() : this(1.0f) { }

        public PointSizeSwitch(float pointSize)
        {
            this.PointSize = pointSize;
            this.MinPointSize = min;
            this.MaxPointSize = max;
        }

        float[] original = new float[1];

        public override string ToString()
        {
            return string.Format("Point Size: {0}", PointSize);
        }

        public override void On()
        {
            GL.GetFloat(GetTarget.PointSize, original);

            GL.PointSize(PointSize);
        }

        public override void Off()
        {
            GL.PointSize(original[0]);
        }
    }
}
