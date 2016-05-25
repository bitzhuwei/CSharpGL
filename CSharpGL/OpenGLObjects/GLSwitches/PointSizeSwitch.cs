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

        private float originalPointSize;

        static PointSizeSwitch()
        {
            GL.PointSizeRange(out min, out max);
            //GL.GetFloat(GetTarget.PointSizeGranularity, pointSizeWidthRange);//TODO: what does PointSizeGranularity mean?
        }

        public float MinPointSize { get; private set; }
        public float MaxPointSize { get; private set; }

        public float PointSize { get; set; }

        public PointSizeSwitch() : this(1.0f) { }

        public PointSizeSwitch(float pointSize)
        {
            var original = new float[1];
            GL.GetFloat(GetTarget.PointSize, original);
            this.Init(pointSize, original[0]);
        }

        public PointSizeSwitch(float targetPointSize, float currentPointSize)
        {
            this.Init(targetPointSize, currentPointSize);
        }

        private void Init(float targetPointSize, float currentPointSize)
        {
            this.PointSize = targetPointSize;
            this.originalPointSize = currentPointSize;
            this.MinPointSize = min;
            this.MaxPointSize = max;
        }

        public override string ToString()
        {
            return string.Format("Point Size: {0}/{1}", PointSize, originalPointSize);
        }

        protected override void SwitchOn()
        {
            GL.PointSize(PointSize);
        }

        protected override void SwitchOff()
        {
            GL.PointSize(originalPointSize);
        }
    }
}
